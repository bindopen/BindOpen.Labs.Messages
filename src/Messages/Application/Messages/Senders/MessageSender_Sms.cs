using BindOpen.Core.System.Diagnostics;
using meltingSoft.Flow.Extensions.Messages.Extension.Entities.Messages;

namespace meltingSoft.Flow.Extensions.Platform.Application.Messages.Senders
{
    /// <summary>
    /// This class represents the internal message sender.
    /// </summary>
    public class MessageSender_Sms : MessageSender
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The simple message to send.</param>
        /// <param name="requestDelivery">The send request delivery to use.</param>
        /// <returns>The log of task.</returns>
        public override Log Send(
            BasicMessage message,
            MessageSendRequestDelivery requestDelivery)
        {
            Log log = new Log();
            return log;
        }
    }
}
