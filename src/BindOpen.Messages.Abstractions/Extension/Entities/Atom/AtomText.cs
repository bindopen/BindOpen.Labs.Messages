using System.ComponentModel;
using System.Xml.Serialization;
using BindOpen.Data.Items;

namespace BindOpen.Messages.Extension.Entities.Atom
{
    /// <summary>
    /// This class represents an Atom text.
    /// </summary>
    [XmlType("AtomText", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomText : DataItem
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Type of this instance.
        /// </summary>
        [XmlAttribute("type")]
        [DefaultValue(AtomTextType.text)]
        public AtomTextType Type { get; set; } = AtomTextType.text;

        /// <summary>
        /// Specification of the Type property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool TypeSpecified => Type != AtomTextType.text;

        /// <summary>
        /// Value of this instance.
        /// </summary>
        [XmlText()]
        public string Value { get; set; } = null;

        /// <summary>
        /// Specification of the Value property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool ValueSpecified => !string.IsNullOrEmpty(Value);

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AtomText class.
        /// </summary>
        public AtomText()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomText class.
        /// </summary>
        public AtomText(
            AtomTextType type,
            string value)
        {
            Type = type;
            Value = value;
        }

        #endregion
    }
}
