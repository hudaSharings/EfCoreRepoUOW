using System.Collections.Generic;

namespace RBACdemo.Core.Domain
{
    #region  Entity Models
    public class Role : BaseEntityModel
    {

        public string Name { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

    }
    #endregion

}
