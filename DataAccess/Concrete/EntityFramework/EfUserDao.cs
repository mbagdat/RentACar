using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDao : EfEntityRepositoryBase<User, RentACarContext>, IUserDao
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.UserId equals customer.UserId
                             select new UserDetailDto
                             {
                                 UserId = user.UserId,
                                 CompanyName = customer.CompanyName
                             };
                return result.ToList();

            }

        }
    }
}
