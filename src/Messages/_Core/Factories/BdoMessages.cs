using BindOpen.Kernel.Data;
using BindOpen.Labs.Messages.Contacts;

namespace BindOpen.Labs.Messages
{
    /// <summary>
    /// This class extends BindOpenHost.
    /// </summary>
    public static class BdoMessages
    {
        public static T NewContact<T>()
            where T : IBdoContact, new()
        {
            return BdoData.New<T>();
        }

        public static BdoContact NewContact()
        {
            return BdoData.New<BdoContact>();
        }

        public static T NewMessage<T>(string subject = null, string body = null)
            where T : IBdoMessage, new()
        {
            var obj = BdoData.New<T>()
                .WithSubject(BdoData.NewDictionary(subject))
                .WithBody(BdoData.NewDictionary(body));

            return obj;
        }

        public static BdoMessage NewMessage(string subject = null, string body = null)
        {
            return NewMessage<BdoMessage>(subject, body);
        }

        public static BdoSendingMessage NewSendingMessage(string subject = null, string body = null)
        {
            return NewMessage<BdoSendingMessage>(subject, body);
        }

        public static BdoMessage NewSendingRequest()
        {
            return BdoData.New<BdoMessage>();
        }
    }
}
