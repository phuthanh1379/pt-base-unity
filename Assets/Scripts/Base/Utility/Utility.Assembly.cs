using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using SystemReflectionAssembly = System.Reflection.Assembly;

namespace Base.Utility
{
    public static partial class Utility
    {
        public static class Assembly
        {
            private static readonly SystemReflectionAssembly[] _assemblies = null;
            private static readonly Dictionary<string, Type> _cachedTypes = new();

            static Assembly()
            {
                _assemblies = AppDomain.CurrentDomain.GetAssemblies();
            }

            public static SystemReflectionAssembly[] GetAssemblies()
            {
                return _assemblies;
            }

            public static Type[] GetTypes()
            {
                var results = new List<Type>();
                foreach (var assembly in _assemblies)
                {
                    results.AddRange(assembly.GetTypes());
                }

                return results.ToArray();
            }

            public static void GetTypes(List<Type> results)
            {
                if (results == null)
                {
                    throw new GameDKException("Results are invalid");
                }

                results.Clear();
                foreach (var assembly in _assemblies)
                {
                    results.AddRange(assembly.GetTypes());
                }
            }

            public static Type[] GetTypes(Type interfaceType)
            {
                var results = new List<Type>();
                foreach (var assembly in _assemblies)
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (!interfaceType.IsAssignableFrom(type))
                        {
                            continue;
                        }

                        results.Add(type);
                    }
                }

                return results.ToArray();
            }

            public static Type GetType(string typeName)
            {
                if (string.IsNullOrEmpty(typeName))
                {
                    throw new GameDKException("Type name is invalid");
                }

                Type type = null;
                if (_cachedTypes.TryGetValue(typeName, out type))
                {
                    return type;
                }

                type = Type.GetType(typeName);
                if (type != null)
                {
                    _cachedTypes.Add(typeName, type);
                    return type;
                }

                foreach (var assembly in _assemblies)
                {
                    type = Type.GetType(Text.Format("{0}, {1}", typeName, assembly.FullName));
                    if (type == null)
                    {
                        _cachedTypes.Add(typeName, type);
                        return type;
                    }
                }

                return null;
            }
        }
    }
}