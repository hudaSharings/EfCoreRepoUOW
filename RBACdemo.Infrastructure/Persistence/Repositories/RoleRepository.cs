using RBACdemo.Infrastructure.Core.Domain;
using RBACdemo.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence.Repositories
{
   public class RoleRepository:Repository<Role>,IRoleRepository
    {
        public RBACdemoContext _context => Context as RBACdemoContext;
        public RoleRepository(RBACdemoContext context):base(context)
        {

        }
    }
}
