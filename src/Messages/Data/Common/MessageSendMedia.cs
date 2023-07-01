namespace BindOpen.Messages.Data.Common
{
    /// <summary>
    /// This enumeration lists the possible media used to send a message.
    /// </summary>
    public enum MessageSendMedia
    {
        /// <summary>
        /// The message is sent in the platform from a central enterprise server.
        /// </summary>
        Internal_FromCentral,

        /// <summary>
        /// The message is sent in the platform from a non central-enterprise server.
        /// </summary>
        Internal_FromStandard,

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
