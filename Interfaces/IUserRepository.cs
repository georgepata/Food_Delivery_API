using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Dtos.User;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IUserRepository
{
    User GetUserById(string id);
    bool AddUser(User user);
    bool UpdateUser(string id, UpdateUserDto user);
    bool DeleteUser(string id);
    User OrderHistory(string id);
}