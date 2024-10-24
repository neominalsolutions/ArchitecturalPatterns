using Aspect.Core.Aspects;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspect.Core
{
  public class AspectModule:Module
  {
    protected override void Load(ContainerBuilder builder) // IoC Container
    {

      // Ne kadaar Aspect varsa hepsini IoC register ediyoruz.
      builder.RegisterType<BenchMarkAspect>();

      base.Load(builder);
    }
  }
}
