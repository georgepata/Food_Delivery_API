using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Models.Validations;

namespace Food_Delivery_API.Dtos;

public class UserDto
{
    public string? UserId {get; set;}
    [Required]
    public string? Name { get; set; }
    [Required]
    [User_EnsureCorrectEmailFormat]
    public string? Email {get; set;}
    [Required]
    [User_EnsureCorrectPhoneFormat]
    public string? Phone { get; set; }
    [Required]
    public string Address { get; set; }
    public string Role {get; set;}
}