﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,ReCapDemoContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDemoContext context =new ReCapDemoContext())
            {
                var result = from p in context.Cars
                             join k in context.Colors on p.ColorID equals k.ID
                             join l in context.Brands on p.BrandID equals l.ID
                             select new CarDetailDto { ID = p.ID, ColorName = k.ColorName, BrandName = l.BrandName, DailyPrice = p.DailyPrice, Description = p.Description, ModelYear = p.ModelYear };
                return result.ToList();
            }
        }
    }
}