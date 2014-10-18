using System.Threading.Tasks;

namespace Raging.Toolbox.Messaging
{
    public interface IAsyncMessageHandler<in TMessage>
    {
        Task Handle(TMessage message);
    }
}