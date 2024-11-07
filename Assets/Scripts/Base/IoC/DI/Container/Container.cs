using Base.IoC.DI.Providers;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace Base.IoC.DI.Container
{
    public sealed class Container : IContainer, IInternalContainer
    {
        private static readonly Type InjectAttributeType = typeof(InjectAttribute);
        private readonly Dictionary<Type, MemberInfo[]> _cachedProperties;
        private readonly IProviderContainer _providers;
        private readonly string _name;
        private readonly IContainer _fallbackContainer;

        public Container(string name)
        {
            _name = name;
            _providers = ProviderBehaviour();
            _cachedProperties = new Dictionary<Type, MemberInfo[]>();
        }

        public Container(string name, IContainer fallbackContainer)
        {
            _name = name;
            _providers = ProviderBehaviour();
            _cachedProperties = new Dictionary<Type, MemberInfo[]>();
            _fallbackContainer = fallbackContainer;
        }

        public IBinder Bind<T>() where T : class
        {
            var binder = InternalBind<T>();
            return binder;
        }

        public IBinder Bind(Type type)
        {
            throw new NotImplementedException();
        }

        public IBinder BindInterfaces(Type type)
        {
            throw new NotImplementedException();
        }

        public IBinder BindInterfaces(object instance)
        {
            throw new NotImplementedException();
        }

        public void BindSelf<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T Build<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Release<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T Inject<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public object CreateDependency(Type contract, PropertyInfo info)
        {
            throw new NotImplementedException();
        }

        public void Register(Type type, IProvider provider)
        {
            throw new NotImplementedException();
        }

        private IProviderContainer ProviderBehaviour()
        {
            return new ProviderContainer();
        }

        private IBinder BinderProvider() => new Binder();

        private IBinder InternalBind<T>() where T : class
        {
            var binder = BinderProvider();
            binder.Bind<T>(this);

            return binder;
        }
    }
}