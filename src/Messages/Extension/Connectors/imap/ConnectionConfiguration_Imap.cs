using cor_base_wdl.data.connectors;
using cor_base_wdl.data.objects;
using cor_base_wdl.data.objects.generic;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace dkm.messages.definition.connections.imap
{
    /// <summary>
    /// This class represents a Imap connection configuration.
    /// </summary>
    public class ConnectionParameterStatement_Imap : DataSource
    {

       // -----------------------------------------------
       // PROPERTIES
       // -----------------------------------------------

       #region Properties

        /// <summary>
        /// The host of the remote server.
        /// </summary>
        [XmlElement("host")]
        public String Host
        {
            get
            {
                return this.Detail.GetElementStringValue("Host");
            }
        }

        /// <summary>
        /// Login of this instance.
        /// </summary>
        [XmlElement("login")]
        public String Login
        {
            get
            {
                return this.Detail.GetElementStringValue("Login");
            }
        }

        /// <summary>
        /// Password of this instance.
        /// </summary>
        [XmlElement("password")]
        public String Password
        {
            get
            {
                return this.Detail.GetElementStringValue("Password");
            }
        }

        /// <summary>
        /// Port of this instance.
        /// </summary>
        [XmlElement("port")]
        public int Port
        {
            get
            {
                return (int)this.Detail.GetElementValue("Port");
            }
        }
        
        /// <summary>
        /// Indicates whether this instance enables SSL.
        /// </summary>
        [XmlElement("isSslEnabled")]
        public Boolean IsSslEnabled
        {
            get
            {
                return (Boolean)this.Detail.GetElementValue("IsSslEnabled");
            }
        }
        
        /// <summary>
        /// Indicates whether this instance uses the default credentials.
        /// </summary>
        [XmlElement("isDefaultCredentialsUsed")]
        public Boolean IsDefaultCredentialsUsed
        {
            get
            {
                return (Boolean)this.Detail.GetElementValue("IsDefaultCredentialsUsed");
            }
        }
        
        /// <summary>
        /// Time out of this instance.
        /// </summary>
        [XmlElement("timeout")]
        public int Timeout
        {
            get
            {
                return (int)this.Detail.GetElementValue("Timeout");
            }
        }
            
       #endregion
               

       // -----------------------------------------------
       // CONSTRUCTORS
       // -----------------------------------------------

       #region Constructors

        /// <summary>
        /// This instantiates a new instance of the ConnectionParameterStatementDefinition_Imap class.
        /// </summary>
        public ConnectionParameterStatement_Imap()
            : base()
        {
        }

        /// <summary>
        /// This instantiates a new instance of the ConnectionParameterStatementDefinition_Imap class.
        /// </summary>
        /// <param name="aConnectionParameterStatement">The connection configuration to consider.</param>
        public ConnectionParameterStatement_Imap(DataSource aConnectionParameterStatement)
            : base(aConnectionParameterStatement)
        {
        }

       #endregion


        // -----------------------------------------------
        // MUTATORS
        // -----------------------------------------------

        #region Mutators

        /// <summary>
        /// Repairs this instance.
        /// </summary>
        protected override void Initialize()
        {
            this.ConnectorUniqueName = "messages$imap";
            this.Detail.Repair(
                new DataElementSet()
                {
                    Elements= new List<DataElement>()
                    {
                        new DataElement("Host", DataValueType.Text),
                        new DataElement("Login", DataValueType.Text),
                        new DataElement("Password", DataValueType.Text),
                        new DataElement("Port", DataValueType.Integer),
                        new DataElement("IsSslEnabled", DataValueType.Boolean),
                        new DataElement("IsDefaultCredentialsUsed", DataValueType.Boolean),
                        new DataElement("Timeout", DataValueType.Integer)
                    }
                });
        }

        #endregion

    }
}
