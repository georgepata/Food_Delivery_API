using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.DeliveryDriver;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IDeliveryDriverRepository
{
    ICollection<DeliveryDriver> GetDeliveryDrivers();
    DeliveryDriver GetDeliveryDriver(int id);
    bool CreateDeliveryDriver(DeliveryDriver deliveryDriver);
    bool UpdateDeliveryDriver(int id, DeliveryDriverDto deliveryDriverDto);
    bool DeleteDeliveryDriver(int id);
    DeliveryDriver GetAvailableDeliveryDriver();
}