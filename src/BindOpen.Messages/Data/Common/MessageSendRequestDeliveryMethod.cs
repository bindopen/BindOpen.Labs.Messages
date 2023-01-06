using System;
using System.Xml.Serialization;
using BindOpen.Data.Items;

namespace BindOpen.Messages.Data.Common
{
    /// <summary>
    /// This class represents the delivery method for a message send request.
    /// </summary>
    public class MessageSendRequestDeliveryMethod : DataItem
    {
        // --------------------------------------
        // PROPERTIES
        // --------------------------------------

        #region Properties

        /// <summary>
        /// Media of this instance.
        /// </summary>
        [XmlElement("media")]
        public MessageSendMedia Media { get; set; } = MessageSendMedia.Internal_FromStandard;

        /// <summary>
        /// Mode of this instance.
        /// </summary>
        [XmlElement("mode")]
        public MessageSendMode Mode { get; set; } = MessageSendMode.SendingPool;

        /// <summary>
        /// To mode of this instance.
        /// </summary>
        [XmlElement("toMode")]
        public MessageSendToMode ToMode { get; set; }

        /// <summary>
        /// The data source name of this instance.
        /// </summary>
        [XmlElement("dataSourceName")]
        public String DataSourceName { get; set; } = "";

        #endregion


        // --------------------------------------
        // CONSTRUCTORS
        // --------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MessageSendRequestDeliveryMethod class.
        /// </summary>
        public MessageSendRequestDeliveryMethod()
        {
        }

        #endregion
    }
}
