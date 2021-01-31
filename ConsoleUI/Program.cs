using Business.Concrate;
using DataAccess.Concrate;
using Entities.Concrate;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car() { Id = 5, BrandId = 2,ColorId=3,DailyPrice=111,Description="abcde",ModelYear="12.19.111" };
            Car car1 = new Car() { Id = 1, BrandId = 2,ColorId=3,DailyPrice=111,Description="abcde",ModelYear="12.19.111" };
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            carManager.Add(car);
            carManager.Delete(car);
            carManager.GetAll();
            carManager.GetById(1);
            carManager.Update(car1);
        }
    }
}
