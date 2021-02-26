using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapDemoContext>, IUserDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from p in context.Customers
                             join k in context.Users on p.UserID equals k.ID
                             select new CustomerDetailDto { ID = p.ID, CompanyName = p.CompanyName, Email = k.Email, FirstName = k.FirstName, LastName = k.LastName, NickName = k.NickName, Password = k.Password };
                return result.ToList();
            }
        }
    }
}
