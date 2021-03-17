﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDemoContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentedCarDto(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from p in context.Rentals
                             join k in context.Customers on p.CustomerID equals k.ID
                             join t in context.Cars on p.CarID equals t.ID
                             join l in context.Brands on t.BrandID equals l.ID
                             join m in context.Users on k.UserID equals m.ID
                             select new RentalDetailDto { ID = p.ID, BrandName = l.BrandName, CustomerID = p.CustomerID, FullName = m.FirstName + m.LastName, RentDate = p.RentDate, ReturnDate = p.ReturnDate };
                return result.ToList();

            }
        }
    }
}
