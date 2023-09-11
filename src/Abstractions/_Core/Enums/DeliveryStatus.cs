namespace BindOpen.Labs.Messages.Data.Common
{
    /// <summary>
    /// This enumeration lists the possible statuses of a send request of a message.
    /// </summary>
    public enum DeliveryStatus
    {
        /// <summary>
        /// Queueing.
        /// </summary>
        Queueing,

        /// <summary>
        /// Error. An error occured during the last message.
        /// </summary>
        Error,

        /// <summary>
        /// Done. The message has been well sent.
        /// </summary>
        Done
    }
}
