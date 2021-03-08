using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstact
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllById(int id );

        void Add(Car car);
    }
}
