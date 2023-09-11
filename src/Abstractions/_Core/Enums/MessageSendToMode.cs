namespace BindOpen.Labs.Messages
{
    /// <summary>
    /// This enumeration lists the possible modes to send a message.
    /// </summary>
    public enum MessageSendToMode
    {
        /// <summary>
        /// Request for sending the message to contacts one by one.
        /// </summary>
        ToOneByOne,

        /// <summary>
        /// Request for sending the message to all the contacts.
        /// </summary>
        ToAll,
    }
}
