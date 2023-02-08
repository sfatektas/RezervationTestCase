
using Autofac;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.Bussines.Services;
using RezervationTestCase.DataAccess.Interfaces;
using RezervationTestCase.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.DependencyResolvers.AutoFac
{
    public class AutofacBussinesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Uow>().As<IUow>();
            builder.RegisterType<RoomService>().As<IRoomService>();
            
        }

    }
}
