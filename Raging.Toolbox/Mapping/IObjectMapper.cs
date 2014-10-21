using System.Threading.Tasks;

namespace Raging.Toolbox.Mapping
{
    /// <summary>Interface for implementing object mappers.</summary>
    public interface IObjectMapper
    {
        /// <summary>Maps the given source object to another one of the provided type.</summary>
        /// <tparam name="TSource">Type of the source.</tparam>
        /// <tparam name="TDestination">Type of the destination.</tparam>
        /// <param name="source">Source object.</param>
        /// <returns>A TDestination object.</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>Maps the given source object asynchronously to another one of the provided type.</summary>
        /// <tparam name="TSource">Type of the source.</tparam>
        /// <tparam name="TDestination">Type of the destination.</tparam>
        /// <param name="source">Source object.</param>
        /// <returns>A TDestination object.</returns>
        Task<TDestination> MapAsync<TSource, TDestination>(TSource source);
    }
}