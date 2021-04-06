using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetAllRentalDetailDto(Expression<Func<RentalDetailDto, bool>> filter = null);
        RentalDetailDto GetRentalDetailDto(Expression<Func<RentalDetailDto, bool>> filter = null);
    }
}
