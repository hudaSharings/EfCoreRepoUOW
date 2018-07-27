using Microsoft.AspNetCore.Identity;
using RBACdemo.Infrastructure.Core.Domain;
using RBACdemo.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Infrastructure.Core.Repositories
{
  public  interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> AddUserToRole(ApplicationUser user, string role);
        Task<LoginResultDto> SignIn(LoginDto login);

    }
}
