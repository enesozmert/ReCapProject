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
            Car car1 = new Car() { BrandID = 3, ColorID = 2, DailyPrice = 2, Description = "bcde", ModelYear = 1990 };
            //Car car2 = new Car() { BrandID = 1, ColorID =2 , DailyPrice = 111, Description = "yenieklendi", ModelYear = 1992 };
            User user1 = new User { Email = "enes1@enes1.com", FirstName = "enes1", LastName = "abc", NickName = "enes1abc", Password = "abc" };
            //
            Rental rental = new Rental { CarID=11,CustomerID=1,RentDate=DateTime.Now.Date,ReturnDate=null,IsEnabled=false};
            CarManager carManager = new CarManager(new EfCarDal());
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user1);
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add()
            CarAdded(car1, carManager);
            //CarDeatails(carManager);

        }

        private static void CarDeatails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                //carManager.Add(car1);
                foreach (var item in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(item.ID + "/" + item.DailyPrice + "/" + "=>" + item.ColorName + "/" + item.BrandName);
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
                //carManager.Add(car1);
                Console.WriteLine(carManager.Add(car1).Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
