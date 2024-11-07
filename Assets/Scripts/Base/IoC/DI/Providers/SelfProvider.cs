using System.Reflection;

namespace Base.IoC.DI.Providers
{
    public class SelfProvider<T> : IProvider<T>
    {
        private readonly T _instance;
        private bool _mustInject = true;

        public SelfProvider(T instance)
        {
            _instance = instance;
        }

        public bool Create(PropertyInfo info, out object instance)
        {
            instance = _instance;
            if (!_mustInject)
            {
                return false;
            }

            _mustInject = false;
            return true;
        }
    }
}