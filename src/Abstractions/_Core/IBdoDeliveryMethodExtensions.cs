namespace BindOpen.Messages
{
    /// <summary>
    /// This class represents the delivery method for a message send request.
    /// </summary>
    public static class IBdoDeliveryMethodExtensions
    {
        /// <summary>
        /// Media of this instance.
        /// </summary>
        public static T WithMedium<T>(this T obj, MessageSendMedium medium)
            where T : IBdoDeliveryMethod
        {
            if (obj != null)
            {
                obj.Medium = medium;
            }

            return obj;
        }

        /// <summary>
        /// Mode of this instance.
        /// </summary>
        public static T WithMode<T>(this T obj, MessageSendMode mode)
            where T : IBdoDeliveryMethod
        {
            if (obj != null)
            {
                obj.Mode = mode;
            }

            return obj;
        }

        /// <summary>
        /// To mode of this instance.
        /// </summary>
        public static T WithToMode<T>(this T obj, MessageSendToMode mode)
            where T : IBdoDeliveryMethod
        {
            if (obj != null)
            {
                obj.ToMode = mode;
            }

            return obj;
        }
    }
}
