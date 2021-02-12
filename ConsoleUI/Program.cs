using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;



namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());

            Console.ReadKey();
            
        }

        private static void ColorTest(ColorManager colorManager)
        {
            Console.WriteLine("*****************Mevcut Renkler****************");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk Id:{0}     Renk Adı:{1}", color.ColorId, color.ColorName);
            }

            Console.WriteLine("\n*****************Mevcut Renkler****************");
            colorManager.Add(new Color { ColorName = "Mavi" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk Id:{0}     Renk Adı:{1}", color.ColorId, color.ColorName);
            }

            Console.WriteLine("\n*****************Mevcut Renkler****************");
            colorManager.Update(new Color { ColorId = 5, ColorName = "Lacivert" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk Id:{0}     Renk Adı:{1}", color.ColorId, color.ColorName);
            }

            Console.WriteLine("\n*****************Mevcut Renkler****************");
            colorManager.Delete(new Color { ColorId = 5, ColorName = "Lacivert" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Marka Id:{0}     Marka Adı:{1}", color.ColorId, color.ColorName);
            }

           
        }

        private static void BrandTest(BrandManager brandManager)
        {
            Console.WriteLine("*****************Mevcut Markalar****************");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka Id:{0}     Marka Adı:{1}", brand.BrandId, brand.BrandName);
            }

            Console.WriteLine("\n*****************Mevcut Markalar****************");
            brandManager.Add(new Brand { BrandName = "Land-Rover" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka Id:{0}     Marka Adı:{1}", brand.BrandId, brand.BrandName);
            }

            Console.WriteLine("\n*****************Mevcut Markalar****************");
            brandManager.Update(new Brand { BrandId = 4, BrandName = "Cadillac" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka Id:{0}     Marka Adı:{1}", brand.BrandId, brand.BrandName);
            }

            Console.WriteLine("\n*****************Mevcut Markalar****************");
            brandManager.Delete(new Brand { BrandId = 4, BrandName = "Cadillac" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka Id:{0}     Marka Adı:{1}", brand.BrandId, brand.BrandName);
            }

            
        }

        private static void CarTest(CarManager carManager)
        {

            Console.WriteLine("*****************Mevcut arabalar****************");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = 2003, DailyPrice = 60000, Description = "Güzel." });
            Console.WriteLine("*****************Mevcut arabalar****************");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            carManager.Update(new Car { CarId = 5, BrandId = 3, ColorId = 3, ModelYear = 2007, DailyPrice = 60000, Description = "Güzel." });
            Console.WriteLine("*****************Mevcut arabalar****************");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            carManager.Delete(new Car { CarId = 5, BrandId = 3, ColorId = 3, ModelYear = 2007, DailyPrice = 60000, Description = "Güzel." });
            Console.WriteLine("*****************Mevcut arabalar****************");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

           
            Console.WriteLine("\n-------------BrandId--------------");
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("-------------ColorId--------------");
            foreach (var car in carManager.GetCarsByColorId(4).Data)
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }
            
        }

    }
}
