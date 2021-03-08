using Business.Abstact;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Abstract;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carmanager = new CarManager(new InMemoryCarDal());
            foreach (Car car in carmanager.GetAll())
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
