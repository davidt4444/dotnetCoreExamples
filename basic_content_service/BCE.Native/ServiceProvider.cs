using System;
using System.Collections.Generic;

namespace BCE.Native
{
    // A simple implementation of IServiceProvider
    public class SimpleServiceProvider : IServiceProvider
    {
        private readonly Dictionary<Type, Func<object>> _services = new Dictionary<Type, Func<object>>();

        public void RegisterService<T>(Func<T> serviceFactory) where T : class
        {
            _services[typeof(T)] = () => serviceFactory();
        }

        public object GetService(Type serviceType)
        {
            if (_services.TryGetValue(serviceType, out Func<object> factory))
            {
                return factory();
            }
            return null;
        }
    }
}