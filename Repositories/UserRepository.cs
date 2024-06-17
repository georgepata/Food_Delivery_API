using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Dtos.User;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public UserRepository(FoodDeliveryContext foodDeliveryContext){
        _foodDeliveryContext = foodDeliveryContext;
    }

    public User GetUserById(string id)
    {
        return _foodDeliveryContext.Users.Where(u => u.Id.Equals(id)).FirstOrDefault();
    }
    public bool AddUser(User user)
    {
        _foodDeliveryContext.Add(user);
        return Save();
    }
    public bool UpdateUser(string id, UpdateUserDto userDto)
    {
        var userToUpdate = _foodDeliveryContext.Users.First(u => u.Id.Equals(id));
        userToUpdate.UserName = userDto.Name;
        userToUpdate.Email = userDto.Email;
        userToUpdate.Phone = userDto.Phone;
        userToUpdate.Address = userDto.Address;
        return Save();
    }
    public bool DeleteUser(string userId)
    {
        var userToDelete = GetUserById(userId);
        if (userToDelete != null)
            _foodDeliveryContext.Remove(userToDelete);
        return Save();
    }

    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges > 0 ? true : false;
    }

    public User OrderHistory(string id)
    {
        return _foodDeliveryContext.Users
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderMenuItems)
                    .ThenInclude(m => m.MenuItem)
                    .FirstOrDefault(u => u.Id == id);
    }
}