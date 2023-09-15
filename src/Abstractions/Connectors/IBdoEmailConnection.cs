using BindOpen.Kernel.Logging;
using BindOpen.Kernel.Scoping.Connectors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BindOpen.Plus.Messages.Services
{
    /// <summary>
    /// This enumeration lists the possible media used to send a message.
    /// </summary>
    public interface IBdoEmailConnection : IBdoConnection
    {
        Task SendMessageAsync(IBdoSendingMessage message, IBdoLog log = null);

        void SendMessage(IBdoSendingMessage message, IBdoLog log = null);

        Task<IEnumerable<IBdoSendingMessage>> ReceiveMessagesAsync(IBdoLog log = null);

        IEnumerable<IBdoSendingMessage> ReceiveMessages(IBdoLog log = null);
    }
}
