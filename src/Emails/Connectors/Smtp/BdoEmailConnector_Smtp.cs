namespace BindOpen.Messages.Emails.Connectors.Smtp
{
    /// <summary>
    /// This class represents a SMTP email connector.
    /// </summary>
    [BdoConnector(Name = "messages$smtp")]
    public class BdoEmailConnector_Smtp : BdoEmailConnector
    {
        // -----------------------------------------------
        // PROPERTIES
        // -----------------------------------------------

        #region Properties

        /// <summary>
        /// The host of this instance.
        /// </summary>
        [DetailProperty(Name = "host")]
        public string Host { get; set; }

        /// <summary>
        /// Indicates whether this instance enables SSL.
        /// </summary>
        [DetailProperty(Name = "isSslEnabled")]
        public bool? IsSslEnabled { get; set; }

        /// <summary>
        /// The port of this instance.
        /// </summary>
        [DetailProperty(Name = "port")]
        public int? Port { get; set; }

        /// <summary>
        /// The timeout of this instance.
        /// </summary>
        [DetailProperty(Name = "timeout")]
        public int? Timeout { get; set; }

        /// <summary>
        /// Indicates whether this instance uses default credentials.
        /// </summary>
        [DetailProperty(Name = "isDefaultCredentialsUsed")]
        public bool? IsDefaultCredentialsUsed { get; set; }

        /// <summary>
        /// The login of this instance.
        /// </summary>
        [DetailProperty(Name = "login")]
        public string Login { get; set; }

        /// <summary>
        /// The password of this instance.
        /// </summary>
        [DetailProperty(Name = "password")]
        public string Password { get; set; }

        #endregion

        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoEmailConnector_Smtp class.
        /// </summary>
        public BdoEmailConnector_Smtp() : base()
        {
        }

        #endregion

        // -----------------------------------------------
        // EMAIL MANAGEMENT
        // -----------------------------------------------

        #region Email_Management

        /// <summary>
        /// Creates a connection.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <returns>Returns this instance.</returns>
        public override IBdoConnection CreateConnection(IBdoLog log = null)
        {
            return null;
        }

        //// Push ---------------------------------------

        ///// <summary>
        ///// Posts a local file to a remote URI.
        ///// </summary>
        ///// <param name="aLocalEmail">The local email to consider.</param>
        ///// <param name="isRemoved">Indicates whether the local item must be removed.</param>
        //public IBdoLog Push(
        //          Email aLocalEmail,
        //          Boolean isRemoved = false)
        //     {
        //         IBdoLog log = new BdoLog();

        //         if (aLocalEmail == null)
        //             log.AddError(
        //                 "Local email missing.",
        //                 LogEventCriticality.High,
        //                 "",
        //                 "Local email to send is missing."
        //                 );
        //         if (Configuration == null)
        //             log.AddError(
        //                 "Configuration missing.",
        //                 LogEventCriticality.High,
        //                 "",
        //                 "Could not push emails beacause the configuration is missing."
        //                 );

        //         if (!log.HasErrorOrException())
        //             try
        //             {
        //                 //if (!System.IO.File.Exists(aLocalEmail.FilePath))
        //                 //    log.AddError(
        //                 //        "Local email file not found.",
        //                 //        LogEvent.LogEventCriticality.High,
        //                 //        "",
        //                 //        "Could not push emails beacause the email file was not found."
        //                 //        );
        //                 //else
        //                 //{
        //                     Message aMessage = Parser.ParseMessageFromFile("aLocalEmail.FilePath");
        //                     if (aMessage != null)
        //                     {
        //                         SmtpMessage aSmtpMessage = new SmtpMessage()
        //                         {
        //                             Bcc = aMessage.Bcc,
        //                             BodyHtml = aMessage.BodyHtml,
        //                             BodyText = aMessage.BodyText,
        //                             Cc = aMessage.Cc,
        //                         //    HeaderFields = aMessage.HeaderFields,
        //                             ReplyTo = aMessage.ReplyTo,
        //                             To = aMessage.To,
        //                             From = aMessage.To[0]
        //                         };

        //                         foreach (MimePart aMimePart in aMessage.Attachments)
        //                             aSmtpMessage.Attachments.Add(aMimePart);

        //                         aSmtpMessage.BuildMimePartTree();

        //                         if (GetConfiguration().IsSslEnabled)
        //                             aSmtpMessage.Send(GetConfiguration().Host,
        //                                 GetConfiguration().Port, GetConfiguration().Login,
        //                                 GetConfiguration().Password, SaslMechanism.Login);
        //                         else
        //                             aSmtpMessage.Send(GetConfiguration().Host, GetConfiguration().Port,
        //                                 GetConfiguration().Login, GetConfiguration().Password, SaslMechanism.CramMd5);
        //                     }

        //                     // we update the execution result level
        //                     log.Execution.ResultLevel = 10;
        //                 //}
        //             }
        //         catch (Exception ex)
        //         {
        //             log.AddException(
        //                 ex,
        //                 LogEventCriticality.High,
        //                 ""
        //                 );
        //         }

        //         return log;
        //     }

        //     /// <summary>
        //     /// Posts a local file to a remote URI.
        //     /// </summary>
        //     /// <param name="aEmailElement">The email element to send.</param>
        //     /// <param name="isRemoved">Indicates whether the local item must be removed.</param>
        //     public IBdoLog Push(
        //          EmailElement aEmailElement,
        //          Boolean isRemoved = false)
        //     {
        //         IBdoLog log = new BdoLog();

        //         if (aEmailElement == null)
        //             log.AddError(
        //                 "Message to send missing.",
        //                 LogEventCriticality.High,
        //                 "",
        //                 "Message to send is missing."
        //                 );
        //         if (GetConfiguration() == null)
        //             log.AddError(
        //                 "Configuration missing.",
        //                 LogEventCriticality.High,
        //                 "",
        //                 "Could not push emails beacause the configuration is missing."
        //                 );

        //         if (!log.HasErrorOrException())
        //             try
        //             {
        //                 //if (!System.IO.File.Exists(aLocalEmail.FilePath))
        //                 //    log.AddError(
        //                 //        "Local email file not found.",
        //                 //        LogEvent.LogEventCriticality.High,
        //                 //        "",
        //                 //        "Could not push emails beacause the email file was not found."
        //                 //        );
        //                 //else
        //                 //{
        //                 if (aEmailElement != null)
        //                 {
        //                      SmtpMessage aSmtpMessage = new SmtpMessage();
        //                      for (int i = 0; i < aEmailElement.To.Count; i++)
        //                          aSmtpMessage.Bcc.Add(new Address(aEmailElement.To[i].Address, aEmailElement.To[i].DisplayName));
        //                      for (int i = 0; i < aEmailElement.Bcc.Count; i++) 
        //                          aSmtpMessage.Bcc.Add(new Address(aEmailElement.Bcc[i].Address,aEmailElement.Bcc[i].DisplayName));
        //                      for(int i=0; i<aEmailElement.CC.Count;i++) 
        //                          aSmtpMessage.Bcc.Add(new Address(aEmailElement.CC[i].Address,aEmailElement.CC[i].DisplayName));
        //                      aSmtpMessage.From = new Address(aEmailElement.From.Address, aEmailElement.From.DisplayName);
        //                      if (aEmailElement.ReplyToList.Count > 0)
        //                          aSmtpMessage.ReplyTo = new Address(aEmailElement.ReplyToList[0].Address, aEmailElement.ReplyToList[0].DisplayName);
        //                      if (aEmailElement.IsBodyHtml)
        //                          aSmtpMessage.BodyHtml.Text = aEmailElement.Body;
        //                     else
        //                         aSmtpMessage.BodyText.Text = aEmailElement.Body;

        //                     //foreach (MimePart aMimePart in aEmailElement.att.Attachments)
        //                     //    aSmtpMessage.Attachments.Add(aMimePart);

        //                     aSmtpMessage.BuildMimePartTree();

        //                     if (GetConfiguration().IsSslEnabled)
        //                         aSmtpMessage.Send(GetConfiguration().Host, GetConfiguration().Port,
        //                             GetConfiguration().Login, GetConfiguration().Password, SaslMechanism.Login);
        //                     else
        //                         aSmtpMessage.Send(GetConfiguration().Host, GetConfiguration().Port,
        //                             GetConfiguration().Login, GetConfiguration().Password, SaslMechanism.CramMd5);
        //                 }

        //                 // we update the execution result level
        //                 log.Execution.ResultLevel = 10;
        //                 //}
        //             }
        //             catch (Exception ex)
        //             {
        //                 log.AddException(
        //                     ex,
        //                     LogEventCriticality.High,
        //                     ""
        //                     );
        //             }

        //         return log;
        //     }

        //     // Open / Close ---------------------------------------


        //     // Browser ---------------------------------------

        //     /// <summary>
        //     /// Gets the list of elements of the remote folder.
        //     /// </summary>
        //     /// <param name="aFolderURI">The URI of the folder path to consider.</param>
        //     /// <param name="aFilter">The filter to consider.</param>
        //     /// <param name="isRecursive">Indicates whether the search is folder recursive.</param>
        //     /// <param name="aEmailElementKind">The kind of elements to consider.</param>
        //     /// <returns>Lists of elements of the remote folder.</returns>
        //     public override List<EmailElement> GetEmailElements(
        //         string aFolderURI,
        //         string aFilter,
        //         Boolean isRecursive)
        //     {
        //         List<EmailElement> emailElements =  new List<EmailElement>();
        //         if (Directory.Exists(aFolderURI))
        //             {
        //                 FileInfo[] fileInfos = null;

        //                 Boolean isRegularExpression = ((!String.IsNullOrEmpty(aFilter)) && (aFilter.StartsWith(@"/")));
        //                 System.Text.RegularExpressions.Regex aRegex = null;
        //                 if (!isRegularExpression)
        //                     fileInfos = (new DirectoryInfo(aFolderURI)).GetFiles((aFilter ?? "*.*"), (isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly) );
        //                 else
        //                 {
        //                     aFilter = aFilter.Substring(1);
        //                     fileInfos = (new DirectoryInfo(aFolderURI)).GetFiles("*.*", (isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
        //                         try
        //                         {
        //                             aRegex = new System.Text.RegularExpressions.Regex(aFilter);
        //                         }
        //                         catch
        //                         {
        //                             isRegularExpression = false;
        //                         }
        //                 }

        //                 foreach (FileInfo fileInfo in fileInfos)
        //                 {
        //                     Boolean isFound = !isRegularExpression;
        //                     if ((isRegularExpression)&(aRegex!=null))
        //                         isFound = aRegex.IsMatch(fileInfo.Name);

        //                     if (isFound)
        //                     {
        //                         EmailElement aEmailElement = new EmailElement()
        //                         {
        //                             //CreationTime = fileInfo.CreationTime,
        //                             //Name = fileInfo.Name,
        //                             //FullPath = fileInfo.FullName,
        //                             //Kind = ((File.GetAttributes(fileInfo.FullName) & FileAttributes.Directory) != 0 ?
        //                             //    EmailElement.EmailElementKind.Folder : EmailElement.EmailElementKind.File),
        //                             //Size = (ulong)fileInfo.Length,
        //                             //ParentPath = aFolderURI
        //                         };
        //                             emailElements.Add(aEmailElement);
        //                     }
        //                 }
        //             }
        //         return emailElements;
        //     }

        #endregion
    }
}
