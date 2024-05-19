using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class DeliveryDriver
{
    public int DeliveryDriverId { get; set; }   
    public string Name { get; set; } 
    public string Phone {get; set;}   
    public Order? Order{ get; set; }
    [ForeignKey("Order")]
    public int? OrderId { get; set; }
}