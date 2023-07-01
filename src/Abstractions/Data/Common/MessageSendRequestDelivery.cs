using BindOpen.Data.Business;
using BindOpen.Data.Items;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Messages.Data.Common
{
    /// <summary>
    /// This class represents the delivery of a to-send message.
    /// </summary>
    public class MessageSendRequestDelivery : DataItem
    {
        // --------------------------------------
        // PROPERTIES
        // --------------------------------------

        #region Properties

        /// <summary>
        /// Delivery method of this instance.
        /// </summary>
        [XmlElement("method")]
        public MessageSendRequestDeliveryMethod Method { get; set; }

        /// <summary>
        /// User contact to reach.
        /// </summary>
        [XmlArray("userContactTo")]
        [XmlArrayItem("userContact")]
        public List<Contact> ContactTo { get; set; } = new List<Contact>();

        #endregion

        // --------------------------------------
        // CONSTRUCTORS
        // --------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MessageSendRequestDelivery class.
        /// </summary>
        public MessageSendRequestDelivery()
        {
        }

        #endregion
    }
}
