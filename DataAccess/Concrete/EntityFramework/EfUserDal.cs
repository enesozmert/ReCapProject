using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapDemoContext>, IUserDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from p in context.Customers
                             join k in context.Users on p.UserID equals k.ID
                             select new CustomerDetailDto { ID = p.ID, CompanyName = p.CompanyName, Email = k.Email, FirstName = k.FirstName, LastName = k.LastName, NickName = k.NickName };
                return result.ToList();
            }
        }
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapDemoContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.ID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.ID
                             select new OperationClaim { ID = operationClaim.ID, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
