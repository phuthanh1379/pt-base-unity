using System.Reflection;

namespace Base.IoC.DI.Providers
{
    public class StandardProvider<T> : IProvider<T> where T : new()
    {
        private T _object;

        public bool Create(PropertyInfo info, out object instance)
        {
            var mustInject = false;
            if (_object == null)
            {
                _object = new T();
                mustInject = true;
            }

            instance = _object;
            return mustInject;
        }
    }
}