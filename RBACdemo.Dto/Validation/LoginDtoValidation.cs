using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace RBACdemo.Dto
{
   public class LoginDtoValidation :AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
