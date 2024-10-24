using EventDrivenDevelopment.UseCases.Events;
using MediatR;

namespace EventDrivenDevelopment.UseCases.Handlers
{
  // Single Responsibity Prensibini uyguluyor.
  public class ProductCreatedNotificationHandler : INotificationHandler<ProductCreated>
  {
    public Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
      Console.Out.WriteLineAsync($"{notification.Name} ürünü için email gönderildi");

      return Task.CompletedTask;
    }
  }
}
