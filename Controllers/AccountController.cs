using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Dtos.User;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_API.Controllers;

// [Route("api/account")]
// [ApiController]
// public class AccountController : ControllerBase
// {
//     private readonly UserManager<User> _userManager;
//     public AccountController(UserManager<User> userManager)
//     {
//         _userManager = userManager;
//     }

// [HttpPost("register")]
// public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
// {
//     try
//     {
//         if (!ModelState.IsValid)
//             return BadRequest(ModelState);

//         var user = new User()
//         {
//             UserName = registerDto.Username,
//             Email = registerDto.Email,
//             Phone = registerDto.Phone
//         };

//         var createUser = await _userManager.CreateAsync(user, registerDto.Password);
//         if (createUser.Succeeded)
//         {
//             var roleResult = await _userManager.AddToRoleAsync(user, "User");
//             if (roleResult.Succeeded){
//                 return Ok(
//                     new NewUserDto{
//                         Name = user.Name,
//                         Email = user.Email,
//                         Phone = user.Phone
//                     }
//                 );
//             } 
//             else return StatusCode(500, roleResult.Errors);
//         }
//         else
//             return StatusCode(500, createUser.Errors);
//     }
//     catch (Exception e)
//     {
//         return StatusCode(500, e);
//     }
// }

// }