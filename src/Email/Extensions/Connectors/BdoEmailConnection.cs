using BindOpen.Kernel.Logging;
using BindOpen.Kernel.Scoping.Connectors;
using BindOpen.Plus.Messages.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BindOpen.Plus.Messages.Email.Connectors
{

    /// <summary>
    /// This class defines a email connector.
    /// </summary>
    public abstract class BdoEmailConnection : BdoConnection, IBdoEmailConnection
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoEmailConnection class.
        /// </summary>
        protected BdoEmailConnection(IBdoConnector connector) //: base(connector)
        {
            Connector = connector;
        }

        #endregion


        public IEnumerable<IBdoSendingMessage> ReceiveMessages(IBdoLog log = null)
        {
            return ReceiveMessagesAsync().Result;
        }

        public abstract Task<IEnumerable<IBdoSendingMessage>> ReceiveMessagesAsync(IBdoLog log = null);

        public void SendMessage(IBdoSendingMessage message, IBdoLog log = null)
        {
            SendMessageAsync(message, log).Wait();
        }

        public abstract Task SendMessageAsync(IBdoSendingMessage message, IBdoLog log = null);

    }
}
