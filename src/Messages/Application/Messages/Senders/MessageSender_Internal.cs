using BindOpen.Core.System.Diagnostics;
using meltingSoft.Flow.Messages.Extension.Entities.Messages;
using BindOpen.Runtime.Application.Managers;

namespace meltingSoft.Flow.Platform.Application.Messages.Senders
{
    /// <summary>
    /// This class represents the internal message sender from standard enterprise server.
    /// </summary>
    public class MessageSender_Internal : MessageSender
    {

        // --------------------------------------
        // VARIABLES
        // --------------------------------------

        #region Variables

        private ApplicationManager _ApplicationManager;

        #endregion
        
        
        // --------------------------------------
        // CONSTRUCTORS
        // --------------------------------------

        #region Constructors

        /// <summary>
        /// This initializes a new instance of the MessageSender_InternalFromStandard class.
        /// </summary>
        /// <param name="applicationManager">The application manager.</param>
        public MessageSender_Internal(ApplicationManager applicationManager)
        {
            this._ApplicationManager = applicationManager;
        }

        #endregion


        // --------------------------------------
        // SENDING
        // --------------------------------------

        #region Sending

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The simple message to send.</param>
        /// <param name="requestDelivery">The send request delivery to use.</param>
        /// <returns>The log of task.</returns>
        public override Log Send(
            BasicMessage message,
            MessageSendRequestDelivery requestDelivery)
        {
            Log log = new Log();

            // we update the execution result level?
            log.Execution.ResultLevel = 10;

            // <-- we call the web servie -->


            return log;
        }

        #endregion

    }
}
