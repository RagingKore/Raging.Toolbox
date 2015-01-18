using System;
using System.Threading.Tasks;

namespace Raging.Toolbox.Mapping
{
    /// <summary>
    ///     A ambient container for an IObjectMapper instance.
    /// </summary>
    public static class SystemMapper
    {
        private static AmbientSingleton<IObjectMapper> singleton;

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return singleton.Value.Map<TSource, TDestination>(source);
        }

        public static TDestination Map<TSource1, TSource2, TDestination>(TSource1 source1, TSource2 source2)
        {
            return singleton.Value.Map<TSource1, TSource2, TDestination>(source1, source2);
        }

        public static TDestination Map<TSource1, TSource2, TSource3, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3)
        {
            return singleton.Value.Map<TSource1, TSource2, TSource3, TDestination>(source1, source2, source3);
        }

        public static TDestination Map<TSource1, TSource2, TSource3, TSource4, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4)
        {
            return singleton.Value.Map<TSource1, TSource2, TSource3, TSource4, TDestination>(source1, source2, source3, source4);
        }

        public static TDestination Map<TSource1, TSource2, TSource3, TSource4, TSource5, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5)
        {
            return singleton.Value.Map<TSource1, TSource2, TSource3, TSource4, TSource5, TDestination>(source1, source2, source3, source4, source5);
        }

        public static TDestination Map<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5, TSource6 source6)
        {
            return singleton.Value.Map<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TDestination>(source1, source2, source3, source4, source5, source6);
        }

        public static TDestination Map<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5, TSource6 source6, TSource7 source7)
        {
            return singleton.Value.Map<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TDestination>(source1, source2, source3, source4, source5, source6, source7);
        }

        public static TDestination Map<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5, TSource6 source6, TSource7 source7, TSource8 source8)
        {
            return singleton.Value.Map<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TDestination>(source1, source2, source3, source4, source5, source6, source7, source8);
        }

        public static async Task<TDestination> MapAsync<TSource, TDestination>(TSource source)
        {
            return await singleton.Value.MapAsync<TSource, TDestination>(source);
        }

        public static async Task<TDestination> MapAsync<TSource1, TSource2, TDestination>(TSource1 source1, TSource2 source2)
        {
            return await singleton.Value.MapAsync<TSource1, TSource2, TDestination>(source1, source2);
        }

        public static async Task<TDestination> MapAsync<TSource1, TSource2, TSource3, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3)
        {
            return await singleton.Value.MapAsync<TSource1, TSource2, TSource3, TDestination>(source1, source2, source3);
        }

        public static async Task<TDestination> MapAsync<TSource1, TSource2, TSource3, TSource4, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4)
        {
            return await singleton.Value.MapAsync<TSource1, TSource2, TSource3, TSource4, TDestination>(source1, source2, source3, source4);
        }

        public static async Task<TDestination> MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5)
        {
            return await singleton.Value.MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TDestination>(source1, source2, source3, source4, source5);
        }

        public static async Task<TDestination> MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5, TSource6 source6)
        {
            return await singleton.Value.MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TDestination>(source1, source2, source3, source4, source5, source6);
        }

        public static async Task<TDestination> MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5, TSource6 source6, TSource7 source7)
        {
            return await singleton.Value.MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TDestination>(source1, source2, source3, source4, source5, source6, source7);
        }

        public static async Task<TDestination> MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TDestination>(TSource1 source1, TSource2 source2, TSource3 source3, TSource4 source4, TSource5 source5, TSource6 source6, TSource7 source7, TSource8 source8)
        {
            return await singleton.Value.MapAsync<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TDestination>(source1, source2, source3, source4, source5, source6, source7, source8);
        }

        public static IObjectMapper SetFactory(Func<IObjectMapper> objectMapperFactory)
        {
            return (singleton = AmbientSingleton.Create(objectMapperFactory())).Value;
        }
    }
}
