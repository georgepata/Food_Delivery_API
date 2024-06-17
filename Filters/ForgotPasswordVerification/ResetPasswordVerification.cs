using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.User;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Food_Delivery_API.Filters.ForgotPasswordVerification;

public class ResetPasswordVerification : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context){
        var httpContext = context.HttpContext;
        var query = httpContext.Request.Query;
        var token = query["token"].FirstOrDefault();
        var email = query["email"].FirstOrDefault();
        
        if (String.IsNullOrEmpty(token) || String.IsNullOrEmpty(email)){
            context.ModelState.AddModelError("", "Token and email are required");
            context.Result = new BadRequestObjectResult(context.ModelState);
            return;
        }

        if (context.ActionArguments.TryGetValue("model", out var value) && value is ResetPasswordDto model)
        {
            if (!model.NewPassword.Equals(model.ConfirmedPassword)){
                context.ModelState.AddModelError("", "Passwords do not match");
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            
        } else{
            context.ModelState.AddModelError("", "Invalid request payload.");
            context.Result = new BadRequestObjectResult(context.ModelState);
            return;
        }
        base.OnActionExecuting(context);
    }
}