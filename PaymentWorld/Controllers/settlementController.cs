using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Codebase.Website.Models;
using System.Web.Helpers;

namespace Codebase.Website.Pw.Controllers
{
    public class settlementController : Controller
    {
        //
        // GET: /settlement/

        public ActionResult index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult index(AccountSetupViewModel accountSetupViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string path = Server.MapPath("App_Data") + "\\" + "settlement.txt";

                    if (System.IO.File.Exists(path))
                    {
                        string body = System.IO.File.ReadAllText(path);

                        string stxs = @"[\***";
                        string etxs = @"***/]";

                        int stx = body.IndexOf(stxs);
                        int etx = body.IndexOf(etxs);

                        if (stx == 0 && etx > 0)
                        {
                            string settings = body.Substring(stxs.Length, (etx - etxs.Length));

                            if (settings.Trim().Length > 0)
                            {
                                Dictionary<string, string> d = this.ParseSettings(settings);

                                if (d.Count > 0)
                                {
                                    body = body.Substring(etx + etxs.Length);

                                    string subject = d.ContainsKey("EmailSubject") ? d["EmailSubject"] : "Payment World Inquiry";
                                    string fromName = d.ContainsKey("EmailFromName") ? d["EmailFromName"] : "Payment World";
                                    string from = d.ContainsKey("EmailFrom") ? d["EmailFrom"] : "clientservices@paymentworld.com";

                                    string cc = d.ContainsKey("Cc") ? d["Cc"] : null;
                                    string bcc = d.ContainsKey("Bcc") ? d["Bcc"] : null;

                                    body = body.Replace("[*NAME*]", accountSetupViewModel.Name);
                                    body = body.Replace("[*BUSINESSNAME*]", accountSetupViewModel.BusinessName);
                                    body = body.Replace("[*PHONENUMBER*]", accountSetupViewModel.PhoneNumber);
                                    body = body.Replace("[*EMAILADDRESS*]", accountSetupViewModel.EmailAddress);

                                    string smtpServer = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpServer");
                                    string smtpUsername = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpUsername");
                                    string smtpPassword = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpPassword");
                                    string smtpPort = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpPort");

                                    if (!string.IsNullOrEmpty(smtpServer))
                                    {
                                        WebMail.SmtpServer = smtpServer;

                                        if (!string.IsNullOrEmpty(smtpPort))
                                            WebMail.SmtpPort = Int32.Parse(smtpPort);

                                        if (!string.IsNullOrEmpty(smtpUsername))
                                            WebMail.UserName = smtpUsername;

                                        if (!string.IsNullOrEmpty(smtpPassword))
                                            WebMail.Password = smtpPassword;

                                        WebMail.Send(accountSetupViewModel.EmailAddress, subject, body, from, cc, null, true);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string test = "";

                }

                accountSetupViewModel = new AccountSetupViewModel();
                accountSetupViewModel.Message = "Thank You!";
            }
            else
            {
                accountSetupViewModel.Message = "Please correct the following:";
            }

            return View(accountSetupViewModel);
        }

        private Dictionary<string, string> ParseSettings(string value)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            string[] settings = value.Split('&');

            foreach (string setting in settings)
            {
                string[] buffer = setting.Split('=');

                if (buffer.Length == 2)
                {
                    if (!d.ContainsKey(buffer[0]))
                        d.Add(buffer[0], buffer[1]);
                }
            }

            return d;
        }

    }
}
