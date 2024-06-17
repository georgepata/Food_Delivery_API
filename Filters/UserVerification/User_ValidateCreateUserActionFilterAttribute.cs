using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Food_Delivery_API.Filters;

public class User_ValidateCreateUserActionFilterAttribute : ActionFilterAttribute
{
    public readonly FoodDeliveryContext _foodDeliveryContext;
    public User_ValidateCreateUserActionFilterAttribute(FoodDeliveryContext foodDeliveryContext){
        _foodDeliveryContext = foodDeliveryContext;
    }
    public override void OnActionExecuting(ActionExecutingContext context){
        var user = context.ActionArguments["registerDto"] as RegisterDto;
        if (user == null){
            context.ModelState.AddModelError("User", "User object is null.");
            var problemDetails = new ValidationProblemDetails(context.ModelState){
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        } else {
            if(_foodDeliveryContext.Users.FirstOrDefault(u => u.Email == user.Email)!=null){
                context.ModelState.AddModelError("User", "User already exists ");
                var problemDetails = new ValidationProblemDetails(context.ModelState){
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);

            } else if(_foodDeliveryContext.Users.FirstOrDefault(u => u.Phone == user.Phone)!=null){
                context.ModelState.AddModelError("User", "User already exists");
                var problemDetails = new ValidationProblemDetails(context.ModelState){
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}