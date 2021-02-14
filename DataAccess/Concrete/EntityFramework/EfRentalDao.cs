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
    public class EfRentalDao : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDao
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId


                             from user in context.Users
                             join customer in context.Customers on user.UserId equals customer.UserId

                             from carr in context.Cars
                             join brand in context.Brands on carr.BrandId equals brand.BrandId
                             join color in context.Colors on carr.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 CarId = car.CarId,
                                 CompanyName = customer.CompanyName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
