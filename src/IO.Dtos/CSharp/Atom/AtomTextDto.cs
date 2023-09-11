using BindOpen.Kernel;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BindOpen.Labs.Messages.Atom
{
    /// <summary>
    /// This class represents an Atom text.
    /// </summary>
    [XmlType("AtomText", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomTextDto : IBdoDto
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
        public AtomTextDto()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomText class.
        /// </summary>
        public AtomTextDto(
            AtomTextType type,
            string value)
        {
            Type = type;
            Value = value;
        }

        #endregion
    }
}
