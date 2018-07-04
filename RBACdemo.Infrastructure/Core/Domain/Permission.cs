using System.Collections.Generic;

namespace RBACdemo.Infrastructure.Core.Domain
{
    #region  Entity Models
    public class Permission : BaseEntityModel
    {

        public string Name { get; set; }

        public List<RolePermission> RolePermissions { get; set; }
    }
    #endregion

}
