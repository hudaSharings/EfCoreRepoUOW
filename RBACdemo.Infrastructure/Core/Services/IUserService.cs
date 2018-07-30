using RBACdemo.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Core.Services
{
    interface IUserService :IService<ApplicationUser>
    {
    }
}
