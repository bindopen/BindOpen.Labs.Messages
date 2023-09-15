using BindOpen.Kernel.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BindOpen.Plus.Messages.Email.Connectors
{

    /// <summary>
    /// This class defines a email connector.
    /// </summary>
    public class BdoSmtpConnection : BdoEmailConnection
    {
        private SmtpClient _client;

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoSmtpConnection class.
        /// </summary>
        public BdoSmtpConnection(BdoSmtpConnector connector) : base(connector)
        {
            if (connector != null)
            {
                _client = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = connector.IsSslEnabled == true,
                    Host = connector.Host,
                    Port = connector.Port ?? -1,
                    Timeout = connector.Timeout ?? -1,
                    UseDefaultCredentials = connector.IsDefaultCredentialsUsed == true
                };
                if (!string.IsNullOrEmpty(connector.Login) && !string.IsNullOrEmpty(connector.Password))
                {
                    _client.Credentials = new NetworkCredential(
                        connector.Login,
                        connector.Password);
                }
            }
        }

        #endregion

        public override void Connect(IBdoLog log = null)
        {
        }

        public override void Disconnect(IBdoLog log = null)
        {
        }


        public override Task<IEnumerable<IBdoSendingMessage>> ReceiveMessagesAsync(IBdoLog log = null)
        {
            return Task.FromResult(Enumerable.Empty<IBdoSendingMessage>());
        }

        public override async Task SendMessageAsync(IBdoSendingMessage message, IBdoLog log = null)
        {
            var mailMessage = message.ToMail();

            await _client?.SendMailAsync(mailMessage);
        }
    }
}
