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
using RBACdemo.Core.Settings;
using RBACdemo.Infrastructure.Persistence;
using System.Linq;
using RBACdemo.Utility;
namespace RBACdemo.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<ApplicationRole> _roleManager;
        
        private RBACdemoContext DbContext { get; }

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RBACdemoContext context, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            DbContext = context;
        }



        public async Task<IdentityResult> AddUserToRole(UserRoleDto user)
        {
            var u = _userManager.Users.FirstOrDefault(x => x.UserName == user.Username);
            return await _userManager.AddToRoleAsync(u, user.RoleName);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        => await _userManager.CreateAsync(user, password);

        public async Task<LoginResultDto> SignIn(LoginDto login)
        {
            var res = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, login.LockonFailure);

            var retres = new LoginResultDto();
            if (res.Succeeded)
            {
                UserinfoDto userinfoDto = GetUserInfoByUserName(login.Username);
               userinfoDto.Menus = GetMenusByRoleId(userinfoDto.RoleId);
                var tenantinfo = GetTenantinfoByUserId(userinfoDto.userId);
                var token = GenerateToken(login, tenantinfo);
                retres.Token = new JwtSecurityTokenHandler().WriteToken(token);
                retres.TokenExpiration = token.ValidTo;
                retres.UserInfo = userinfoDto;

            }

            return retres;
        }

        //private Dictionary<long, string> GetMenusByUserId(string userid)
        //{
        //    return (from um in DbContext.UserMenuItems.Where(x => x.UserId == userid)
        //            join m in DbContext.MenuItems on um.MenuItemNo equals m.MenuItemNo
        //            select new KeyValuePair<long, string>(m.MenuItemNo, m.Name))
        //        .ToDictionary(x => x.Key, x => x.Value);
        //}

        private List<MenusDto> GetMenusByRoleId(string roleId)
        {
            var menuitems = DbContext.RoleMenuItems.Where(x => x.RoleId == roleId).Select(x => x.MenuItem);
            var parentmenus = menuitems.Where(x => x.ParentId == 0);
            List<MenusDto> menus = new List<MenusDto>();

            foreach (var item in parentmenus)
            {
                MenusDto md = new MenusDto();
                md.ParentId = item.ParentId;
                md.id = item.Id;
                md.Path = item.Url;
                md.Component = item.Name;
                if (menuitems.Where(x => x.ParentId == item.MenuItemNo).Any())
                    md.Child = getChildmenus(menuitems.Where(x => x.ParentId == item.MenuItemNo).ToList());
                menus.Add(md);
            }

            return menus;


        }

        private List<MenusDto> getChildmenus(List<MenuItem> menuitems)
        {

            List<MenusDto> menus = new List<MenusDto>();

            foreach (var item in menuitems)
            {
                MenusDto md = new MenusDto();
                md.ParentId = item.ParentId;
                md.id = item.Id;
                md.Path = item.Url;
                md.Component = item.Name;
                if (menuitems.Where(x => x.ParentId == item.MenuItemNo).Any())
                    md.Child = getChildmenus(menuitems.Where(x => x.ParentId == item.MenuItemNo).ToList());
                menus.Add(md);
            }
            return menus;


        }



        private Tenant GetTenantinfoByUserId(string userId)
        {
            return (from u in DbContext.Users.Where(x => x.Id == userId)
                    join t in DbContext.Tenants on u.TenantNo equals t.TenantNo
                    select t).FirstOrDefault();
        }

        private UserinfoDto GetUserInfoByUserName(string userName)
        {         

           return (from u in DbContext.Users.Where(x => x.UserName == userName)
                    join t in DbContext.Tenants on u.TenantNo equals t.TenantNo
                    join ur in DbContext.UserRoles on u.Id equals ur.UserId
                    join r in DbContext.Roles on ur.RoleId equals r.Id
                    select new UserinfoDto
                    {
                        Companyname = t.Companyname,
                        DataBaseName = t.DataBaseName,
                        DomainName = t.DomainName,
                        Email = u.Email,
                        FirsrName = u.FirstName,
                        LastName = u.LastName,
                        FromDate = t.FromDate,
                        Todate = t.Todate,
                        TenantNo = t.TenantNo,
                        username = u.UserName,
                        userId = u.Id,
                        RoleId=r.Id,
                        Role=r.Name
                    }).FirstOrDefault();
           
        }
        public Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var role = new ApplicationRole();
            role.Name = roleName;
          return  _roleManager.CreateAsync(role);
        }

        public Task<IdentityResult> CreateRoleClims(string roleName, string clims)
        {
            var role = new ApplicationRole();
            role.Name = roleName;
            var rid = _roleManager.GetRoleIdAsync(role);
            if (rid != null)
            {
                Task<IdentityResult> result = null;
                foreach (var item in clims.Split(','))
                {
                    string[] itms = item.Split('-');
                    Claim claim = new Claim(item[0].ToString(), item[1].ToString());
                  result=  _roleManager.AddClaimAsync(role, claim);
                }
                return result;
            }
            else
                throw new ArgumentNullException(roleName);
        }

        private JwtSecurityToken GenerateToken(LoginDto login, Tenant tenantinfo)
        {
            string tenant = EncryptDecrypt.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(tenantinfo));
            var clims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("TenantInfo",tenant),
                };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting.SecreteKey));

            var token = new JwtSecurityToken(
                issuer: JwtSetting.Issuer,//"https://localhost:44335",
                audience: JwtSetting.Audience, //"https://localhost:44335",
                expires: DateTime.UtcNow.AddMinutes(JwtSetting.ExpairesInMinutes),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: clims
                 );

            return token;
        }

    }
}
