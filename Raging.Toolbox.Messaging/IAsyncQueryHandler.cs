using System.Threading.Tasks;

namespace Raging.Toolbox.Messaging
{
    public interface IAsyncQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}