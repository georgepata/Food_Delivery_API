using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class OrderList
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int MenuItemId {get; set;}
    public MenuItem MenuItem { get; set;}
} 