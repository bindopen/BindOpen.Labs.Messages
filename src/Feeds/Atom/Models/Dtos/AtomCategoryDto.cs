using BindOpen.Data;
using System.Xml.Serialization;

namespace BindOpen.Labs.Messages.Feeds.Atom
{
    /// <summary>
    /// This class represents an Atom category.
    /// </summary>
    [XmlType("AtomCategory", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomCategoryDto : IBdoDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Identifies the category.
        /// </summary>
        [XmlAttribute("term")]
        public string Term { get; set; }

        /// <summary>
        /// Identifies the categorization scheme via a URI.
        /// </summary>
        [XmlAttribute("scheme")]
        public string Scheme { get; set; } = null;

        /// <summary>
        /// Specification of the Scheme property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool SchemeSpecified => !string.IsNullOrEmpty(Scheme);

        /// <summary>
        /// Provides a human-readable label for display.
        /// </summary>
        [XmlAttribute("label")]
        public string Label { get; set; } = null;

        /// <summary>
        /// Specification of the Label property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool LabelSpecified => !string.IsNullOrEmpty(Label);

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AtomCategory class.
        /// </summary>
        public AtomCategoryDto()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomCategory class.
        /// </summary>
        /// <param name="term"></param>
        /// <param name="scheme"></param>
        /// <param name="label"></param>
        public AtomCategoryDto(
            string term,
            string scheme = null,
            string label = null)
        {
            Term = term;
            Scheme = scheme;
            Label = label;
        }

        #endregion
    }
}
