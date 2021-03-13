using Business.Abstact;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Core.Utilities.Results;
using System.Collections.Generic;

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
            IDataResult<List<CarDetailDto>> result = carmanager.GetCarDetails();
            if (result.IsSuccess == true)
            {
                foreach (CarDetailDto carDetailDto in result.Data)
                {
                    Console.WriteLine("Car Name: " + carDetailDto.CarName + ", Brand Name: " + carDetailDto.BrandName + ", Color Name: " + carDetailDto.ColorName + ", Daily Price: " + carDetailDto.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
