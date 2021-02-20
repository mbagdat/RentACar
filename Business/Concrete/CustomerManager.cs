using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

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
