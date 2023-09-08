namespace BindOpen.Messages.Data.Common
{
    /// <summary>
    /// This enumeration lists the possible methods to send a message.
    /// </summary>
    public enum MessageSendMode
    {
        /// <summary>
        /// The message is sent directly.
        /// </summary>
        Direct,

        /// <summary>
        /// The message is put in the sending pool.
        /// </summary>
        SendingPool
    }
}
