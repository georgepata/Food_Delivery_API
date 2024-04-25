using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public string GetUsers(){
        return "Returning all users";
    }

    [HttpGet("{id}")]
    public string GetUserById(int id){
        return $"Reading the user with id: {id}";
    }

    [HttpPost]
    public string CreateUser([FromBody]User user){
        return $"Creating a user";
    }

    [HttpPut("{id}")]
    public string UpdateUser(int id){
        return $"Updating user with id: {id}";
    }

    [HttpDelete("{id}")]
    public string DeleteUser(int id){
        return $"Deleting the user with id: {id}";
    }

}