namespace RBACdemo.Infrastructure.Core.Domain
{
    public class RolePermission : BaseEntityModel
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }


}
