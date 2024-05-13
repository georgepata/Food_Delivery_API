using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.Restaurant;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public RestaurantRepository(FoodDeliveryContext foodDeliveryContext)
    {
        _foodDeliveryContext = foodDeliveryContext;
    }
    public Restaurant GetRestaurantById(int id)
    {
        return _foodDeliveryContext.Restaurants.Where(r => r.RestaurantId == id).FirstOrDefault();
    }
    public bool AddRestaurant(Restaurant restaurant)
    {
        _foodDeliveryContext.Add(restaurant);
        return Save();
    }

    public bool UpdateRestaurant(int id, RestaurantDto restaurantDto)
    {
        var restaurant = _foodDeliveryContext.Restaurants.First(r => r.RestaurantId == id);
        restaurant.Name = restaurantDto.Name;
        restaurant.PhoneNumber = restaurantDto.PhoneNumber;
        restaurant.Cuisine = restaurantDto.Cuisine;
        return Save();
    }
    public bool DeleteRestaurant(int id)
    {
        var restaurantToDelete = _foodDeliveryContext.Restaurants.First(r => r.RestaurantId == id);
        if (restaurantToDelete != null)
            _foodDeliveryContext.Remove(restaurantToDelete);
        return Save();
    }

    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges>0 ? true : false;
    }
}