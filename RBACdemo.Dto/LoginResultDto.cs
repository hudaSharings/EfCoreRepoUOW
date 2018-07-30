using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Dto
{
   public class LoginResultDto 
    {
        public string username { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
