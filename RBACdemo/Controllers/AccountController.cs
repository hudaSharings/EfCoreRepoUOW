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


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RBACdemo.Controllers
{
    [Route("api/[controller]/[action]")]
    //[ServiceFilter(typeof(ValidateModelAttribute))]
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        IAccountService _svc;

        IMenuItemService _mnuSvc;

        public AccountController(IAccountService svc, IUserService usersvc, IMenuItemService mnuSvc)
        {
            _svc = svc;
            _mnuSvc = mnuSvc;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public async Task<IdentityResult> Register([FromBody]RegisterDto user)
        {
            return await _svc.CreateUserAsync(user, user.password);

        }
        [HttpPost]
        public async Task<LoginResultDto> Login([FromBody]LoginDto user)
        {
            throw new ApiException("sample demo test", 500);
            //return await _svc.SignIn(user);

        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _mnuSvc.SingleOrDefault(x => x.CreatedBy == id)?.Name;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
