namespace Raging.Toolbox.Messaging
{
    public interface IMessageHandler<in TMessage>
    {
        void Handle(TMessage message);
    }
}