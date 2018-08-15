using Microsoft.AspNetCore.Identity;
using RBACdemo.Dto;
using RBACdemo.Core.Domain;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Core.Services
{
   public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto user, string password);
        Task<IdentityResult> AddUserToRole(UserRoleDto user);
        Task<LoginResultDto> SignIn(LoginDto login);
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> CreateRoleClims(string role, string clims);
    }
   
}
