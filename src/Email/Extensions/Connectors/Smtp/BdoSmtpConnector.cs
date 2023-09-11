using BindOpen.Kernel.Data.Meta;
using BindOpen.Kernel.Logging;
using BindOpen.Kernel.Scoping;
using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Labs.Messages.Email.Connectors
{
    /// <summary>
    /// This class represents a SMTP email connector.
    /// </summary>
    [BdoConnector("messages$smtp")]
    public class BdoSmtpConnector : BdoEmailConnector
    {
        // -----------------------------------------------
        // PROPERTIES
        // -----------------------------------------------

        #region Properties

        /// <summary>
        /// The host of this instance.
        /// </summary>
        [BdoProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Indicates whether this instance enables SSL.
        /// </summary>
        [BdoProperty("isSslEnabled")]
        public bool? IsSslEnabled { get; set; }

        /// <summary>
        /// The port of this instance.
        /// </summary>
        [BdoProperty("port")]
        public int? Port { get; set; }

        /// <summary>
        /// The timeout of this instance.
        /// </summary>
        [BdoProperty("timeout")]
        public int? Timeout { get; set; }

        /// <summary>
        /// Indicates whether this instance uses default credentials.
        /// </summary>
        [BdoProperty("isDefaultCredentialsUsed")]
        public bool? IsDefaultCredentialsUsed { get; set; }

        /// <summary>
        /// The login of this instance.
        /// </summary>
        [BdoProperty("login")]
        public string Login { get; set; }

        /// <summary>
        /// The password of this instance.
        /// </summary>
        [BdoProperty("password")]
        public string Password { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoSmtpEmailConnector class.
        /// </summary>
        public BdoSmtpConnector() : base()
        {
        }

        #endregion

        public override IBdoConnection NewConnection(IBdoLog log = null) => new BdoSmtpConnection(this);
    }
}
