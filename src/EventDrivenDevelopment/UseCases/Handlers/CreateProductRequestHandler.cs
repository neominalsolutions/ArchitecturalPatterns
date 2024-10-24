using EventDrivenDevelopment.UseCases.Events;
using EventDrivenDevelopment.UseCases.Requests;
using MediatR;

namespace EventDrivenDevelopment.UseCases.Handlers
{
  public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, int>
  {
    private readonly IMediator mediator; // DIP

    public CreateProductRequestHandler(IMediator mediator) // DI Contructor
    {
      this.mediator = mediator;
    }

    public Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {

      Console.Out.WriteLineAsync("İstek alındı: " + request.Name);

      // sideEffect
      // logService.Log();
      // emailService.send();

      var @event = new ProductCreated(1, request.Name);
      this.mediator.Publish(@event);

      return Task.FromResult<int>(1);
    }
  }
}
