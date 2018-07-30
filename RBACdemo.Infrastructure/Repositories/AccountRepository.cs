using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RBACdemo.Dto;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RBACdemo.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserToRole(ApplicationUser user, string role)
        => await _userManager.AddToRoleAsync(user, role);

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        => await _userManager.CreateAsync(user, password);

        public async Task<LoginResultDto> SignIn(LoginDto login)
        {
            var res = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, login.LockonFailure);
            var retres = new LoginResultDto();
            if (res.Succeeded)
            {
                var token = GenerateToken(login);
                retres.Token = new JwtSecurityTokenHandler().WriteToken(token);
                retres.Expiration = token.ValidTo;
            }
            
            return retres;
        }

        private JwtSecurityToken GenerateToken(LoginDto login)
        {
            var clims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtValues.SecreteKey));

            var token = new JwtSecurityToken(
                issuer: JwtValues.Issuer,//"https://localhost:44335",
                audience:JwtValues.Audience, //"https://localhost:44335",
                expires: DateTime.UtcNow.AddMinutes(JwtValues.ExpairesInMinutes),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                 );

            return token;
        }

    }
}
