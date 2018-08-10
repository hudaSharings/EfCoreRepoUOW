using RBACdemo.Core.Persistence;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RBACdemo.Infrastructure.Persistence;

namespace RBACdemo.Infrastructure.Repositories
{
    public class UserRepository :Repository<ApplicationUser>, IUserRepository
    {
        public RBACdemoContext RBACdemoContext => Context as RBACdemoContext; 
        public UserRepository(IContextFactory context):base(context)
        {

        }
    }
}
