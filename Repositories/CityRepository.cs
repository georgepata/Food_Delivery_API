using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.User.City;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_API.Repositories;

public class CityRepository : ICityRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public CityRepository(FoodDeliveryContext foodDeliveryContext)
    {
        _foodDeliveryContext = foodDeliveryContext;
    }
    public City GetCityById(int id)
    {
        return _foodDeliveryContext.Cities.Where(u => u.CityId == id).FirstOrDefault();
    }
    public bool AddCity(City city)
    {
        _foodDeliveryContext.Add(city);
        return Save();
    }

    public bool UpdateCity(int id, CityDto cityDto)
    {
        var cityToUpdate = _foodDeliveryContext.Cities.First(u=> u.CityId == id);
        cityToUpdate.Name = cityDto.Name;
        return Save();
    }
    public bool DeleteCity(int id)
    {
        var cityToDelete = GetCityById(id);
        if (cityToDelete != null)
            _foodDeliveryContext.Remove(cityToDelete);
        return Save();
    }

    public bool AddUserToUsersCollection(int id, User user){
        var city = GetCityById(id);
        if (city !=null)
            city.Users.Add(user);
        return Save();
    }


    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges > 0 ? true : false;
    }
}