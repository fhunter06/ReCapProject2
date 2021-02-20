using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {

            var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name).
                GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttribute.AddRange(methodAttributes);
            return classAttribute.OrderBy(x => x.Priority).ToArray();
        }
    }

}
