using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Filters;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Food_Delivery_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    private readonly IUserRepository _userRepository;
    public UsersController(FoodDeliveryContext foodDeliveryContext, IUserRepository userRepository){
        _foodDeliveryContext = foodDeliveryContext;
        _userRepository = userRepository;
    }


    [HttpGet("{id}")]
    [Authorize]
    [TypeFilter(typeof(User_ValidateUserIdActionFilterAttribute))]
    public IActionResult GetUserById(int id){
        return Ok(_userRepository.GetUserById(id));
    }

    [HttpPost]
    [TypeFilter(typeof(User_ValidateCreateUserActionFilterAttribute))]
    public IActionResult CreateUser([FromBody]UserDto user){
        var User = new User(){
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address
        };
        _userRepository.AddUser(User);
        return Ok(User);
    }

    [HttpPut("{id}")]
    [Authorize]
    [TypeFilter(typeof(User_ValidateUserIdActionFilterAttribute))]
    public IActionResult UpdateUser(int id, UserDto userDto){
        _userRepository.UpdateUser(id, userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [TypeFilter(typeof(User_ValidateUserIdActionFilterAttribute))]
    public IActionResult DeleteUser(int id){
        var userToDelete = _userRepository.GetUserById(id);
        _userRepository.DeleteUser(id);
        return Ok(userToDelete);
    }

}