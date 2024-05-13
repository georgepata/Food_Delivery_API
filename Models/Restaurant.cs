using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }
    [Required]
    public string Name {get; set;}
    [Required]
    public string PhoneNumber {get; set;}
    [Required]
    public string Cuisine {get; set;}
    public int? CityId {get; set;}
    public City? City {get; set;}
    public ICollection<Menu>? Menus{get; set;}
    public ICollection<Order>? Orders{get; set;}
    public ICollection<RatingRestaurant>? RatingRestaurants{get; set;}
}