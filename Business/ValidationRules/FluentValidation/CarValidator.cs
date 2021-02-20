using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty().WithMessage("Araç İsmi Boş Bırakılamaz.");
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage("Araç İsmi en az 2 karakter olmalıdır.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Aracın Günlük Değeri 0 dan büyük olamlıdır.");
            RuleFor(c => c.Description).MinimumLength(6).WithMessage("Araç Açıklaması En az 6 Karakter olmalıdır.");
        }
    }
}
