using Aspect.Core;
using AspectOrientedPrograming.Middlewares;
using AspectOrientedPrograming.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BussinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Net Core üzerinden keyedScoped
builder.Services.AddKeyedScoped<IPayment, CreditCardPayment>("credit-card");
// en son yazýlan deðer üzerinden instance aldý.
builder.Services.AddKeyedScoped<IPayment,VirtualWalletPayment>("virtual-wallet");


// IoC iþlemlerinin register süreçlerini AutoFac paketine devretmek için bu kodu yazdýk.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(autoFacBuilder =>
{
  // "credit-card" anahtar deðer üzerinden hangi class tetikleneceðiniz yazdýk.
  // bu Keyed özelliði net core yok.
  autoFacBuilder.RegisterType<CreditCardPayment>().Keyed<IPayment>("credit-card").InstancePerLifetimeScope();

  // addScoped servis yerine InstancePerLifetimeScope method kullanarak ayný servis registeration iþlemini saðladýk.

  autoFacBuilder.RegisterType<VirtualWalletPayment>().Keyed<IPayment>("virtual-wallet").InstancePerLifetimeScope(); ;


  // module Net Core API uygulamama register ettik.
  autoFacBuilder.RegisterModule(new AspectModule());
  autoFacBuilder.RegisterModule(new BussinessModule());

});


var app = builder.Build();

// middlewares

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<CustomExceptionMiddleware>();

app.Run();
