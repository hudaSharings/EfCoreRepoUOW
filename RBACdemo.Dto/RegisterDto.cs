﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RBACdemo.Infrastructure.Dto
{
   public partial class RegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Compare("password")]
        public string ConfirmPassword { get; set; }
    }
}