using BindOpen.Kernel;
using BindOpen.Kernel.Data;

namespace BindOpen.Labs.Messages.Contacts
{
    /// <summary>
    /// This enumeration lists the possible media used to send a message.
    /// </summary>
    public interface IBdoContact : IBdoObject, IIdentified, IReferenced, INamed
    {
        string LastName { get; set; }

        string FirstName { get; set; }

        string Email { get; set; }
    }
}
