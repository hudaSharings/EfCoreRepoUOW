using System;
using System.Text;

namespace RBACdemo.Dto
{
    public class LoginResultDto 
    {
        
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public UserinfoDto UserInfo { get; set; }
    }
}
