using Microsoft.AspNetCore.Identity;
using RBACdemo.Dto;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<IdentityResult> AddUserToRole(UserRoleDto user)
        {
           
            return await _repository.AddUserToRole(user);
        }

        public Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            return  _repository.CreateRoleAsync(roleName);
        }

        public Task<IdentityResult> CreateRoleClims(string role, string clims)
        {
            return _repository.CreateRoleClims(role, clims);
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDto user, string password)
        {
            var _user = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            return await _repository.CreateUserAsync(_user, password);
        }

        public async Task<LoginResultDto> SignIn(LoginDto login)
        {
            return await _repository.SignIn(login);
        }
    }
}
