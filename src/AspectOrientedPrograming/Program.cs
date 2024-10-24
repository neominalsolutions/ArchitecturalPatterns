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

// Net Core �zerinden keyedScoped
builder.Services.AddKeyedScoped<IPayment, CreditCardPayment>("credit-card");
// en son yaz�lan de�er �zerinden instance ald�.
builder.Services.AddKeyedScoped<IPayment,VirtualWalletPayment>("virtual-wallet");


// IoC i�lemlerinin register s�re�lerini AutoFac paketine devretmek i�in bu kodu yazd�k.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(autoFacBuilder =>
{
  // "credit-card" anahtar de�er �zerinden hangi class tetiklenece�iniz yazd�k.
  // bu Keyed �zelli�i net core yok.
  autoFacBuilder.RegisterType<CreditCardPayment>().Keyed<IPayment>("credit-card").InstancePerLifetimeScope();

  // addScoped servis yerine InstancePerLifetimeScope method kullanarak ayn� servis registeration i�lemini sa�lad�k.

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
