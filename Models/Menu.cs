using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class Menu
{
    public int MenuId {get; set;}
    public string Name {get; set;}
    public Restaurant Restaurant {get; set;}
    public ICollection<MenuItem> MenuItems {get; set;}
}