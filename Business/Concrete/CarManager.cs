using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDao _carDao;

        public CarManager(ICarDao carDao)
        {
            _carDao = carDao;
        }

        public IResult Add(Car car)
        {
            var context = new ValidationContext<Car>(car);
            CarValidator productValidator = new CarValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            _carDao.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDao.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Car>>(_carDao.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDao.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDao.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDao.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDao.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDao.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
