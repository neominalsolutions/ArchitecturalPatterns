using MediatR;

namespace EventDrivenDevelopment.UseCases.Requests
{
  // isimlendirirken emir kipi kullan
  public record CreateProductRequest(string Name, decimal Price, int Stock):IRequest<int>;

  //public record CreateProductRequest:IRequest
  //{
  //      public string Name { get; init; }

  //      public CreateProductRequest(string name)
  //      {
  //        Name = name;
  //      }
  //}

}
