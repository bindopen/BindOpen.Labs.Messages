using BindOpen.Extensions.References;
using BindOpen.Messages._Core.Enums;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// This class extends BindOpenHost.
    /// </summary>
    public static class ExtensionReferenceFactory
    {
        /// <summary>
        /// Creates a reference to the Messages extension.
        /// </summary>
        /// <returns>Returns the reference to the PostgreSql extension.</returns>
        public static IBdoExtensionReference CreateMessages()
        {
            return BdoExtensionReferenceFactory.CreateFrom<MessageSendMode>();
        }

        /// <summary>
        /// Adds a Messages extension reference to a specified list of references.
        /// </summary>
        /// <param name="references">The references to consider.</param>
        /// <returns>Returns the updated list of references.</returns>
        public static IBdoExtensionReferenceCollection AddMessages(this IBdoExtensionReferenceCollection references)
        {
            references?.Add(BdoExtensionReferenceFactory.CreateFrom<MessageSendMode>());

            return references;
        }
    }
}
