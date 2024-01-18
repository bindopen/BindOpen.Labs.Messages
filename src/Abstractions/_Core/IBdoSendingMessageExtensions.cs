using BindOpen.Messages.Contacts;
using System.Linq;

namespace BindOpen.Messages
{
    /// <summary>
    /// This class represents the delivery method for a message send request.
    /// </summary>
    public static class IBdoSendingMessageExtensions
    {
        public static T WithUICulture<T>(this T obj, string uiCulture)
            where T : IBdoSendingMessage
        {
            if (obj != null)
            {
                obj.UICulture = uiCulture;
            }

            return obj;
        }

        /// <summary>
        /// Media of this instance.
        /// </summary>
        public static T WithFrom<T>(this T obj, IBdoContact contact)
            where T : IBdoSendingMessage
        {
            if (obj != null)
            {
                obj.From = contact;
            }

            return obj;
        }

        /// <summary>
        /// Mode of this instance.
        /// </summary>
        public static T WithReplyTo<T>(this T obj, params IBdoContact[] contacts)
            where T : IBdoSendingMessage
        {
            if (obj != null)
            {
                obj.ReplyTo = contacts?.ToList();
            }

            return obj;
        }

        /// <summary>
        /// To mode of this instance.
        /// </summary>
        public static T WithTo<T>(this T obj, params IBdoContact[] contacts)
            where T : IBdoSendingMessage
        {
            if (obj != null)
            {
                obj.To = contacts?.ToList();
            }

            return obj;
        }

        /// <summary>
        /// To mode of this instance.
        /// </summary>
        public static T WithCc<T>(this T obj, params IBdoContact[] contacts)
            where T : IBdoSendingMessage
        {
            if (obj != null)
            {
                obj.Cc = contacts?.ToList();
            }

            return obj;
        }

        /// <summary>
        /// To mode of this instance.
        /// </summary>
        public static T WithBcc<T>(this T obj, params IBdoContact[] contacts)
            where T : IBdoSendingMessage
        {
            if (obj != null)
            {
                obj.Bcc = contacts?.ToList();
            }

            return obj;
        }
    }
}
