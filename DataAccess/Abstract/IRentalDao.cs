using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDao : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
    }
}
