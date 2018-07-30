using Microsoft.AspNetCore.Identity;
using RBACdemo.Dto;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Infrastructure.Persistence.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<IdentityResult> AddUserToRole(ApplicationUser user, string role)
        {
            return await _repository.AddUserToRole(user, role);
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
