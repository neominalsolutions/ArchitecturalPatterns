using AspectOrientedPrograming.Attributes;
using AspectOrientedPrograming.Requests;
using AspectOrientedPrograming.Services;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspectOrientedPrograming.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentsController : ControllerBase
  {
    // PaymentsController ile CreditCardPayment yada VirtualPayment direk bağlamayı ara bir servis ile tetikleme işlemi yapıyorum.

    private readonly ILifetimeScope lifetimeScope;
    private readonly IServiceProvider serviceProvider;


    public PaymentsController(ILifetimeScope lifetimeScope, IServiceProvider serviceProvider)
    {
      this.lifetimeScope = lifetimeScope;
      this.serviceProvider = serviceProvider;
    }

    [HttpPost]
    public IActionResult PaymentRequest([FromBody] PaymentRequest request)
    {
      var service = this.lifetimeScope.ResolveKeyed<IPayment>(request.PaymentType);
      service.Pay(amount: request.Amount, currency: request.Currency);

      return Ok();
    }


    [HttpPost("v2")]
    [RequestAttribute] // Interception görevi görüyor.
    public IActionResult PaymentRequest2([FromBody] PaymentRequest request)
    {

      var service = this.serviceProvider.GetKeyedService<IPayment>(request.PaymentType);

      service.Pay(amount: request.Amount, currency: request.Currency);

      return Ok();
    }


  }
}
