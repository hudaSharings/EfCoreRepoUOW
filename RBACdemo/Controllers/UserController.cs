using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RBACdemo.Infrastructure.Core;
using RBACdemo.Infrastructure.Core.Domain;
using RBACdemo.Infrastructure.Core.Repositories;
using RBACdemo.Infrastructure.Persistence.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RBACdemo.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : BaseController
    {
        IUnitOfWork _uow;
        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<User> getUser()
        {
            return _uow.User.GetAll();
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
