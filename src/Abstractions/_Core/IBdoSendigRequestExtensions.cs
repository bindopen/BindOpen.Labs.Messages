using System.Linq;

namespace BindOpen.Labs.Messages
{
    /// <summary>
    /// This class represents the delivery method for a message send request.
    /// </summary>
    public static class IBdoSendigRequestExtensions
    {
        /// <summary>
        /// Media of this instance.
        /// </summary>
        public static T WithUICulture<T>(this T obj, string uiCulture)
            where T : IBdoSendigRequest
        {
            if (obj != null)
            {
                obj.UICulture = uiCulture;
            }

            return obj;
        }

        /// <summary>
        /// Media of this instance.
        /// </summary>
        public static T WithMessage<T>(this T obj, IBdoMessage message)
            where T : IBdoSendigRequest
        {
            if (obj != null)
            {
                obj.Message = message;
            }

            return obj;
        }

        /// <summary>
        /// Mode of this instance.
        /// </summary>
        public static T WithDeliveryRequests<T>(this T obj, params IBdoDeliveryRequest[] requests)
            where T : IBdoSendigRequest
        {
            if (obj != null)
            {
                obj.DeliveryRequests = requests?.ToList();
            }

            return obj;
        }

        /// <summary>
        /// To mode of this instance.
        /// </summary>
        public static T WithMaxTryNumber<T>(this T obj, int tryNumber)
            where T : IBdoSendigRequest
        {
            if (obj != null)
            {
                obj.MaxTryNumber = tryNumber;
            }

            return obj;
        }
    }
}
