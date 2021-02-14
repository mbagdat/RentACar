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
    class RentalManager : IRentalService
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
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
