using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public PaymentRepository(FoodDeliveryContext foodDeliveryContext)
    {
        _foodDeliveryContext = foodDeliveryContext;
    }


    public Payment GetPaymentById(int id)
    {
        return _foodDeliveryContext.Payments.First(x => x.PaymentId == id);
    }
    public bool CreatePayment(Payment payment)
    {
        _foodDeliveryContext.Add(payment);
        return Save();
    }

    public bool Save(){
        var savedChanges = _foodDeliveryContext.SaveChanges();
        return savedChanges>0 ? true : false;
    }
}