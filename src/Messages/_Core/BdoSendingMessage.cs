using BindOpen.Messages.Contacts;
using System.Collections.Generic;

namespace BindOpen.Messages
{
    /// <summary>
    /// This class represents the message.
    /// </summary>
    public class BdoSendingMessage : BdoMessage, IBdoSendingMessage
    {
        // Sender

        /// <summary>
        /// User contact that sends.
        /// </summary>
        public IBdoContact From { get; set; }

        /// <summary>
        /// User contacts can be replied to.
        /// </summary>
        public List<IBdoContact> ReplyTo { get; set; }

        // Recipients

        /// <summary>
        /// List of user contacts to send to.
        /// </summary>
        public List<IBdoContact> To { get; set; }

        /// <summary>
        /// List of user contacts to send to in copy.
        /// </summary>
        public List<IBdoContact> Cc { get; set; }

        /// <summary>
        /// List of user contacts to send to in hidden copy.
        /// </summary>
        public List<IBdoContact> Bcc { get; set; }

        /// <summary>
        /// List of user contacts to send to in hidden copy.
        /// </summary>
        public List<IBdoContact> NotificationTo { get; set; }

        public string UICulture { get; set; }

        public BdoSendingMessage() { }
    }
}
