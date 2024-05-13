using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.Restaurant;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public RestaurantController(IRestaurantRepository restaurantRepository, FoodDeliveryContext foodDeliveryContext)
    {
        _restaurantRepository = restaurantRepository;
        _foodDeliveryContext = foodDeliveryContext;
    }

    [HttpGet("{id}")]
    public IActionResult GetRestaurantById(int id){
        var restaurant = _restaurantRepository.GetRestaurantById(id);
        if (restaurant == null)
            return NotFound();
        var finalRestaurant = _foodDeliveryContext.Restaurants
                            .Include(r => r.City)
                            .Include(r => r.Menus)
                            .FirstOrDefault(r => r.RestaurantId == id);
        return Ok(finalRestaurant);
    }

    [HttpPost]
    public IActionResult CreateRestaurant([FromBody] RestaurantDto restaurantDto){
        var restaurant = new Restaurant(){
            Name = restaurantDto.Name,
            PhoneNumber = restaurantDto.PhoneNumber,
            Cuisine = restaurantDto.Cuisine,
            CityId = restaurantDto.CityId
        };
        _restaurantRepository.AddRestaurant(restaurant);

        return Ok(new RestaurantDto{
            Name = restaurant.Name,
            PhoneNumber = restaurant.PhoneNumber,
            Cuisine = restaurant.Cuisine
        });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRestaurant(int id, RestaurantDto restaurantDto){
        var restaurant = _restaurantRepository.GetRestaurantById(id);
        if (restaurant == null)
            return NotFound();
        _restaurantRepository.UpdateRestaurant(id, restaurantDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteRestaurant(int id){
        var restaurantToDelete = _restaurantRepository.GetRestaurantById(id);
        if (restaurantToDelete != null)
        {   _restaurantRepository.DeleteRestaurant(id);
            return Ok(restaurantToDelete);
        }
        return NotFound();
    }
}