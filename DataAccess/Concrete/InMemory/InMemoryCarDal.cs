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
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId=1,ColorId=6,DailyPrice=12000,Description="Good",ModelYear=1999,Id=1 },
                new Car{BrandId=1,ColorId=7,DailyPrice=1200000,Description="Expensive",ModelYear=2010,Id=2 },
                new Car{BrandId=1,ColorId=4,DailyPrice=14000,Description="Good",ModelYear=1990,Id=3},
                new Car{BrandId=2,ColorId=3,DailyPrice=6,Description="Cheap",ModelYear=1992,Id=4},
                new Car{BrandId=2,ColorId=6,DailyPrice=1684,Description="Cheap",ModelYear=1981,Id=5 },
                new Car{BrandId=3,ColorId=1,DailyPrice=18556464,Description="Expensive",ModelYear=2019,Id=6 }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(p => p.Id == car.Id);
            carToUpdate = car;
        }
    }
}
