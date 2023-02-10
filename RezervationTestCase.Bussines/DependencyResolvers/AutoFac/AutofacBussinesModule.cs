
using Autofac;
using FluentValidation;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.Bussines.Services;
using RezervationTestCase.Bussines.Validator.FluentValidation;
using RezervationTestCase.DataAccess.Interfaces;
using RezervationTestCase.DataAccess.UnitOfWork;
using RezervationTestCase.Dtos.BookingDtos;
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
            builder.RegisterType<BookingServices>().As<IBookingService>();
            builder.RegisterType<BookingCreateDtoValidator>().As<IValidator<BookingCreateDto>>();
        }

    }
}
