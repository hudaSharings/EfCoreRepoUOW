using System.Collections.Generic;

namespace RBACdemo.Core.Domain
{
    public class MenuItem : BaseEntityModel
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        public List<UserMenuItem> UserMenuItems { get; set; }
    }


}
