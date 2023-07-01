using BindOpen.Data.Common;
using BindOpen.Data.Helpers.Strings;
using BindOpen.Data.Items;
using System;
using System.Xml.Serialization;

namespace BindOpen.Messages.Extension.Entities.Atom
{
    /// <summary>
    /// This class represents a Atom feed entry.
    /// </summary>
    [XmlType("AtomFeedEntry", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomFeedEntry : DataItem, IIdentified, IReferenced
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
        /// Specification of the Title property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool TitleSpecified => !string.IsNullOrEmpty(Title);

        /// <summary>
        /// Contributor of this instance.
        /// </summary>
        [XmlElement("published")]
        public string PublicationDate { get; set; }

        /// <summary>
        /// Last modification date of this instance.
        /// </summary>
        [XmlElement("updated")]
        public string LastModificationDate { get; set; } = null;

        /// <summary>
        /// Author of this instance.
        /// </summary>
        [XmlElement("author")]
        public AtomPerson Author { get; set; }

        /// <summary>
        /// Specification of the Author property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool AuthorSpecified => Author != null;

        /// <summary>
        /// Content of this instance.
        /// </summary>
        [XmlElement("content")]
        public AtomContent Content { get; set; }

        /// <summary>
        /// Specification of the Content property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool ContentSpecified => Content != null;

        /// <summary>
        /// Link of this instance.
        /// </summary>
        [XmlElement("link")]
        public AtomLink Link { get; set; }

        /// <summary>
        /// Specification of the Link property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool LinkSpecified => Link != null;

        /// <summary>
        /// Summary of this instance.
        /// </summary>
        [XmlElement("summary")]
        public AtomText Summary { get; set; }

        /// <summary>
        /// Specification of the Summary property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool SummarySpecified => Summary != null;

        /// <summary>
        /// Category of this instance.
        /// </summary>
        [XmlElement("category")]
        public AtomCategory Category { get; set; }

        /// <summary>
        /// Specification of the Category property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool CategorySpecified => Category != null;

        /// <summary>
        /// Contributor of this instance.
        /// </summary>
        [XmlElement("contributor")]
        public AtomPerson Contributor { get; set; }

        /// <summary>
        /// Specification of the Contributor property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool ContributorSpecified => Contributor != null;

        /// <summary>
        /// Logo of this instance.
        /// </summary>
        [XmlElement("rights")]
        public AtomText Rights { get; set; }

        /// <summary>
        /// Specification of the Rights property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool RightsSpecified => Rights != null;

        /// <summary>
        /// Source of this instance.
        /// </summary>
        [XmlElement("source")]
        public AtomSource Source { get; set; }

        /// <summary>
        /// Specification of the Source property of this instance.
        /// </summary>
        [XmlIgnore()]
        public bool SourceSpecified => Source != null;

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AtomFeedEntry class.
        /// </summary>
        public AtomFeedEntry()
        {
        }

        /// <summary>
        /// Creates a new instance of the AtomFeedEntry class.
        /// </summary>
        public AtomFeedEntry(
            string id,
            string title,
            DateTime? lastModificationDate = null,
            DateTime? publicationDate = null)
        {
            Id = id;
            Title = title;
            LastModificationDate = StringHelper.ToString(lastModificationDate ?? (DateTime?)DateTime.Now);
            PublicationDate = StringHelper.ToString(publicationDate ?? (DateTime?)DateTime.Now);
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
