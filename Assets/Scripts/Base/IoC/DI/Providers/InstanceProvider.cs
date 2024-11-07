using System;
using System.Reflection;

namespace Base.IoC.DI.Providers
{
    public class InstanceProvider : IProvider
    {
        private readonly object _object;
        private bool _mustInject = true;

        public InstanceProvider(object instance, Type type)
        {
            _object = instance;
        }

        public bool Create(PropertyInfo info, out object instance)
        {
            var mustInject = _mustInject;
            if (_mustInject)
            {
                _mustInject = false;
            }

            instance = _object;
            return mustInject;
        }
    }
}