using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models.Validations;

public class User_EnsureCorrectEmailFormatAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var user = validationContext.ObjectInstance as User;

        if (user is not null && !string.IsNullOrWhiteSpace(user.Email)){
            string email = user.Email;
            if (!IsValidEmailFormat(email))
                return new ValidationResult(ErrorMessage ?? "Invalid email format");
        }  
        return ValidationResult.Success;
    }

    private bool IsValidEmailFormat(string email){
        return email.EndsWith("@yahoo.com", StringComparison.OrdinalIgnoreCase) || email.EndsWith("@gmail.com");
    }
}