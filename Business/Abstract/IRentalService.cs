using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetById(int rentalID);
        IDataResult<Rental> IsForRent(int carID);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        IResult IsRentedByCarId(int carID);
    }
}
