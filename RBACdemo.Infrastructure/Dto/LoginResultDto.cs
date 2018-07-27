using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Dto
{
   public class LoginResultDto :SignInResult
    {
        public string username { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
