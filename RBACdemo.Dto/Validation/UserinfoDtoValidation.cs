using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace RBACdemo.Dto.Validation
{
   public class UserinfoDtoValidation:AbstractValidator<UserinfoDto>
    {
        public UserinfoDtoValidation()
        {
            RuleFor(x => x.username).NotEmpty();
            RuleFor(x => x.Role).NotEmpty();
        }
    }
}
