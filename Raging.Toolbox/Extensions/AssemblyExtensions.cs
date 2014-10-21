using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Raging.Toolbox.Extensions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        ///     Gets the loadable types for the given assembly.</summary>
        /// <remarks>
        ///     Source: http://haacked.com/archive/2012/07/23/get-all-types-in-an-assembly.aspx/
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="assembly">The assembly to act on.</param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the loadable types in this collection.
        /// </returns>
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if(assembly == null) throw new ArgumentNullException("assembly");

            try
            {
                return assembly.GetTypes();
            }
            catch(ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null);
            }
        }
    }
}
