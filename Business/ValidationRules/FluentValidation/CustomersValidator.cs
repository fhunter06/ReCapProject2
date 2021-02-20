using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomersValidator :AbstractValidator<Customers>
    {
        public CustomersValidator()
        {
            RuleFor(e => e.CompanyName).NotEmpty();
        }
    }
}
