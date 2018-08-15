using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace RBACdemo.Dto
{
   public class RoleClaimDtoValidation:AbstractValidator<RoleClaimDto>
    {
        public RoleClaimDtoValidation()
        {
            RuleFor(x => x.Role).NotEmpty();
            RuleFor(x => x.Claims).NotNull();
        }
    }
}
