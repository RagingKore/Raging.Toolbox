using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Raging.Toolbox.Extensions
{
    public static class AppDomainExtensions
    {
        /// <summary>
        /// Gets the referenced assemblies in this collection, by scanning the application domain's base directory.
        /// </summary>
        ///
        /// <remarks>
        /// Because of the JIT(Just in time) mechanism of .NET,
        /// not all the assemblies are yet loaded and thus reflection will not return all referenced assemblies.
        /// </remarks>
        ///
        /// <param name="domain">   The application domain to act on. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the referenced assemblies in this collection.
        /// </returns>
        public static IEnumerable<Assembly> GetReferencedAssemblies(this AppDomain domain)
        {
            var assemblies = Directory
                .GetFiles(domain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Select(Assembly.LoadFile);

            return assemblies;
        }
    }
}