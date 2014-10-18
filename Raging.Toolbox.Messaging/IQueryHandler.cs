namespace Raging.Toolbox.Messaging
{
    public interface IQueryHandler<in TQuery, out TResult>
       where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}