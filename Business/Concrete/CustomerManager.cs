using Business.Abstact;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult("The Customer was added successfully!");
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("The Customer was deleted successfully!");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), "The Customers were listed successfully!");
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.UserId == userId), "The Customer was listed successfully!");
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult("The Customer was updated successfully!");
        }
    }
}
