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
    
    public class TenantController : GenericController<Tenant,long>
    {
        public TenantController(ITenantService tenatService):base(tenatService)
        {
           
        }

      
    }
}