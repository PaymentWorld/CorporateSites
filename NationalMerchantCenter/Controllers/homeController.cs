using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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

            var parameters = "'" + MerchantId +
                                 "','" + SSN +
                                 "','" + FirstName +
                                 "','" + LastName +
                                 "','" + Email +
                                 "','" + Phone +
                                 "','" + City +
                                 "','" + Zip + "',";

             parameters += "@Disclosure, @OptOut, @Access, @Deletion";

                if (Disclosure == "on")
                {
                    parameters = parameters.Replace("@Disclosure", "'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "'");
                }
                if (OptOut == "on")
                {
                    parameters = parameters.Replace("@OptOut", "'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "'");
                }
                if (Access == "on")
                {
                    parameters = parameters.Replace("@Access", "'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "'");
                }
                if (Deletion == "on")
                {
                    parameters = parameters.Replace("@Deletion", "'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "'");
                }

                //replace unchecked policy with NULLs
                parameters = parameters
                    .Replace("@Disclosure", "NULL")
                    .Replace("@OptOut", "NULL")
                    .Replace("@Access", "NULL")
                    .Replace("@Deletion", "NULL");

            using (SqlConnection connection = new SqlConnection(Nmc.Properties.Settings.Default.connString))
            {
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("EXEC api_MerchantPolicy_Insert " + parameters, connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    try
                    {
                        connection.Open();

                        // Run the stored procedure.
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        var x = ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return Redirect("opt_out_policy");
        }
    }
}
