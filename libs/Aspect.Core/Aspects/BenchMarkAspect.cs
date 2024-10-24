using Castle.Core.Logging;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspect.Core.Aspects
{

  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
  public class BenchMarkAttribute: Attribute
  {

  }


  public class BenchMarkAspect : IInterceptor
  {
    private readonly Stopwatch sp;
    private readonly ILogger<BenchMarkAspect> logger;

    public BenchMarkAspect(ILogger<BenchMarkAspect> logger)
    {
      sp = new Stopwatch();
      this.logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {

      // çağırılan method bir attribute içeriyor mu içer miyor mu ?
      // Method için tanımlanmış bir attribute var mı
      var method = invocation.MethodInvocationTarget ?? invocation.Method;
      var attributeExist = method.GetCustomAttributes(typeof(BenchMarkAttribute), true).Any();

      if (!attributeExist)
        invocation.Proceed(); // method üzerinde attribute yoksa iş akışına devam et. varsa aşağıdaki logic üzerinden süreci devam ettir.
      else
      {
        try
        {
          // OnBefore => Methoda girmeden önce
          sp.Start();
          this.logger.LogInformation($"OnBefore");

          invocation.Proceed(); // methoda geç süreci devam ettir.

          // OnAfter => Method çalıştıktan sonra

          this.logger.LogInformation($"OnAfter");
        }
        catch (Exception ex)
        {
          // OnException => Hata durumunda hatayı yakalama ve loglama
          sp.Stop();
          this.logger.LogInformation($"OnException => {ex.Message}");
        }
        finally
        {
          // OnComplete
          sp.Stop();
          this.logger.LogInformation($"OnComplete {sp.ElapsedMilliseconds} ms ");
        }
      }
     
    }
  }
}
