using Business.Abstract;
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

        public List<Color> GetAll()
        {
            return _colorDao.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDao.Get(c => c.ColorId == colorId);
        }
    }
}
