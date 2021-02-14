using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDao _brandDao;

        public BrandManager(IBrandDao brandDao)
        {
            _brandDao = brandDao;
        }

        public void Add(Brand brand)
        {
            _brandDao.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDao.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDao.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDao.Get(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            _brandDao.Update(brand);
        }
    }
}
