using Business.Abstact;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Abstract;
using System;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carmanager = new CarManager(new EfCarDal());
            foreach (Car car in carmanager.GetAll())
            {
                Console.WriteLine("BrandId: "+car.BrandId+" ColorId: "+ car.ColorId+" Description "+ car.Description);
            }
            Console.WriteLine("****************************************************");
            Console.WriteLine("BrandId:2***");
            foreach (Car car in carmanager.GetCarsByBrandId(2))
            {
                Console.WriteLine(" BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Description " + car.Description);
            }
            Console.WriteLine("****************************************************");
            Console.WriteLine("ColorId:3");
            foreach (Car car in carmanager.GetCarsByColorId(3))
            {
                Console.WriteLine(" BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Description " + car.Description);
            }
            carmanager.AddCar(new Car()
            {
                BrandId=6,
                ColorId=7,
                DailyPrice=14,
                Description="exp",
                Id=9,
                ModelYear=2020
            });
            foreach (Car car in carmanager.GetAll())
            {
                Console.WriteLine("BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Description " + car.Description);
            }
            Console.WriteLine("****************************************************");

        }
    }
}
