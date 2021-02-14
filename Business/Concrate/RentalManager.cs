using Business.Abstract;
using Business.Constant;
using Business.ValidationRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    [Validator(typeof(RentalValidator))]
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            #region ValidationToolToIResult
            //var verification = ValidationTool.ValidaterVoid(new RentalValidator(rental), rental, Messages.RentalAdd);
            //if (verification.Success == true)
            //{
            //    _rentalDal.Add(rental);
            //}
            //_rentalDal.Add(new Rental
            //{
            //    CarID = rental.CarID,
            //    CustomerID = rental.CustomerID,
            //    RentDate = DateTime.Now.Date,
            //    ReturnDate = null
            //});
            //return verification;
            #endregion

            var result = _rentalDal.Get(k => k.CarID == rental.CarID && k.ReturnDate == null);
            if (result.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarAddedInvalid);
            }
            _rentalDal.Add(new Rental
            {
                CarID = rental.CarID,
                CustomerID = rental.CustomerID,
                RentDate = DateTime.Now.Date,
                ReturnDate = null
            });

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
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}
