
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RBACdemo.Dto
{
    public partial class RegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
