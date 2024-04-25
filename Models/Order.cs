using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class Order
{
    public int OrderId {get; set;}    
    public User User {get; set;}
    public int UserId {get; set;}
    public Restaurant Restaurant {get; set;}
    public int RestaurantId {get; set;}
    public Payment Payment {get; set;}
    public DeliveryDriver DeliveryDriver {get; set;}
}