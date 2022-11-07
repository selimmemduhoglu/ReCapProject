using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car{ Id=1, BrandId=1, ColorId=1, ModelYear="2021", DailyPrice=2000000, Description="bmw" },
                new Car{ Id=2, BrandId=2, ColorId=2, ModelYear="2022", DailyPrice=4000000, Description="audi" },
                new Car{ Id=3, BrandId=3, ColorId=3, ModelYear="2020", DailyPrice=3000000, Description="mercedes" }
            };
        }
        public void Add(Car car)
        {
           _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete= _car.SingleOrDefault(p=>p.Id==car.Id);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAllByCategory(int brandId)
        {
            return _car.Where(p=>p.BrandId==brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Id = car.Id;
        }
    }
}
