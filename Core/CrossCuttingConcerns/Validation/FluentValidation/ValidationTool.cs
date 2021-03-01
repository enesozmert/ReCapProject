using Core.Entities.Concrete;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object etity)
        {
            var context = new ValidationContext<Object>(etity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
