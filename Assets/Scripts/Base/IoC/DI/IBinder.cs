using Base.IoC.DI.Providers;
using System;
using Base.IoC.DI.Container;

namespace Base.IoC.DI
{
    public interface IBinder
    {
        void AsInstance<T>(T instance) where T : class;

        void AsSingle<T>() where T : new();

        void ToProvider<T>(IProvider<T> provider) where T : class;

        void Bind<T>(IInternalContainer container) where T : class;

        void Bind(Type type, IInternalContainer container);

        void BindInterfaces(Type type, IInternalContainer container);

        void BindInterfaces(object instance, IInternalContainer container);
    }
}