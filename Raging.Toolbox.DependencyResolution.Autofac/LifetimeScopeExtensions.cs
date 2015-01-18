using System;
using System.Collections.Generic;
using Autofac;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.DependencyResolution.Autofac
{
    public static class LifetimeScopeExtensions
    {
        /// <summary>
        ///     Enumerates all resolved service types in this collection.
        /// </summary>
        /// <tparam name="TService">Type of the service.</tparam>
        /// <param name="container">The container to act on.</param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all resolved service types in this collection.
        /// </returns>
        public static IEnumerable<TService> ResolveAll<TService>(this ILifetimeScope container)
            where TService : class
        {
            return container.Resolve<IEnumerable<TService>>().EmptyIfNull();
        }

        /// <summary>
        ///     Enumerates all resolved service types in this collection.
        /// </summary>
        /// <param name="container">The container to act on.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all resolved service types in this collection.
        /// </returns>
        public static IEnumerable<object> ResolveAll(this ILifetimeScope container, Type serviceType)
        {
            var collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);

            var instances = container.Resolve(collectionType);

            return ((IEnumerable<object>)instances).EmptyIfNull();
        }
    }
}