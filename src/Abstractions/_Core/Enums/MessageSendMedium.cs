namespace BindOpen.Labs.Messages
{
    /// <summary>
    /// This enumeration lists the possible media used to send a message.
    /// </summary>
    public enum MessageSendMedium
    {
        /// <summary>
        /// The message is sent via email.
        /// </summary>
        Email,

        /// <summary>
        /// The message is sent by sms.
        /// </summary>
        Sms,

        /// <summary>
        /// The message is sent by phone.
        /// </summary>
        Vocal,

        /// <summary>
        /// The message is sent by fax.
        /// </summary>
        Fax
    }
}
