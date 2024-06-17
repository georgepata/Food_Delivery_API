using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Interfaces;

public interface IEmailSend
{
    Task SendEmailAsync(string email, string subject, string message);
}