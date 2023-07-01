using System.Xml.Serialization;

namespace BindOpen.Messages.Emails.Connectors.imap
{
    /// <summary>
    /// This class represents a Imap connection configuration.
    /// </summary>
    public class ConnectionParameterStatement_Imap : DataSource
    {

        // -----------------------------------------------
        // PROPERTIES
        // -----------------------------------------------

        #region Properties

        /// <summary>
        /// The host of the remote server.
        /// </summary>
        [XmlElement("host")]
        public string Host
        {
            get
            {
                return this.Detail.GetElementStringValue("Host");
            }
        }

        /// <summary>
        /// Login of this instance.
        /// </summary>
        [XmlElement("login")]
        public string Login
        {
            get
            {
                return this.Detail.GetElementStringValue("Login");
            }
        }

        /// <summary>
        /// Password of this instance.
        /// </summary>
        [XmlElement("password")]
        public string Password
        {
            get
            {
                return this.Detail.GetElementStringValue("Password");
            }
        }

        /// <summary>
        /// Port of this instance.
        /// </summary>
        [XmlElement("port")]
        public int Port
        {
            get
            {
                return (int)this.Detail.GetElementValue("Port");
            }
        }

        /// <summary>
        /// Indicates whether this instance enables SSL.
        /// </summary>
        [XmlElement("isSslEnabled")]
        public bool IsSslEnabled
        {
            get
            {
                return (bool)this.Detail.GetElementValue("IsSslEnabled");
            }
        }

        /// <summary>
        /// Indicates whether this instance uses the default credentials.
        /// </summary>
        [XmlElement("isDefaultCredentialsUsed")]
        public bool IsDefaultCredentialsUsed
        {
            get
            {
                return (bool)this.Detail.GetElementValue("IsDefaultCredentialsUsed");
            }
        }

        /// <summary>
        /// Time out of this instance.
        /// </summary>
        [XmlElement("timeout")]
        public int Timeout
        {
            get
            {
                return (int)this.Detail.GetElementValue("Timeout");
            }
        }

        #endregion


        // -----------------------------------------------
        // CONSTRUCTORS
        // -----------------------------------------------

        #region Constructors

        /// <summary>
        /// This instantiates a new instance of the ConnectionParameterStatementDefinition_Imap class.
        /// </summary>
        public ConnectionParameterStatement_Imap()
            : base()
        {
        }

        /// <summary>
        /// This instantiates a new instance of the ConnectionParameterStatementDefinition_Imap class.
        /// </summary>
        /// <param name="aConnectionParameterStatement">The connection configuration to consider.</param>
        public ConnectionParameterStatement_Imap(DataSource aConnectionParameterStatement)
            : base(aConnectionParameterStatement)
        {
        }

        #endregion
    }
}
