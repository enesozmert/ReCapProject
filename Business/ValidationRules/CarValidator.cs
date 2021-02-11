using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(t => t.DailyPrice).GreaterThan(0).WithMessage("0'dan büyük olmalı=> DailPrice");
            RuleFor(t => t.Description).Must(DescriptionLengthWithTwo).WithMessage("Açıklama 2 karakterden büyük olmalıdır.=>Description");
        }

        private bool DescriptionLengthWithTwo(string arg)
        {
            return arg.Length > 2;
        }
    }
}
