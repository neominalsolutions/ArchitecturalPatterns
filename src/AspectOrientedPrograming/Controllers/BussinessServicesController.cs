using BussinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspectOrientedPrograming.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BussinessServicesController : ControllerBase
  {
    private readonly IBussinessService bussinessService;

    public BussinessServicesController(IBussinessService bussinessService)
    {
      this.bussinessService = bussinessService;
    }

    [HttpPost]
    public IActionResult Request()
    {
     

      this.bussinessService.Handle();

      return Ok();
    }

  }
}
