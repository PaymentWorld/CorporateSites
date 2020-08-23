using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Codebase.Website.Nmc.Helpers
{
    public enum AddressTypeEnums
    {
        To = 1,
        Cc = 2,
        Bcc = 3
    }
    /// <summary>
    /// Facade that is used to send electronic mail to a Simple Mail Transfer Protocol (SMTP) server for delivery. 
    /// </summary>
    public class SmtpClient
    {
        private static readonly char SEMICOLON = ';';
        private static readonly char VERTICALBAR = '|';

        /// <summary>
        /// static. Overloaded. Sends an e-mail message to an SMTP server for delivery. These methods block the executing thread while the message is being transmitted.
        /// </summary>
        /// <param name="smtpServer">The name or IP address of the host computer used for SMTP transactions.</param>
        /// <param name="message">A class used to construct e-mail messages that are transmitted to an SMTP server. (Namespace: System.Net.Mail).</param>
        /// <returns>bool. true if the message was sent, otherwise false.</returns>
        public static bool SendEmail(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, bool Ssl, MailMessage message)
        {
            bool sent = false;

            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpServer, smtpPort);
                client.UseDefaultCredentials = true;

                if (!string.IsNullOrEmpty(smtpUsername))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                }
                client.EnableSsl = Ssl;
                client.Send(message);
                sent = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sent;
        }

        /// <summary>
        /// static. Overloaded. Sends an e-mail message to an SMTP server for delivery. These methods block the executing thread while the message is being transmitted.
        /// </summary>
        /// <param name="smtpServer">The name or IP address of the host computer used for SMTP transactions.</param>
        /// <param name="from">The sender address for this e-mail.</param>
        /// <param name="fromName">The display name associated with the from address. This parameter can be null.</param>
        /// <param name="to">The address collection that contains the recipients for this e-mail message. 
        /// <remarks>1. additional addresses are semicolon ';' separated.  2. (optional) to display name of recipient separate name and address with vertical bar '|'.  </remarks>
        /// <example>ex1. superuser1@yahoo.com  ex2. SuperUserName1|superuser1@yahoo.com  ex3. SuperUserName1|superuser1@yahoo.com; superuser2@gmail.com; SuperUserName3|superuser3@hotmail.com</example>
        /// </param>
        /// <param name="cc">The address collection yhat contains the carbon copy (cc) recipients for this e-mail message. 
        /// <remarks>Please see remarks for parameter 'to'.</remarks>
        /// <example>Please see example for parameter 'to'.</example>
        /// </param>
        /// <param name="bcc">The address collection that contains the blind carbon copy (bcc) recipients for this e-mail message. 
        /// <remarks>Please see remarks for parameter 'to'.</remarks>
        /// <example>Please see example for parameter 'to'.</example>
        /// </param>
        /// <param name="subject">The subject line for this e-mail.</param>
        /// <param name="body">The message body for this e-mail.</param>  
        /// <param name="priority">Specifies the priority of an e-mail.</param>
        /// <param name="attachments">A string that contains a file path to use to create this attachment.</param>
        /// <remarks>1. additional attachments are semicolon ';' separated  </remarks>
        /// <returns>bool. true if the message was sent, otherwise false.</returns>        
        public static bool SendEmail(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, bool Ssl, string from, string fromName, string to, string cc, string bcc, string subject, string body, MailPriority priority)
        {
            #region " testing/debug only "

            //to = "eespinosa@nationalmerchant";

            #endregion

            MailMessage message = new MailMessage();

            message.From = string.IsNullOrEmpty(from) ? null : new MailAddress(from, fromName);

            // parse recepient address(es) here
            SmtpClient.AddAddress(message, AddressTypeEnums.To, to);

            if (!string.IsNullOrEmpty(cc))
                SmtpClient.AddAddress(message, AddressTypeEnums.Cc, cc);

            if (!string.IsNullOrEmpty(bcc))
                SmtpClient.AddAddress(message, AddressTypeEnums.Bcc, bcc);

            // set additional message properties
            message.IsBodyHtml = true;
            message.Priority = priority;
            message.Subject = subject;
            message.Body = body;

            return SmtpClient.SendEmail(smtpServer, smtpPort, smtpUsername, smtpPassword, Ssl, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtpServer"></param>
        /// <param name="smtpPort"></param>
        /// <param name="smtpUsername"></param>
        /// <param name="smtpPassword"></param>
        /// <param name="from"></param>
        /// <param name="fromName"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="priority"></param>
        /// <param name="attachments"></param>
        /// <returns></returns>
        public static bool SendEmail(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, bool Ssl, string from, string fromName, string to, string cc, string bcc, string subject, string body, MailPriority priority, string attachments)
        {
            MailMessage message = new MailMessage();

            message.From = string.IsNullOrEmpty(from) ? null : new MailAddress(from, fromName);

            // parse recepient address(es) here
            SmtpClient.AddAddress(message, AddressTypeEnums.To, to);

            if (!string.IsNullOrEmpty(cc))
                SmtpClient.AddAddress(message, AddressTypeEnums.Cc, cc);

            if (!string.IsNullOrEmpty(bcc))
                SmtpClient.AddAddress(message, AddressTypeEnums.Bcc, bcc);

            if (!string.IsNullOrEmpty(attachments))
                SmtpClient.AddAttachments(message, attachments);

            // set additional message properties
            message.IsBodyHtml = true;
            message.Priority = priority;
            message.Subject = subject;
            message.Body = body;

            return SmtpClient.SendEmail(smtpServer, smtpPort, smtpUsername, smtpPassword, Ssl, message);
        }

        /// <summary>
        /// static. Sends a SMS text message to an SMTP server for delivery. This method blocks the executing thread while the message is being transmitted.
        /// </summary>
        /// <param name="smtpServer">The name or IP address of the host computer used for SMTP transactions.</param>
        /// <param name="from">The sender phone number or e-mail address for this text message.</param>
        /// <remarks>1. phone number must be 10 digits (area code + phone number) no special characters. </remarks>
        /// <param name="fromName">The display name associated with the from parameter. This parameter can be null.</param>
        /// <param name="toPhoneNumber">The phone number collection that contains the recipients for this text message. Please see phone carrier as to what host name to use.
        /// <remarks>1. phone number must be 10 digits (area code + phone number) no special characters.  2. additional phone numbers are semicolon ';' separated. </remarks>
        /// <example>ex1. 1234567890@att.net  ex2. 1234567890@att.net; 9876543210@verizon.net; 9494198400@tmomail.net</example>        
        /// </param>
        /// <param name="subject">The subject line for this text message.</param>
        /// <param name="body">The message body for this text message.</param>        
        /// <returns>bool. true if the message was sent, otherwise false.</returns>
        public static bool SendTextMessage(string smtpServer, int smtpPort, string from, string fromName, string toPhoneNumber, string subject, string body, string smtpUsername, string smtpPassword, bool Ssl)
        {
            MailMessage message = new MailMessage();

            message.From = string.IsNullOrEmpty(from) ? null : new MailAddress(from, fromName);

            // parse recepient address(es) here.
            SmtpClient.AddAddress(message, AddressTypeEnums.To, toPhoneNumber);

            // set additional message properties
            message.IsBodyHtml = false;
            message.Priority = MailPriority.Normal;
            message.Subject = subject;
            message.Body = body;

            return SmtpClient.SendEmail(smtpServer, smtpPort, smtpUsername, smtpPassword, Ssl, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="additionalMessage"></param>
        /// <returns></returns>
        public static bool SendEmail(Exception ex, bool Ssl, string additionalMessage)
        {
            NotificationConfiguration notification = ConfigurationManager.GetSection("notificationConfiguration") as NotificationConfiguration;

            if (notification == null)
                throw new ConfigurationErrorsException("notificationConfiguration section is missing.");

            NotificationConfigurationElement e = notification.Smtp.GetNotificationElement("exception");

            if (e == null)
                throw new ConfigurationErrorsException("could not load <smtp> e name \"exception\"");

            int port = 80;

            if (!string.IsNullOrEmpty(e.Port))
            {
                if (!Int32.TryParse(e.Port, out port))
                    port = 80;
            }

            string message = ex.Message + "\r\n" + ex.StackTrace + ".\r\n" + (string.IsNullOrEmpty(additionalMessage) ? string.Empty : "Additional Message: " + additionalMessage);

            return SmtpClient.SendEmail(e.Server, port, e.Username, e.Password, Ssl, e.From, e.FromName, e.To, e.Cc, e.Bcc, e.Subject, message, MailPriority.High);
        }

        #region " Helper Functions "

        private static bool AddAddress(MailMessage message, AddressTypeEnums type, string address)
        {
            string ename = null;
            string eaddress = null;

            string[] addressCollection = address.Split(',');

            foreach (string addr in addressCollection)
            {
                ename = null;
                eaddress = null;

                if (addr.Contains(VERTICALBAR.ToString()))
                {
                    string[] nameAddressCollection = addr.Split(VERTICALBAR);

                    if (String.IsNullOrEmpty(nameAddressCollection[1].Trim()))
                        return false;

                    ename = String.IsNullOrEmpty(nameAddressCollection[0].Trim()) ? null : nameAddressCollection[0].Trim();
                    eaddress = nameAddressCollection[1].Trim();
                }
                else
                {
                    if (String.IsNullOrEmpty(addr.Trim()))
                        return false;

                    eaddress = addr;
                }

                switch (type)
                {
                    case AddressTypeEnums.To:
                        message.To.Add(new MailAddress(eaddress, ename));
                        break;

                    case AddressTypeEnums.Cc:
                        message.CC.Add(new MailAddress(eaddress, ename));
                        break;

                    case AddressTypeEnums.Bcc:
                        message.Bcc.Add(new MailAddress(eaddress, ename));
                        break;
                }
            }

            return true;
        }

        private static void AddAttachments(MailMessage message, string attachments)
        {
            string[] collection = attachments.Split(SEMICOLON);

            foreach (string attachment in collection)
                message.Attachments.Add(new Attachment(attachment.Trim()));
        }

        #endregion
    }

    public class NotificationConfiguration : ConfigurationSection
    {
        /// <summary>
        /// The configuration e collection for the Adaptors.
        /// </summary>
        [ConfigurationProperty("smtp")]
        public NotificationConfigurationElementCollection Smtp
        {
            get
            {
                return this["smtp"] as NotificationConfigurationElementCollection;
            }
        }
    }

    public class NotificationConfigurationElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// The Adaptors configuration e section.
        /// </summary>
        /// <param name="index">The index of the congifuration e to retrieve.</param>
        /// <returns>NotificationConfigurationElement. The configuration e specified by the index.</returns>
        public NotificationConfigurationElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as NotificationConfigurationElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Gets the configuration e.
        /// </summary>
        /// <param name="name">The reference of the configuration e to get.</param>
        /// <returns>NotificationConfigurationElement. The configuration e specified by the name.</returns>
        public NotificationConfigurationElement GetNotificationElement(string name)
        {
            return base.BaseGet(name) as NotificationConfigurationElement;
        }

        /// <summary>
        /// Creates a new congfiguration e.
        /// </summary>
        /// <returns>NotificationConfigurationElement.  A new configuration e.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new NotificationConfigurationElement();
        }

        /// <summary>
        /// Gets the configuration e.
        /// </summary>
        /// <param name="e">The configuration e to get.</param>
        /// <returns>object. NotificationConfigurationElement. </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NotificationConfigurationElement)element).Name;
        }

        ///// <summary>
        ///// Property Field: xmlMapPath; IsRequired = true
        ///// </summary>
        //[ConfigurationProperty("default", IsRequired = true)]
        //public string Default
        //{
        //    get { return this["default"] as string; }
        //}

        ///// <summary>
        ///// Property Field: xmlMapPath; IsRequired = true
        ///// </summary>
        //[ConfigurationProperty("exception", IsRequired = true)]
        //public string Exception
        //{
        //    get { return this["exception"] as string; }
        //}
    }

    public class NotificationConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Property Field: name; IsKey = true; IsRequired = true
        /// </summary>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
        }

        /// <summary>
        /// Property Field: server; IsRequired = true
        /// </summary>
        [ConfigurationProperty("server", IsRequired = true)]
        public string Server
        {
            get { return this["server"] as string; }
        }

        /// <summary>
        /// Property Field: port; IsRequired = true
        /// </summary>
        [ConfigurationProperty("port", IsRequired = true)]
        public string Port
        {
            get { return this["port"] as string; }
        }

        /// <summary>
        /// Property Field: username; IsRequired = false
        /// </summary>
        [ConfigurationProperty("username", IsRequired = false)]
        public string Username
        {
            get { return this["username"] as string; }
        }

        /// <summary>
        /// Property Field: password; IsRequired = false
        /// </summary>
        [ConfigurationProperty("password", IsRequired = false)]
        public string Password
        {
            get { return this["password"] as string; }
        }

        /// <summary>
        /// Property Field: from; IsRequired = false
        /// </summary>
        [ConfigurationProperty("from", IsRequired = false)]
        public string From
        {
            get { return this["from"] as string; }
        }

        /// <summary>
        /// Property Field: fromName; IsRequired = false
        /// </summary>
        [ConfigurationProperty("fromName", IsRequired = false)]
        public string FromName
        {
            get { return this["fromName"] as string; }
        }

        /// <summary>
        /// Property Field: to; IsRequired = false
        /// </summary>
        [ConfigurationProperty("to", IsRequired = false)]
        public string To
        {
            get { return this["to"] as string; }
        }

        /// <summary>
        /// Property Field: cc; IsRequired = false
        /// </summary>
        [ConfigurationProperty("cc", IsRequired = false)]
        public string Cc
        {
            get { return this["cc"] as string; }
        }

        /// <summary>
        /// Property Field: bcc; IsRequired = false
        /// </summary>
        [ConfigurationProperty("bcc", IsRequired = false)]
        public string Bcc
        {
            get { return this["bcc"] as string; }
        }

        /// <summary>
        /// Property Field: subject; IsRequired = false
        /// </summary>
        [ConfigurationProperty("subject", IsRequired = false)]
        public string Subject
        {
            get { return this["subject"] as string; }
        }
    }
}