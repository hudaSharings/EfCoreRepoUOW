using RBACdemo.Infrastructure.Core.Domain;
using RBACdemo.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence.Repositories
{
    public class UserRepository :Repository<User>, IUserRepository
    {
        public RBACdemoContext RBACdemoContext => Context as RBACdemoContext; 
        public UserRepository(RBACdemoContext context):base(context)
        {

        }
    }
}
