using Entities.Concrete;
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
            RuleFor(p => p.BrandID).NotEmpty();
            RuleFor(p => p.ColorID).NotEmpty();
            RuleFor(t => t.DailyPrice).GreaterThan(0).WithMessage("0'dan büyük olmalı=> DailPrice");
            RuleFor(t => t.Description).Must(DescriptionLengthWithTwo).WithMessage("Açıklama 2 karakterden büyük olmalıdır.=>Description");
            RuleFor(t => t.Description).Must(DescriptionWithA).WithMessage("Açıklama A karakterden başlamalıdır.=>Description");
        }

        private bool DescriptionWithA(string arg)
        {
            return arg.StartsWith('a');
        }

        private bool DescriptionLengthWithTwo(string arg)
        {
            return arg.Length > 2;
        }
    }
}
