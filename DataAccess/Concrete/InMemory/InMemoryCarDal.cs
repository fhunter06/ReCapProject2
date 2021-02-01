using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
            new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, Description = "Toyota", ModelYear = 2016 },
            new Car { CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 350, Description = "Toyota", ModelYear = 2019 },
            new Car { CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 500, Description = "BMW", ModelYear = 2018 },
            new Car { CarId = 4, BrandId = 3, ColorId = 2, DailyPrice = 500, Description = "Mercedes", ModelYear = 2016 },
            new Car { CarId = 5, BrandId = 3, ColorId = 3, DailyPrice = 550, Description = "Mercedes", ModelYear = 2019 },
            new Car { CarId = 6, BrandId = 4, ColorId = 4, DailyPrice = 200, Description = "Fiat", ModelYear = 2020 },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(car => car.CarId == Id).ToList();
        }

        
        public void Update(Car car)
        {
            Car carToUpdate= _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
