using Codebase.Website.Nmc.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Codebase.Website.Nmc.Controllers
{
    public class DataBreachController : Controller
    {
        // GET: DataBreach
        public ActionResult Index()
        {
            ViewBag.Video = ConfigurationManager.AppSettings["DataBreachVideo"];
            return View();
        }
        public ActionResult Video()
        {
            ViewBag.Video = ConfigurationManager.AppSettings["DataBreachVideo"];
            return View();
        }
        [HttpPost]
        public JsonResult sendMessage(contactModel model)
        {
            //Initialize SMTP credentials
            var z_SmtpPassword = WebConfigurationManager.AppSettings["SmtpPassword"];
            var z_SmtpPort = Convert.ToInt32(WebConfigurationManager.AppSettings["SmtpPort"]);
            var z_SmtpServer = WebConfigurationManager.AppSettings["SmtpHost"];
            var z_SmtpUsername = WebConfigurationManager.AppSettings["SmtpUsername"];
            var z_EmailPriority = Convert.ToInt32(WebConfigurationManager.AppSettings["SmtpPriority"]);
            var z_SmtpSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SmtpSSL"]);
            var z_SmtpAdminEmail = System.Configuration.ConfigurationManager.AppSettings["SmtpAdminEmail"];

            string fromEmail = string.Empty;
            string fromName = string.Empty;
            string cc = string.Empty;
            string bcc = string.Empty;
            string subject = string.Empty;
            string body = string.Empty;
            string recipient = string.Empty;

            fromEmail = model.Email;
            fromName = model.Name;
            recipient = z_SmtpAdminEmail;
            subject = model.Subject;
            body = @"From: " + model.Email;
            body += @"</br>";
            body += @"Name: " + model.Name;
            body += @"</br>";
            body += @"Subject: " + model.Subject;
            body += @"</br>";
            body += @"Message: " + model.Message;

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

            return Json(true);
        }
    }
    public class contactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}