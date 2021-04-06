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
        IDataResult<bool> IsForRent(int carID);
        IDataResult<bool> IsForRentCompany(Rental rental);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        IDataResult<RentalDetailDto> GetRentalDetailsByCarId(int carId);
        IResult IsRentedByCarId(int carID);
    }
}
