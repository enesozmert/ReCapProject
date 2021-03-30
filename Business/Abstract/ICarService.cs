using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int CarID);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarImageDetailDto>> GetCarImageDetails(int carID);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandID);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorID);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorOrBrandId(int colorID, int brandID);
        IDataResult<CarDetailDto> GetCarDetailsById(int carID);

    }
}
