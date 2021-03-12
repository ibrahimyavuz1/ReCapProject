using Business.Abstact;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("The car was addded successfully.");
            }
            else
            {
                if (car.CarName.Length <= 2 && car.DailyPrice <= 0)
                {
                    Console.WriteLine("The car was not addded.Check your CarName and DailyPrice of the car!");
                }
                else if(car.CarName.Length <= 2)
                {
                    Console.WriteLine("The car was not addded.Check your CarName of the car!");
                }
                else
                {
                    Console.WriteLine("The car was not addded.Check your DailyPrice of the car!");
                }
            }
        }

        public void DeleteCar(Car car)
        {
            //Bussiness Codes...
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }

        public Car GetById(int id )
        {
            return _carDal.Get(p=>p.Id==id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id).ToList();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id).ToList();
        }

        public void UpdateCar(Car car)
        {
            //Bussiness Codes
            _carDal.Update(car);
        }
    }
}
