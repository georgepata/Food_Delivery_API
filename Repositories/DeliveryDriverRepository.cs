using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos.DeliveryDriver;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Repositories;

public class DeliveryDriverRepository : IDeliveryDriverRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public DeliveryDriverRepository(FoodDeliveryContext foodDeliveryContext)
    {
        _foodDeliveryContext = foodDeliveryContext;
    }
    public DeliveryDriver GetDeliveryDriver(int id)
    {
        return _foodDeliveryContext.DeliveryDrivers.First(x => x.DeliveryDriverId == id);
    }
    public bool CreateDeliveryDriver(DeliveryDriver deliveryDriver)
    {
        _foodDeliveryContext.Add(deliveryDriver);
        return Save();
    }

    public bool UpdateDeliveryDriver(int id, DeliveryDriverDto deliveryDriverDto)
    {
        var deliveryDriver = GetDeliveryDriver(id);
        if (deliveryDriver != null){
            deliveryDriver.Name = deliveryDriverDto.Name;
            deliveryDriver.Phone = deliveryDriverDto.Phone;
        }
        return Save();
    }
    public bool DeleteDeliveryDriver(int id)
    {
        var deliveryDriverToDelete = GetDeliveryDriver(id);
        if (deliveryDriverToDelete != null)
            _foodDeliveryContext.Remove(deliveryDriverToDelete);
        return Save();
    }

    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges > 0 ? true : false;
    }
}