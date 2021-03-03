using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();

            //Test2();

            //Ödev10Test();

            

        }

        private static void Ödev10Test()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(new User
            {
                Id = 1,
                FirstName = "Hasan",
                LastName = "Çifçi",
                Email = "hhasancifci@gmail.com",
                //Password = "1234"
            });

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer
            {
                Id = 1,
                UserId = 1,
                CompanyName = "HECE YAZILIM"
            });

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2020, 02, 22),
                ReturnDate = new DateTime(2020, 02, 28),
            });
        }

        private static void Test2()
        {
            //CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetCarDetail())
            //{
            //    Console.WriteLine(car.Description + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
            //}
        }

        private static void Test1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            colorManager.Add(new Color { Id = 1, ColorName = "Yeşil" });

            brandManager.Add(new Brand { Id = 1, BrandName = "Opel" });

            carManager.Add(new Car { Id = 1, ColorId = 1, BrandId = 1, ModelYear = 2015, DailyPrice = 350, Description = "Opel Kiralama Bedeli" });


            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);              
            //}
        }
    }
}
