using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDao : IEntityRepository<User>
    {
        List<UserDetailDto> GetUserDetails();
    }
}
