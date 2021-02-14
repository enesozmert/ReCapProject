using Business.Constant;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RentValidationAttribute:Attribute
    {
       
        public RentValidationAttribute(Action action)
        {
            action.Invoke();
        }
    }
}
