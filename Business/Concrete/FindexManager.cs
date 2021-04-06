using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindexManager : IFindexService
    {
        public IResult Add(Findex findex)
        {
            Console.WriteLine("Added");
            return new SuccessResult();
        }

        public IResult Delete(Findex findex)
        {
            Console.WriteLine("Deleted");
            return new SuccessResult();
        }

        public IDataResult<List<Findex>> GetAll()
        {
            return new SuccessDataResult<List<Findex>>();
        }

        public IDataResult<Findex> GetById(int findexDtoID)
        {
            return new SuccessDataResult<Findex>();
        }

        public IDataResult<int> GetCarFindex()
        {
            Random random = new Random();
            int result = random.Next(0, 1900);
            return new SuccessDataResult<int>(result);
        }

        public IDataResult<int> GetUserFindex()
        {
            Random random = new Random();
            int result = random.Next(0, 1900);
            return new SuccessDataResult<int>(result);
        }

        public IResult Update(Findex findex)
        {
            Console.WriteLine("Update");
            return new SuccessResult();
        }
    }
}
