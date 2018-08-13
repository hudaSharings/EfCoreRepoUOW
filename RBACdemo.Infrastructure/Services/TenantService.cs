using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Services
{
    public class TenantService : Service<Tenant>, ITenantService
    {
        public ITenantRepository _repository { get; }
        public TenantService(ITenantRepository repository) : base(repository)
        {
            _repository = repository;
        }


    }
}
