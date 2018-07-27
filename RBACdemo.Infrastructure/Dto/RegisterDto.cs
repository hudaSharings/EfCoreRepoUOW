using RBACdemo.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RBACdemo.Infrastructure.Dto
{
   public partial class RegisterDto:ApplicationUser
    {
        [Required]
        public string password { get; set; }
        [Compare("password")]
        public string ConfirmPassword { get; set; }
    }
}
