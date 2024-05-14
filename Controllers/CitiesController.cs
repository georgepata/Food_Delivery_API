using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.User.City;
using Food_Delivery_API.Filters;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    private readonly ICityRepository _cityRepository;
    public CitiesController(FoodDeliveryContext foodDeliveryContext, ICityRepository cityRepository)
    {
        _foodDeliveryContext = foodDeliveryContext;
        _cityRepository = cityRepository;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetCityById(int id){
        // var city = _cityRepository.GetCityById(id);
        var city = _foodDeliveryContext.Cities
                .Include(c => c.Users)
                .Include(c => c.Restaurants)
                .FirstOrDefault(u => u.CityId == id);
        Console.WriteLine(city.Users.Count());
        return Ok(city);
    }

    [HttpPost]
    public IActionResult AddCity(CityDto cityDto){
        var city = new City(){
            Name = cityDto.Name
        };
        _cityRepository.AddCity(city);
        return Ok(new CityDto{
            Name = city.Name
        });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCity(int id, CityDto cityDto){
        var city = _cityRepository.GetCityById(id);
        _cityRepository.UpdateCity(id, cityDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCity(int id){
        var cityToDelete = _cityRepository.GetCityById(id);
        _cityRepository.DeleteCity(id);
        return Ok(cityToDelete);
    }

}