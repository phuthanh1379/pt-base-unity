using System;
using Base.IoC.DI.Providers;

namespace Base.IoC.DI.Container
{
    public class Binder : IBinder
    {
        private IInternalContainer _container;
        private Type _interfaceType;
        private readonly Type _initializeType = typeof(IInitialize);

        public void AsInstance<T>(T instance) where T : class
        {
            _container.Register(_interfaceType, new SelfProvider<T>(instance));
        }

        public void AsSingle<T>() where T : new()
        {
            _container.Register(_interfaceType, new StandardProvider<T>());
        }

        public void ToProvider<T>(IProvider<T> provider) where T : class
        {
            _container.Register(_interfaceType, provider);
        }

        public void Bind<T>(IInternalContainer container) where T : class
        {
            _container = container;
            _interfaceType = typeof(T);
        }

        public void Bind(Type type, IInternalContainer container)
        {
            _container = container;
            _interfaceType = type;
        }

        public void BindInterfaces(Type type, IInternalContainer container)
        {
            _container = container;
            var interfaces = type.GetInterfaces();

            foreach (var @interface in interfaces)
            {
                if (@interface == _initializeType)
                {
                    continue;
                }

                container.Register(@interface, new DefaultProvider(type));
            }
        }

        public void BindInterfaces(object instance, IInternalContainer container)
        {
            _container = container;
            var type = instance.GetType();
            var interfaces = type.GetInterfaces();

            foreach (var @interface in interfaces)
            {
                if (@interface == _initializeType)
                {
                    continue;
                }

                container.Register(@interface, new InstanceProvider(instance, type));
            }
        }
    }
}