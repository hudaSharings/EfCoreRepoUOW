using RBACdemo.Core;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Persistence;
using RBACdemo.Core.Repositories;
using RBACdemo.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Repositories
{
   public class RoleRepository:Repository<Role>,IRoleRepository
    {
        public RBACdemoContext _context => Context as RBACdemoContext;
        public RoleRepository(IContextFactory context):base(context)
        {

        }
    }
}
