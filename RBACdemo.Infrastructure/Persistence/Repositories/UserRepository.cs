using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence.Repositories
{
    public class UserRepository :Repository<ApplicationUser>, IUserRepository
    {
        public RBACdemoContext RBACdemoContext => Context as RBACdemoContext; 
        public UserRepository(RBACdemoContext context):base(context)
        {

        }
    }
}
