using BindOpen.Data;
using System;
using System.Xml.Serialization;

namespace BindOpen.Messages.Atom;

/// <summary>
/// This class represents an Atom source.
/// </summary>
[XmlType("AtomSource", Namespace = "http://www.w3.org/2005/Atom")]
public class AtomSourceDto : IBdoDto, IIdentified
{
    // ------------------------------------------
    // PROPERTIES
    // ------------------------------------------

    #region Properties

    /// <summary>
    /// Id of this instance.
    /// </summary>
    [XmlElement("id")]
    public string Identifier { get; set; }

    /// <summary>
    /// Specification of the Id property of this instance.
    /// </summary>
    [XmlIgnore()]
    public bool IdSpecified => !string.IsNullOrEmpty(Identifier);

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
    /// Last modification date of this instance.
    /// </summary>
    [XmlElement("updated")]
    public string LastModificationDate { get; set; } = null;

    /// <summary>
    /// Specification of the LastModificationDate property of this instance.
    /// </summary>
    [XmlIgnore()]
    public bool LastModificationDateSpecified => LastModificationDate != null;

    #endregion

    // ------------------------------------------
    // CONSTRUCTORS
    // ------------------------------------------

    #region Constructors

    /// <summary>
    /// Creates a new instance of the AtomSource class.
    /// </summary>
    public AtomSourceDto()
    {
    }

    /// <summary>
    /// Creates a new instance of the AtomSource class.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="lastModificationDate"></param>
    public AtomSourceDto(
        string id,
        string title,
        DateTime? lastModificationDate)
    {
        Identifier = id;
        Title = title;
        LastModificationDate = lastModificationDate?.ToString();
    }

    #endregion
}
