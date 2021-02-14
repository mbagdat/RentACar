using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDao : ICarDao
    {
        List<Car> _car;
        public InMemoryCarDao()
        {
            _car = new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=175,ModelYear="2018",Description="Şirketlerin sunduğu ilave hizmetler bazen müsait olmayabileceği için rezerve ettiğiniz ilave hizmetleri alamayabilirsiniz. Ayrıca burada belirtilen fiyatların araç kiralama noktasında ödeyeceğiniz fiyatla aynı olmasını da garanti edemeyiz.İhtiyacınız olan başka bir şey var mı? Taleplerinizi mümkün olduğunca araç kiralama şirketine ileteceğiz."},
                new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=275,ModelYear="2019",Description="Şirketlerin sunduğu ilave hizmetler bazen müsait olmayabileceği için rezerve ettiğiniz ilave hizmetleri alamayabilirsiniz. Ayrıca burada belirtilen fiyatların araç kiralama noktasında ödeyeceğiniz fiyatla aynı olmasını da garanti edemeyiz.İhtiyacınız olan başka bir şey var mı? Taleplerinizi mümkün olduğunca araç kiralama şirketine ileteceğiz."},
                new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=375,ModelYear="2020",Description="Şirketlerin sunduğu ilave hizmetler bazen müsait olmayabileceği için rezerve ettiğiniz ilave hizmetleri alamayabilirsiniz. Ayrıca burada belirtilen fiyatların araç kiralama noktasında ödeyeceğiniz fiyatla aynı olmasını da garanti edemeyiz.İhtiyacınız olan başka bir şey var mı? Taleplerinizi mümkün olduğunca araç kiralama şirketine ileteceğiz."},
                new Car{CarId=4,BrandId=4,ColorId=4,DailyPrice=475,ModelYear="2021",Description="Şirketlerin sunduğu ilave hizmetler bazen müsait olmayabileceği için rezerve ettiğiniz ilave hizmetleri alamayabilirsiniz. Ayrıca burada belirtilen fiyatların araç kiralama noktasında ödeyeceğiniz fiyatla aynı olmasını da garanti edemeyiz.İhtiyacınız olan başka bir şey var mı? Taleplerinizi mümkün olduğunca araç kiralama şirketine ileteceğiz."},
                new Car{CarId=5,BrandId=5,ColorId=5,DailyPrice=575,ModelYear="2021",Description="Şirketlerin sunduğu ilave hizmetler bazen müsait olmayabileceği için rezerve ettiğiniz ilave hizmetleri alamayabilirsiniz. Ayrıca burada belirtilen fiyatların araç kiralama noktasında ödeyeceğiniz fiyatla aynı olmasını da garanti edemeyiz.İhtiyacınız olan başka bir şey var mı? Taleplerinizi mümkün olduğunca araç kiralama şirketine ileteceğiz."},
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _car.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
