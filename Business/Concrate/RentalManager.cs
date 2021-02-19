using Business.Abstract;
using Business.Attributes;
using Business.Constant;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            var result = _rentalDal.Get(k => k.CarID == rental.CarID && (k.ReturnDate == null || k.RentDate < DateTime.Now));
            if (result != null)
            {
                return new ErrorResult(Messages.RentalAddInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdd);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalID)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.ID == rentalID));
        }

        public IDataResult<Rental> IsForRent(int rentalID)
        {
            IDataResult<Rental> dataResult = null;
            if (_rentalDal.Get(p => p.ID == rentalID).ReturnDate == null)
            {
                dataResult = new ErrorDataResult<Rental>(_rentalDal.Get(p => p.ID == rentalID), Messages.IsForRentInvalid);
            }
            else if (_rentalDal.Get(p => p.ID == rentalID).ReturnDate != null)
            {
                dataResult = new SuccessDataResult<Rental>(_rentalDal.Get(p => p.ID == rentalID), Messages.IsForRent);
            }
            return dataResult;
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarID == rental.CarID && r.ReturnDate == null);

            if (result != null) return new ErrorResult(Messages.RentalUpdatedInvalid);

            result.ReturnDate = DateTime.Now.Date;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}
