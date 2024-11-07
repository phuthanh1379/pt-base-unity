using Base.IoC.DI.Providers;
using System;

namespace Base.IoC.DI.Container
{
    public interface IProviderContainer
    {
        void Remove(Type type);
        bool Retrieve(Type contract, out IProvider provider);
        void Register(Type type, IProvider provider);
    }
}