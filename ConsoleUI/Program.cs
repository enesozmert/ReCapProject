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
            Car car1 = new Car() { BrandID = 3, ColorID = 2, DailyPrice = 2, Description = "bcdea", ModelYear = 1990 };
            //Car car2 = new Car() { BrandID = 1, ColorID =2 , DailyPrice = 111, Description = "yenieklendi", ModelYear = 1992 };
            User user1 = new User { Email = "enes1@enes2.com", FirstName = "enes2", LastName = "abc1", NickName = "enes2abc1", Password = "abc1" };
            //
            string iDate = "2022-05-05";
            DateTime oDate = DateTime.Parse(iDate);
            //
            Rental rental = new Rental { CarID = 13, CustomerID = 1002, RentDate = DateTime.Now.Date, ReturnDate = oDate, IsEnabled = true };
            CarManager carManager = new CarManager(new EfCarDal());
            //CarAdded(car1, carManager);
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(user1);
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Console.WriteLine(rentalManager.Add(rental).Message);
            var result = rentalManager.IsForRent(20);
            if (result.Success == true)
            {
                rentalManager.IsForRent(20);
                Console.WriteLine(rentalManager.IsForRent(20).Message);
                Console.WriteLine(rentalManager.IsForRent(20).Data.ID);
            }
            else
            {
                Console.WriteLine(rentalManager.IsForRent(20).Message);
            }

            //rentalManager.IsForRent(1);
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
