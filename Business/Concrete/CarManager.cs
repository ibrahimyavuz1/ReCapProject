using Business.Abstact;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("The car was addded successfully.");
            }
            else
            {
                if (car.Description.Length <= 2 && car.DailyPrice <= 0)
                {
                    Console.WriteLine("The car was not addded.Check your Description and DailyPrice of the car!");
                }
                else if(car.Description.Length <= 2)
                {
                    Console.WriteLine("The car was not addded.Check your Description of the car!");
                }
                else
                {
                    Console.WriteLine("The car was not addded.Check your DailyPrice of the car!");
                }
            }
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }

        public List<Car> GetAllById(int id )
        {
            return _carDal.GetAll(p=>p.Id==id).ToList();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id).ToList();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id).ToList();
        }
    }
}
