using BindOpen.Core.System.Script;

namespace meltingSoft.Flow.Extensions.Messages.Application.Messages.Management
{
    /// <summary>
    /// This class represents a builder of message.
    /// </summary>
    public class MessageBuilder
    {

        // --------------------------------------
        // ENUMERATIONS
        // --------------------------------------

        #region Enumerations

        /// <summary>
        /// This enumerates all the possible domains of a message.
        /// </summary>
        public enum MessageSettingsDomain
        {
            /// <summary>
            /// Platform.
            /// </summary>
            Platform,
            /// <summary>
            /// Enterprise Content Management.
            /// </summary>
            ECM
        };

        #endregion

        
        // --------------------------------------
        // VARIABLES
        // --------------------------------------

        #region Variables

        private ScriptInterpreter _ScriptInterpreter;

        #endregion


        // --------------------------------------
        // CONSTRUCTORS
        // --------------------------------------

        #region Constructors

        /// <summary>
        /// This initializes a new instance of the MessageBuilder class.
        /// </summary>
        /// <param name="scriptInterpreter">The script interpreter to consider.</param>
        public MessageBuilder(ScriptInterpreter scriptInterpreter)
        {
            this._ScriptInterpreter = scriptInterpreter;
        }

        #endregion


        // --------------------------------------
        // BUILD
        // --------------------------------------

        #region Build

        ///// <summary>
        ///// Builds a message from the specified platform message settings.
        ///// </summary>
        ///// <param name="messageSettingsDomain">The domain of the message settings..</param>
        ///// <param name="messageSettingsAccount">The acount of the message settings. If the domain is Platform, the account is not considered.</param>
        ///// <param name="messageSettingsType">Type of the message settings.</param>
        ///// <param name="messageSettingsCaseId">Case of the message settings.</param>
        ///// <param name="languageCode">The code of the language of the message to build.</param>
        ///// <param name="basicMessage">The output message.</param>
        ///// <returns>The log of the task.</returns>
        //public Log BuildMessageFromPlatformSettings(
        //    MessageSettingsDomain messageSettingsDomain,
        //    String messageSettingsAccount,
        //    String messageSettingsType,
        //    String messageSettingsCaseId,
        //    String languageCode,
        //    out Message basicMessage)
        //{
        //    Log log = new Log();

        //    basicMessage = null;
        //    try
        //    {
        //        String filePath = "";
        //        if (messageSettingsDomain == MessageSettingsDomain.Platform)
        //            filePath = this._ApplicationManager.DataSourceManager.GetStringConnection("PTF_MAIN_RP", null) +
        //                "settings\\messages\\" + messageSettingsType + "\\messageSettings.xml";
        //        else if (messageSettingsDomain == MessageSettingsDomain.ECM)
        //            filePath = this._ApplicationManager.DataSourceManager.GetStringConnection("ECM_MAIN_RP", null) +
        //                messageSettingsAccount + "\\settings\\messages\\" + messageSettingsType + "\\messageSettings.xml";
        //        MessageSettings messageSettings =null;
        //        if (!File.Exists(filePath))
        //            log.AddEvent(EventKind.Exception,
        //                "Could not find message settings of type '" + messageSettingsType + "'",
        //                description: "Could not find message settings of type '" + messageSettingsType + "'.");
        //        else
        //        {
        //            messageSettings = MessageSettings.Load(filePath, log);
        //            // we generate an error if the message settings could be well loaded.
        //            if (messageSettings == null)
        //                log.AddEvent(EventKind.Exception,
        //                        "Could not read message settings of type '" + messageSettingsType + "'");
        //            else
        //            {
        //                // we check that the settings case exists.
        //                MessageSettingsCase messageSettingsCase = messageSettings.GetCaseWithId(messageSettingsCaseId);
        //                if (messageSettingsCase == null)
        //                    log.AddEvent(EventKind.Exception,
        //                        "No case found with ID '" + messageSettingsCaseId + "'",
        //                        description: "No case was found with ID '" + messageSettingsCaseId + "' of platform message settings type " +
        //                            "'" + messageSettingsType + "'.");
        //                else
        //                {
        //                    // we check that the required business libraries are loaded.
        //                    Boolean isAllBusinessLibrariesLoaded = true;
        //                    //String missingBusinessLibraryName = "";
        //                    //foreach (String currentBusinessLibraryName in messageSettingsCase.BusinessLibraryNames)
        //                    //    if (!scriptInterpreter.AppScope.AppExtension.GetLibraryNames().Contains(currentBusinessLibraryName))
        //                    //    {
        //                    //        isAllBusinessLibrariesLoaded = false;
        //                    //        missingBusinessLibraryName = currentBusinessLibraryName;
        //                    //        break;
        //                    //    }

        //                    if (isAllBusinessLibrariesLoaded)
        //                    //if (!isAllBusinessLibrariesLoaded)
        //                    //    log.AddEvent(
        //                    //        EventKind.Exception,
        //                    //        "Could not interpret the (subject, body) content of the message settings case because the business library '" + missingBusinessLibraryName + "' was not loaded",
        //                    //        description: "Could not interpret the (subject, body) content of the message settings case of ID '" + messageSettingsCaseId + "' " +
        //                    //        " and of type '" + messageSettingsType + "' because the business library '" + missingBusinessLibraryName + "' was not loaded.");
        //                    //else
        //                    {
        //                        // we initiate the out message
        //                        basicMessage = new Message();

        //                        List<Contact> loadedContacts;
        //                        // we build From
        //                        if (messageSettingsCase.Message.From != null)
        //                        {
        //                            loadedContacts = this._ContactDirectoryManager.GetDistinctContacts(
        //                                new List<Contact>() { messageSettingsCase.Message.From },
        //                                this._ScriptInterpreter,
        //                                log);
        //                            if (loadedContacts.Count > 0)
        //                                basicMessage.From = (Contact)loadedContacts[0];
        //                        }
        //                        // we build NotificationTo
        //                        if (messageSettingsCase.Message.NotificationTo != null)
        //                        {
        //                            loadedContacts = this._ContactDirectoryManager.GetDistinctContacts(
        //                                new List<Contact>() { messageSettingsCase.Message.NotificationTo },
        //                                this._ScriptInterpreter,
        //                                log);
        //                            if (loadedContacts.Count > 0)
        //                                basicMessage.From = (Contact)loadedContacts[0];
        //                        }
        //                        // we build ReplyTo
        //                        basicMessage.ReplyTo = this._ContactDirectoryManager.GetDistinctContacts(messageSettingsCase.Message.ReplyTo, scriptInterpreter, log);
        //                        // we build To
        //                        basicMessage.To = this._ContactDirectoryManager.GetDistinctContacts(messageSettingsCase.Message.To, scriptInterpreter, log);
        //                        // we build Cc
        //                        basicMessage.Cc = this._ContactDirectoryManager.GetDistinctContacts(messageSettingsCase.Message.Cc, scriptInterpreter, log);
        //                        // we build Bcc
        //                        basicMessage.Bcc = this._ContactDirectoryManager.GetDistinctContacts(messageSettingsCase.Message.Bcc, scriptInterpreter, log);
        //                        // we build Subject
        //                        String content;
        //                        content = "";
        //                        this._ScriptInterpreter.Evaluate(
        //                            (messageSettingsCase.Message.Subject.HasKey(languageCode) ? messageSettingsCase.Message.Subject.GetContent(languageCode) : messageSettingsCase.Message.Subject.GetContent(messageSettingsCase.DefaultLanguage)),
        //                            out content, null, log);

        //                        basicMessage.Subject.SetValue(content);
        //                        // we build Body
        //                        content = "";
        //                        this._ScriptInterpreter.Evaluate(
        //                            (messageSettingsCase.Message.Body.HasKey(languageCode) ? messageSettingsCase.Message.Body.GetContent(languageCode) : messageSettingsCase.Message.Body.GetContent(messageSettingsCase.DefaultLanguage)),
        //                            out content, null, log);

        //                        basicMessage.Body.SetValue(content);

        //                        // we build IsBodyHtml
        //                        basicMessage.IsBodyHtml = messageSettingsCase.Message.IsBodyHtml;
        //                        // we build attached files
        //                        foreach (String aCurrentAttachedFile in messageSettingsCase.Message.AttachedFiles)
        //                        {
        //                            content = "";
        //                            this._ScriptInterpreter.Evaluate(aCurrentAttachedFile, out content, null, log);
        //                            if (!basicMessage.AttachedFiles.Contains(content))
        //                                basicMessage.AttachedFiles.Add(content);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.AddException(ex);
        //    }

        //    return log;
        //}


        #endregion

    }
}
