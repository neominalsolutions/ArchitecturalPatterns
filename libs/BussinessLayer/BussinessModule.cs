using Aspect.Core.Aspects;
using Autofac;
using Autofac.Extras.DynamicProxy;
using BussinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
  public class BussinessModule:Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<BussinessService>().As<IBussinessService>().AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(BenchMarkAspect));

      base.Load(builder);
    }
  }
}
