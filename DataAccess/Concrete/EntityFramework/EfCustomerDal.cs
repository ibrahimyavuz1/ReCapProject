using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
    }
}
