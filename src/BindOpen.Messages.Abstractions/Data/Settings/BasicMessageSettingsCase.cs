using BindOpen.Messages.Extension.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Messages.Data.Settings
{

    /// <summary>
    /// This class represents the case of message settings.
    /// </summary>
    [XmlType("MessageSettingsCase", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "basicMessageSettingsCase", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class MessageSettingsCase
    {

        // ------------------------------------------
        // VARIABLES
        // ------------------------------------------

        #region Variables

        private string _Id;
        private string _DefaultLanguage;
        private List<String> _BusinessLibraryNames;
        private ContactMessage _Message = new ContactMessage();

        #endregion


        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Id of this instance.
        /// </summary>
        [XmlAttribute("id")]
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// Default language of this instance.
        /// </summary>
        [XmlAttribute("defaultLanguage")]
        public string DefaultLanguage
        {
            get { return _DefaultLanguage; }
            set { _DefaultLanguage = value; }
        }

        /// <summary>
        /// Business libraries of this instance.
        /// </summary>
        [XmlArray("businessLibraryNames")]
        [XmlArrayItem("businessLibraryName")]
        public List<String> BusinessLibraryNames
        {
            get { return _BusinessLibraryNames; }
            set { _BusinessLibraryNames = value; }
        }

        /// <summary>
        /// Message of this instance.
        /// </summary>
        [XmlElement("message")]
        public ContactMessage Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        #endregion


        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Initiliazes a new instance of the MessageSettingsCase class.
        /// </summary>
        public MessageSettingsCase()
        {
        }

        #endregion

    }
}
