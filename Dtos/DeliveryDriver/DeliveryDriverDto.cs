using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.DeliveryDriver;

public class DeliveryDriverDto
{
    [Required]
    public string Name {get; set;}
    [Required]
    public string Phone {get; set;}
}