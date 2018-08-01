using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBACdemo.POCO
{
    public class ApiException : Exception
    {

        string _message;
        public override string Message => _message;
        public int StatucCode { get; set; }
        public ApiException(string message) : base(message)
        {
            _message = message;
        }
        public ApiException(string message, int statusCode)
        {
            _message = message;
            StatucCode = statusCode;
        }
    }
}
