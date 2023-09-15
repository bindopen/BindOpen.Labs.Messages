using BindOpen.Plus.Messages.Contacts;
using System.Collections.Generic;

namespace BindOpen.Plus.Messages
{
    /// <summary>
    /// This class represents the delivery of a to-send message.
    /// </summary>
    public interface IBdoDeliveryRequest
    {
        /// <summary>
        /// Delivery method of this instance.
        /// </summary>
        IBdoDeliveryMethod Method { get; set; }

        /// <summary>
        /// User contact to reach.
        /// </summary>
        List<IBdoContact> To { get; set; }
    }
}
