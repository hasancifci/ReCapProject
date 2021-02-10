using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.Description + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice );
            }
        }

        private static void Test1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            colorManager.Add(new Color { Id = 4, ColorName = "Yeşil" });

            brandManager.Add(new Brand { Id = 5, BrandName = "Opel" });

            carManager.Add(new Car { Id = 7, ColorId = 4, BrandId = 5, ModelYear = 2015, DailyPrice = 350, Description = "Opel Kiralama Bedeli" });


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
