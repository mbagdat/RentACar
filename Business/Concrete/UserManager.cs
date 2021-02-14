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
    public class UserManager : IUserService
    {
        IUserDao _userDao;

        public UserManager(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2 && user.LastName.Length < 2 && user.Email.Length < 0 && user.Password.Length < 4)
            {
                return new ErrorResult(Messages.UserInvalid);
            }
            _userDao.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDao.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<User>>(_userDao.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDao.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            _userDao.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
