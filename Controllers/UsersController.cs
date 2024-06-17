using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Dtos.User;
using Food_Delivery_API.Filters;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Food_Delivery_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    //[TypeFilter(typeof(User_ValidateUserIdActionFilterAttribute))]
    public IActionResult GetUserById(string id){
        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId");

        if (userIdClaim == null)
            return Unauthorized();
        
        var userId = userIdClaim.Value;

        var user = _userRepository.GetUserById(id);

        if (user == null || !user.Id.Equals(userId))
            return Unauthorized();

        var finalUser  = _foodDeliveryContext.Users
            .Include(c=> c.City)
            .Include(c=> c.Orders)
            .ThenInclude(u => u.Payment)
            .FirstOrDefault(c => c.Id.Equals(id));
        return Ok(finalUser);
    }


    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateUser(string id, UpdateUserDto userDto){
        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId");

        if (userIdClaim == null)
            return Unauthorized();
        
        var userId = userIdClaim.Value;

        var user = _userRepository.GetUserById(id);

        if (user == null || !user.Id.Equals(userId))
            return Unauthorized();
        _userRepository.UpdateUser(id, userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin")]
    public IActionResult DeleteUser(string id){
        var userToDelete = _userRepository.GetUserById(id);
        _userRepository.DeleteUser(id);
        return Ok(userToDelete);
    }

    [HttpGet("orderhistory")]
    [Authorize]
    public IActionResult GetOrderHistory(){
        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId");
        if (userIdClaim == null)
            return Unauthorized();
        var userId = userIdClaim.Value;
        var user = _userRepository.GetUserById(userId);
        if (user == null || !user.Id.Equals(userId))
            return Unauthorized();
        var orderHistory = _userRepository.OrderHistory(user.Id);
        return Ok(orderHistory);
    }
}