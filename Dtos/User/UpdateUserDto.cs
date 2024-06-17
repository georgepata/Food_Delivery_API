using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.User;

public class UpdateUserDto
{
    public string? Name {get; set;}
    public string? Email {get; set;}
    public string? Phone {get; set;}
    public string? Address {get; set;}
}