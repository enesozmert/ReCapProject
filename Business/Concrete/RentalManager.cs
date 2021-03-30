using Business.Abstract;
using Business.Attributes;
using Business.Constant;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

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

        [ValidationAspect(typeof(RentalValidator))]
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

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetailDto());
        }

        public IDataResult<Rental> IsForRent(int carID)
        {
            if (_rentalDal.Get(p => p.ID == carID).ReturnDate == null)
            {
                return new ErrorDataResult<Rental>(_rentalDal.Get(p => p.CarID == carID), Messages.IsForRentInvalid);
            }

            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CarID == carID), Messages.IsForRent);
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarID == rental.CarID && r.ReturnDate == null);

            if (result != null) return new ErrorResult(Messages.RentalUpdatedInvalid);

            result.ReturnDate = DateTime.Now.Date;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalUpdate);
        }

        public IResult IsRentedByCarId(int carID)
        {
            var result = BusinessRules.Run(CheckIsRentedToCarId(carID));
            if (result != null)
            { return result; }
            return new SuccessResult(Messages.IsForRent);
        }
        #region Business
        public IResult CheckIsRentedToCarId(int carID)
        {
            var result = _rentalDal.Get(p => p.CarID == carID);
            if (result.ReturnDate != null)
            {
                return new SuccessResult(Messages.IsForRent);
            }
            return new ErrorResult(Messages.IsForRentInvalid);
        }
        #endregion
    }
}
