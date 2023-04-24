using dkm.core.data.application.contacts;
using dkm.core.system.diagnostics;
using dkm.database.data.queries;
using dkm.messages.extension.entities.messages;
using dkm.runtime.application.managers;
using dkm.session.data;
using System;

namespace dkm.platform.classes.messages.senders
{
    /// <summary>
    /// This class represents the internal message sender sent from central enterprise server.
    /// </summary>
    public class BasicMessageSender_InternalFromCentral : BasicMessageSender
    {

        // **************************************
        // VARIABLES
        // **************************************

        #region Variables

        private ApplicationManager myApplicationManager;
        private SessionManager mySessionManager;

        #endregion
        
        
        // **************************************
        // CONSTRUCTORS
        // **************************************

        #region Constructors

        /// <summary>
        /// This initializes a new instance of the BasicMessageSender_InternalFromCentral class.
        /// </summary>
        /// <param name="aApplicationManager">The application manager.</param>
        public BasicMessageSender_InternalFromCentral(ApplicationManager aApplicationManager)
        {
            this.myApplicationManager = aApplicationManager;
        }

        /// <summary>
        /// This initializes a new instance of the BasicMessageSender_InternalFromCentral class.
        /// </summary>
        /// <param name="aSessionManager">The session manager.</param>
        public BasicMessageSender_InternalFromCentral(SessionManager aSessionManager)
        {
            this.mySessionManager = aSessionManager;
            if (this.mySessionManager != null)
                this.myApplicationManager = this.mySessionManager.ApplicationManager;
        }

        #endregion


        // **************************************
        // SENDING
        // **************************************

        #region Sending

        /// <summary>
        /// Sends the specified basic message.
        /// </summary>
        /// <param name="aSimpleBasicMessage">The simple basic message to send.</param>
        /// <param name="aBasicMessageSendRequestDelivery">The send request delivery to use.</param>
        /// <returns>The log of task.</returns>
        public override Log Send(
            SimpleBasicMessage aSimpleBasicMessage,
            BasicMessageSendRequestDelivery aBasicMessageSendRequestDelivery)
        {
            Log aLog = new Log();

            // we update the execution result level?
            aLog.Execution.ResultLevel = 10;

            // we create the message sending request in database
            ConnectionManager aConnectionManager;
            try
            {                
                if (this.mySessionManager != null)
                    aConnectionManager = this.mySessionManager.ConnectionManager;
                else
                    aConnectionManager = new ConnectionManager(this.myApplicationManager.ScriptInterpreter, this.myApplicationManager.DataModuleDictionary);
                if (!aConnectionManager.OpenDataModule("ENT_CENTRAL_DB", BasicConnectionKindName.OleDb).HasErrorOrExceptions())
                {
                    DbDataQuery aDbDataQuery;

                    // we inset a new basic message record
                    aDbDataQuery = DataQueryDefinition_standard.GetDbDataQuery_InsertInternalMessage(
                        aSimpleBasicMessage.From.Id,
                        aSimpleBasicMessage.From.Name,
                        aSimpleBasicMessage.Subject.GetLabel(),
                        aSimpleBasicMessage.Body.GetLabel(),
                        aSimpleBasicMessage.IsBodyHtml,
                        aSimpleBasicMessage.AttachedFiles,
                        aSimpleBasicMessage.Detail);
                    Log aSubLog = aConnectionManager.ExecuteDbDataNonQuery(aDbDataQuery);
                    long aInternalMessageId=-1;
                    aConnectionManager.CurrentConnectionManager.GetIdentity(ref aInternalMessageId);
                    aLog.Append(aSubLog);

                    if (!aLog.HasErrorOrExceptions())
                        foreach (UserContact aCurrentUserContact in aBasicMessageSendRequestDelivery.UserContactTo)
                        {
                            // we inset the send request delivery
                            aDbDataQuery = DataQueryDefinition_standard.GetDbDataQuery_InsertInternalMessageUserRelationship(
                                aInternalMessageId,
                                aCurrentUserContact.Name,
                                aCurrentUserContact.UserId);
                            aLog.Append(aConnectionManager.ExecuteDbDataNonQuery(aDbDataQuery));
                        }
                    aConnectionManager.Close();
                }
            }
            catch (Exception ex)
            {
                aLog.AddException(ex);
            }

            return aLog;
        }

        #endregion

    }
}
