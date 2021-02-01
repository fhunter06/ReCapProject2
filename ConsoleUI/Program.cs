using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GettAll())
            {
                Console.WriteLine(car.Description+ " - Günlük Fiyatı =  " +car.DailyPrice);
            }
            
            
        }
    }
}
