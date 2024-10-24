using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC => Nesne Instancelarýný merkezi bir þekilde Framework'ün yönetimine devretme olayý.
// Mediator servislerini Net Core API uygulamasýna tanýmlamamýz lazým.  IoC
// ServiceColletion üzerinden servisleri yöneten ServiceProvider sýnýfý ise IoC Container
builder.Services.AddMediatR(opt =>
{
  // Reflection ile assembly içindeki tüm handlerlarý IoC Container'a register et.
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
