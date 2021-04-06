using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDemoContext>, ICarDal
    {
        public List<CarImageDetailDto> GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from p in context.Cars
                             join k in context.Colors on p.ColorID equals k.ID
                             join l in context.Brands on p.BrandID equals l.ID
                             join m in context.CarImages on p.ID equals m.CarID
                             select new CarImageDetailDto
                             {
                                 ID = m.ID,
                                 BrandName = k.ColorName,
                                 ColorName = l.BrandName,
                                 CarID = p.ID,
                                 DailyPrice = p.DailyPrice,
                                 Date = m.Date,
                                 Description = p.Description,
                                 ImagePath = m.ImagePath,
                                 ModelYear = p.ModelYear
                             };
                return result.Where(filter).ToList();
            }
        }
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from p in context.Cars
                             join k in context.Colors on p.ColorID equals k.ID
                             join l in context.Brands on p.BrandID equals l.ID
                             select new CarDetailDto { ID = p.ID, ColorName = k.ColorName, BrandName = l.BrandName, DailyPrice = p.DailyPrice, Description = p.Description, ModelYear = p.ModelYear };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                             join k in context.Colors on p.ColorID equals k.ID
                             join l in context.Brands on p.BrandID equals l.ID
                             select new CarDetailDto { ID = p.ID, ColorName = k.ColorName, BrandName = l.BrandName, DailyPrice = p.DailyPrice, Description = p.Description, ModelYear = p.ModelYear };
                return result.ToList();
            }
        }
    }
}
