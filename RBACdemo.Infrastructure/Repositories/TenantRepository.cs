using RBACdemo.Core.Domain;
using RBACdemo.Core.Persistence;
using RBACdemo.Core.Repositories;
using RBACdemo.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Repositories
{
   public class TenantRepository:Repository<Tenant>,ITenantRepository
    {
        public RBACdemoContext RBACdemoContext => Context as RBACdemoContext;
        public TenantRepository(IContextFactory context) : base(context)
        {

        }
    }
}
