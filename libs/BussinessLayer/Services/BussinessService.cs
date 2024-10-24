using Aspect.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
  // [BenchMark]
  public class BussinessService : IBussinessService
  {
    [BenchMark]
    public void Handle()
    {
      Thread.SpinWait(100000);

      //throw new Exception("Hata");

      Console.WriteLine("Bussiness Logic"); // Bussiness Kod bloğu
    }
  }
}
