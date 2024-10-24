using MediatR;

namespace EventDrivenDevelopment.UseCases.Events
{
  // Eventler dili geçmiş zaman kipinde tanımlanır.
  // ve publish methodu ile tetiklenir. INotification interface ile işaretlenir.
  public record ProductCreated(int Id,string Name):INotification;

}
