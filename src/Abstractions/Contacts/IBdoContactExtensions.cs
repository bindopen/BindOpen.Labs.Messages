namespace BindOpen.Plus.Messages.Contacts
{
    /// <summary>
    /// This class represents the delivery method for a message send request.
    /// </summary>
    public static class IBdoContactExtensions
    {
        /// <summary>
        /// The first name of this instance.
        /// </summary>
        public static T WithFirstName<T>(this T obj, string firstName)
            where T : IBdoContact
        {
            if (obj != null)
            {
                obj.FirstName = firstName;
            }

            return obj;
        }

        /// <summary>
        /// The last name of this instance.
        /// </summary>
        public static T WithLastName<T>(this T obj, string lastName)
            where T : IBdoContact
        {
            if (obj != null)
            {
                obj.LastName = lastName;
            }

            return obj;
        }

        /// <summary>
        /// The email of this instance.
        /// </summary>
        public static T WithEmail<T>(this T obj, string email)
            where T : IBdoContact
        {
            if (obj != null)
            {
                obj.Email = email;
            }

            return obj;
        }
    }
}
