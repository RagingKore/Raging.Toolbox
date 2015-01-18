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

        /// <summary>Maps two sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Map<T1, T2, TDestination>(T1 source1, T2 source2);

        /// <summary>Maps three sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Map<T1, T2, T3, TDestination>(T1 source1, T2 source2, T3 source3);

        /// <summary>Maps four sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Map<T1, T2, T3, T4, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4);

        /// <summary>Maps five sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Map<T1, T2, T3, T4, T5, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5);

        /// <summary>Maps six sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <param name="source6">The sixth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="T6">Type of the sixth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Map<T1, T2, T3, T4, T5, T6, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5, T6 source6);

        /// <summary>Maps seven sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <param name="source6">The sixth source.</param>
        /// <param name="source7">The seventh source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="T6">Type of the sixth source.</typeparam>
        /// <typeparam name="T7">Type of the seventh source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Map<T1, T2, T3, T4, T5, T6, T7, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5, T6 source6, T7 source7);

        /// <summary>Maps eight sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <param name="source6">The sixth source.</param>
        /// <param name="source7">The seventh source.</param>
        /// <param name="source8">The eighth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="T6">Type of the sixth source.</typeparam>
        /// <typeparam name="T7">Type of the seventh source.</typeparam>
        /// <typeparam name="T8">Type of the eighth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        TDestination Map<T1, T2, T3, T4, T5, T6, T7, T8, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5, T6 source6, T7 source7, T8 source8);

        /// <summary>Maps the given source object asynchronously to another one of the provided type.</summary>
        /// <tparam name="TSource">Type of the source.</tparam>
        /// <tparam name="TDestination">Type of the destination.</tparam>
        /// <param name="source">Source object.</param>
        /// <returns>A TDestination object.</returns>
        Task<TDestination> MapAsync<TSource, TDestination>(TSource source);

        /// <summary>Maps two sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        Task<TDestination> MapAsync<T1, T2, TDestination>(T1 source1, T2 source2);

        /// <summary>Maps three sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        Task<TDestination> MapAsync<T1, T2, T3, TDestination>(T1 source1, T2 source2, T3 source3);

        /// <summary>Maps four sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        Task<TDestination> MapAsync<T1, T2, T3, T4, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4);

        /// <summary>Maps five sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        Task<TDestination> MapAsync<T1, T2, T3, T4, T5, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5);

        /// <summary>Maps six sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <param name="source6">The sixth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="T6">Type of the sixth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        Task<TDestination> MapAsync<T1, T2, T3, T4, T5, T6, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5, T6 source6);

        /// <summary>Maps seven sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <param name="source6">The sixth source.</param>
        /// <param name="source7">The seventh source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="T6">Type of the sixth source.</typeparam>
        /// <typeparam name="T7">Type of the seventh source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        Task<TDestination> MapAsync<T1, T2, T3, T4, T5, T6, T7, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5, T6 source6, T7 source7);

        /// <summary>Maps eight sources to a single object.</summary>
        /// <param name="source1">The first source.</param>
        /// <param name="source2">The second source.</param>
        /// <param name="source3">The third source.</param>
        /// <param name="source4">The fourth source.</param>
        /// <param name="source5">The fifth source.</param>
        /// <param name="source6">The sixth source.</param>
        /// <param name="source7">The seventh source.</param>
        /// <param name="source8">The eighth source.</param>
        /// <typeparam name="T1">Type of the first source.</typeparam>
        /// <typeparam name="T2">Type of the second source.</typeparam>
        /// <typeparam name="T3">Type of the third source.</typeparam>
        /// <typeparam name="T4">Type of the fourth source.</typeparam>
        /// <typeparam name="T5">Type of the fifth source.</typeparam>
        /// <typeparam name="T6">Type of the sixth source.</typeparam>
        /// <typeparam name="T7">Type of the seventh source.</typeparam>
        /// <typeparam name="T8">Type of the eighth source.</typeparam>
        /// <typeparam name="TDestination">Type of the destination.</typeparam>
        /// <returns>The <see cref="TDestination"/>.</returns>
        Task<TDestination> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TDestination>(T1 source1, T2 source2, T3 source3, T4 source4, T5 source5, T6 source6, T7 source7, T8 source8);
    }
}