using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDao _rentalDao;

        public RentalManager(IRentalDao rentalDao)
        {
            _rentalDao = rentalDao;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate > DateTime.Now && rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalCanNotAdded);
            }
            return new SuccessResult(Messages.RentalRentable);
        }


        public IDataResult<List<Rental>> GetAll()
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDao.GetAll(), Messages.CustomerListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
