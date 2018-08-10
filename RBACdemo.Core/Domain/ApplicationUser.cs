using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBACdemo.Core.Domain
{
    #region  Entity Models
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("TenantNo")]
        public Tenant Tenant { get; set; }
        public List<UserMenuItem> UserMenuItems { get; set; }
    }


    #endregion

}
