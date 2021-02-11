using Core.Entity;
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
        public static void Validater(IValidator validator,object entities)
        {
            var result = validator.Validate((IValidationContext)entities);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
