using Business.Abstract;
using Business.Concrete;
using Business.Constant;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Business.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RentalValidationAttribute : Attribute
    {
        IRentalService _rentalDal;

        public RentalValidationAttribute(IRentalService rentalDal)
        {
            _rentalDal = rentalDal;

            //MethodInfo methodInfo = typeof(IRentalService).GetMethod("Add", new[] { typeof(string) });
            //methodInfo.Invoke(new,new[],{ });
        }
    }
}
