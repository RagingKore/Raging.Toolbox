using System;
using System.Threading.Tasks;

namespace Raging.Toolbox.Messaging
{
    /// <summary>
    ///     A ambient container for an IQueryService instance.
    /// </summary>
    public static class SystemQueryService
    {
        private static AmbientSingleton<IQueryService> singleton;

        public static TResult Run<TResult>(IQuery<TResult> query)
        {
            return singleton.Value.Run(query);
        }

        public static async Task<TResult> RunAsync<TResult>(IQuery<TResult> query)
        {
            return await singleton.Value.RunAsync(query);
        }

        public static IQueryService SetFactory(Func<IQueryService> queryServiceFactory)
        {
            return (singleton = AmbientSingleton.Create(queryServiceFactory())).Value;
        }
    }
}