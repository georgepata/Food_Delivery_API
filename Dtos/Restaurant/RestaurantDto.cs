using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.Restaurant;

public class RestaurantDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string PhoneNumber {get; set;}
    [Required]
    public string Cuisine { get; set;}
    [Required]
    public int CityId {get; set;}
}