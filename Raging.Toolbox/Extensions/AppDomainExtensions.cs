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
        ///     Gets the types from the assemblies that have been loaded into the execution context of this application domain.
        /// </summary>
        /// <param name="domain">The application domain to act on.</param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the types in this collection.
        /// </returns>
        public static IEnumerable<Type> GetTypes(this AppDomain domain)
        {
            Guard.Null(() => domain, domain);

            var types = domain
                .GetAssemblies()
                .SelectMany(a => a.GetLoadableTypes());

            return types;
        }

        /// <summary>
        ///     Gets the types from the assemblies that have been loaded into the execution context of this application domain, 
        ///     and that are assignable to a given type, excluding that same type.
        /// </summary>
        /// <param name="domain">The application domain to act on.</param>
        /// <param name="baseType">The base Type.</param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the types assignable froms in this collection.
        /// </returns>
        public static IEnumerable<Type> GetTypesAssignableTo(this AppDomain domain, Type baseType)
        {
            Guard.Null(() => domain, domain);

            var types = domain
                .GetTypes()
                .Where(baseType.IsAssignableFrom)
                .Where(type => type != baseType);

            return types;
        }

        /// <summary>
        ///     Gets the types from the assemblies that are referenced to this domain.
        /// </summary>
        /// <param name="domain">The application domain to act on.</param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the types in this collection.
        /// </returns>
        public static IEnumerable<Type> GetReferencedTypes(this AppDomain domain)
        {
            Guard.Null(() => domain, domain);

            var types = domain
                .GetReferencedAssemblies()
                .SelectMany(a => a.GetLoadableTypes());

            return types;
        }

        /// <summary>
        ///     Gets the referenced assemblies in this collection, by scanning the application domain's base directory.
        /// </summary>
        /// <remarks>
        ///     Because of the JIT(Just in time) mechanism of .NET,
        ///     not all the assemblies is yet loaded and thus reflection will not return all referenced assemblies.
        /// </remarks>
        /// <param name="domain">The application domain to act on. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the referenced assemblies in this collection.
        /// </returns>
        public static IEnumerable<Assembly> GetReferencedAssemblies(this AppDomain domain)
        {
            Guard.Null(() => domain, domain);

            var files = Directory.GetFiles(domain.BaseDirectory, "*.dll", SearchOption.AllDirectories);

            foreach (var filename in files)
            {
                // Assembly.LoadFile(filename); --> this can not be done, because this will lock the file and we will have problems when rebuilding the application
                // http://stackoverflow.com/questions/1031431/system-reflection-assembly-loadfile-locks-file
                Assembly.Load(File.ReadAllBytes(filename));
            }

            return AppDomain.CurrentDomain
                .GetAssemblies()
                .ToList()
                .Distinct(EqualityHelper<Assembly>.CreateComparer(assembly => assembly.FullName));
        }
    }
}