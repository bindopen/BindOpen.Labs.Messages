using System;
using BindOpen.Framework.Core.Extensions.Items.Connectors;

namespace BindOpen.Framework.Labs.Messages.Extension.Connectors
{

    /// <summary>
    /// This class represents a email data source.
    /// </summary>
    [Serializable()]
    public class EmailDataSource : ConnectorConfiguration
    {
        // -----------------------------------------------
        // CONSTRUCTORS
        // -----------------------------------------------

        #region Constructors

        /// <summary>
        /// This instantiates a new instance of the EmailDataSource class.
        /// </summary>
        public EmailDataSource()
            : base()
        {
        }

        #endregion
    }
}
