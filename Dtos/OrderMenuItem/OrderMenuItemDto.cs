using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.OrderMenuItem;

public class OrderMenuItemDto
{
    [Required]
    public int Quantity {get ;set;}
    [Required]
    public string ItemName {get; set;}
}