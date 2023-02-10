using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using RezervationTestCase.Bussines.DependencyResolvers;
using RezervationTestCase.Bussines.DependencyResolvers.AutoFac;
using RezervationTestCase.UI.Models;
using RezervationTestCase.UI.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.DependencyExtension(builder.Configuration.GetConnectionString("LocalDb"));

            //Autofac

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBussinesModule());
        builder.RegisterType<BookingSearchModelValidator>().As<IValidator<BookingSearchModel>>();
    });


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
