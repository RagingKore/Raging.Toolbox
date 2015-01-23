using System;
using Rebus;

namespace Tru.Common.Rebus
{
    public static class BusExtensions
    {
        public static void Publish<TEvent>(this IBus bus, Action<TEvent> action)
            where TEvent : new()
        {
            var message = new TEvent();
            action(message);
            bus.Publish(message);
        }

        public static void Send<TCommand>(this IBus bus, Action<TCommand> action)
            where TCommand : new()
        {
            var message = new TCommand();
            action(message);
            bus.Send(message);
        }
    }
}
