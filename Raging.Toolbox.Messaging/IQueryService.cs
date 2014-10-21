using System.Threading.Tasks;

namespace Raging.Toolbox.Messaging
{
    public interface IQueryService
    {
        Task<TResult> RunAsync<TResult>(IQuery<TResult> query);

        TResult Run<TResult>(IQuery<TResult> query);
    }
}