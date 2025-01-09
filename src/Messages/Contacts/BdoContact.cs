using BindOpen.Data;

namespace BindOpen.Messages.Contacts
{
    /// <summary>
    /// This enumeration lists the possible media used to send a message.
    /// </summary>
    public class BdoContact : BdoObject, IBdoContact
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public BdoContact()
        {
        }

        // IIdentified Implementation

        public string Identifier { get; set; }

        // IReferenced Implementation

        public string Key() => Identifier;
    }
}
