using BindOpen.Extensions.Modeling;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BindOpen.Messages.Emails.Carriers
{
    /// <summary>
    /// This class represents the email.
    /// </summary>
    public class Email : BdoCarrier
    {
        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        /// <summary>
        /// Email unique ID of this instance.
        /// </summary>
        [XmlIgnore()]
        public string EmailUniqueId
        {
            get { return myEmailUniqueIds == null || myEmailUniqueIds.Count == 0 ? "" : myEmailUniqueIds[0]; }
            set { myEmailUniqueIds = new List<string>() { value }; }
        }

        /// <summary>
        /// Email unique IDs of this instance.
        /// </summary>
        [XmlArray("emailUniqueIds")]
        [XmlArrayItem("emailUniqueId")]
        public List<string> EmailUniqueIds
        {
            get { return myEmailUniqueIds; }
            set { myEmailUniqueIds = value; }
        }

        /// <summary>
        /// Attachement file names of this instance.
        /// </summary>
        [XmlArray("attachementFileNames")]
        [XmlArrayItem("attachementFileName")]
        public List<string> AttachementFileNames
        {
            get { return myAttachementFileNames; }
            set { myAttachementFileNames = value; }
        }

        #endregion


        // ------------------------------------------
        // CONSTRUCTORS
        // ------------------------------------------

        #region Constructors

        /// <summary>
        /// Instantiates a new instance of the Email class.
        /// </summary>
        public Email()
            : base(DocumentKind.Email)
        {
        }

        #endregion


        // --------------------------------------------------
        // ACCESSORS
        // --------------------------------------------------

        #region Accessors

        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// <param name="aIsConfigurationChecked">Indicates whether the configuration is checked.</param>
        /// <returns>The check log.</returns>
        public virtual Log Check(
            bool aIsConfigurationChecked = true)
        {
            Log aLog = new Log();

            return aLog;
        }

        /// <summary>
        /// Gets a default title for this instance.
        /// </summary>
        public override string GetDefaultTitle()
        {
            string aPath = "Email";

            if (this.ReferenceKind == DocumentElementReferenceKind.Single && !string.IsNullOrEmpty(EmailUniqueId))
                aPath += "_" + EmailUniqueId;
            else if (this.ReferenceKind == DocumentElementReferenceKind.Multiple)
            {
                if (myEmailUniqueIds.Count > 0 && !string.IsNullOrEmpty(myEmailUniqueIds[0]))
                    aPath += "_" + Path.GetFileName(myEmailUniqueIds[0]);
                if (myEmailUniqueIds.Count > 1 && !string.IsNullOrEmpty(myEmailUniqueIds[1]))
                    aPath += "," + Path.GetFileName(myEmailUniqueIds[1]);
                if (myEmailUniqueIds.Count > 2 && !string.IsNullOrEmpty(myEmailUniqueIds[2]))
                    aPath += ",...";
            }
            else
                aPath = Path.GetFileName(aPath);

            return aPath;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns the cloned instance.</returns>
        public override InformationCarrier Clone()
        {
            return new Email()
            {
                AttachementFileNames = new List<string>(AttachementFileNames),
                AvailableConnectorDefinitionUniqueNames = new List<string>(this.AvailableConnectorDefinitionUniqueNames),
                AvailableReferenceKinds = new List<DocumentElementReferenceKind>(this.AvailableReferenceKinds),
                EmailUniqueId = EmailUniqueId,
                EmailUniqueIds = new List<string>(EmailUniqueIds),
                ConnectionParameterStatement = this.ConnectionParameterStatement,
                ConnectorDefinitionUniqueName = this.ConnectorDefinitionUniqueName,
                ConnectorDefinitionSpecificationLevels = new List<SpecificationLevel>(this.ConnectorDefinitionSpecificationLevels),
                ReferenceKind = this.ReferenceKind,
                ReferenceSpecificationLevels = new List<SpecificationLevel>(this.ReferenceSpecificationLevels),
                PropertyStatement = this.PropertyStatement == null ? null : this.PropertyStatement.Clone()
            };
        }

        #endregion


        // ------------------------------------------
        // MUTATORS
        // ------------------------------------------

        #region Mutators

        /// <summary>
        /// Initializes the path of this instance.
        /// </summary>
        public override void InitializePath()
        {
            myEmailUniqueIds = new List<string>();
            myAttachementFileNames = new List<string>();
        }

        #endregion


        // --------------------------------------------------
        // LOADING
        // --------------------------------------------------

        #region Loading

        /// <summary>
        /// Instantiates a new instance of Email class from a xml string.
        /// </summary>
        /// <param name="aXmlString">The Xml string to load.</param>
        public new static InformationCarrier LoadFromXmlString(string aXmlString)
        {
            Email aEmail = null;
            StringReader aStringReader = null;
            try
            {
                // we parse the xml string
                XDocument aXDocument = XDocument.Parse(aXmlString);

                // then we load
                XmlSerializer aXmlSerializer = new XmlSerializer(typeof(Email));
                aStringReader = new StringReader(aXmlString);
                aEmail = (Email)aXmlSerializer.Deserialize(XmlReader.Create(aStringReader));
            }
            catch
            {
            }
            finally
            {
                if (aStringReader != null)
                    aStringReader.Close();
            }

            return aEmail;
        }

        #endregion


        // ------------------------------------------
        // CHECK / REPAIR
        // ------------------------------------------

        #region Check Repair

        /// <summary>
        /// Repairs this instance.
        /// </summary>
        /// <returns>Returns a repair log.</returns>
        public override Log Repair()
        {
            Log aLog = base.Repair();

            return aLog;
        }

        #endregion
    }
}
