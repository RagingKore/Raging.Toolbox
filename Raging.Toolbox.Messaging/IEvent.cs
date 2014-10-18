namespace Raging.Toolbox.Messaging
{
    /// <summary>
    ///     Interface for events.
    ///     * Can be published.
    ///     * Can be subscribed and unsubscribed to.
    ///     * Cannot be sent using IMessageBus.SendCommand() since all events should be published.
    ///     * Cannot implement ICommand.
    /// </summary>
    public interface IEvent { }
}