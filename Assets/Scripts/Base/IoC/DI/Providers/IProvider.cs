using System.Reflection;

namespace Base.IoC.DI.Providers
{
    public interface IProvider
    {
        bool Create(PropertyInfo info, out object instance);
    }

    public interface IProvider<T> : IProvider { }
}