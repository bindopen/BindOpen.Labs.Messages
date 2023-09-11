using BindOpen.Labs.Messages.Contacts;
using System.Collections.Generic;

namespace BindOpen.Labs.Messages
{
    /// <summary>
    /// This class represents the message.
    /// </summary>
    public interface IBdoSendingMessage : IBdoMessage
    {
        // Sender

        /// <summary>
        /// User contact that sends.
        /// </summary>
        IBdoContact From { get; set; }

        /// <summary>
        /// User contacts can be replied to.
        /// </summary>
        List<IBdoContact> ReplyTo { get; set; }

        // Recipients

        /// <summary>
        /// List of user contacts to send to.
        /// </summary>
        List<IBdoContact> To { get; set; }

        /// <summary>
        /// List of user contacts to send to in copy.
        /// </summary>
        List<IBdoContact> Cc { get; set; }

        /// <summary>
        /// List of user contacts to send to in hidden copy.
        /// </summary>
        List<IBdoContact> Bcc { get; set; }

        // Notification

        /// <summary>
        /// List of user contacts to send to.
        /// </summary>
        List<IBdoContact> NotificationTo { get; set; }
    }
}
