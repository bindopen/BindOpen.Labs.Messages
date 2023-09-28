namespace BindOpen.Plus.Messages
{
    /// <summary>
    /// This class represents the delivery method for a message send request.
    /// </summary>
    public class BdoDeliveryMethod
    {
        /// <summary>
        /// Media of this instance.
        /// </summary>
        public MessageSendMedium Media { get; set; }

        /// <summary>
        /// Mode of this instance.
        /// </summary>
        public MessageSendMode Mode { get; set; }

        /// <summary>
        /// To mode of this instance.
        /// </summary>
        public MessageSendToMode ToMode { get; set; }

        public BdoDeliveryMethod()
        {
        }
    }
}
