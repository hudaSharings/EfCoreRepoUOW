using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace RBACdemo.Dto.Validation
{
   public class UserRoleDtoValidation :AbstractValidator<UserRoleDto>
    {
        public UserRoleDtoValidation()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.RoleName).NotEmpty();
        }
    }
}
