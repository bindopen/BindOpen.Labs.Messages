using BindOpen.Data.Business;
using BindOpen.Data.Common;
using BindOpen.Data.Elements;
using BindOpen.Data.Items;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BindOpen.Messages.Extension.Entities.Messages
{
    /// <summary>
    /// This class represents the message.
    /// </summary>
    [XmlType("BasicMessage", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "basicMessage", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    [XmlInclude(typeof(ContactMessage))]
    public class Message : StoredDataItem
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// User contact that sends.
        /// </summary>
        [XmlElement("from")]
        public Contact From { get; set; } = null;

        /// <summary>
        /// User contact that sends.
        /// </summary>
        [XmlElement("notificationTo")]
        public Contact NotificationTo { get; set; } = null;

        /// <summary>
        /// User contacts can be replied to.
        /// </summary>
        [XmlArray("replyTo")]
        [XmlArrayItem("userContact")]
        public List<Contact> ReplyTo { get; set; } = new List<Contact>();

        /// <summary>
        /// Subject of this instance.
        /// </summary>
        [XmlElement("subject")]
        public DictionaryDataItem Subject { get; set; } = new DictionaryDataItem();

        /// <summary>
        /// Body of this instance.
        /// </summary>
        [XmlElement("body")]
        public DictionaryDataItem Body { get; set; } = new DictionaryDataItem();

        /// <summary>
        /// Indicates whether the content is in html.
        /// </summary>
        [XmlElement("isBodyHtml")]
        public bool IsBodyHtml { get; set; } = true;

        /// <summary>
        /// Attached files.
        /// </summary>
        [XmlArray("attachedFiles")]
        [XmlArrayItem("attachedFile")]
        public List<String> AttachedFiles { get; set; } = new List<String>();

        /// <summary>
        /// Priority of this isntance.
        /// </summary>
        [XmlElement("priority")]
        public ActionPriorities Priority { get; set; }

        /// <summary>
        /// Indicates whether a notification should be sent on success.
        /// </summary>
        [XmlElement("isNotificationOnSucess")]
        public bool IsNotificationOnSucess { get; set; } = false;

        /// <summary>
        /// Indicates whether a notification should be sent on failure.
        /// </summary>
        [XmlElement("isNotificationOnFailure")]
        public bool IsNotificationOnFailure { get; set; } = false;

        /// <summary>
        /// Indicates whether a notification should be sent on reception.
        /// </summary>
        [XmlElement("isNotificationOnReception")]
        public bool IsNotificationOnReception { get; set; } = false;

        /// <summary>
        /// Indicates whether a notification should be sent on read.
        /// </summary>
        [XmlElement("isNotificationOnRead")]
        public bool IsNotificationOnRead { get; set; } = false;

        /// <summary>
        /// Detail of this instance.
        /// </summary>
        [XmlElement("detail")]
        public DataElementSet Detail { get; set; } = new DataElementSet();

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the Message class.
        /// </summary>
        public Message()
        {
        }

        #endregion

        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors

        /// <summary>
        /// Returns the attached files in string format.
        /// </summary>
        public string GetAttachedFilesString()
        {
            string st = "";
            foreach (String currentString in AttachedFiles)
                st += (st?.Length == 0 ? currentString : currentString + ",");
            return st;
        }

        #endregion
    }
}
