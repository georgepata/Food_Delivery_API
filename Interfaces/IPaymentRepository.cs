using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface IPaymentRepository
{
    Payment GetPaymentById(int id);
    bool CreatePayment(Payment payment);
}