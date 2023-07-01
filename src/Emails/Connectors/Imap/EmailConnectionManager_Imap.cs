using cor_base_wdl.data.carriers.emails;
using cor_base_wdl.system.logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace BindOpen.Messages.Emails.Connectors.imap
{
    /// <summary>
    /// This class represents a IMAP email connector.
    /// </summary>
    public class EmailConnectionManager_Imap : EmailConnectionManager
    {

        // -----------------------------------------------
        // CONSTRUCTORS
        // -----------------------------------------------

        #region Constructors

        /// <summary>
        /// This instantiates a new instance of the FileConnectionManager_Imap class.
        /// </summary>
        /// <param name="aConfigurationSettings">The file connection configuration to consider.</param>
        public EmailConnectionManager_Imap(ConnectionParameterStatement_Imap aConfigurationSettings = null)
        {
            this.myConfiguration = aConfigurationSettings;
        }

        #endregion


        // ------------------------------------------
        // ACCESSORS
        // ------------------------------------------

        #region Accessors

        /// <summary>
        /// Gets the configuration of this instance.
        /// </summary>
        public new ConnectionParameterStatement_Imap GetConfiguration()
        {
            return this.Configuration as ConnectionParameterStatement_Imap;
        }

        #endregion


        // -----------------------------------------------
        // EMAIL MANAGEMENT
        // -----------------------------------------------

        #region Email_Management

        //// Pull ---------------------------------------

        ///// <summary>
        ///// Gets a remote file to a local URI.
        ///// </summary>
        ///// <param name="aRemoteFileURI">The remote URI to consider.</param>
        ///// <param name="aImapPathURI">The URI of the local path to consider.</param>
        ///// <param name="aCanOverwrite">Indicates whether the local file can be overwritten.</param>
        //public override Log Pull(
        //    String aRemoteFileURI,
        //    String aImapPathURI,
        //    Boolean aCanOverwrite)
        //{
        //    Log aLog = new Log();
        //    try
        //    {
        //        if (!Directory.Exists(System.IO.Path.GetDirectoryName(aImapPathURI)))
        //            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(aImapPathURI));

        //        File.Copy(aRemoteFileURI, aImapPathURI, aCanOverwrite);
        //    }
        //    catch (Exception aException)
        //    {
        //        LogEvent aLogEvent = aLog.AddException(
        //             aException,
        //             LogEvent.LogEventCriticality.High,
        //             ""
        //         );
        //    }
        //    return aLog;
        //}

        //// Push ---------------------------------------

        ///// <summary>
        ///// Posts a local file to a remote URI.
        ///// </summary>
        ///// <param name="aImapFileURI">The local URI to consider.</param>
        ///// <param name="aRemotePathURI">The URI of the remote path to consider.</param>
        ///// <param name="aCanOverwrite">Indicates whether the remote file can be overwritten.</param>
        //public override Log Push(
        //    String aImapFileURI,
        //    String aRemotePathURI,
        //    Boolean aCanOverwrite)
        //{
        //    Log aLog = new Log();
        //    try
        //    {
        //        if (!Directory.Exists(System.IO.Path.GetDirectoryName(aRemotePathURI)))
        //            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(aRemotePathURI));

        //        File.Copy(aImapFileURI, aRemotePathURI, aCanOverwrite);
        //    }
        //    catch (Exception aException)
        //    {
        //        aLog.AddException(
        //            aException,
        //            LogEvent.LogEventCriticality.High,
        //            ""
        //            );
        //    }
        //    return aLog;
        //}

        // Open / Close ---------------------------------------

        /// <summary>
        /// Opens a connection.
        /// </summary>
        public override Log Open()
        {
            return base.Open();
        }

        /// <summary>
        /// Closes the existing connection.
        /// </summary>
        public override Log Close()
        {
            return base.Close();
        }

        // Browser ---------------------------------------

        /// <summary>
        /// Gets the list of elements of the remote folder.
        /// </summary>
        /// <param name="aFolderURI">The URI of the folder path to consider.</param>
        /// <param name="aFilter">The filter to consider.</param>
        /// <param name="aIsRecursive">Indicates whether the search is folder recursive.</param>
        /// <param name="aEmailElementKind">The kind of elements to consider.</param>
        /// <returns>Lists of elements of the remote folder.</returns>
        public override List<EmailElement> GetEmailElements(
            string aFolderURI,
            string aFilter,
            bool aIsRecursive)
        {
            List<EmailElement> someEmailElements = new List<EmailElement>();
            if (Directory.Exists(aFolderURI))
            {
                FileInfo[] someFileInfos = null;

                bool aIsRegularExpression = !string.IsNullOrEmpty(aFilter) && aFilter.StartsWith(@"/");
                System.Text.RegularExpressions.Regex aRegex = null;
                if (!aIsRegularExpression)
                    someFileInfos = new DirectoryInfo(aFolderURI).GetFiles(aFilter ?? "*.*", aIsRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                else
                {
                    aFilter = aFilter.Substring(1);
                    someFileInfos = new DirectoryInfo(aFolderURI).GetFiles("*.*", aIsRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                    try
                    {
                        aRegex = new System.Text.RegularExpressions.Regex(aFilter);
                    }
                    catch
                    {
                        aIsRegularExpression = false;
                    }
                }

                foreach (FileInfo aFileInfo in someFileInfos)
                {
                    bool aIsFound = !aIsRegularExpression;
                    if (aIsRegularExpression & aRegex != null)
                        aIsFound = aRegex.IsMatch(aFileInfo.Name);

                    if (aIsFound)
                    {
                        EmailElement aEmailElement = new EmailElement()
                        {
                            //CreationTime = aFileInfo.CreationTime,
                            //Name = aFileInfo.Name,
                            //FullPath = aFileInfo.FullName,
                            //Kind = ((File.GetAttributes(aFileInfo.FullName) & FileAttributes.Directory) != 0 ?
                            //    EmailElement.EmailElementKind.Folder : EmailElement.EmailElementKind.File),
                            //Size = (ulong)aFileInfo.Length,
                            //ParentPath = aFolderURI
                        };

                        someEmailElements.Add(aEmailElement);
                    }
                }
            }
            return someEmailElements;
        }

        #endregion

    }

}
