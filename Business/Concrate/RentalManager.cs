using Business.Abstract;
using Business.Constant;
using Business.ValidationRules;
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

        public IResult Add(Rental rental)
        {
            var verification = ValidationTool.ValidaterVoid(new RentalValidator(), rental, Messages.RentalAdd);
            if (verification.Success == true)
            {
                if (rental.ReturnDate != null)
                {
                    _rentalDal.Add(rental);
                }
            }
            return verification;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return ValidationTool.ValidaterVoid(new RentalValidator(), rental, Messages.RentalDelete);
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
            return ValidationTool.ValidaterVoid(new RentalValidator(), rental, Messages.RentalUpdate);
        }
    }
}
