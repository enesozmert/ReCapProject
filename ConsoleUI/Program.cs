using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependency injection // Ioc Container=>Ninject
            //Car car = new Car() { Id = 5, BrandId = 2,ColorId=3,DailyPrice=111,Description="abcde",ModelYear="12.19.111" };
            //Car car1 = new Car() { Id = 1, BrandId = 2,ColorId=3,DailyPrice=111,Description="abcde",ModelYear="12.19.111" };
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetail())
            {
                Console.WriteLine(item.CarID+"/"+item.Description+"/" +"=>" +item.ColorName+"/"+item.BrandName);
            }
        }
    }
}
