using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IUserRepository
{
    User GetUserById(int id);
    bool AddUser(User user);
    bool UpdateUser(int id, UserDto user);
    bool DeleteUser(int id);
}