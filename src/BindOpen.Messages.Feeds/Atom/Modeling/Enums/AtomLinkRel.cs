using System.Xml.Serialization;

namespace BindOpen.Messages.Feeds.Atom
{
    /// <summary>
    /// This class represents an Atom link relation.
    /// </summary>
    [XmlType("AtomLinkRel", Namespace = "http://www.w3.org/2005/Atom")]
    public enum AtomLinkRel
    {
        /// <summary>
        /// An alternate representation of the entry or feed, for example a permalink to the html version of the entry, or the front page of the weblog.
        /// </summary>
        alternate,

        /// <summary>
        /// A related resource which is potentially large in size and might require special handling, for example an audio or video recording.
        /// </summary>
        enclosure,

        /// <summary>
        /// An document related to the entry or feed.
        /// </summary>
        related,

        /// <summary>
        /// The feed itself.
        /// </summary>
        self,

        /// <summary>
        /// The source of the information provided in the entry.
        /// </summary>
        via
    }
}
