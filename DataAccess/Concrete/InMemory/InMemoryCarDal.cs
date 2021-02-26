using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrate
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ID=1,BrandID=1,ColorID=1,DailyPrice=15,Description="ab",ModelYear=1999},
                new Car{ID=2,BrandID=2,ColorID=2,DailyPrice=10,Description="abc",ModelYear=1999},
                new Car{ID=3,BrandID=2,ColorID=3,DailyPrice=5,Description="abcd",ModelYear=1999},
                new Car{ID=4,BrandID=3,ColorID=3,DailyPrice=1,Description="abce",ModelYear=1999},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.ID == car.ID);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            var ListedId = _cars.Where(p => p.ID == CarId).ToList();
            return ListedId;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.ID == car.ID);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.BrandID = car.BrandID;
        }
    }
}
