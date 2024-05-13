using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.Restaurant;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IRestaurantRepository
{
    Restaurant GetRestaurantById(int id);
    bool AddRestaurant(Restaurant restaurant);
    bool UpdateRestaurant(int id, RestaurantDto restaurantDto);
    bool DeleteRestaurant(int id);
}