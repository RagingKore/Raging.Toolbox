using System;
using System.Threading.Tasks;

namespace Raging.Toolbox.Messaging
{
    public static class QueryRunner
    {
        private static Func<IQueryRunner> factoryFunc;

        public static void SetFactory(Func<IQueryRunner> factory)
        {
            Guard.Null(() => factory);

            factoryFunc = factory;
        }

        public static Task<TResult> RunAsync<TResult>(IQuery<TResult> query)
        {
            Guard.Null(() => query);
            return factoryFunc().RunAsync(query);
        }

        public static TResult Run<TResult>(IQuery<TResult> query)
        {
            Guard.Null(() => query);
            return factoryFunc().Run(query);
        }
    }

    public static class Bus
    {
        private static Func<IMessageBus> factoryFunc;

        public static void SetFactory(Func<IMessageBus> factory)
        {
            Guard.Null(() => factory);

            factoryFunc = factory;
        }

        public static void Publish<TEvent>(TEvent message) where TEvent : IEvent
        {
            Guard.Null(() => message);
            factoryFunc().Publish(message);
        }

        public static void Send<TCommand>(TCommand message) where TCommand : ICommand
        {
            Guard.Null(() => message);
            factoryFunc().Send(message);
        }

        public static Task PublishAsync<TEvent>(TEvent message) where TEvent : IEvent
        {
            Guard.Null(() => message);
            return factoryFunc().PublishAsync(message);
        }

        public static Task SendAsync<TCommand>(TCommand message) where TCommand : ICommand
        {
            Guard.Null(() => message);
            return factoryFunc().SendAsync(message);
        }
    }
}