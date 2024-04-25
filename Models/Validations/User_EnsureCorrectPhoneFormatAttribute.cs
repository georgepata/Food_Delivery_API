using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_API.Models.Validations;

public class User_EnsureCorrectPhoneFormatAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var user = validationContext.ObjectInstance as User;
        if (user is not null && !string.IsNullOrWhiteSpace(user.Phone)){
            string phoneNumber = user.Phone;
            if (!isPhoneNumberFormatValid(phoneNumber))
                return new ValidationResult(ErrorMessage ?? "Phone number is not valid");
        }
        return ValidationResult.Success;
    }

    public bool isPhoneNumberFormatValid(string phoneNumber){
        string pattern = @"^\d{10}$";
        return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern);
    }
}