using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarService>().To<CarManager>();
            Bind<ICarDal>().To<EfCarDal>();

            Bind<IRentalService>().To<RentalManager>();
            Bind<IRentalDal>().To<EfRentalDal>();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();
        }
    }
}
