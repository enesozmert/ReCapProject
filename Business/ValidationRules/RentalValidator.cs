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
            RuleFor(t => t.CarID).NotEmpty().WithMessage("boş olmamalı => NotEmpty");
            RuleFor(t => t.CustomerID).NotEmpty().WithMessage("boş olmamalı => NotEmpty");
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
