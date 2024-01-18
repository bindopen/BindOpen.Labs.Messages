using BindOpen.Scoping.Connectors;

namespace BindOpen.Messages.Email.Connectors
{

    /// <summary>
    /// This class defines a email connector.
    /// </summary>
    public interface IBdoEmailConnection : ITBdoConnection<IBdoMessage>
    {
    }
}
