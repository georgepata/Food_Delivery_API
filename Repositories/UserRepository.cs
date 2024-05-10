using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public UserRepository(FoodDeliveryContext foodDeliveryContext){
        _foodDeliveryContext = foodDeliveryContext;
    }

    public User GetUserById(int id)
    {
        return _foodDeliveryContext.Users.Where(u => u.UserId == id).FirstOrDefault();
    }
    public bool AddUser(User user)
    {
        _foodDeliveryContext.Add(user);
        return Save();
    }
    public bool UpdateUser(int id, UserDto userDto)
    {
        var userToUpdate = _foodDeliveryContext.Users.First(u => u.UserId == id);
        userToUpdate.Name = userDto.Name;
        userToUpdate.Email = userDto.Email;
        userToUpdate.Phone = userDto.Phone;
        userToUpdate.Address = userDto.Address;
        return Save();
    }
    public bool DeleteUser(int userId)
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
}