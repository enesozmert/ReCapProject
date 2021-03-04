using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.CancellationToken
{
    public class CancellationTokenAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            var token = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext.RequestAborted;
            Task.Run(() => { invocation.Proceed(); }, token).Wait(token);
        }
    }
}
