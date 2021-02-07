using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetById(int CarID);
        List<Car> GetCarsByColorId(int ColorID);
        List<Car> GetCarsByBrandId(int BrandID);
        List<CarDetailDto> GetCarDetail();
    }
}
