using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public OrderRepository(FoodDeliveryContext foodDeliveryContext)
    {
        _foodDeliveryContext = foodDeliveryContext;
    }
    public Order GetOrder(int id)
    {
        return _foodDeliveryContext.Orders.FirstOrDefault(o => o.OrderId == id);
    }
    public bool CreateOrder(Order order)
    {
        _foodDeliveryContext.Add(order);
        return Save();
    }

    public bool UpdateOrder()
    {
        throw new NotImplementedException();
    }
    public bool DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges > 0 ? true : false;
    }

}