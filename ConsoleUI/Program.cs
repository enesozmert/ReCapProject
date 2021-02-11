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
            //Car car1 = new Car() { BrandID = 3, ColorID = 2, DailyPrice = 2, Description = "yeni", ModelYear = 1991 };
            //Car car2 = new Car() { BrandID = 1, ColorID =2 , DailyPrice = 111, Description = "yenieklendi", ModelYear = 1992 };
            //carManager.Add(new Car {ColorID=3,BrandID=2,DailyPrice=15,Description="enes5",ModelYear=1999 });
            CarManager carManager = new CarManager(new EfCarDal());
            //CarAdded(car1, carManager);
            CarDeatails(carManager);

        }

        private static void CarDeatails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                //carManager.Add(car1);
                foreach (var item in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(item.CarID + "/" + item.DailyPrice + "/" + "=>" + item.ColorName + "/" + item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarAdded(Car car1, CarManager carManager)
        {
            try
            {
                carManager.Add(car1);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
