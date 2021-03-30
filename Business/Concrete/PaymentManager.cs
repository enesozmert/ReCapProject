using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult Add(Payment payment)
        {
            Console.WriteLine("Added");
            return new SuccessResult();
        }

        public IResult Delete(Payment payment)
        {
            Console.WriteLine("Deleted");
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand> GetById(int paymnetID)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment payment)
        {
            Console.WriteLine("Updated");
            return new SuccessResult();
        }
    }
}
