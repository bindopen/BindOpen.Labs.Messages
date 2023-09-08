using System.Xml.Serialization;
using BindOpen.Data.Items;

namespace BindOpen.Messages.Extension.Entities.Atom
{
    /// <summary>
    /// This class represents a Atom content.
    /// </summary>
    [XmlType("AtomContent", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomContent : DataItem
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Source of this instance.
        /// </summary>
        [XmlAttribute("src")]
        public string Source { get; set; }

        /// <summary>
        /// Specification of the Source property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool SourceSpecified => !string.IsNullOrEmpty(Source);

        /// <summary>
        /// Type of this instance.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; } = null;

        /// <summary>
        /// Specification of the Type property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool TypeSpecified => !string.IsNullOrEmpty(Type);

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
        /// Creates a new instance of the AtomContent class.
        /// </summary>
        public AtomContent()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomContent class.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public AtomContent(
            string type,
            string value)
        {
            Type= type;
            Value = value;
        }

        #endregion
    }
}
