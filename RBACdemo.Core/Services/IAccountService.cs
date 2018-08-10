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
        Task<IdentityResult> AddUserToRole(RegisterDto user, string role);
        Task<LoginResultDto> SignIn(LoginDto login);
    }
   
}
