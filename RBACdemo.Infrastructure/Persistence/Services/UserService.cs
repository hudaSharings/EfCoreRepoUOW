using RBACdemo.Core.Domain;
using RBACdemo.Core.Services;
using RBACdemo.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence.Services
{
  public class UserService :Service<ApplicationUser>, IUserService
    {
        public UserRepository _userRepo { get; }
        public UserService(UserRepository userRepo):base(userRepo)
        {
            _userRepo = userRepo;
        }

       
    }
}
