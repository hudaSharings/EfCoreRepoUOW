using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Dto
{
  public class RoleClaimDto
    {
        public string Role { get; set; }

        public List<string> Claims { get; set; }
    }
}
