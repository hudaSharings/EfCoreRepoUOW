using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RBACdemo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBACdemo.Filters
{
    public class ApiExceptionFilter :ExceptionFilterAttribute
    {
        
        public ApiExceptionFilter()
        {

        }
        public override void OnException(ExceptionContext context)
        {
            var result= new ApiResult(false);
            var exception = context.Exception;
            result.Message = exception.GetBaseException().Message;
            result.Detail = exception.StackTrace;
            result.StatusCode = 500;
            context.HttpContext.Response.StatusCode = (int)result.StatusCode;
            context.Result = new  JsonResult(result);
            
            base.OnException(context);
        }
    }
}
