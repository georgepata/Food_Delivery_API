using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Food_Delivery_API.Filters;

public class User_ValidateUpdateUserActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context){
        var id = context.ActionArguments["id"] as int?;
        var user = context.ActionArguments["user"] as User;

        if (id.HasValue && user != null && id != int.Parse(user.Id)){
            context.ModelState.AddModelError("UserId", "UserId is not the same as id");
            var problemDetails = new ValidationProblemDetails(){
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}