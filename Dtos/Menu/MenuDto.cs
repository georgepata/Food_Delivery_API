using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.Menu;

public class MenuDto
{
    [Required]
    public string Name {get ;set;}
    [Required]
    public int RestaurantId {get; set;}
}