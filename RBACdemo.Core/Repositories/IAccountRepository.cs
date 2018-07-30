using Microsoft.AspNetCore.Identity;
using RBACdemo.Dto;
using RBACdemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Core.Repositories
{
  public  interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> AddUserToRole(ApplicationUser user, string role);
        Task<LoginResultDto> SignIn(LoginDto login);

    }
}
