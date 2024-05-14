using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models;

public class MenuItem
{
    public int MenuItemId {get; set;}
    [Required]
    [MaxLength(50)]
    public string? Name {get; set;}
    [Required]
    public double? Price {get; set;}
    [Required]
    public string? Description {get; set;}
    public double? Rating {get; set;}
    public int MenuId { get; set;}
    public Menu Menu {get; set;}
    public ICollection<OrderList> OrderLists {get; set;}
}