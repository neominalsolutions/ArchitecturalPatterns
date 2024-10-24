using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC => Nesne Instancelar�n� merkezi bir �ekilde Framework'�n y�netimine devretme olay�.
// Mediator servislerini Net Core API uygulamas�na tan�mlamam�z laz�m.  IoC
// ServiceColletion �zerinden servisleri y�neten ServiceProvider s�n�f� ise IoC Container
builder.Services.AddMediatR(opt =>
{
  // Reflection ile assembly i�indeki t�m handlerlar� IoC Container'a register et.
  opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
