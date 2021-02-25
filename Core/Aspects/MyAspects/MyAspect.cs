using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.MyAspects
{
    public class MyAspect : MethodInterception
    {
        public MyAspect()
        {
            Console.WriteLine("noname");
        }
        public MyAspect(string name)
        {
            Console.WriteLine("name{0}", name);
        }
        protected override void OnAfter(IInvocation invocation)
        {
            Console.WriteLine("Çalışıyor");
        }
        protected override void OnBefore(IInvocation invocation)
        {
            Console.WriteLine("Çaşışmaya başlıyor örnekler hazırlanıyor");
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            Console.WriteLine("Bitti");
        }
        protected override void OnException(IInvocation invocation, Exception e)
        {
            Console.WriteLine("Hatayı aldın {0}", e.ToString());
        }
    }
}
