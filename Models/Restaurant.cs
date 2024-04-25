using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }
    public string Name {get; set;}
    public string PhoneNumber {get; set;}
    public string Cuisine {get; set;}
    public City City {get; set;}
    public ICollection<Menu> Menus{get; set;}
    public ICollection<Order> Orders{get; set;}
    public ICollection<RatingRestaurant> RatingRestaurants{get; set;}
}