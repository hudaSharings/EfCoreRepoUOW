using System;
using System.Collections.Generic;

namespace RBACdemo.Dto
{
    public class UserinfoDto
    {
        public string userId { get; set; }
        public string username { get; set; }
        public string FirsrName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TenantNo { get; set; }

        public string DomainName { get; set; }
        public string Companyname { get; set; }
        public string DataBaseName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime Todate { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
        public List<string> RoleClaims { get; set; }
        public List<string> UserClaims { get; set; }
        //public Dictionary<long,string> Menus { get; set; }
        public List<MenusDto> Menus { get; set; }

    }
}
