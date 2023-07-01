using BindOpen.Application.Scopes;
using BindOpen.Data.Business;
using BindOpen.Data.Common;
using BindOpen.Data.Stores;
using BindOpen.Extensions.Runtime;
using BindOpen.Messages.Data.Common;
using BindOpen.Messages.Extension.Connectors.smtp;
using BindOpen.Messages.Extension.Entities.Messages;
using BindOpen.System.Diagnostics;
using System;
using System.Net;
using System.Net.Mail;

namespace BindOpen.Messages.Application.Messages.Senders
{
    /// <summary>
    /// This class represents the email sender.
    /// </summary>
    public static class MessageSender_Email
    {
        // --------------------------------------
        // SENDING
        // --------------------------------------

        #region Sending

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="appHost">The application host to consider.</param>
        /// <param name="message">The simple message to send.</param>
        /// <param name="method">The send request delivery to use.</param>
        /// <param name="log">The log to consider.</param>
        /// <returns>The log of task.</returns>
        public static bool SendSmtp(
            this IBdoHost appHost,
            ContactMessage message,
            MessageSendRequestDeliveryMethod method,
            IBdoLog log = null)
        {
            log = log ?? new BdoLog();

            if (appHost == null)
                return false;

            try
            {
                string datasourceName = method.DataSourceName;
                if ((datasourceName?.Length == 0) || (datasourceName == null))
                {
                    datasourceName = "smtp_default";
                }

                IBdoConnectorConfiguration configuration = null;
                if ((configuration = appHost.Scope.DataStore.GetDatasourceDepot()?.GetConnectorConfiguration(datasourceName, "messages$smtp")) == null)
                {
                    log.AddError("No email account settings found",
                        description: "No email account settings named '" + datasourceName + "' found.");
                }
                else
                {
                    BdoEmailConnector_Smtp emailConnector = appHost.Scope.CreateConnector<BdoEmailConnector_Smtp>(configuration, null, log);

                    if (emailConnector != null)
                    {
                        // we build the smtp client.
                        SmtpClient smtpClient = new SmtpClient
                        {
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            EnableSsl = emailConnector.IsSslEnabled == true,
                            Host = emailConnector.Host,
                            Port = emailConnector.Port ?? -1,
                            Timeout = emailConnector.Timeout ?? -1,
                            UseDefaultCredentials = emailConnector.IsDefaultCredentialsUsed == true
                        };
                        if (!string.IsNullOrEmpty(emailConnector.Login) && !string.IsNullOrEmpty(emailConnector.Password))
                        {
                            smtpClient.Credentials = new NetworkCredential(
                                emailConnector.Login,
                                emailConnector.Password);
                        }

                        // we build the mail message.
                        MailMessage mailMessage = new MailMessage
                        {
                            From = new MailAddress(message.From.Email, message.From.Name),
                            // we do not use Cc and Bcc as these user contacts (of a message)
                            // are put into the To of a simple message.
                            Subject = message.Subject.GetContent(),
                            Body = message.Body.GetContent(),
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

                        foreach (Contact currentContact in message.To)
                        {
                            if (!String.IsNullOrEmpty(currentContact.Email))
                            {
                                mailMessage.To.Add(new MailAddress(
                                currentContact.Email,
                                currentContact.Name));
                            }
                        }

                        switch (message.Priority)
                        {
                            case ActionPriorities.High:
                                mailMessage.Priority = MailPriority.High;
                                break;
                            case ActionPriorities.Low:
                                mailMessage.Priority = MailPriority.Low;
                                break;
                            default:
                                mailMessage.Priority = MailPriority.Normal;
                                break;
                        }
                        if (message.IsNotificationOnFailure)
                            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        if (message.IsNotificationOnSucess)
                            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                        if ((message.IsNotificationOnFailure) && (message.IsNotificationOnSucess))
                            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure & DeliveryNotificationOptions.OnSuccess;
                        if ((message.IsNotificationOnReception) && (message.NotificationTo != null))
                            mailMessage.Headers.Add("Disposition-Notification-To", message.NotificationTo.Email);
                        if ((message.IsNotificationOnRead) && (message.NotificationTo != null))
                            mailMessage.Headers.Add("Read-Receipt-To", message.NotificationTo.Email);

                        foreach (string attachedFile in message.AttachedFiles)
                            mailMessage.Attachments.Add(new Attachment(attachedFile));

                        // we send the email
                        smtpClient.Send(mailMessage);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.AddException(ex);
            }

            return false;
        }

        #endregion

    }
}
