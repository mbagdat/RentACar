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
            CarManager carManager = new CarManager(new EfCarDao());
            foreach (var item in carManager.GetByDailyPrice(15,18))
            {
                Console.WriteLine(item.DailyPrice);
            }
        }
    }
}
