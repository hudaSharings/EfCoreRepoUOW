using RBACdemo.Infrastructure.Core.Domain;
using RBACdemo.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence.Repositories
{
   public class PermissionRepository:Repository<Permission>,IPermissionRepository
    {
        public RBACdemoContext _context => Context as RBACdemoContext;
        public PermissionRepository(RBACdemoContext context):base(context)
        {

        }
    }
}
