using Business.Abstract;
using Business.Constant;
using Business.ValidationRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
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

        public IResult Add(Car car)
        {
            //CarValidator validationRules = new CarValidator();
            //var result = validationRules.Validate(car);
            //if (result.Errors.Count > 0)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //ValidationTool.Validater(new CarValidator(),car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetById(int ID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarID == ID));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandID == BrandID));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int ColorID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorID == ColorID));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
