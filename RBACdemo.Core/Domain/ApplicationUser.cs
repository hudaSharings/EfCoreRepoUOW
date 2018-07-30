using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RBACdemo.Core.Domain
{
    #region  Entity Models
    public class ApplicationUser : IdentityUser
    {
        public List<UserMenuItem> UserMenuItems { get; set; }
    }


    #endregion

}
