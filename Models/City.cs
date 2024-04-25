using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class City
{
    public int CityId { get; set; }
    public string Name { get; set;}
    public ICollection<User> Users {get; set;}
    public ICollection<Restaurant> Restaurants {get; set;}
}