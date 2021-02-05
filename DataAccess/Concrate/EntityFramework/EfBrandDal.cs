using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfBrandDal:EfEntityRepositoryBase<Brand,ReCapDemoContext>,IBrandDal
    {
    }
}
