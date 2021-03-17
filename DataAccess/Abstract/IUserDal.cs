using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<CustomerDetailDto> GetCustomerDetails();
        List<OperationClaim> GetClaims(User user);
    }
}
