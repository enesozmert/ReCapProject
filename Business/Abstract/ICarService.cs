using Core.Utilities.Results.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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
        IDataResult<List<Car>> GetCarsByColorId(int ColorID);
        IDataResult<List<Car>> GetCarsByBrandId(int BrandID);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
