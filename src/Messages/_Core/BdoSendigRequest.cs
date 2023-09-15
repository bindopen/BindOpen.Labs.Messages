using System;
using System.Collections.Generic;

namespace BindOpen.Plus.Messages
{
    /// <summary>
    /// This class represents the message send request.
    /// </summary>
    public class BdoSendigRequest : IBdoSendigRequest
    {
        /// <summary>
        /// Message of this instance.
        /// </summary>
        public string UICulture { get; set; }

        /// <summary>
        /// Message of this instance.
        /// </summary>
        public IBdoMessage Message { get; set; }

        /// <summary>
        /// User contact that sends.
        /// </summary>
        public List<IBdoDeliveryRequest> DeliveryRequests { get; set; }

        /// <summary>
        /// Maximum number of sending tries. Unlimited if -1.
        /// </summary>
        public int MaxTryNumber { get; set; }

        public BdoSendigRequest() { }

        // IIdentified

        public string Id { get; set; }

        // IReferenced

        public string Key() => Id;

        // IDated

        public DateTime? CreationDate { get; set; }

        public DateTime? LastModificationDate { get; set; }
    }
}
