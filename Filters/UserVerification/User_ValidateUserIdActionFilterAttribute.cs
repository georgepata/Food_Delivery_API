using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Food_Delivery_API.Filters;

public class User_ValidateUserIdActionFilterAttribute : ActionFilterAttribute
{
    private readonly FoodDeliveryContext _foodDeliveryContext;
    public User_ValidateUserIdActionFilterAttribute(FoodDeliveryContext foodDeliveryContext){
        _foodDeliveryContext = foodDeliveryContext;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var userId = context.ActionArguments["id"] as int?;

        if (userId.HasValue){
            if (userId.Value <=0){
                context.ModelState.AddModelError("UserId", "UserId is invalid");
                context.Result = new BadRequestObjectResult(context.ModelState);
            } else {
                var user = _foodDeliveryContext.Users.Find(userId.Value);

                if (user == null) {
                    context.ModelState.AddModelError("UserId", "User doesn't exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState){
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        } 
    }
}