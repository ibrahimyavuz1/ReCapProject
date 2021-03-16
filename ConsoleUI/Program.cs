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
            //CarTest();
            //CustomerTest();
            RentalTest();
        }

        private static void RentalTest()
        {
            IRentalService rentalmanager = new RentalManager(new EfRentalDal());
            var result = rentalmanager.GetAll();
            if (result.IsSuccess == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Id: " + rental.Id + " Car Id: " + rental.CarId + " Customer Id: " + rental.CustomerId + " Rent Date: " + rental.RentDate + " Return Date: " + rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine("*****************************************************************");
            var result1=rentalmanager.Add(new Rental() { CarId = 4, CustomerId = 7, Id = 10, RentDate = DateTime.Now,ReturnDate=default});
            result = rentalmanager.GetAll();
            if (result1.IsSuccess == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Id: " + rental.Id + " Car Id: " + rental.CarId + " Customer Id: " + rental.CustomerId + " Rent Date: " + rental.RentDate + " Return Date: " + rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result1.Message);
            }
        }

        private static void CustomerTest()
        {
            ICustomerService customermanager = new CustomerManager(new EfCustomerDal());
            var result = customermanager.GetAll();
            if (result.IsSuccess == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("User Id " + customer.UserId + " Company Name: " + customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            customermanager.Add(new Customer() {CompanyName=null,UserId=11 });
            result = customermanager.GetAll();
            Console.WriteLine("****************************************************");
            foreach (var customer in result.Data)
            {
                Console.WriteLine("User Id " + customer.UserId + " Company Name: " + customer.CompanyName);
            }
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
