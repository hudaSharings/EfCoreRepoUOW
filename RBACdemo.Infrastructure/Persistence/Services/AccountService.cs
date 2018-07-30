using Microsoft.AspNetCore.Identity;
using RBACdemo.Infrastructure.Core.Domain;
using RBACdemo.Infrastructure.Core.Repositories;
using RBACdemo.Infrastructure.Core.Services;
using RBACdemo.Infrastructure.Dto;
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

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _repository.CreateUserAsync(user, password);
        }

        public async Task<LoginResultDto> SignIn(LoginDto login)
        {
            return await _repository.SignIn(login);
        }
    }
}
