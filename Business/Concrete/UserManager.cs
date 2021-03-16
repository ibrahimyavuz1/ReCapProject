using Business.Abstact;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager: IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("The User was added successfully!");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("The User was deleted successfully!");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "The Users were listed successfully!");
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id), "The User was listed successfully!");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("The User was updated successfully!");
        }
    }
}
