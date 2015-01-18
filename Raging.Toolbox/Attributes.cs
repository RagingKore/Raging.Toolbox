using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Raging.Toolbox
{
    /// <summary>A helper class that returns a given attribute from a decorated class.</summary>
    /// <tparam name="TDecorated">Type of the decorated class.</tparam>
    /// <remarks>Sergio Silveira, 12-12-2014.</remarks>
    public static class Attributes<TDecorated>
    {
        private static readonly ConcurrentDictionary<Type, Attribute> Cache = new ConcurrentDictionary<Type, Attribute>();

        /// <summary>Gets the attibute it it exists.</summary>
        /// <tparam name="TAttribute">Type of the attribute.</tparam>
        /// <returns>A TAttribute.</returns>
        public static TAttribute Get<TAttribute>()
            where TAttribute : Attribute
        {
            var decoratedType = typeof(TDecorated);
            var attributeType = typeof(TAttribute);

            var attribute = decoratedType
                .GetCustomAttributes(attributeType, true)
                .FirstOrDefault() as TAttribute;

            if(attribute != null)
                return Cache.GetOrAdd(decoratedType, attribute) as TAttribute;

            return null;
        }

        public static void ClearCache()
        {
            Cache.Clear();
        }
    }

    /// <summary>A helper class that returns a given attribute from a decorated class.</summary>
    /// <remarks>Sergio Silveira, 12-12-2014.</remarks>
    public static class Attributes
    {
        private static readonly ConcurrentDictionary<Type, Attribute> Cache = new ConcurrentDictionary<Type, Attribute>();

        /// <summary>Gets the attribute if it exists.</summary>
        /// <param name="decoratedType">Type of the decorated object.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns>A TAttribute.</returns>
        public static Attribute Get(Type decoratedType, Type attributeType)
        {
            if(attributeType != typeof(Attribute))
            {
                throw new ArgumentException();
            }

            var attribute = decoratedType
                .GetCustomAttributes(attributeType, true)
                .FirstOrDefault() as Attribute;

            if(attribute != null)
                return Cache.GetOrAdd(decoratedType, attribute);

            return null;
        }

        public static void ClearCache()
        {
            Cache.Clear();
        }
    }
}