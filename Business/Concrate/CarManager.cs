using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        private delegate void DelegateValidator();
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(),car);
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int ID)
        {
           return _carDal.GetAll(p=>p.CarID == ID);
        }

        public List<Car> GetCarsByBrandId(int BrandID)
        {
            return _carDal.GetAll(p => p.BrandID == BrandID);
        }

        public List<Car> GetCarsByColorId(int ColorID)
        {
            return _carDal.GetAll(p => p.ColorID == ColorID);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _carDal.GetCarDetails();
        }
    }
}
