using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UsersValidator : AbstractValidator<Users>
    {
        public UsersValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim Boş Bırakılamaz.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soy isim Boş Bırakılamaz.");
        }
    }
}
