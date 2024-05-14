using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.MenuItem;

public class MenuItemDto
{
    [Required]
    public string Name {get; set;}
    [Required]
    public double Price {get; set;}
    [Required]
    public string Description {get; set;}
    public double? Rating {get; set;} 
    [Required]
    public int MenuId {get; set;}
}