namespace BindOpen.Messages.Email;

/// <summary>
/// This enumeration lists all the possible kinds of email connectors.
/// </summary>
public enum EmailConnectorKind
{
    /// <summary>
    /// None.
    /// </summary>
    None,

    /// <summary>
    /// Pop3.
    /// </summary>
    Pop3,

    /// <summary>
    /// Smtp.
    /// </summary>
    Smtp,

    /// <summary>
    /// Imap.
    /// </summary>
    Imap
}
