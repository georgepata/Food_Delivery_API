using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.Order;

public class OrdersDto
{
    [Required]
    public IDictionary<string, int> MenuItems {get; set;}
    [Required]
    public string MethodPayment{get; set;}
}