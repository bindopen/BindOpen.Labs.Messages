using BindOpen.Data.Business;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BindOpen.Messages.Extension.Entities.Messages
{
    /// <summary>
    /// This class represents the message.
    /// </summary>
    [XmlType("Message", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "message", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class ContactMessage : Message
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// List of user contacts to send to.
        /// </summary>
        [XmlArray("to")]
        [XmlArrayItem("contact")]
        public List<Contact> To { get; set; } = new List<Contact>();

        /// <summary>
        /// List of user contacts to send to in copy.
        /// </summary>
        [XmlArray("cc")]
        [XmlArrayItem("contact")]
        public List<Contact> Cc { get; set; } = new List<Contact>();

        /// <summary>
        /// List of user contacts to send to in hidden copy.
        /// </summary>
        [XmlArray("bcc")]
        [XmlArrayItem("userContact")]
        public List<Contact> Bcc { get; set; } = new List<Contact>();

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the Message class.
        /// </summary>
        public ContactMessage()
        {
        }

        #endregion
    }
}
