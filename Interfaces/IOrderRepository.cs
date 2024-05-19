using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IOrderRepository
{
    Order GetOrder(int id);
    bool CreateOrder(Order order);
    bool UpdateOrder();
    bool DeleteOrder(int id);
}