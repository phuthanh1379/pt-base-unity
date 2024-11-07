using Base.IoC.DI.Providers;
using System.Collections.Generic;
using System;

namespace Base.IoC.DI.Container
{
    public sealed class ProviderContainer : IProviderContainer
    {
        private readonly Dictionary<Type, IProvider> _providers = new();

        public void Remove(Type type)
        {
            _providers.Remove(type);
        }

        public bool Retrieve(Type contract, out IProvider provider)
        {
            return _providers.TryGetValue(contract, out provider);
        }

        public void Register(Type type, IProvider provider)
        {
            _providers[type] = provider;
        }
    }
}