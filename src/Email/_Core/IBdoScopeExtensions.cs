using BindOpen.Messages.Email.Connectors;
using BindOpen.Scoping;

namespace BindOpen.Messages.Email
{
    /// <summary>
    /// This class represents an application scope factory.
    /// </summary>
    public static class IBdoScopeExtensions
    {
        /// <summary>
        /// Creates a reference to the PostgreSql extension.
        /// </summary>
        /// <returns>Returns the reference to the PostgreSql extension.</returns>
        public static BdoSmtpConnector CreateSmtpConnector(this IBdoScope scope)
        {
            return scope.CreateConnector<BdoSmtpConnector>();
        }
    }
}