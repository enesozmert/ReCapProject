using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDemoContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from p in context.Customers
                             join k in context.Users on p.UserID equals k.ID
                             select new CustomerDetailDto { ID = p.ID, CompanyName = p.CompanyName, Email = k.Email, FirstName = k.FirstName, LastName = k.LastName, NickName = k.NickName };
                return result.ToList();
            }
        }
    }
}
