using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,ReCapDemoContext>,ICarDal
    {
    }
}
