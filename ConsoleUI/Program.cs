using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
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
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarId + "/" + item.BrandName + "/" + item.ColorName);
            }
        }
    }
}
