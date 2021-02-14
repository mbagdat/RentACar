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
            CarTest();
            //BrandTest();
            //ColorTest();
            Console.WriteLine("----------------------------------------------");

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDao());
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDao());
            //carManager.Add(new Car()
            //{
            //    CarId = 4,
            //    BrandId = 5,
            //    ColorId = 1,
            //    DailyPrice = 123,
            //    Description = "sfdsfdsf",
            //    ModelYear = "1968"
            //});
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CarId + "/" + item.BrandName + "/" + item.ColorName + "/" + item.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }






        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDao());
            colorManager.Add(new Color()
            {
                ColorId = 7,
                ColorName = "Turuncu"
            });
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.ColorName);
            }
        }
    }
}
