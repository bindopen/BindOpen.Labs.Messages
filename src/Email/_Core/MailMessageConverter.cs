using BindOpen.Kernel;
using BindOpen.Kernel.Data.Helpers;
using System.Net.Mail;

namespace BindOpen.Labs.Messages.Email
{
    /// <summary>
    /// This class represents the delivery of a to-send message.
    /// </summary>
    public static class MailMessageConverter
    {
        public static MailMessage ToMail(this IBdoSendingMessage message, string uiCulture = StringHelper.__Star)
        {
            if (message != null)
            {
                MailMessage mailMessage = new()
                {
                    From = new MailAddress(message.From.Email, message.From.Name),
                    Subject = message.Subject[uiCulture],
                    Body = message.Body[uiCulture],
                    IsBodyHtml = message.IsBodyHtml
                };
                if (message.ReplyTo.Count > 0)
                {
                    if (!string.IsNullOrEmpty(message.ReplyTo[0].Email))
                    {
                        mailMessage.ReplyToList.Add(new MailAddress(
                            message.ReplyTo[0].Email,
                            message.ReplyTo[0].Name));
                    }
                }

                foreach (var currentContact in message.To)
                {
                    if (!string.IsNullOrEmpty(currentContact.Email))
                    {
                        mailMessage.To.Add(new MailAddress(
                        currentContact.Email,
                        currentContact.Name));
                    }
                }

                mailMessage.Priority = message.Priority switch
                {
                    ActionPriorities.High => MailPriority.High,
                    ActionPriorities.Low => MailPriority.Low,
                    _ => MailPriority.Normal,
                };

                //if (message.IsNotificationOnFailure)
                //    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //if (message.IsNotificationOnSucess)
                //    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                //if (message.IsNotificationOnFailure && message.IsNotificationOnSucess)
                //    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure & DeliveryNotificationOptions.OnSuccess;
                //if (message.IsNotificationOnReception && message.NotificationTo != null)
                //    mailMessage.Headers.Add("Disposition-Notification-To", message.NotificationTo.Email);
                //if (message.IsNotificationOnRead && message.NotificationTo != null)
                //    mailMessage.Headers.Add("Read-Receipt-To", message.NotificationTo.Email);

                foreach (string attachedFile in message.AttachedFiles)
                    mailMessage.Attachments.Add(new Attachment(attachedFile));

                return mailMessage;
            }

            return null;
        }
    }
}
