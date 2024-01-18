using BindOpen.Data;
using System.Xml.Serialization;

namespace BindOpen.Messages.Atom
{
    /// <summary>
    /// This class represents an Atom generator.
    /// </summary>
    [XmlType("AtomGenerator", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomGeneratorDto : IBdoDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Uri of this instance.
        /// </summary>
        [XmlAttribute("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Specification of the Uri property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool UriSpecified => !string.IsNullOrEmpty(Uri);

        /// <summary>
        /// Version of this instance.
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; } = null;

        /// <summary>
        /// Specification of the Version property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool VersionSpecified => !string.IsNullOrEmpty(Version);

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
        /// Creates a new instance of the AtomGenerator class.
        /// </summary>
        public AtomGeneratorDto()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomGenerator class.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="version"></param>
        /// <param name="value"></param>
        public AtomGeneratorDto(
            string uri,
            string version,
            string value)
        {
            Uri = uri;
            Version = version;
            Value = value;
        }

        #endregion
    }
}
