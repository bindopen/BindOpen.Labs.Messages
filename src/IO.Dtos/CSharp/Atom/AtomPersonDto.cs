using BindOpen.Kernel;
using System.Xml.Serialization;

namespace BindOpen.Plus.Messages.Atom
{
    /// <summary>
    /// This class represents an Atom person.
    /// </summary>
    [XmlType("AtomPerson", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomPersonDto : IBdoDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Conveys a human-readable name for the person.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Contains a home page for the person.
        /// </summary>
        [XmlElement("uri")]
        public string Uri { get; set; } = null;

        /// <summary>
        /// Specification of the Scheme property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool UriSpecified => !string.IsNullOrEmpty(Uri);

        /// <summary>
        /// Contains an email address for the person.
        /// </summary>
        [XmlAttribute("email")]
        public string Email { get; set; } = null;

        /// <summary>
        /// Specification of the Label property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool EmailSpecified => !string.IsNullOrEmpty(Email);

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AtomPerson class.
        /// </summary>
        public AtomPersonDto()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomPerson class.
        /// </summary>
        public AtomPersonDto(
            string name,
            string uri = null,
            string email = null)
        {
            Name = name;
            Uri = uri;
            Email = email;
        }

        #endregion
    }
}
