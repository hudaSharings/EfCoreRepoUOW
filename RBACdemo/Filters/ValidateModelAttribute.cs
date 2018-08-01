using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RBACdemo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBACdemo.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ApiResult(context.ModelState));
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            dynamic actionResult = context.Result;
            if(actionResult!=null)
            context.Result = new JsonResult(new ApiResult(actionResult.Value,context.HttpContext.Response.StatusCode));
            base.OnActionExecuted(context);
        }

       

    }
}
