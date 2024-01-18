using BindOpen.Messages.Contacts;
using System.Collections.Generic;

namespace BindOpen.Messages
{
    /// <summary>
    /// This class represents the delivery of a to-send message.
    /// </summary>
    public class BdoDeliveryRequest
    {
        /// <summary>
        /// Delivery method of this instance.
        /// </summary>
        public IBdoDeliveryMethod Method { get; set; }

        /// <summary>
        /// User contact to reach.
        /// </summary>
        public List<IBdoContact> To { get; set; }

        public BdoDeliveryRequest() { }
    }
}
