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
        //public static IResult ValidaterVoid(IValidator validator,object entities,string successMessage)
        //{
        //    IResult _resultVoid = null;
        //    var result = validator.Validate(entities);
        //    if (result.Errors.Count > 0)
        //    {
        //        var exception = new ValidationException(result.Errors);
        //        _resultVoid = new ErrorResult(exception.Message.ToString());
        //        //throw new ValidationException(result.Errors);
        //    }
        //    else
        //    {
        //        _resultVoid = new SuccessResult(successMessage);
        //    }
        //    return _resultVoid;
        //}
        public static void ValidaterVoid(IValidator validator, object entities)
        {
            var result = validator.Validate(entities);
            if (result.Errors.Count > 0)
            {
                var exception = new ValidationException(result.Errors);
                throw new Exception(exception.Message.ToString());
                //throw new ValidationException(result.Errors);
            }
        }
    }
}
