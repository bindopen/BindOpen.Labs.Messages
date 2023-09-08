using System.Collections.Generic;

namespace BindOpen.Framework.Labs.Messages.Application.Messages.Senders
{
    /// <summary>
    /// This class represents a message sender.
    /// </summary>
    public static class MessageSender
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The simple message to send.</param>
        /// <param name="requestDelivery">The send request delivery to use.</param>
        /// <returns>The log of task.</returns>
        public virtual ILog Send(
            Message message,
            MessageSendRequestDelivery requestDelivery)
        {
            Log log = new Log();
            return log;
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The simple message to send.</param>
        /// <param name="requestDeliveries">The send request deliveries to use.</param>
        /// <returns>The log of task.</returns>
        public virtual ILog Send(
            BasicMessage message,
            List<MessageSendRequestDelivery> requestDeliveries)
        {
            Log log = new Log();
            return log;
        }

    }
}
