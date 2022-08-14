using System;
using System.Collections.Generic;
using System.Reflection;

namespace Data
{
    public class ObjectFactory
    {
        Dictionary<Type, Type> _cachedImplementedTypes = new Dictionary<Type, Type>();
        Assembly _assembly;

        public ObjectFactory(Assembly assembly)
        {
            _assembly = assembly;
        }

        public T CreateObjectFromType<T>() where T : class
        {
            Type implementationType = GetCachedType<T>();
            return Activator.CreateInstance(implementationType) as T;
        }

        private Type GetCachedType<T>()
        {
            Type baseType = typeof(T);
            if (!_cachedImplementedTypes.TryGetValue(baseType, out Type implementationType))
            {
                foreach (Type t in _assembly.GetTypes())
                {
                    if (baseType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                    {
                        _cachedImplementedTypes.Add(baseType, t);
                        return t;
                    }
                }

                throw new ArgumentException(baseType.FullName);
            }

            return implementationType;
        }
    }
}
