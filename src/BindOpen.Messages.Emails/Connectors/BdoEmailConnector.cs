using BindOpen.Extensions.Connecting;

namespace BindOpen.Messages.Emails.Connectors
{

    /// <summary>
    /// This class defines a email connector.
    /// </summary>
    public abstract class BdoEmailConnector : BdoConnector
    {
        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the BdoEmailConnector class.
        /// </summary>
        protected BdoEmailConnector() : base()
        {
        }

        #endregion


        // ------------------------------------------
        // EMAIL MANAGEMENT
        // ------------------------------------------

        #region Email Management

        ///// <summary>
        ///// Gets the connector unique name corresponding to the specified name.
        ///// </summary>
        ///// <param name="connectorName">The name of connection to consider.</param>
        ///// <returns>The created connector.</returns>
        //public static string GetConnectorKey()(String connectorName)
        //{
        //    return (!connectorName.Contains("$") ? "email$" : "") + connectorName;
        //}

        ///// <summary>
        ///// Creates a connector of the specified unique name.
        ///// </summary>
        ///// <param name="scope">The application scope to consider.</param>
        ///// <param name="connectorKey()">The unique name of connection to create.</param>
        ///// <param name="log">The log to consider.</param>
        ///// <returns>The created connector.</returns>
        //public new static EmailConnector Create(AppScope scope, string connectorKey(), IBdoLog log = null)
        //{
        //    return BdoConnectorConfiguration.Create(scope,
        //        EmailConnector.GetConnectorKey()(connectorKey()), log) as EmailConnector;
        //}

        ///// <summary>
        ///// Creates a connector of the specified unique name.
        ///// </summary>
        ///// <param name="scope">The application scope to consider.</param>
        ///// <param name="connectorKey()">The unique name of connection to create.</param>
        ///// <param name="dynamicObject">The dynamic object to consider.</param>
        ///// <param name="log">The log to consider.</param>
        ///// <returns>The created connector.</returns>
        //public new static EmailConnector Create(AppScope scope, string connectorKey(), dynamic dynamicObject, IBdoLog log = null)
        //{
        //    return BdoConnectorConfiguration.Create(scope,
        //        EmailConnector.GetConnectorKey()(connectorKey()),
        //        dynamicObject, log) as EmailConnector;
        //}

        ///// <summary>
        ///// Creates a connector of the specified unique name.
        ///// </summary>
        ///// <param name="scope">The application scope to consider.</param>
        ///// <param name="aEmailConnectorKind">The kind of email connector to consider.</param>
        ///// <param name="dynamicObject">The dynamic object to consider.</param>
        ///// <param name="log">The log to consider.</param>
        ///// <returns>The created connector.</returns>
        //public static EmailConnector Create(
        //    AppScope scope, EmailConnectorKind aEmailConnectorKind, dynamic dynamicObject, IBdoLog log = null)
        //{
        //    return BdoConnectorConfiguration.Create(scope,
        //        EmailConnector.GetConnectorKey()(aEmailConnectorKind.ToString()),
        //        dynamicObject, log) as EmailConnector;
        //}

        ///// <summary>
        ///// Creates a connector of the specified unique name.
        ///// </summary>
        ///// <param name="scope">The application scope to consider.</param>
        ///// <param name="dataSource">The data source to consider.</param>
        ///// <param name="log">The log to consider.</param>
        ///// <returns>The created connector.</returns>
        //public new static EmailConnector Create(AppScope scope, DataSource dataSource = null, IBdoLog log = null)
        //{
        //    return BdoConnectorConfiguration.Create(scope, dataSource, log) as EmailConnector;
        //}

        ///// <summary>
        ///// Creates a data source of the specified unique name.
        ///// </summary>
        ///// <param name="scope">The application scope to consider.</param>
        ///// <param name="connectorKey()">The unique name of connection to create.</param>
        ///// <param name="log">The log to consider.</param>
        ///// <returns>The created data source.</returns>
        //public new static DataSource CreateDataSource(AppScope scope, string connectorKey(), IBdoLog log = null)
        //{
        //    return BdoConnectorConfiguration.CreateDataSource(scope, EmailConnector.GetConnectorKey()(connectorKey()), log);
        //}

        //// Pull ---------------------------------------

        ///// <summary>
        ///// Pulls an email to the specified folder path.
        ///// </summary>
        ///// <param name="aRemoteEmail">The remote email to consider.</param>
        ///// <param name="aLocalFolderPathURI">The local folder path URI to consider.</param>
        ///// <param name="somRepositoryElements">The repository elements that have been pulled.</param>
        ///// <param name="isRemoved">Indicates whether the remote email must be removed.</param>
        //public virtual IBdoLog Pull(
        //    Email aRemoteEmail,
        //    string aLocalFolderPathURI,
        //    out List<RepositoryElement> somRepositoryElements,
        //    Boolean isRemoved = false)
        //{
        //    somRepositoryElements = new List<RepositoryElement>();

        //    return new BdoLog();
        //}

        ///// <summary>
        ///// Pulls an email to the specified folder path.
        ///// </summary>
        ///// <param name="remoteEmails">The remote emails to consider.</param>
        ///// <param name="aLocalFolderPathURI">The local folder path URI to consider.</param>
        ///// <param name="somRepositoryElements">The repository elements that have been pulled.</param>
        ///// <param name="isRemoved">Indicates whether the remote email must be removed.</param>
        //public virtual IBdoLog Pull(
        //    List<Email> remoteEmails,
        //    string aLocalFolderPathURI,
        //    out List<RepositoryElement> somRepositoryElements,
        //    Boolean isRemoved = false)
        //{
        //    IBdoLog log = new BdoLog();
        //    somRepositoryElements = new List<RepositoryElement>();

        //    foreach (Email aEmail in remoteEmails)
        //        log.AddEvents(Pull(aEmail, aLocalFolderPathURI, out somRepositoryElements, isRemoved));

        //    return log;
        //}

        //// Push ---------------------------------------

        ///// <summary>
        ///// Pushes a local file to a remote URI.
        ///// </summary>
        ///// <param name="aLocalFolderPathURI">The local folder path URI to consider.</param>
        ///// <param name="aRemoteEmail">The remote email to consider.</param>
        ///// <param name="emailElements">The email elements that have been pushed.</param>
        //public virtual IBdoLog Push(
        //    string aLocalFolderPathURI,
        //    Email aRemoteEmail,
        //    out List<EmailElement> emailElements)
        //{
        //    emailElements = new List<EmailElement>();

        //    return new BdoLog();
        //}

        ///// <summary>
        ///// Pushes local files to a remote URI.
        ///// </summary>
        ///// <param name="localFileURIs">The local URIs to consider.</param>
        ///// <param name="aRemoteEmail">The remote email to consider.</param>
        ///// <param name="emailElements">The email elements that have been pushed.</param>
        //public virtual IBdoLog Push(
        //    List<String> localFileURIs,
        //    Email aRemoteEmail,
        //    out List<EmailElement> emailElements)
        //{
        //    IBdoLog log = new BdoLog();
        //    emailElements = new List<EmailElement>();

        //    foreach (String remoteFileUri in localFileURIs)
        //        log.AddEvents(Push(remoteFileUri, aRemoteEmail, out emailElements));

        //    return log;
        //}

        //// Browser ---------------------------------------

        ///// <summary>
        ///// Gets the list of elements of the remote folder.
        ///// </summary>
        ///// <param name="aFolderURI">The URI of the folder path to consider.</param>
        ///// <param name="aFilter">The filter to consider.</param>
        ///// <param name="isRecursive">Indicates whether the search is folder recursive.</param>
        ///// <param name="aEmailElementKind">The kind of elements to consider.</param>
        ///// <returns>Lists of elements of the remote folder.</returns>
        //public virtual List<CarrierElement> GetEmailElements(
        //    string aFolderURI,
        //    string aFilter,
        //    Boolean isRecursive)
        //{
        //    return new List<CarrierElement>();
        //}

        #endregion


        //// -----------------------------------------------
        //// EMAIL MANAGEMENT
        //// -----------------------------------------------

        //#region Email_Management

        //// Pull ---------------------------------------

        ///// <summary>
        ///// Pulls an email to the specified folder path.
        ///// </summary>
        ///// <param name="aRemoteEmail">The remote email to consider.</param>
        ///// <param name="aLocalFolderPathURI">The local folder path URI to consider.</param>
        ///// <param name="somRepositoryElements">The repository elements that have been pulled.</param>
        ///// <param name="isRemoved">Indicates whether the remote email must be removed.</param>
        //public virtual IBdoLog Pull(
        //   Email aRemoteEmail,
        //   string aLocalFolderPathURI,
        //   out List<RepositoryElement> somRepositoryElements,
        //   Boolean isRemoved = false)
        //{
        //    somRepositoryElements = new List<RepositoryElement>();

        //    return new BdoLog();
        //}

        ///// <summary>
        ///// Pulls an email to the specified folder path.
        ///// </summary>
        ///// <param name="remoteEmails">The remote emails to consider.</param>
        ///// <param name="aLocalFolderPathURI">The local folder path URI to consider.</param>
        ///// <param name="somRepositoryElements">The repository elements that have been pulled.</param>
        ///// <param name="isRemoved">Indicates whether the remote email must be removed.</param>
        //public virtual IBdoLog Pull(
        //    List<Email> remoteEmails,
        //    string aLocalFolderPathURI,
        //    out List<RepositoryElement> somRepositoryElements,
        //    Boolean isRemoved = false)
        //{
        //    IBdoLog log = new BdoLog();
        //    somRepositoryElements = new List<RepositoryElement>();

        //    foreach (Email aEmail in remoteEmails)
        //        log.AddEvents(Pull(aEmail, aLocalFolderPathURI, out somRepositoryElements, isRemoved));

        //    return log;
        //}

        //// Push ---------------------------------------

        ///// <summary>
        ///// Pushes a local file to a remote URI.
        ///// </summary>
        ///// <param name="aLocalFolderPathURI">The local folder path URI to consider.</param>
        ///// <param name="aRemoteEmail">The remote email to consider.</param>
        ///// <param name="emailElements">The email elements that have been pushed.</param>
        //public virtual IBdoLog Push(
        //    string aLocalFolderPathURI,
        //    Email aRemoteEmail,
        //    out List<EmailElement> emailElements)
        //{
        //    emailElements = new List<EmailElement>();

        //    return new BdoLog();
        //}

        ///// <summary>
        ///// Pushes local files to a remote URI.
        ///// </summary>
        ///// <param name="localFileURIs">The local URIs to consider.</param>
        ///// <param name="aRemoteEmail">The remote email to consider.</param>
        ///// <param name="emailElements">The email elements that have been pushed.</param>
        //public virtual IBdoLog Push(
        //    List<String> localFileURIs,
        //    Email aRemoteEmail,
        //    out List<EmailElement> emailElements)
        //{
        //    IBdoLog log = new BdoLog();
        //    emailElements = new List<EmailElement>();

        //    foreach (String remoteFileUri in localFileURIs)
        //        log.AddEvents(Push(remoteFileUri, aRemoteEmail, out emailElements));

        //    return log;
        //}

        //// Open / Close ---------------------------------------

        ///// <summary>
        ///// Opens a connection.
        ///// </summary>
        //public virtual IBdoLog Open()
        //{
        //    return new BdoLog();
        //}

        ///// <summary>
        ///// Closes the existing connection.
        ///// </summary>
        //public virtual IBdoLog Close()
        //{
        //    return new BdoLog();
        //}

        ///// <summary>
        ///// Indicates whether the instance is connected.
        ///// </summary>
        //public virtual Boolean IsConnected()
        //{
        //    return false;
        //}

        //// Browser ---------------------------------------

        ///// <summary>
        ///// Gets the list of elements of the remote folder.
        ///// </summary>
        ///// <param name="aFolderURI">The URI of the folder path to consider.</param>
        ///// <param name="aFilter">The filter to consider.</param>
        ///// <param name="isRecursive">Indicates whether the search is folder recursive.</param>
        ///// <param name="aEmailElementKind">The kind of elements to consider.</param>
        ///// <returns>Lists of elements of the remote folder.</returns>
        //public virtual List<EmailElement> GetEmailElements(
        //    string aFolderURI,
        //    string aFilter,
        //    Boolean isRecursive)
        //{
        //    return new List<EmailElement>();
        //}

        //#endregion

    }
}
