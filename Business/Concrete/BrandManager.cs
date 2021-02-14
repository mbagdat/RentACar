using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
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

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 3)
            {
                return new ErrorResult(Messages.BrandAdded);
            }
            _brandDao.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDao.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Brand>>(_brandDao.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDao.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDao.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
