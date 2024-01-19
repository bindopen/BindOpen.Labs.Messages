using BindOpen.Data;
using BindOpen.Data.Meta;
using BindOpen.Logging;
using BindOpen.Scoping.Connectors;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BindOpen.Messages.Email.Connectors
{

    /// <summary>
    /// This class defines a email connector.
    /// </summary>
    public class BdoSmtpConnection : BdoConnection, ITBdoConnection<IBdoSendingMessage>
    {
        private SmtpClient _client;

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoSmtpConnection class.
        /// </summary>
        public BdoSmtpConnection(BdoSmtpConnector connector) : base()
        {
            Connector = connector;

            if (connector != null)
            {
                _client = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = connector.IsSslEnabled == true,
                    Host = connector.Host,
                    Port = connector.Port ?? 0,
                    Timeout = connector.Timeout ?? 0,
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

        // Pull

        IEnumerable<IBdoSendingMessage> ITBdoConnection<IBdoSendingMessage>.Pull(IBdoMetaSet paramSet, IBdoLog log)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IBdoSendingMessage>> PullAsync(IBdoMetaSet paramSet = null, IBdoLog log = null)
        {
            throw new System.NotImplementedException();
        }

        // Push

        public IEnumerable<IResultItem> Push(IBdoLog log, params IBdoSendingMessage[] messages)
        {
            var results = new List<IResultItem>();

            foreach (var message in messages)
            {
                var mailMessage = message.ToMail(log);

                var status = ResourceStatus.None;

                if (mailMessage != null)
                {
                    try
                    {
                        _client?.Send(mailMessage);
                        status = ResourceStatus.Created;
                    }
                    catch (Exception ex)
                    {
                        log?.AddEvent(EventKinds.Exception, "Could not send email", ex.ToString());
                    }
                }

                results.Add(BdoData.NewResultItem(message.Id, status));
            }

            return results;
        }

        public async Task<IEnumerable<IResultItem>> PushAsync(IBdoLog log = null, params IBdoSendingMessage[] messages)
        {
            var results = new List<IResultItem>();

            foreach (var message in messages)
            {
                var mailMessage = message.ToMail(log);

                var status = ResourceStatus.None;

                if (mailMessage != null)
                {
                    try
                    {
                        await _client?.SendMailAsync(mailMessage);
                        status = ResourceStatus.Created;
                    }
                    catch (Exception ex)
                    {
                        log?.AddException(ex);
                    }
                }

                results.Add(BdoData.NewResultItem(message.Id, status));
            }

            return results;
        }
    }
}
