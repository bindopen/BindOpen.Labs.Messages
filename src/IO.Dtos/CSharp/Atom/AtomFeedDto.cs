using BindOpen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace BindOpen.Messages.Atom
{
    /// <summary>
    /// This class represents a Feed channel.
    /// </summary>
    [XmlType("AtomFeed", Namespace = "http://www.w3.org/2005/Atom")]
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom", IsNullable = false)]
    public class AtomFeedDto : IBdoDto, IIdentified, IReferenced
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Id of this instance.
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Title of this instance.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Last modification date of this instance.
        /// </summary>
        [XmlElement("updated")]
        public string LastModificationDate { get; set; } = null;

        /// <summary>
        /// Icon of this instance.
        /// </summary>
        [XmlElement("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Specification of the Icon property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool IconSpecified => !string.IsNullOrEmpty(Icon);

        /// <summary>
        /// Logo of this instance.
        /// </summary>
        [XmlElement("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// Specification of the Logo property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool LogoSpecified => !string.IsNullOrEmpty(Logo);

        /// <summary>
        /// Entries of this instance.
        /// </summary>
        [XmlArray("entries")]
        [XmlArrayItem("entry")]
        public List<AtomFeedEntryDto> Entries { get; set; }

        /// <summary>
        /// Specification of the Entries property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool EntriesSpecified => Entries != null && Entries.Count > 0;

        /// <summary>
        /// Author of this instance.
        /// </summary>
        [XmlElement("author")]
        public AtomPersonDto Author { get; set; }

        /// <summary>
        /// Specification of the Author property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool AuthorSpecified => Author != null;

        /// <summary>
        /// Link of this instance.
        /// </summary>
        [XmlElement("link")]
        public AtomLinkDto Link { get; set; }

        /// <summary>
        /// Specification of the Link property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool LinkSpecified => Link != null;

        /// <summary>
        /// Category of this instance.
        /// </summary>
        [XmlElement("category")]
        public AtomCategoryDto Category { get; set; }

        /// <summary>
        /// Specification of the Category property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool CategorySpecified => Category != null;

        /// <summary>
        /// Contributor of this instance.
        /// </summary>
        [XmlElement("contributor")]
        public AtomPersonDto Contributor { get; set; }

        /// <summary>
        /// Specification of the Contributor property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool ContributorSpecified => Contributor != null;

        /// <summary>
        /// Generator of this instance.
        /// </summary>
        [XmlElement("generator")]
        public AtomGeneratorDto Generator { get; set; }

        /// <summary>
        /// Specification of the Generator property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool GeneratorSpecified => Generator != null;

        /// <summary>
        /// Logo of this instance.
        /// </summary>
        [XmlElement("rights")]
        public AtomTextDto Rights { get; set; }

        /// <summary>
        /// Specification of the Rights property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool RightsSpecified => Rights != null;

        /// <summary>
        /// Sub title of this instance.
        /// </summary>
        [XmlElement("subtitle")]
        public AtomTextDto SubTitle { get; set; }

        /// <summary>
        /// Specification of the SubTitle property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool SubTitleSpecified => SubTitle != null;

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AtomFeed class.
        /// </summary>
        public AtomFeedDto()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomFeed class.
        /// </summary>
        /// <param name="id">The ID to consider.</param>
        /// <param name="title">The title to consider.</param>
        /// <param name="lastModificationDate">The last modification date to consider.</param>
        /// <param name="entries">The entry items to consider.</param>
        public AtomFeedDto(
            string id,
            string title,
            DateTime? lastModificationDate = null,
            params AtomFeedEntryDto[] entries)
        {
            Id = id;
            Title = title;
            LastModificationDate = (lastModificationDate ?? (DateTime?)DateTime.Now).ToString();
            Entries = entries?.ToList();
        }

        #endregion

        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Gets the key of this instance.
        /// </summary>
        /// <returns>Returns the key of this instance.</returns>
        public string Key() => Id;

        #endregion
    }
}
