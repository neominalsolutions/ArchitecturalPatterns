using EventDrivenDevelopment.UseCases.Events;
using MediatR;

namespace EventDrivenDevelopment.UseCases.Handlers
{
  public class ProductCreatedLogHandler : INotificationHandler<ProductCreated>
  {
    public Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
      Console.Out.WriteLineAsync($"{notification.Name} isimli ürün loglandı");

      return Task.CompletedTask;
    }
  }
}
