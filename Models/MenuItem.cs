using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class MenuItem
{
    public int MenuItemId {get; set;}
    public string Name {get; set;}
    public double Price {get; set;}
    public string Description {get; set;}
    public double Rating {get; set;}
    public Menu Menu {get; set;}
}