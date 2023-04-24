using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using BindOpen.Framework.Core.Data.Items;

namespace BindOpen.Framework.Labs.Messages.Application.Messages.Senders
{
    /// <summary>
    /// This class represents the message send request.
    /// </summary>
    [XmlType("MessageSendRequest", Namespace = "http://www.w3.org/2001/dkm.xsd")]
    [XmlRoot(ElementName = "MessageSendRequest", Namespace = "http://www.w3.org/2001/dkm.xsd", IsNullable = false)]
    public class MessageSendRequest : DataItem
    {

        // --------------------------------------
        // VARIABLES
        // --------------------------------------

        #region Variables

        private String _Id;
        private BasicMessage _Message;
        private List<MessageSendRequestDelivery> _DeliveryLogs = new List<MessageSendRequestDelivery>();
        private int _MaxTryNumber = -1;

        #endregion


        // --------------------------------------
        // PROPERTIES
        // --------------------------------------

        #region Properties

        /// <summary>
        /// ID of this instance.
        /// </summary>
        [XmlElement("id")]
        public String Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }

        /// <summary>
        /// Message of this instance.
        /// </summary>
        [XmlElement("message")]
        public BasicMessage Message
        {
            get { return this._Message; }
            set { this._Message = value; }
        }

        /// <summary>
        /// User contact that sends.
        /// </summary>
        [XmlArray("deliveries")]
        [XmlArrayItem("delivery")]
        public List<MessageSendRequestDelivery> SendRequestDeliveries
        {
            get { return this._DeliveryLogs; }
            set { this._DeliveryLogs = value; }
        }

        /// <summary>
        /// Maximum number of sending tries. Unlimited if -1.
        /// </summary>
        [XmlElement("maxTryNumber")]
        public int MaxTryNumber
        {
            get { return this._MaxTryNumber; }
            set { this._MaxTryNumber = value; }
        }

        #endregion


        // --------------------------------------
        // CONSTRUCTORS
        // --------------------------------------

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MessageSendRequest class.
        /// </summary>
        public MessageSendRequest()
        {
            this._Id = "msr_" + DateTime.Now.Ticks;
        }

        /// <summary>
        /// Initializes a new instance of the MessageSendRequest class.
        /// </summary>
        /// <param name="applicationManager">The application manager to use.</param>
        public MessageSendRequest(ApplicationManager applicationManager)
        {
            this._ApplicationManager = applicationManager;
            this._Id = "msr_" + DateTime.Now.Ticks + ".xml";
        }

        #endregion


        // --------------------------------------
        // ACCESSORS
        // --------------------------------------

        #region Accessors

        /// <summary>
        /// Gets the file path.
        /// </summary>
        public String GetFilePath()
        {
            return this._ApplicationManager.DataSourceManager.GetStringConnection("ptf_main_rp", null) +
                "runtime\\sendbox\\" + this._Id + ".xml";
        }

        #endregion

        
        // --------------------------------------
        // IMPORTATION
        // --------------------------------------

        #region Importation

        /// <summary>
        /// Initializes a new instance of Log class from a xml file.
        /// </summary>
        /// <param name="aAplicationManager">The application manager.</param>
        /// <param name="filePath">The path of the Xml file to load.</param>
        /// <param name="loadLog">The output log of the load task.</param>
        /// <returns>The task log defined in the Xml file.</returns>
        public static MessageSendRequest Load(
            ApplicationManager aAplicationManager,
            String filePath,
            Log loadLog)
        {
            MessageSendRequest basicMessageSendRequest = null;

            try
            {
                XDocument aXDocument = XDocument.Load(filePath);

                Assembly aAssembly = Assembly.Load("cor_base_wdl");
                Stream aStream = aAssembly.GetManifestResourceStream("cor_runtime_wdl.data.xsd.MessageSendRequest.xsd");
                XmlSchemaSet aXmlSchemaSet = new XmlSchemaSet();
                aXmlSchemaSet.Add("http://www.w3.org/2001/dkm.xsd", XmlReader.Create(new StreamReader(aStream)));
                aXDocument.Validate(aXmlSchemaSet, (o, e) =>
                {
                    loadLog.AddError("File '" + filePath + "' not valid",
                        description: e.Message);
                });

                if (!loadLog.HasErrorsOrExceptionsOrWarnings())
                {
                    // then we load
                    XmlSerializer aXmlSerializer = new XmlSerializer(typeof(Log));
                    StreamReader streamReader = new StreamReader(filePath);
                    basicMessageSendRequest = (MessageSendRequest)
                        aXmlSerializer.Deserialize(XmlReader.Create(streamReader));
                    basicMessageSendRequest._ApplicationManager = aAplicationManager;
                }
            }
            catch (Exception ex)
            {
                loadLog.AddException(ex);
            }
            return basicMessageSendRequest;
        }

        #endregion


        // --------------------------------------
        // EXPORTATION
        // --------------------------------------

        #region Exportation

        /// <summary>
        /// Gets the xml string of this instance.
        /// </summary>
        /// <returns>The Xml string of this instance.</returns>
        public String ToXml()
        {
            String st = "";
            try
            {
                XmlSerializer aXmlSerializer = new XmlSerializer(this.GetType());
                StringWriter streamWriter = new StringWriter();
                aXmlSerializer.Serialize(streamWriter, this);
                st = streamWriter.ToString();
            }
            catch
            {
            }

            return st;
        }

        /// <summary>
        /// Saves this instance in the specified file.
        /// </summary>
        /// <returns>True if the file has been well saved. False otherwise.</returns>
        public Boolean SaveXml()
        {
            Boolean aIsWasSaved = false;
            try
            {
                String logFilePath = this._ApplicationManager.DataSourceManager.GetStringConnection("PTF_MAIN_RP", null) +
                    "\\runtime\\sendbox\\msr_" + DateTime.Now.Ticks + ".xml";

                // we create the folder if it does not exist
                if (!Directory.Exists(Path.GetDirectoryName(logFilePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

                // we save the xml file
                XmlSerializer aXmlSerializer = new XmlSerializer(this.GetType());
                StreamWriter streamWriter = new StreamWriter(logFilePath);

                aXmlSerializer.Serialize(streamWriter, this);
                aIsWasSaved = true;
            }
            catch
            {
                aIsWasSaved = false;
            }

            return aIsWasSaved;
        }


        #endregion

    }
}
