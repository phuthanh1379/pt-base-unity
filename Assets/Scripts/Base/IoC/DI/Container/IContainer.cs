using Base.IoC.DI.Providers;
using System.Reflection;
using System;

namespace Base.IoC.DI.Container
{
    public interface IContainer
    {
        IBinder Bind<T>() where T : class;

        IBinder Bind(Type type);

        IBinder BindInterfaces(Type type);

        IBinder BindInterfaces(object instance);

        void BindSelf<T>() where T : class, new();

        T Build<T>() where T : class;

        void Release<T>() where T : class;

        T Inject<T>(T instance);

        object CreateDependency(Type contract, PropertyInfo info);
    }

    public interface IInternalContainer
    {
        void Register(System.Type type, IProvider provider);
    }
}