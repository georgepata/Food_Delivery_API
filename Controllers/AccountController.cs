using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Dtos.User;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Food_Delivery_API.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signingManager;
    private readonly ICityRepository _cityRepository; 
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, ICityRepository cityRepository, FoodDeliveryContext foodDeliveryContext)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signingManager = signInManager;
        _cityRepository = cityRepository;
        _foodDeliveryContext = foodDeliveryContext;
    }

[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
{
    try
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User()
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
            Phone = registerDto.Phone,
            Address = registerDto.Address,
            CityId = registerDto.CityId
        };

        var createUser = await _userManager.CreateAsync(user, registerDto.Password);
        if (createUser.Succeeded)
        {
            int cityId = registerDto.CityId ?? default(int);
            var cityToAddUser = _foodDeliveryContext.Cities.Where(u=> u.CityId == registerDto.CityId).FirstOrDefault();
            if (cityToAddUser !=null){
                if (cityToAddUser.Users == null)
                    cityToAddUser.Users = new List<User>();
                cityToAddUser.Users.Add(user);
                await _foodDeliveryContext.SaveChangesAsync();
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (roleResult.Succeeded){
                return Ok(
                    new NewUserDto{
                        Name = user.UserName,
                        Email = user.Email,
                        Phone = user.Phone,
                        Address = user.Address,
                        Token = _tokenService.CreateToken(new UserDto(){
                            Name = user.UserName,
                            Email = user.Email,
                            Phone = user.Phone,
                            Address = user.Address,
                            UserId = user.Id,
                            Role = "User"
                        })
                    }
                );
            } 
            else return StatusCode(500, roleResult.Errors);
        }
        else
            return StatusCode(500, createUser.Errors);
    }
    catch (Exception e)
    {
        return StatusCode(500, e);
    }
}

[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginDto loginDto){
    if(!ModelState.IsValid)
        return BadRequest(ModelState);

    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Name.ToLower());
    if (user == null)
        return Unauthorized("Invalid username!");
    
    var result = await _signingManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    var role = await _userManager.GetRolesAsync(user);
    string finalRole;
    if (role.Count()==0)
        finalRole = "User";
    else finalRole = role.ElementAt(0);
    

    if (!result.Succeeded)
        return Unauthorized("Username not found and/or password incorrect");

    return Ok(new NewUserDto{
        Name = user.UserName,
        Email = user.Email,
        Phone = user.Phone,
        Address = user.Address,
        Token = _tokenService.CreateToken(new UserDto{
            Name = user.UserName,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address,
            UserId = user.Id,
            Role = finalRole
        })
    });
}


[HttpPost("assignadmin/{userId}")]
public async Task<IActionResult> AssignAdminRole(string userId)
{
    try
    {
        var user = await _userManager.FindByIdAsync(userId);
        
        if (user == null)
        {
            return NotFound("User not found");
        }

        var roleResult = await _userManager.AddToRoleAsync(user, "Admin");


        var token = _tokenService.CreateToken(new UserDto{
            UserId = user.Id,
            Name = user.UserName,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address,
            Role = "Admin"
        });
        if (roleResult.Succeeded)
        {
            return Ok(new NewUserDto{
                Name = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Token = token
            });
        }
        else
        {
            return StatusCode(500, "Failed to assign admin role");
        }
    }
    catch (Exception e)
    {
        return StatusCode(500, e.Message);
    }
}
}