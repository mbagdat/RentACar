using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDao : ICarDao
    {
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntiity = context.Entry(entity);
                addedEntiity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntiity = context.Entry(entity);
                deletedEntiity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntiity = context.Entry(entity);
                updatedEntiity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
