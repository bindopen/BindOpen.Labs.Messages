using BindOpen.Data;
using BindOpen.Data.Helpers;
using BindOpen.Logging;
using System.Net.Mail;

namespace BindOpen.Messages.Email;

/// <summary>
/// This class represents the delivery of a to-send message.
/// </summary>
public static class MailMessageConverter
{
    public static MailMessage ToMail(
        this IBdoSendingMessage message,
        IBdoLog log = null)
    {
        if (message != null)
        {
            if (string.IsNullOrEmpty(message.From?.Email))
            {
                log?.AddEvent(EventKinds.Error, "Recipient email missing");
            }
            else
            {
                MailMessage mailMessage = new()
                {
                    From = new MailAddress(message.From?.Email, message.From?.Name),
                    Subject = message.Subject?[message?.UICulture ?? StringHelper.__Star],
                    Body = message.Body?[message?.UICulture ?? StringHelper.__Star],
                    IsBodyHtml = message.IsBodyHtml
                };

                if (message.ReplyTo?.Count > 0)
                {
                    if (!string.IsNullOrEmpty(message.ReplyTo[0].Email))
                    {
                        mailMessage.ReplyToList.Add(new MailAddress(
                            message.ReplyTo[0].Email,
                            message.ReplyTo[0].Name));
                    }
                }

                if (message.To?.Count > 0)
                {
                    foreach (var currentContact in message.To)
                    {
                        if (!string.IsNullOrEmpty(currentContact.Email))
                        {
                            mailMessage.To.Add(new MailAddress(
                            currentContact.Email,
                            currentContact.Name));
                        }
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

                if (message.AttachedFiles?.Count > 0)
                {
                    foreach (string attachedFile in message.AttachedFiles)
                        mailMessage.Attachments.Add(new Attachment(attachedFile));
                }

                return mailMessage;
            }
        }

        return null;
    }
}
