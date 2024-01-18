using BindOpen.Data;
using System.Collections.Generic;

namespace BindOpen.Messages
{
    /// <summary>
    /// This class represents the message send request.
    /// </summary>
    public interface IBdoSendigRequest : IIdentified, IReferenced, IDated
    {
        /// <summary>
        /// Message of this instance.
        /// </summary>
        string UICulture { get; set; }

        /// <summary>
        /// Message of this instance.
        /// </summary>
        IBdoMessage Message { get; set; }

        /// <summary>
        /// User contact that sends.
        /// </summary>
        List<IBdoDeliveryRequest> DeliveryRequests { get; set; }

        /// <summary>
        /// Maximum number of sending tries. Unlimited if -1.
        /// </summary>
        int MaxTryNumber { get; set; }
    }
}
