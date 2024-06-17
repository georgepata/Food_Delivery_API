using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.DeliveryDriver;
using Food_Delivery_API.Dtos.Order;
using Food_Delivery_API.Dtos.OrderMenuItem;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    private readonly IDeliveryDriverRepository _deliveryDriverRepository;
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public OrdersController(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository, IUserRepository userRepository, FoodDeliveryContext foodDeliveryContext, IMenuRepository menuRepository,
                            IPaymentRepository paymentRepository, IDeliveryDriverRepository deliveryDriverRepository)
    {
        _orderRepository = orderRepository;        
        _menuItemRepository = menuItemRepository;
        _userRepository = userRepository;
        _menuRepository = menuRepository;
        _paymentRepository = paymentRepository;
        _deliveryDriverRepository = deliveryDriverRepository;
        _foodDeliveryContext = foodDeliveryContext;
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetAllOrders(){
        var userId = HttpContext.User.Claims.First(u => u.Type == "userId").Value;
        var user = _userRepository.GetUserById(userId);

        var listOfOrders = _foodDeliveryContext.Orders
                        .Include(o => o.User)
                        .Include(o => o.Restaurant)
                        .Include (o => o.DeliveryDriver)
                        .Include(o => o.Payment)
                        .Include(o => o.OrderMenuItems).ThenInclude(r => r.MenuItem)
                        .Where(o => o.UserId == userId && o.Payment!=null && o.DeliveryDriver!=null
                        && o.OrderMenuItems!=null && o.Restaurant!=null && o.User !=null).ToList();
        
        ICollection<DisplayOrderDto> listOfDisplayOrderDto = new List<DisplayOrderDto>();

        foreach (var order in listOfOrders){
            ICollection<OrderMenuItemDto> orderMenuItemDtoList = new List<OrderMenuItemDto>();
            foreach(var i in order.OrderMenuItems){
                orderMenuItemDtoList.Add(new OrderMenuItemDto{
                    ItemName = i.MenuItem.Name,
                    Quantity = i.Quantity
                });
            }
            var item = new DisplayOrderDto{
                Name = user.UserName,
                RestaurantName = order.Restaurant.Name,
                PaymentMethod = order.Payment.PaymentMethod,
                DeliveryDriver = new DeliveryDriverDto{
                    Name = order.DeliveryDriver.Name,
                    Phone = order.DeliveryDriver.Phone
                },
                orderMenuItems = orderMenuItemDtoList
            };
            listOfDisplayOrderDto.Add(item);
        }

        return Ok(listOfDisplayOrderDto);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateOrder(OrdersDto ordersDto){
        IDictionary<string, int> menuItemsOrdered = ordersDto.MenuItems;
        var userId = HttpContext.User.Claims.First(u => u.Type == "userId").Value;
        var user = _userRepository.GetUserById(userId);
        Menu menu = null;
        var orderMenuItems = new List<OrderMenuItem>();
        foreach (var menuItem in menuItemsOrdered){
            string itemName = menuItem.Key;
            int quantity = menuItem.Value;
            var menu_item = _menuItemRepository.GetMenuItemByName(itemName);

            if (menu_item == null)
                return NotFound(new String($"{itemName} nu exista"));

            menu = _menuRepository.GetMenuById(menu_item.MenuId);
            if (menu == null)
                return BadRequest("Menu not found for the specified menu item.");
            
            orderMenuItems.Add(new OrderMenuItem(){
                Quantity = quantity,
                MenuItemId = menu_item.MenuItemId
            });
        }

        var deliveryDriver = _deliveryDriverRepository.GetAvailableDeliveryDriver();
        if (deliveryDriver == null)
            return NotFound("No delivery driver available");

        var payment = new Payment{
            Price = 100,
            PaymentMethod = ordersDto.MethodPayment
        };
        
        _paymentRepository.CreatePayment(payment);
        var order = new Order{
            UserId = userId,
            RestaurantId = menu.RestaurantId,
            Payment = payment,
            OrderMenuItems = orderMenuItems,
            DeliveryDriver = deliveryDriver
        };

        _orderRepository.CreateOrder(order);
        return await Task.FromResult(Ok());
    }
}