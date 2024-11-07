using System;

namespace Core.Factory.GameObject
{
    public interface IStaticGameObjectFactory : IFactory
    {
        T BuildSharedGameObject<T>(Type type);
        T BuildSharedGameObject<T>();
        T BuildUniqueGameObject<T>();
        T BuildUniqueGameObject<T>(string typeName) where T : class;
    }
}