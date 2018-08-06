using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RBACdemo.Dto;
using RBACdemo.Core;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using Microsoft.AspNetCore.Authorization;
using RBACdemo.Filters;
using RBACdemo.POCO;
using Microsoft.AspNetCore.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RBACdemo.Controllers
{
    [Route("api/[controller]/[action]")]
    //[ServiceFilter(typeof(ValidateModelAttribute))]
    [AllowAnonymous]
   
    public class AccountController : BaseController
    {
        IAccountService _svc;
        public AccountController(IAccountService svc)
        {
            _svc = svc;
            
        }
       [HttpPost]
        public async Task<IdentityResult> Register([FromBody]RegisterDto user)
        {
            return await _svc.CreateUserAsync(user, user.password);

        }
        [HttpPost]
        public async Task<LoginResultDto> Login([FromBody]LoginDto user)
        {
           // throw new ApiException("sample demo test", 500);
            return await _svc.SignIn(user);

        }
     
    }
}
