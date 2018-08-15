using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace RBACdemo.Core.Domain
{
   public class ApplicationUserClaim :IdentityUserClaim<string>
    {
    }
}
