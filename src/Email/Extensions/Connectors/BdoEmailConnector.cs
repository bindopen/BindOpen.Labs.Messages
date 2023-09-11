using BindOpen.Kernel.Scoping.Connectors;

namespace BindOpen.Labs.Messages.Email.Connectors
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
    }
}
