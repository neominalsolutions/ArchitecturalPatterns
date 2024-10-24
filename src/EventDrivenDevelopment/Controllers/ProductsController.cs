using EventDrivenDevelopment.UseCases.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventDrivenDevelopment.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    // ProductsController ile CreateProductRequestHandler direk olarak bağlı değiller. // IMediator üzerinden DIP yaptık.

    private readonly IMediator mediator; // Mediator pattern => Kaotik uygulamalarda nesnelerin birbirleri ile iletişimi merkezi bir yapı üzerinden yönetme davranış tasarım deseni.
    // loosly coupled bir yazılım geliştirmiş olduk.

    // DI
    public ProductsController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
      var response = await this.mediator.Send(request);

      return Ok(response);
    }

  }
}
