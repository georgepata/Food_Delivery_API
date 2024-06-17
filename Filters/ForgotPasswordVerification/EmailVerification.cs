using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Food_Delivery_API.Filters.ForgotPasswordVerification;

public class EmailVerification<T> : ActionFilterAttribute where T : class
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var httpContext = context.HttpContext;
        var emailClaim = httpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        if (emailClaim == null)
        {
            context.ModelState.AddModelError("", "Invalid email address");
            context.Result = new BadRequestObjectResult(context.ModelState);
            return;
        }

        if (context.ActionArguments.TryGetValue("model", out var value) && value is T model)
        {
            var emailProperty = typeof(T).GetProperty("Email");
            if (emailProperty == null)
            {
                context.ModelState.AddModelError("", "Email property not found!");
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            var emailValue = emailProperty.GetValue(model) as string;
            if (emailValue == null || !emailValue.Equals(emailClaim))
            {
                context.ModelState.AddModelError("", "Email address does not match");
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
        }

        base.OnActionExecuting(context);
    }
}