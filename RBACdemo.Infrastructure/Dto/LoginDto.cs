using RBACdemo.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Dto
{
    public class LoginDto 
    {
       public string Username { get; set; }
       public string Password { get; set; }
       public bool RememberMe { get; set; }
       public bool LockonFailure { get; set; }
    }
}
