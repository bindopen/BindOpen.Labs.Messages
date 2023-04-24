using ActiveUp.Net.Mail;
using cor_base_wdl.data.carriers;
using cor_base_wdl.data.connectors;
using cor_base_wdl.data.carriers.emails;
using cor_base_wdl.system.logging;
using System;
using System.IO;

namespace dkm.messages.definition.connections.pop3
{
    /// <summary>
    /// This class represents a POP3 email connector.
    /// </summary>
    public class EmailConnectionManager_Pop3 : EmailConnectionManager
    {

        // -----------------------------------------------
        // VARIABLES
        // -----------------------------------------------

        #region Variables

        public Pop3Client myPop3Client = null;

        #endregion


        // -----------------------------------------------
        // CONSTRUCTORS
        // -----------------------------------------------

        #region Constructors

        /// <summary>
        /// This instantiates a new instance of the FileConnectionManager_Pop3 class.
        /// </summary>
        /// <param name="aConfiguration">The file connection configuration to consider.</param>
        public EmailConnectionManager_Pop3(ConnectionParameterStatement_Pop3 aConfiguration = null)
        {
            this.myConfiguration = aConfiguration;
        }

        #endregion


        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors

        /// <summary>
        /// Gets the configuration of this instance.
        /// </summary>
        public new ConnectionParameterStatement_Pop3 GetConfiguration()
        {
            return this.myConfiguration as ConnectionParameterStatement_Pop3;
        }

        #endregion


        // -----------------------------------------------
        // EMAIL MANAGEMENT
        // -----------------------------------------------

        #region Email_Management

        // Pull ---------------------------------------

        /// <summary>
        /// Pulls an email to the specified file path.
        /// </summary>
        /// <param name="aRemoteEmailIndex">The remote email index to consider.</param>
        /// <param name="aLocalFileURI">The local file URI to consider.</param>
        /// <param name="aOutputEmail">The output email to consider.</param>
        /// <param name="aIsRemoved">Indicates whether the remote email must be removed.</param>
        public Log Pull(
            int aRemoteEmailIndex,
            String aLocalFileURI,
            out Email aOutputEmail,
            Boolean aIsRemoved = false)
        {
            Log aLog = new Log();

            aOutputEmail = null;

            if (this.Configuration == null)
                aLog.AddError(
                    "Configuration missing.",
                    LogEventCriticality.High,
                    "",
                    "Could push emails beacause the configuration is missing."
                    );
            if ((this.myPop3Client == null) || (!this.myPop3Client.IsConnected))
                aLog.AddError(
                    "Connection not opened.",
                    LogEventCriticality.High,
                    "",
                    "Could push emails beacause the connection was not opened."
                    );

            if (!aLog.HasErrorOrException())
                try
                {
                    if (this.myPop3Client.MessageCount > 0)
                    {
                        Message aMessage = this.myPop3Client.RetrieveMessageObject(aRemoteEmailIndex);
                        if (aMessage != null)
                        {
                            aOutputEmail = new Email()
                            {
                                ReferenceKind = DocumentElementReferenceKind.Single,
                                ConnectorDefinitionUniqueName = "messages$pop3",
                                EmailUniqueId = this.myPop3Client.GetUniqueId(aRemoteEmailIndex),
                                ConnectionParameterStatement= this.Configuration
                            };

                            // we create the folder if needed
                            String aFolderPath = System.IO.Path.GetDirectoryName(aLocalFileURI) + "\\";
                            if (!Directory.Exists(aFolderPath))
                                Directory.CreateDirectory(aFolderPath);

                            // we store the attached files
                            if (aMessage.Attachments.Count > 0)
                                foreach (MimePart aMimePart in aMessage.Attachments)
                                {
                                    String aAttachedFilePath = aFolderPath + aMimePart.Filename;
                                    aOutputEmail.AttachementFileNames.Add(aAttachedFilePath);
                                    aMimePart.StoreToFile(aAttachedFilePath);
                                }

                            // we store the message
                            this.myPop3Client.StoreMessage(aRemoteEmailIndex, aIsRemoved, aLocalFileURI);
                            //aOutputEmail.FilePath = aLocalFileURI;
                        }
                    }

                    // we update the execution result level
                    aLog.Execution.ResultLevel = 10;
                }
                catch (Exception ex)
                {
                    aLog.AddException(
                        ex,
                        LogEventCriticality.High,
                        ""
                        );
                }
                finally
                {
                }

            return aLog;
        }

        /// <summary>
        /// Pulls an email to the specified file path.
        /// </summary>
        /// <param name="aRemoteEmailGuid">The remote email guid to consider.</param>
        /// <param name="aLocalFileURI">The local file URI to consider.</param>
        /// <param name="aOutputEmail">The output email to consider.</param>
        /// <param name="aIsRemoved">Indicates whether the remote email must be removed.</param>
        public Log Pull(
            String aRemoteEmailGuid,
            String aLocalFileURI,
            out Email aOutputEmail,
            Boolean aIsRemoved = false)
        {
            Log aLog = new Log();

            aOutputEmail = null;

            if (this.Configuration == null)
                aLog.AddError(
                    "Configuration missing.",
                    LogEventCriticality.High,
                    "",
                    "Could push emails beacause the configuration is missing."
                    );
            if ((this.myPop3Client == null) || (!this.myPop3Client.IsConnected))
                aLog.AddError(
                    "Connection not opened.",
                    LogEventCriticality.High,
                    "",
                    "Could push emails beacause the connection was not opened."
                    );

            if (!aLog.HasErrorOrException())
                try
                {
                    if (this.myPop3Client.MessageCount > 0)
                    {
                        int aRemoteEmailIndex = this.myPop3Client.GetMessageIndex(aRemoteEmailGuid);
                        aRemoteEmailIndex++;
                        Message aMessage = this.myPop3Client.RetrieveMessageObject(aRemoteEmailIndex);
                        if (aMessage != null)
                        {
                            aOutputEmail = new Email()
                            {
                                ReferenceKind = DocumentElementReferenceKind.Single,
                                ConnectorDefinitionUniqueName = BasicConnectorDefinitionName.Pop3.ToString(),
                                EmailUniqueId = this.myPop3Client.GetUniqueId(aRemoteEmailIndex),
                                ConnectionParameterStatement = this.Configuration
                            };

                            // we create the folder if needed
                            String aFolderPath = System.IO.Path.GetDirectoryName(aLocalFileURI) + "\\";
                            if (!Directory.Exists(aFolderPath))
                                Directory.CreateDirectory(aFolderPath);

                            // we store the attached files
                            if (aMessage.Attachments.Count > 0)
                                foreach (MimePart aMimePart in aMessage.Attachments)
                                {
                                    String aAttachedFilePath = aFolderPath + aMimePart.Filename;
                                    aOutputEmail.AttachementFileNames.Add(aAttachedFilePath);
                                    aMimePart.StoreToFile(aAttachedFilePath);
                                }

                            // we store the message
                            this.myPop3Client.StoreMessage(aRemoteEmailIndex, aIsRemoved, aLocalFileURI);
                            //aOutputEmail.FilePath = aLocalFileURI;
                        }
                    }

                    // we update the execution result level
                    aLog.Execution.ResultLevel = 10;
                }
                catch (Exception ex)
                {
                    aLog.AddException(
                        ex,
                        LogEventCriticality.High,
                        ""
                        );
                }
                finally
                {
                }

            return aLog;
        }

        // Open / Close ---------------------------------------

        /// <summary>
        /// Opens a connection.
        /// </summary>
        public override Log Open()
        {
            Log aLog = new Log();

            if (this.Configuration == null)
                aLog.AddError(
                    "Configuration missing.",
                    LogEventCriticality.High,
                    "",
                    "Could push emails beacause the configuration is missing."
                    );

            if (!aLog.HasErrorOrException())
                try
                {
                    this.myPop3Client = new Pop3Client();
                    if (this.GetConfiguration().IsSslEnabled)
                        this.myPop3Client.ConnectSsl(this.GetConfiguration().Host, this.GetConfiguration().Port,
                            this.GetConfiguration().Login, this.GetConfiguration().Password);
                    else
                        this.myPop3Client.Connect(this.GetConfiguration().Host, this.GetConfiguration().Port,
                            this.GetConfiguration().Login, this.GetConfiguration().Password);
                }
                catch (Exception ex)
                {
                    aLog.AddException(
                        ex,
                        LogEventCriticality.High,
                        ""
                        );
                }

            return aLog;
        }

        /// <summary>
        /// Closes the existing connection.
        /// </summary>
        public override Log Close()
        {
            Log aLog = new Log();

            try
            {
                if ((this.myPop3Client != null) && (this.myPop3Client.IsConnected))
                    this.myPop3Client.Disconnect();
            }
            catch (Exception ex)
            {
                aLog.AddException(
                    ex,
                    LogEventCriticality.High,
                    ""
                    );
            }

            return aLog;
        }

        /// <summary>
        /// Indicates whether the instance is connected.
        /// </summary>
        public override Boolean IsConnected()
        {
            return ((this.myPop3Client != null) && (this.myPop3Client.IsConnected));
        }


        // Browser ---------------------------------------

        ///// <summary>
        ///// Gets the list of elements of the remote folder.
        ///// </summary>
        ///// <param name="aFolderURI">The URI of the folder path to consider.</param>
        ///// <param name="aFilter">The filter to consider.</param>
        ///// <param name="aIsRecursive">Indicates whether the search is folder recursive.</param>
        ///// <param name="aEmailElementKind">The kind of elements to consider.</param>
        ///// <returns>Lists of elements of the remote folder.</returns>
        //public override List<EmailElement> GetEmailElements(
        //    String aFolderURI,
        //    String aFilter,
        //    Boolean aIsRecursive,
        //    EmailElement.EmailElementKind aEmailElementKind = EmailElement.EmailElementKind.Any)
        //{
        //    List<EmailElement> someEmailElements =  new List<EmailElement>();
        //    if (Directory.Exists(aFolderURI))
        //        {
        //            FileInfo[] someFileInfos = null;

        //            Boolean aIsRegularExpression = ((!String.IsNullOrEmpty(aFilter)) && (aFilter.StartsWith(@"/")));
        //            System.Text.RegularExpressions.Regex aRegex = null;
        //            if (!aIsRegularExpression)
        //                someFileInfos = (new DirectoryInfo(aFolderURI)).GetFiles((aFilter ?? "*.*"), (aIsRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly) );
        //            else
        //            {
        //                aFilter = aFilter.Substring(1);
        //                someFileInfos = (new DirectoryInfo(aFolderURI)).GetFiles("*.*", (aIsRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
        //                    try
        //                    {
        //                        aRegex = new System.Text.RegularExpressions.Regex(aFilter);
        //                    }
        //                    catch
        //                    {
        //                        aIsRegularExpression = false;
        //                    }
        //            }

        //            foreach (FileInfo aFileInfo in someFileInfos)
        //            {
        //                Boolean aIsFound = !aIsRegularExpression;
        //                if ((aIsRegularExpression)&(aRegex!=null))
        //                    aIsFound = aRegex.IsMatch(aFileInfo.Name);

        //                if (aIsFound)
        //                {
        //                    EmailElement aEmailElement = new EmailElement()
        //                    {
        //                        //CreationTime = aFileInfo.CreationTime,
        //                        //Name = aFileInfo.Name,
        //                        //FullPath = aFileInfo.FullName,
        //                        //Kind = ((File.GetAttributes(aFileInfo.FullName) & FileAttributes.Directory) != 0 ?
        //                        //    EmailElement.EmailElementKind.Folder : EmailElement.EmailElementKind.File),
        //                        //Size = (ulong)aFileInfo.Length,
        //                        //ParentPath = aFolderURI
        //                    };
        //                    if ((aEmailElement.Kind == aEmailElementKind) |
        //                        (aEmailElementKind == EmailElement.EmailElementKind.Any))
        //                        someEmailElements.Add(aEmailElement);
        //                }
        //            }
        //        }
        //    return someEmailElements;
        //}

        #endregion

    }

}
