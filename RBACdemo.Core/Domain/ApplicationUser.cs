using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBACdemo.Core.Domain
{
    #region  Entity Models
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int? TenantNo { get; set; }
      
        public virtual Tenant Tenant { get; set; }
       
        public virtual List<UserMenuItem> UserMenuItems { get; set; }
    }


    #endregion

}
