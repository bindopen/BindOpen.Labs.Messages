using BindOpen.Kernel.Data;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BindOpen.Labs.Messages.Feeds.Atom
{
    /// <summary>
    /// This class represents an atom link.
    /// </summary>
    [XmlType("AtomLink", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomLinkDto : IBdoDto
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Href of this instance.
        /// </summary>
        [XmlAttribute("href")]
        public string Href { get; set; }

        /// <summary>
        /// Rel of this instance.
        /// </summary>
        [XmlAttribute("rel")]
        [DefaultValue(AtomLinkRel.alternate)]
        public AtomLinkRel Rel { get; set; } = AtomLinkRel.alternate;

        /// <summary>
        /// Specification of the Rel property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool RelSpecified => Rel != AtomLinkRel.alternate;

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
        /// indicates the language of the referenced resource.
        /// </summary>
        [XmlAttribute("hreflang")]
        public string Hreflang { get; set; }

        /// <summary>
        /// Specification of the Hreflang property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool HreflangSpecified => !string.IsNullOrEmpty(Hreflang);

        /// <summary>
        /// Title of this instance.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// Specification of the Title property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool TitleSpecified => !string.IsNullOrEmpty(Title);

        /// <summary>
        /// Length of this instance.
        /// </summary>
        [XmlAttribute("length")]
        public byte Length { get; set; }

        /// <summary>
        /// Specification of the Length property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool LengthSpecified => Length > 0;

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AtomLink class.
        /// </summary>
        public AtomLinkDto()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomLink class.
        /// </summary>
        /// <param name="href"></param>
        /// <param name="rel"></param>
        /// <param name="type"></param>
        /// <param name="hreflang"></param>
        /// <param name="title"></param>
        /// <param name="length"></param>
        public AtomLinkDto(
            string href,
            AtomLinkRel rel = AtomLinkRel.alternate,
            string type = null,
            string hreflang = null,
            string title = null,
            byte length = 0)
        {
            Href = href;
            Rel = rel;
            Type = type;
            Hreflang = hreflang;
            Title = title;
            Length = length;
        }

        #endregion
    }
}
