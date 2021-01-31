using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrate
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=15,Description="ab",ModelYear="12.19.1999"},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=10,Description="abc",ModelYear="12.19.1998"},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=5,Description="abcd",ModelYear="12.19.1997"},
                new Car{Id=4,BrandId=3,ColorId=3,DailyPrice=1,Description="abce",ModelYear="12.19.1996"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int CarId)
        {
            var ListedId= _cars.Where(p => p.Id == CarId).ToList();
            return ListedId;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p=>p.Id==car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
