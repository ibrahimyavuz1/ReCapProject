using Business.Abstact;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result.Count>0)
            {
                return new ErrorResult("The Rental was not added successfully! Because the car have been still rental.");
            }
            _rentalDal.Add(rental);
            return new SuccessResult("The Rental was added successfully!");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("The Rental was deleted successfully!");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),"The Rentals were listed successfully!");
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id),"The Rental was listed successfully");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("The Rental was updated successfully!");
        }
    }
}
