using Entities.Concrate;
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
            RuleFor(t => t.CarID).NotEmpty().WithMessage("boş olmamalı => CarID");
            RuleFor(t => t.CustomerID).NotEmpty().WithMessage("boş olmamalı => NotEmpty");
            RuleFor(t => t.IsEnabled).NotEmpty().WithMessage("boş olmamalı => IsEnabled");
            RuleFor(t => t.ReturnDate).Must(ReturnDateIsNull).WithMessage("araba kiralandı => IsEnabled");

        }

        private bool ReturnDateIsNull(DateTime? arg)
        {
            if (arg == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
