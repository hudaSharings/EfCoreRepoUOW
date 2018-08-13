using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Dto
{
   public class LoginResultDto 
    {
        
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public UserinfoDto UserInfo { get; set; }
    }


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

        public Dictionary<long,string> Menus { get; set; }

    }
}
