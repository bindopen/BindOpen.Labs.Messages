using cor_base_wdl.data.connectors;
using cor_base_wdl.data.objects;
using cor_base_wdl.data.objects.generic;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BindOpen.Messages.Emails.Connectors.pop3
{
    /// <summary>
    /// This class represents a Pop3 connection configuration.
    /// </summary>
    public class ConnectionParameterStatement_Pop3 : DataSource
    {

        // -----------------------------------------------
        // PROPERTIES
        // -----------------------------------------------

        #region Properties

        /// <summary>
        /// The host of the remote server.
        /// </summary>
        [XmlElement("host")]
        public string Host
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
        public string Login
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
        public string Password
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
        public bool IsSslEnabled
        {
            get
            {
                return (bool)this.Detail.GetElementValue("IsSslEnabled");
            }
        }

        /// <summary>
        /// Indicates whether this instance uses the default credentials.
        /// </summary>
        [XmlElement("isDefaultCredentialsUsed")]
        public bool IsDefaultCredentialsUsed
        {
            get
            {
                return (bool)this.Detail.GetElementValue("IsDefaultCredentialsUsed");
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
        /// This instantiates a new instance of the ConnectionParameterStatementDefinition_Pop3 class.
        /// </summary>
        public ConnectionParameterStatement_Pop3()
            : base()
        {
        }

        /// <summary>
        /// This instantiates a new instance of the ConnectionParameterStatementDefinition_Pop3 class.
        /// </summary>
        /// <param name="aConnectionParameterStatement">The connection configuration to consider.</param>
        public ConnectionParameterStatement_Pop3(DataSource aConnectionParameterStatement)
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
            this.ConnectorUniqueName = "messages$pop3";
            this.Detail.Repair(
                new DataElementSet()
                {
                    Elements = new List<DataElement>()
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
