using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CarID).GreaterThan(0);
            RuleFor(p => p.CustomerID).GreaterThan(0);
            RuleFor(p => p.CarID).NotEmpty();
            RuleFor(p => p.CustomerID).NotEmpty();
        }
    }
}
