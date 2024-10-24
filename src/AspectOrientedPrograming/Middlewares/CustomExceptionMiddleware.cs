namespace AspectOrientedPrograming.Middlewares
{
  public class CustomExceptionMiddleware
  {
    private readonly RequestDelegate next;


    public CustomExceptionMiddleware(RequestDelegate next)
    {
      this.next = next;

    }

    public async Task InvokeAsync(HttpContext context)
    {

      try
      {
        await Console.Out.WriteLineAsync("Request Kısmı");

        await next(context);

        await Console.Out.WriteLineAsync("Response Kısmı");
      }
      catch (Exception ex)
      {
        await Console.Out.WriteLineAsync(ex.Message);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new { Message = ex.Message });
      }

    }
  }
}
