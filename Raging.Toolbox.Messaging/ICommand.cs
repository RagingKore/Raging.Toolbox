namespace Raging.Toolbox.Messaging
{
    /// <summary>
    ///     Interface for command.
    ///     * Are not allowed to be published since all commands should have one logical owner and should be sent to the endpoint responsible for processing.
    ///     * Cannot be subscribed and unsubscribed to.
    ///     * Cannot implement IEvent.
    /// </summary>
    public interface ICommand { }
}