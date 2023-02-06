using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using RezervationTestCase.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.DependencyResolvers
{
    public static class DependencyInjection
    {
        public static void DependencyExtension(this IServiceCollection service ,string connectionString)
        {
            service.AddDbContext<TestCaseDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
