using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.Order;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMenuRepository _menuRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public OrdersController(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository, IUserRepository userRepository, FoodDeliveryContext foodDeliveryContext, IMenuRepository menuRepository,
                            IPaymentRepository paymentRepository)
    {
        _orderRepository = orderRepository;        
        _menuItemRepository = menuItemRepository;
        _userRepository = userRepository;
        _menuRepository = menuRepository;
        _paymentRepository = paymentRepository;
        _foodDeliveryContext = foodDeliveryContext;
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateOrder(OrdersDto ordersDto){
        IDictionary<string, int> menuItemsOrdered = ordersDto.MenuItems;
        var userId = HttpContext.User.Claims.First(u => u.Type == "userId").Value;
        var user = _userRepository.GetUserById(userId);
        Menu menu = null;
        foreach (var menuItem in menuItemsOrdered){
            string itemName = menuItem.Key;
            int quantity = menuItem.Value;
            var menu_item = _menuItemRepository.GetMenuItemByName(itemName);
            if (menu_item == null)
                return NotFound(new String($"{itemName} nu exista"));
            menu = _menuRepository.GetMenuById(menu_item.MenuId);
            if (menu == null)
                return BadRequest("Menu not found for the specified menu item.");
        }

        var payment = new Payment{
            Price = 100,
            PaymentMethod = ordersDto.MethodPayment
        };
        
        _paymentRepository.CreatePayment(payment);
        var order = new Order{
            UserId = userId,
            RestaurantId = menu.RestaurantId,
            Payment = payment
        };

        _orderRepository.CreateOrder(order);
        return await Task.FromResult(Ok());
    }
}