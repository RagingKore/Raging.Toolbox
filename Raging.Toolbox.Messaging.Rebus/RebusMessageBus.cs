using System.Threading.Tasks;
using Rebus;

namespace Raging.Toolbox.Messaging.Rebus
{
    public class RebusMessageBus : DisposableBase, IMessageBus
    {
        private readonly IBus bus;

        public RebusMessageBus(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish<TEvent>(TEvent message) where TEvent : IEvent
        {
            this.bus.Publish(message);
        }

        public void Send<TCommand>(TCommand message) where TCommand : ICommand
        {
            this.bus.Send(message);
        }

        public Task PublishAsync<TEvent>(TEvent message) where TEvent : IEvent
        {
            return Task.Run(() => this.bus.Publish(message));
        }

        public Task SendAsync<TCommand>(TCommand message) where TCommand : ICommand
        {
            return Task.Run(() => this.bus.Send(message));
        }
    }
}
