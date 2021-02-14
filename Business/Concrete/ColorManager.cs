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
    public class ColorManager : IColorService
    {
        IColorDao _colorDao;

        public ColorManager(IColorDao colorDao)
        {
            _colorDao = colorDao;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorInvalid);
            }
            _colorDao.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDao.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Color>>(_colorDao.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDao.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _colorDao.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
