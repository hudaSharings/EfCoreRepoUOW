using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RBACdemo.Core.Domain
{
   
    public class ApplicationRole : IdentityRole
    {
        public List<ApplicationUser> Users { get; set; }
        public List<RoleMenuItem> RoleMenuItems { get; set; }
    }
    

}
