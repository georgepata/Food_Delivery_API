using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.User.City;

public class CityDto
{
    [Required]
    public string Name  {get; set;}
}