using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class City
{
    public int CityId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set;}
    public ICollection<User> Users {get; set;}
    public ICollection<Restaurant> Restaurants {get; set;}
}