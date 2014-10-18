using System;
using System.Threading.Tasks;

namespace Raging.Toolbox.Messaging
{
    public interface IMessageBus : IDisposable
    {
        /// <summary>
        /// Publishes an event to all it's subscribed handlers.
        /// </summary>
        /// <typeparam name="TEvent">Type of the event.</typeparam>
        /// <param name="message">The event message.</param>
        void Publish<TEvent>(TEvent message) where TEvent : IEvent;

        /// <summary>
        ///     Sends a command to be proccessed by it's registered handler.
        /// </summary>
        /// <typeparam name="TCommand">Type of the command.</typeparam>
        /// <param name="message">The command message.</param>
        void Send<TCommand>(TCommand message) where TCommand : ICommand;

        /// <summary>
        ///      Asynchronously publishes an event to all it's subscribed handlers.
        /// </summary>
        /// <typeparam name="TEvent">Type of the event.</typeparam>
        /// <param name="message">The event message.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task PublishAsync<TEvent>(TEvent message) where TEvent : IEvent;

        /// <summary>
        ///     Asynchronously sends a command to be proccessed by it's registered handler.
        /// </summary>
        /// <typeparam name="TCommand">Type of the command.</typeparam>
        /// <param name="message">The command message. </param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SendAsync<TCommand>(TCommand message) where TCommand : ICommand;
    }
}