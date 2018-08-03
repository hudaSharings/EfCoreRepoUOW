using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RBACdemo.POCO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RBACdemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    public class BaseController : Controller
    {
       
        public BaseController()
        {
            
        }
       


    }
}
