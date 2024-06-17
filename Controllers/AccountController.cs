using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Dtos.User;
using Food_Delivery_API.Filters;
using Food_Delivery_API.Filters.ForgotPasswordVerification;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
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
    private readonly IEmailSend _emailSender;
    private readonly SignInManager<User> _signingManager;
    private readonly ICityRepository _cityRepository; 
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, ICityRepository cityRepository, 
                    FoodDeliveryContext foodDeliveryContext, IEmailSend emailSender)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _emailSender = emailSender;
        _signingManager = signInManager;
        _cityRepository = cityRepository;
        _foodDeliveryContext = foodDeliveryContext;
    }

[HttpPost("register")]
[ServiceFilter(typeof(User_ValidateCreateUserActionFilterAttribute))]
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
            var userTokenLifetime = TimeSpan.FromHours(3);
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
                        }, userTokenLifetime)
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


[HttpPost("forgotpassword")]
[Authorize]
[ServiceFilter(typeof(EmailVerification<ForgotPasswordRequest>))]
public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model){
    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user == null)
        return RedirectToAction("ForgotPasswordConfirmation");
    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    var callBackUrl = Url.Action(nameof(ResetPassword), "Account", new {
        token,
        email = model.Email
    }, protocol: HttpContext.Request.Scheme);
    Console.WriteLine("@@@@@@@@@@@@@@@@@@@" + callBackUrl);
    string subject = "Reset your password!";
    string message = $"Please reset your password by clicking <a href='{callBackUrl}'>here</a>";
    await _emailSender.SendEmailAsync(model.Email, subject, message);

    return Ok("Password reset mail sent");
}


[HttpPost("resetpassword")]
[Authorize]
[ServiceFilter(typeof(ResetPasswordVerification))]
public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model, [FromQuery] string email, [FromQuery] string token){
    var user = await _userManager.FindByEmailAsync(email);
    if (user == null)
        return NotFound("User not found");
    var result = await _userManager.ResetPasswordAsync(user, token, model.ConfirmedPassword);
    if (result.Succeeded)
        return Ok("ResetPasswordConfirmation");
    foreach(var error in result.Errors)
        ModelState.AddModelError(string.Empty, error.Description);
    return BadRequest(ModelState);
}


[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginDto loginDto){
    if(!ModelState.IsValid)
        return BadRequest(ModelState);

    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Name.ToLower());
    if (user == null)
        return Unauthorized("Invalid username!");
    
    var result = await _signingManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
    if (!result.Succeeded)
        return Unauthorized("Username not found and/or password incorrect");

    var role = await _userManager.GetRolesAsync(user);
    string finalRole = role.FirstOrDefault() ?? "User";
    
    var tokenLifetime = finalRole.Equals("User", StringComparison.OrdinalIgnoreCase)? TimeSpan.FromHours(3) : TimeSpan.FromDays(365*100);

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
        }, tokenLifetime)
    });
}


[HttpPut("changepassword")]
[Authorize]
public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto){
    var userToChange = _userManager.Users.FirstOrDefault(u => u.UserName == changePasswordDto.Name);
    if (userToChange == null)
        return NotFound();
    var result = await _userManager.ChangePasswordAsync(userToChange, changePasswordDto.Password, changePasswordDto.NewPassword);
    if(!result.Succeeded)
        return BadRequest(result.Errors);
    return NoContent();
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


        var adminTokenLifetime = TimeSpan.FromDays(365 * 100);
        var token = _tokenService.CreateToken(new UserDto{
            UserId = user.Id,
            Name = user.UserName,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address,
            Role = "Admin"
        }, adminTokenLifetime);
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