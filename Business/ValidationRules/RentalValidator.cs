using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator(Rental rental)
        {
            RuleFor(t => t.CarID).NotEmpty().WithMessage("boş olmamalı => NotEmpty");
            RuleFor(t => t.CustomerID).NotEmpty().WithMessage("boş olmamalı => NotEmpty");
            RuleFor(k => k.CarID == rental.CarID && k.ReturnDate == null).Empty().WithMessage("bu araba kiralanmış durumda => NotEmpty");
            //RuleFor(t => t.ReturnDate).Must(ReturnDateIsNull).WithMessage("araba kiralanmış durumda => ReturnDate");

        }

        private bool ReturnDateIsNull(DateTime? arg)
        {
            if (arg == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
