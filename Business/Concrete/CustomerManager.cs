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
    public class CustomerManager : ICustomerService
    {
        ICustomerDao _customerDao;

        public CustomerManager(ICustomerDao customerDao)
        {
            _customerDao = customerDao;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 4)
            {
                return new ErrorResult(Messages.CustomerInvalid);
            }
            _customerDao.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer Customer)
        {
            _customerDao.Delete(Customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Customer>>(_customerDao.GetAll(), Messages.CustomerListed);
        }

        public IResult Update(Customer Customer)
        {
            _customerDao.Update(Customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
