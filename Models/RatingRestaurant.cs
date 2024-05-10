using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class RatingRestaurant
{
    public int RatingRestaurantId { get; set;}
    public double Rating { get; set;}
    public int UserId {get; set; }
    public User User{ get; set;}
    public int RestaurantId {get; set;} 
    public Restaurant Restaurant { get; set;}
}