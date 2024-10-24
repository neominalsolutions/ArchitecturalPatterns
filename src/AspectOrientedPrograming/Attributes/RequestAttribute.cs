using Microsoft.AspNetCore.Mvc.Filters;

namespace AspectOrientedPrograming.Attributes
{
  public class RequestAttribute:ActionFilterAttribute
  {

    public override void OnActionExecuting(ActionExecutingContext context)
    {
      // Before
      Console.WriteLine("Controller Action Request Öncesi");
      base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
      // After
      Console.WriteLine("Controller Action Request Sonrası");
      base.OnActionExecuted(context);
    }
  }
}
