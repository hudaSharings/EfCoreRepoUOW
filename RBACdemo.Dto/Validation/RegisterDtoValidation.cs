using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace RBACdemo.Dto
{
   public  class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.password).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.password);
        }
    }
}
