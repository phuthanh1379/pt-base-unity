using System;
using System.Reflection;

namespace Base.IoC.DI.Providers
{
    public class DefaultProvider : IProvider
    {
        private object _object;
        private readonly Type _type;

        public DefaultProvider(Type type)
        {
            _type = type;
        }

        public bool Create(PropertyInfo info, out object instance)
        {
            var mustInject = false;
            if (_object == null)
            {
                _object = Activator.CreateInstance(_type);
                mustInject = true;
            }

            instance = _object;
            return mustInject;
        }
    }
}