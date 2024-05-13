using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IUserRepository
{
    User GetUserById(string id);
    bool AddUser(User user);
    bool UpdateUser(string id, UserDto user);
    bool DeleteUser(string id);
}