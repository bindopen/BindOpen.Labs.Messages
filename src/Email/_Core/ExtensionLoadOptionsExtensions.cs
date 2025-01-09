using BindOpen.Messages.Email.Connectors;
using BindOpen.Scoping;

namespace BindOpen.Messages.Email;

/// <summary>
/// This class represents an application scope factory.
/// </summary>
public static class ExtensionLoadOptionsExtensions
{
    /// <summary>
    /// Creates a reference to the PostgreSql extension.
    /// </summary>
    /// <returns>Returns the reference to the PostgreSql extension.</returns>
    public static IExtensionLoadOptions AddEmail(this IExtensionLoadOptions options)
    {
        options.AddAssemblyFrom<BdoSmtpConnector>();

        return options;
    }
}