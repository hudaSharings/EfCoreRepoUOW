using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBACdemo.POCO
{
    public class ApiResult
    {
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public dynamic Errors { get; set; }
        public dynamic Detail { get; set; }

        public ApiResult(dynamic data,int statusCode)
        {
            Succeeded = true;
            StatusCode = statusCode;
            Data = data;
           
        }
        public ApiResult(bool result, int statusCode)
        {
            Succeeded = result;
             StatusCode = statusCode;
        }
        public ApiResult(bool result)
        {
            Succeeded = result;
            
        }
        public ApiResult(ModelStateDictionary modelState)
        {
            StatusCode = 400;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                Message = "Please correct the specified errors and try again.";
                Errors = modelState.SelectMany(m => m.Value.Errors.Select(me => new { FieldName = m.Key, ErrorMessage = me.ErrorMessage }));

            }
        }
    }
}
