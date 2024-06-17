using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.DeliveryDriver;
using Food_Delivery_API.Dtos.OrderMenuItem;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Dtos.Order;

public class DisplayOrderDto
{
    public string Name{ get; set; }
    public string RestaurantName {get; set;}
    public string PaymentMethod {get; set;}
    public DeliveryDriverDto DeliveryDriver {get; set;}
    public ICollection <OrderMenuItemDto> orderMenuItems {get; set;}   
}