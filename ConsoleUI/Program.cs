using Business.Abstract;
using Business.Concrate;
using Business.HandleException;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static ICarService _carService;
        private static IUserService _userService;
        private static IRentalService _rentalService;
        static void Main(string[] args)
        {

            string iDate = "2022-02-02";
            DateTime oDate = DateTime.Parse(iDate);
            var carImagePathNoName = AppDomain.CurrentDomain.BaseDirectory;
            //Car car1 = new Car() { BrandID = 3, ColorID = 2, DailyPrice = 2, Description = "arenault", ModelYear = 2002 };
            //Car car2 = new Car() { BrandID = 1, ColorID =2 , DailyPrice = 111, Description = "yenieklendi", ModelYear = 1992 };
            //User user1 = new User { Email = "enes1@enes2.com", FirstName = "enes2", LastName = "abc1", NickName = "enes2abc1", Password = "abc1" };
            //Rental rental = new Rental { CarID = 11, CustomerID = 1, RentDate = DateTime.Now.Date, ReturnDate = null, IsEnabled = false };
            ////Dependency injection // Ioc Container=>Ninject
            //_carService = InstanceFactory.GetInstance<ICarService>(new BusinessModule());
            //_userService = InstanceFactory.GetInstance<IUserService>(new BusinessModule());
            //_rentalService = InstanceFactory.GetInstance<IRentalService>(new BusinessModule());
            //CarAdded(car1, _carService);
            //_userService.Add(user1);
            //_rentalService.Add(rental);
            //var result = _rentalService.Add(rental);
            //if (result.Success)
            //{
            //    HandleException.Error(() => { _rentalService.Add(rental); });
            //}
            //Console.WriteLine(result.Message);
            //HandleException.Error(() => { Console.WriteLine(result.Message); });
            //IsForRent();
            //Console.WriteLine(_rentalService.IsForRent(2017).Message);
            //CarDeatails(_carService);

        }

        private static void IsForRent()
        {
            var result = _rentalService.IsForRent(20);
            if (result.Success == true)
            {
                _rentalService.IsForRent(20);
                Console.WriteLine(_rentalService.IsForRent(20).Message);
                Console.WriteLine(_rentalService.IsForRent(20).Data.ID);
            }
            else
            {
                Console.WriteLine(_rentalService.IsForRent(20).Message);
            }
        }

        private static void CarDeatails(ICarService carService)
        {
            var result = carService.GetCarDetails();
            if (result.Success == true)
            {
                //carManager.Add(car1);
                foreach (var item in carService.GetCarDetails().Data)
                {
                    Console.WriteLine(item.ID + "/" + item.DailyPrice + "/" + "=>" + item.ColorName + "/" + item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarAdded(Car car1, ICarService carService)
        {
            try
            {
                //carManager.Add(car1);
                Console.WriteLine(carService.Add(car1).Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
