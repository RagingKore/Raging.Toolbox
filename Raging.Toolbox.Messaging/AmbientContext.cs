using System;
using System.Threading.Tasks;

namespace Raging.Toolbox.Messaging
{
    public static class QueryRunner
    {
        private static Func<IQueryRunner> factoryFunc;

        public static void SetFactory(Func<IQueryRunner> factory)
        {
            Guard.ForNull(() => factory);

            factoryFunc = factory;
        }

        public static Task<TResult> RunAsync<TResult>(IQuery<TResult> query)
        {
            Guard.ForNull(() => query);
            return factoryFunc().RunAsync(query);
        }

        public static TResult Run<TResult>(IQuery<TResult> query)
        {
            Guard.ForNull(() => query);
            return factoryFunc().Run(query);
        }
    }

    public static class Bus
    {
        private static Func<IMessageBus> factoryFunc;

        public static void SetFactory(Func<IMessageBus> factory)
        {
            Guard.ForNull(() => factory);

            factoryFunc = factory;
        }

        public static void Publish<TEvent>(TEvent message) where TEvent : IEvent
        {
            Guard.ForNull(() => message);
            factoryFunc().Publish(message);
        }

        public static void Send<TCommand>(TCommand message) where TCommand : ICommand
        {
            Guard.ForNull(() => message);
            factoryFunc().Send(message);
        }

        public static Task PublishAsync<TEvent>(TEvent message) where TEvent : IEvent
        {
            Guard.ForNull(() => message);
            return factoryFunc().PublishAsync(message);
        }

        public static Task SendAsync<TCommand>(TCommand message) where TCommand : ICommand
        {
            Guard.ForNull(() => message);
            return factoryFunc().SendAsync(message);
        }
    }
}