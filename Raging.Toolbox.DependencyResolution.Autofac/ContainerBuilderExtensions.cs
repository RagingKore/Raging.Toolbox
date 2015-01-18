using System;
using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Features.Scanning;
using Raging.Toolbox.Configuration;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.DependencyResolution.Autofac
{
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        ///     A ContainerBuilder extension method that registers a type, in one simple method.
        /// </summary>
        /// <tparam name="TService">Type of the service.</tparam>
        /// <tparam name="TServiceImplementation">Type of the service implementation.</tparam>
        /// <param name="builder">The builder to act on.</param>
        /// <returns>
        ///     An IRegistrationBuilder&lt;TServiceImplementation,ConcreteReflectionActivatorData,SingleRegistrationStyle&gt;
        /// </returns>
        public static IRegistrationBuilder<TServiceImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> 
            Register<TService, TServiceImplementation>(this ContainerBuilder builder)
            where TService : class
            where TServiceImplementation : TService
        {
            return builder.RegisterType<TServiceImplementation>().As<TService>();
        }

        /// <summary>
        ///     A ContainerBuilder extension method that registers a type as singleton, in one simple method.
        /// </summary>
        /// <tparam name="TService">Type of the service.</tparam>
        /// <tparam name="TServiceImplementation">Type of the service implementation.</tparam>
        /// <param name="builder">The builder to act on.</param>
        /// <returns>
        ///     An IRegistrationBuilder&lt;TServiceImplementation,ConcreteReflectionActivatorData,SingleRegistrationStyle&gt;
        /// </returns>
        public static IRegistrationBuilder<TServiceImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> 
            RegisterSingle<TService, TServiceImplementation>(this ContainerBuilder builder)
            where TService : class
            where TServiceImplementation : TService
        {
            return builder.RegisterType<TServiceImplementation>().As<TService>().SingleInstance();
        }

        /// <summary>
        ///     A ContainerBuilder extension method that scans all the application current domain assemblies,
        ///     and registers all modules found, in one simple method.
        /// </summary>
        /// <param name="builder">The builder to act on.</param>
        /// <returns>
        ///          An IModuleRegistrar.
        /// </returns>
        public static IModuleRegistrar RegisterAllModules(this ContainerBuilder builder)
        {
            return builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetReferencedAssemblies().ToArray());
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            RegisterGenerics(this ContainerBuilder builder, Type openGenericType, string key = null)
        {
            return key == null 
                ? builder
                    .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetReferencedAssemblies().ToArray())
                    .As(type => type
                        .GetInterfaces()
                        .Where(interfaceType => interfaceType.IsClosedTypeOf(openGenericType)))
                : builder
                    .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetReferencedAssemblies().ToArray())
                    .As(type => type
                        .GetInterfaces()
                        .Where(interfaceType => interfaceType.IsClosedTypeOf(openGenericType))
                        .Select(specificType => new KeyedService(key, specificType)));
        }

        /// <summary>
        ///     A ContainerBuilder extension method that scans all the application current domain assemblies,
        ///     and registers all the implementations found of the given base type, in one simple method.
        /// </summary>
        /// <param name="builder">The builder to act on.</param>
        /// <param name="serviceBaseType">Type of the service base.</param>
        /// <returns>
        ///     An IRegistrationBuilder&lt;object,ScanningActivatorData,DynamicRegistrationStyle&gt;
        /// </returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
           RegisterAll(this ContainerBuilder builder, Type serviceBaseType)
        {
            return builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetReferencedAssemblies().ToArray())
                .Where(serviceBaseType.IsAssignableFrom)
                .As(serviceBaseType);
        }

        /// <summary>
        ///     A ContainerBuilder extension method that scans all the application current domain assemblies,
        ///     and registers all the implementations found of the given base type, in one simple method.
        /// </summary>
        /// <tparam name="TServiceBaseType">Type of the service base type.</tparam>
        /// <param name="builder">The builder to act on.</param>
        /// <returns>
        ///     An IRegistrationBuilder&lt;object,ScanningActivatorData,DynamicRegistrationStyle&gt;
        /// </returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
           RegisterAll<TServiceBaseType>(this ContainerBuilder builder)
        {
            return builder.RegisterAll(typeof(TServiceBaseType));
        }

        /// <summary>
        ///     A ContainerBuilder extension method that registers a configuration section as a single typed settings class.
        /// </summary>
        /// <tparam name="TSettings">Type of the settings class.</tparam>
        /// <param name="builder">The builder to act on.</param>
        /// <param name="configurationSectionName">Name of the configuration section.</param>
        /// <returns>An IRegistrationBuilder&lt;TSettings,SimpleActivatorData,SingleRegistrationStyle&gt;</returns>
        public static IRegistrationBuilder<TSettings, SimpleActivatorData, SingleRegistrationStyle>
            RegisterSettings<TSettings>(this ContainerBuilder builder, string configurationSectionName)
            where TSettings : class
        {
            return builder
                .RegisterInstance(ConfigurationManager.GetSection<TSettings>(configurationSectionName))
                .SingleInstance();
        }

        /// <summary>
        ///     A ContainerBuilder extension method that registers a configuration section as a single typed settings class,
        ///     resolving the section name by convention. (IMySettings => mySettings)
        /// </summary>
        /// <tparam name="TSettings">Type of the settings.</tparam>
        /// <param name="builder">The builder to act on.</param>
        /// <returns>An IRegistrationBuilder&lt;TSettings,SimpleActivatorData,SingleRegistrationStyle&gt;</returns>
        public static IRegistrationBuilder<TSettings, SimpleActivatorData, SingleRegistrationStyle>
            RegisterSettings<TSettings>(this ContainerBuilder builder)
            where TSettings : class
        {
            // remove first char, the I from Interface
            var implementationName = typeof(TSettings).Name.Remove(0, 1);

            // get the first char and convert it to lowercase
            var firstLetter = implementationName[0]
                .ToString()
                .ToLower();

            // compose the final name
            var configurationSectionNameByConvention = "{0}{1}".FormatWith(firstLetter, implementationName.Remove(0, 1));

            return builder.RegisterSettings<TSettings>(configurationSectionNameByConvention);
        }
    }
}