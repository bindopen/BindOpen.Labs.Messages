using BindOpen.Data.Items;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace BindOpen.Messages.Data.Settings
{

    /// <summary>
    /// This class represents the settings of message.
    /// </summary>
    [XmlType("MessageSettings", Namespace = "https://docs.bindopen.org/xsd")]
    [XmlRoot(ElementName = "basicMessageSettings", Namespace = "https://docs.bindopen.org/xsd", IsNullable = false)]
    public class MessageSettings : DataItem
    {

        // ------------------------------------------
        // VARIABLES
        // ------------------------------------------

        #region Variables

        private string _Id;
        private List<MessageSettingsCase> _Cases;

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
        /// Cases of this instance.
        /// </summary>
        [XmlArray("cases")]
        [XmlArrayItem("case")]
        public List<MessageSettingsCase> Cases
        {
            get { return _Cases; }
            set { _Cases = value; }
        }

        #endregion


        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors

        /// <summary>
        /// Returns the message settings case with the specified ID.
        /// </summary>
        /// <param name="id">ID of the message settings case to return.</param>
        /// <returns>The message settings case with the specified ID.</returns>
        public MessageSettingsCase GetCaseWithId(String id)
        {
            if (_Cases != null)
                foreach (MessageSettingsCase aMessageSettingsCase in _Cases)
                {
                    if (aMessageSettingsCase.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                        return aMessageSettingsCase;
                }
            return null;
        }

        #endregion
    }
}
