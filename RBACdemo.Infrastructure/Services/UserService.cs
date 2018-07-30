using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Services
{
  public class UserService :Service<ApplicationUser>, IUserService
    {
        public IUserRepository _userRepo { get; }
        public UserService(IUserRepository userRepo):base(userRepo)
        {
            _userRepo = userRepo;
        }

       
    }
}
