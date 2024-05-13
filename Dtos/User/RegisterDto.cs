using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Models.Validations;

namespace Food_Delivery_API.Dtos.User;

public class RegisterDto
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }   
    [Required]
    [User_EnsureCorrectEmailFormat]
    public string? Email { get; set; }
    [Required]
    [User_EnsureCorrectPhoneFormat]
    public string? Phone { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public int? CityId {get; set;}
}