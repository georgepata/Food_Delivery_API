using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class Payment
{
    public int PaymentId {get; set;}
    public double Price {get; set;}
    public string PaymentMethod {get; set;}
    [ForeignKey("Order")]
    public int? OrderId {get; set;}
    public Order? Order{get; set;}
}