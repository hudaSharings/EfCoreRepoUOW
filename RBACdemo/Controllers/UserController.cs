using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Services;

namespace RBACdemo.Controllers
{
    
    public class UserController : GenericController<ApplicationUser,string>
    {
        public UserController(IUserService userService):base(userService)
        {

        }
        
    }
}