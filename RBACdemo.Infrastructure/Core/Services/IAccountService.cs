using Microsoft.AspNetCore.Identity;
using RBACdemo.Dto;
using RBACdemo.Infrastructure.Core.Domain;
using RBACdemo.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Infrastructure.Core.Services
{
   public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto user, string password);
        Task<IdentityResult> AddUserToRole(ApplicationUser user, string role);
        Task<LoginResultDto> SignIn(LoginDto login);
    }
   
}
