using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBACdemo.Core.Services;

namespace RBACdemo.Controllers
{
   
    public class GenericController<T,PKtype> : BaseController where T:class
    {
        protected  IService<T> Service;

        public GenericController(IService<T> service)
        {
            Service = service;
        }

        public IEnumerable<T> Get()
        {
            return Service.GetAll();
        }
        [HttpGet("{id}")]
        public T Get(PKtype id)
        {
            return Service.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] T value)
        {
            Service.AddandSave(value);
        }        
        [HttpPut("{id}")]
        public void Put([FromBody] T value)
        {
            Service.ModifyandSave(value);
        }        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Service.RemoveandSave(id);
        }
    }


   
}