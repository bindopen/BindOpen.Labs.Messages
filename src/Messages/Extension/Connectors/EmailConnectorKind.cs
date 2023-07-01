using System;

namespace BindOpen.Messages.Extension.Connectors
{
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


    // --------------------------------------------------
    // EXTENSION
    // --------------------------------------------------

    #region Extension

    /// <summary>
    /// This class represents an extension of the EmailConnectorKind enumeration.
    /// </summary>
    public static class EmailConnectorKindExtension
    {
        /// <summary>
        /// Returns the connector unique name corresponding to the specified email connector kind.
        /// </summary>
        /// <param name="aEmailConnectorKind">The email connector kind to consider.</param>
        /// <returns>The result object.</returns>
        public static string GetConnectorKey(this EmailConnectorKind aEmailConnectorKind)
        {
            return "email$" + aEmailConnectorKind.ToString().ToLower();
        }
    }

    #endregion
}
