using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rentals, CarDatabaseContext>, IRentalsDal
    {
        public List<RentalsDetailDto> GetRentalDetails(Expression<Func<Rentals, bool>> filter = null)
        {

            using (CarDatabaseContext context = new CarDatabaseContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join cus in context.Customers
                             on re.CustomerId equals cus.Id
                             join us in context.Users
                             on cus.UserId equals us.Id
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             select new RentalsDetailDto
                             {
                                 Id = re.Id,
                                 CarName = br.BrandName,
                                 CustomerName = cus.CompanyName,
                                 CarId = ca.CarId,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = us.FirstName + " " + us.LastName
                             };

                return result.ToList();

            }
        }
    }
}

