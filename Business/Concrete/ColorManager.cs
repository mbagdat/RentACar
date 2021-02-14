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

        public void Add(Color color)
        {
            _colorDao.Add(color);
        }

        public void Delete(Color color)
        {
            _colorDao.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDao.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDao.Get(c => c.ColorId == colorId);
        }

        public void Update(Color color)
        {
            _colorDao.Update(color);
        }
    }
}
