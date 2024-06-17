using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Dtos.User;

public class ResetPasswordDto
{
    [Required]
    public string? NewPassword {get; set;}
    [Required]
    public string? ConfirmedPassword {get; set;}
}