using Codebase.Website.Nmc.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Codebase.Website.Controllers
{
    public class homeController : Controller
    {
        //
        // GET: /home/

        public ActionResult index()
        {
            return View();
        }

        public ActionResult terms_of_use()
        {
            return View();
        }

        public ActionResult privacy_policy()
        {
            return View();
        }

        public ActionResult opt_out_policy() {
            return View();
        }

        public ActionResult submitOptOut() {
            var MerchantId = Request.Form.Get("MerchantId");
            var SSN = Request.Form.Get("SSN");
            var FirstName = Request.Form.Get("FirstName");
            var LastName = Request.Form.Get("LastName");
            var Email = Request.Form.Get("Email");
            var Phone = Request.Form.Get("Phone");
            var City = Request.Form.Get("City");
            var Zip = Request.Form.Get("Zip");
            var Disclosure = Request.Form.Get("Disclosure");
            var OptOut = Request.Form.Get("OptOut");
            var Access = Request.Form.Get("Access");
            var Deletion = Request.Form.Get("Deletion");


            var z_SmtpPassword = WebConfigurationManager.AppSettings["SmtpPassword"];
            var z_SmtpPort = Convert.ToInt32(WebConfigurationManager.AppSettings["SmtpPort"]);
            var z_SmtpServer = WebConfigurationManager.AppSettings["SmtpHost"];
            var z_SmtpUsername = WebConfigurationManager.AppSettings["SmtpUsername"];
            var z_EmailPriority = Convert.ToInt32(WebConfigurationManager.AppSettings["SmtpPriority"]);
            var z_SmtpSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SmtpSSL"]);
            var z_SmtpAdminEmail = System.Configuration.ConfigurationManager.AppSettings["SmtpAdminEmail"];
            var z_SmtpCc = System.Configuration.ConfigurationManager.AppSettings["SmtpCc"];
            var z_SmtpBcc = System.Configuration.ConfigurationManager.AppSettings["SmtpBcc"];


            string fromEmail = Email;
            string fromName = FirstName + ' ' + LastName;
            string recipient = z_SmtpAdminEmail;
            string cc = z_SmtpCc;
            string bcc = z_SmtpBcc;
            string subject = "NMC Opt-Out Request";
            string body = @"From: " + fromEmail;
            body += @"</br>";
            body += @"Name: " + fromName;
            body += @"</br>";
            body += @"Subject: NMC Opt-Out Request";
            body += @"</br>";
            body += @"Phone: " + Phone;
            body += @"</br>";
            body += @"City: " + City;
            body += @"</br>";
            body += @"Zip: " + Zip;
            body += @"</br>";
            body += @"Disclosure: " + (Disclosure == "on" ? "Yes" : "No");
            body += @"</br>";
            body += @"OptOut: " + (OptOut == "on" ? "Yes" : "No");
            body += @"</br>";
            body += @"Access: " + (Access == "on" ? "Yes" : "No");
            body += @"</br>";
            body += @"Deletion: " + (Deletion == "on" ? "Yes" : "No");
            body += @"</br>";

            SmtpClient.SendEmail(z_SmtpServer,
                                z_SmtpPort,
                                z_SmtpUsername,
                                z_SmtpPassword,
                                z_SmtpSsl,
                                fromEmail,
                                fromName,
                                recipient,
                                cc,
                                bcc,
                                subject,
                                body,
                                (System.Net.Mail.MailPriority)z_EmailPriority);

            return Redirect("opt_out_policy");
        }
    }
}
