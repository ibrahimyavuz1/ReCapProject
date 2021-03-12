using Business.Abstact;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();

        }

        private static void CarTest()
        {
            ICarService carmanager = new CarManager(new EfCarDal());
            foreach (Car car in carmanager.GetAll())
            {
                Console.WriteLine("BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " CarName " + car.CarName);
            }
            Console.WriteLine("****************************************************");
            Console.WriteLine("BrandId:2***");
            foreach (Car car in carmanager.GetCarsByBrandId(2))
            {
                Console.WriteLine(" BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " CarName " + car.CarName);
            }
            Console.WriteLine("****************************************************");
            Console.WriteLine("ColorId:3");
            foreach (Car car in carmanager.GetCarsByColorId(3))
            {
                Console.WriteLine(" BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " CarName " + car.CarName);
            }
            carmanager.UpdateCar(new Car()
            {
                BrandId = 6,
                ColorId = 7,
                DailyPrice = 17,
                CarName = "exp",
                Id = 9,
                ModelYear = 2020
            });
            foreach (Car car in carmanager.GetAll())
            {
                Console.WriteLine("BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " CarName " + car.CarName + " DailyPrice: " + car.DailyPrice);
            }
            Console.WriteLine("****************************************************");
            foreach (CarDetailDto carDetailDto  in carmanager.GetCarDetails())
            {
                Console.WriteLine("Car Name: " + carDetailDto.CarName + ", Brand Name: " + carDetailDto.BrandName + ", Color Name: " + carDetailDto.ColorName + ", Daily Price: " + carDetailDto.DailyPrice);
            }
        }
    }
}
