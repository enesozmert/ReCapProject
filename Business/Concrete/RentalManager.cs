using Business.Abstract;
using Business.Attributes;
using Business.Constant;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        public IDataResult<bool> IsForRent(int carID)
        {
            bool isForRent = false;
            var isDateCreated = _rentalDal.GetAll(p => p.CarID == carID).Any(p => p.CarID == carID);
            if (isDateCreated)
            {
                var result = _rentalDal.Get(k => k.CarID == carID && k.ReturnDate != null);
                if (result != null)
                {
                    isForRent = true;
                    return new SuccessDataResult<bool>(isForRent, Messages.IsForRent);
                    //return new ErrorDataResult<bool>(_rentalDal.Get(p => p.CarID == carID), Messages.IsForRentInvalid);
                }
                isForRent = false;
                return new SuccessDataResult<bool>(isForRent, Messages.IsForRent);
            }
            isForRent = true;
            return new SuccessDataResult<bool>(isForRent, Messages.IsForRent);
        }
        public IDataResult<bool> IsForRentCompany(Rental rental)
        {
            bool isForRent = false;
            var isDateCreated = _rentalDal.GetAll(p => p.CarID == rental.CarID).Any(p => p.CarID == rental.CarID);
            if (isDateCreated)
            {
                var result = _rentalDal.Get(k => k.CarID == rental.CarID && k.CustomerID == rental.CustomerID && k.ReturnDate != null);
                if (result != null)
                {
                    isForRent = true;
                    return new SuccessDataResult<bool>(isForRent, Messages.IsForRent);
                    //return new ErrorDataResult<bool>(_rentalDal.Get(p => p.CarID == carID), Messages.IsForRentInvalid);
                }
                isForRent = false;
                return new SuccessDataResult<bool>(isForRent, Messages.IsForRent);
            }
            isForRent = true;
            return new SuccessDataResult<bool>(isForRent, Messages.IsForRent);
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

        public IDataResult<RentalDetailDto> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetailDto(p => p.CarID == carId));
        }
        #endregion
    }
}
