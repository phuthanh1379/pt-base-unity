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
            var binder = InternalBind(type);
            return binder;
        }

        public IBinder BindInterfaces(Type type)
        {
            var binder = BinderProvider();
            binder.BindInterfaces(type, this);
            return binder;
        }

        public IBinder BindInterfaces(object instance)
        {
            var binder = BinderProvider();
            binder.BindInterfaces(instance, this);
            return binder;
        }

        public void BindSelf<T>() where T : class, new()
        {
            var binder = InternalBind<T>();
            binder.AsSingle<T>();
        }

        public T Build<T>() where T : class
        {
            var contract = typeof(T);
            var instance = Get(contract) as T;
            return instance;
        }

        public void Release<T>() where T : class
        {
            var type = typeof(T);
            _providers.Remove(type);
        }

        public T Inject<T>(T instance)
        {
            if (instance != null)
            {
                InternalInject(instance);
            }
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

        private IBinder InternalBind(Type type)
        {
            var binder = BinderProvider();
            binder.Bind(type, this);

            return binder;
        }

        private object Get(Type contract)
        {
            return CreateDependency(contract, null);
        }

        private void InternalInject(object instanceToFulfill)
        {
            var contract = instanceToFulfill.GetType();
            var properties = GetInjectProperties(contract);
        }

        private MemberInfo[] GetInjectProperties(Type contract)
        {
            if (!_cachedProperties.TryGetValue(contract, out var properties))
            {
                var info = Utility.SystemType.GetInjectProperties(contract, InjectAttributeType);
            }
        }
    }
}