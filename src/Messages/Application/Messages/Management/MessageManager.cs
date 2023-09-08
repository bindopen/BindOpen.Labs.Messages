using System;
using System.Collections.Generic;
using BindOpen.Framework.Core.Data.Business.Contacts;
using BindOpen.Framework.Core.System.Diagnostics;

namespace BindOpen.Framework.Labs.Messages.Application.Messages.Senders
{
    /// <summary>
    /// This class represents the manager of messages.
    /// </summary>
    public class MessageManager
    {
        // --------------------------------------
        // VARIABLES
        // --------------------------------------

        #region Variables

        private SphereApplicationManager _ApplicationManager;

        #endregion

        // --------------------------------------
        // CONSTRUCTORS
        // --------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MessageManager class.
        /// </summary>
        /// <param name="applicationManager">The application manager.</param>
        public MessageManager(SphereApplicationManager applicationManager)
        {
            this._ApplicationManager = applicationManager;
        }

        #endregion

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="deliveryMethods">The delivery methods used to send the message.</param>
        /// <param name="maxTryNumber">The number of maximum tries. -1 is unlimited.</param>
        /// <returns>The log of task.</returns>
        public Log Send(Message message,
            List<MessageSendRequestDeliveryMethod> deliveryMethods,
            int maxTryNumber =1)
        {
            Log log = new Log();

            try
            {
                // we create a new send request via sending pool
                MessageSendRequest poolSendingMessageSendRequest = new MessageSendRequest(this._ApplicationManager);
                poolSendingMessageSendRequest.Message = message;
                poolSendingMessageSendRequest.MaxTryNumber = maxTryNumber;

                // we create a new send request for direct sending
                MessageSendRequest directMessageSendRequest = new MessageSendRequest(this._ApplicationManager);
                directMessageSendRequest.Message = message;
                directMessageSendRequest.MaxTryNumber = maxTryNumber;

                // we feach the delivery methods
                foreach (MessageSendRequestDeliveryMethod currentDeliveryMethod in deliveryMethods)
                {
                    // if the To Mode of the current method is to all then
                    if (currentDeliveryMethod.ToMode == MessageSendRequestDeliveryMethod.MessageSendToMode.ToAll)
                    {
                        // we create a delivery for all the user contacts
                        MessageSendRequestDelivery requestDelivery = new MessageSendRequestDelivery();
                        requestDelivery.Method = currentDeliveryMethod;
                        requestDelivery.Status = DeliveryStatus.Queueing;
                        foreach (Contact currentContact in message.To)
                            requestDelivery.ContactTo.Add(currentContact);
                        foreach (Contact aCurrentContact in message.Cc)
                            requestDelivery.ContactTo.Add(aCurrentContact);
                        foreach (Contact aCurrentContact in message.Bcc)
                            requestDelivery.ContactTo.Add(aCurrentContact);
                        if (currentDeliveryMethod.Mode == MessageSendRequestDeliveryMethod.MessageSendMode.Direct)
                            directMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                        else
                            poolSendingMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                    }
                    else
                    {
                        // else we create a delivery for each user contact
                        foreach (Contact currentContact in message.To)
                        {
                            MessageSendRequestDelivery requestDelivery = new MessageSendRequestDelivery();
                            requestDelivery.Method = currentDeliveryMethod;
                            requestDelivery.Status = DeliveryStatus.Queueing;
                            requestDelivery.ContactTo.Add(currentContact);
                            if (currentDeliveryMethod.Mode == MessageSendRequestDeliveryMethod.MessageSendMode.Direct)
                                directMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                            else
                                poolSendingMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                        }
                        foreach (Contact aCurrentContact in message.Cc)
                        {
                            MessageSendRequestDelivery requestDelivery = new MessageSendRequestDelivery();
                            requestDelivery.Method = currentDeliveryMethod;
                            requestDelivery.Status = DeliveryStatus.Queueing;
                            requestDelivery.ContactTo.Add(aCurrentContact);
                            if (currentDeliveryMethod.Mode == MessageSendRequestDeliveryMethod.MessageSendMode.Direct)
                                directMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                            else
                                poolSendingMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                        }
                        foreach (Contact aCurrentContact in message.Bcc)
                        {
                            MessageSendRequestDelivery requestDelivery = new MessageSendRequestDelivery();
                            requestDelivery.Method = currentDeliveryMethod;
                            requestDelivery.Status = DeliveryStatus.Queueing;
                            requestDelivery.ContactTo.Add(aCurrentContact);
                            if (currentDeliveryMethod.Mode == MessageSendRequestDeliveryMethod.MessageSendMode.Direct)
                                directMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                            else
                                poolSendingMessageSendRequest.SendRequestDeliveries.Add(requestDelivery);
                        }
                    }
                }

                // we deal with direct sending requests
                foreach (MessageSendRequestDelivery currentMessageSendRequestDelivery in directMessageSendRequest.SendRequestDeliveries)
                    if ((directMessageSendRequest.MaxTryNumber==-1)||(directMessageSendRequest.MaxTryNumber>0))
                    {
                        Log aSubLog = this.Execute(message, currentMessageSendRequestDelivery);
                        log.Append(aSubLog, p => p.HasErrorsOrExceptions());
                        if (aSubLog.Execution.ResultLevel != 10)
                            poolSendingMessageSendRequest.SendRequestDeliveries.Add(currentMessageSendRequestDelivery);
                    }

                // we deal with direct sending pool requests
                if (poolSendingMessageSendRequest.SendRequestDeliveries.Count > 0)
                    log.Append(this.AddToSendingPool(poolSendingMessageSendRequest));
            }
            catch (Exception ex)
            {
                log.AddException(ex);
            }

            return log;
        }

        /// <summary>
        /// Executes the specified message send request.
        /// </summary>
        /// <param name="simpleMessage">The simple message to send.</param>
        /// <param name="requestDelivery">The message delivery to consider.</param>
        /// <returns>The log of task.</returns>
        public Log Execute(
            BasicMessage simpleMessage,
            MessageSendRequestDelivery requestDelivery)
        {
            Log log = new Log();
            log.Execution = new ProcessExecution();

            try
            {
                // according to the send request kind we use the relevant message sender
                MessageSender messageSender;
                switch (requestDelivery.Method.Media)
                {
                    //case MessageSendRequestDeliveryMethod.MessageSendMedia.Internal_FromCentral:
                    //    // Send internal message.
                    //    messageSender = new MessageSender_InternalFromCentral(this._ApplicationManager);
                    //    log.Execution.ResultLevel =
                    //        (messageSender.Send(
                    //            message,
                    //            requestDelivery)).Execution.ResultLevel;
                    //    break;
                    case MessageSendRequestDeliveryMethod.MessageSendMedia.Email:
                        // Send email message.
                        messageSender = new MessageSender_Email(this._ApplicationManager);
                        log.Execution.ResultLevel =
                            (messageSender.Send(
                                simpleMessage,
                                requestDelivery)).Execution?.ResultLevel ?? 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                log.AddException(ex);
            }

            return log;
        }

        /// <summary>
        /// Executes the specified message send request.
        /// </summary>
        /// <param name="messageSendRequest">The message send request to execute.</param>
        /// <returns>The log of task.</returns>
        public Log Execute(
            MessageSendRequest messageSendRequest)
        {
            Log log = new Log();

            try
            {
                Boolean isExecutionResultLevelGood = true;

                // we feach the send request deliveries.
                foreach (MessageSendRequestDelivery currentMessageSendRequestDelivery in
                    messageSendRequest.SendRequestDeliveries)
                        isExecutionResultLevelGood &=
                            (this.Execute(messageSendRequest.Message,
                                currentMessageSendRequestDelivery)).Execution.ResultLevel==10;

                if (isExecutionResultLevelGood)
                    log.Execution.ResultLevel = 10;
            }
            catch (Exception ex)
            {
                log.AddException(ex);
            }

            return log;
        }

        /// <summary>
        /// Executes the specified message send request.
        /// </summary>
        /// <param name="messageSendRequest">The message send request.</param>
        /// <returns>The log of task.</returns>
        public Log AddToSendingPool(MessageSendRequest messageSendRequest)
        {
            Log log = new Log();

            // we save the send request log
            messageSendRequest.SaveXml();

            // we create the message sending request in database
            ConnectionManager connectionManager;
            if (this._SessionManager != null)
                connectionManager = this._SessionManager.ConnectionManager;
            else
                connectionManager = new ConnectionManager(this._ApplicationManager.AppScope);

            connectionManager.Open<DatabaseConnection>("platform.bdd", null, log).Using(
                (connection) =>
                {
                    //DbDataQuery dbDataQuery= DataQueryDefinition_standard.GetDbDataQuery_InsertMessageSendingRequest(
                    //    messageSendRequest.GetFilePath(),
                    //    messageSendRequest.MaxTryNumber,
                    //    DeliveryStatus.Queueing.ToString());

                    //log.Append(aDatabaseConnector.ExecuteNonQuery(dbDataQuery));
                });

            return log;
        }
    }
}
