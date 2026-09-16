using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["Exception"] != null && Application["Exception"].ToString() != "")
            {
                try
                {
                    string mbody = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath).Replace("/", "\\") + "\\maintemplates\\error.htm");

                    mbody = mbody.Replace("_ERRROLINK", Application["errorurl"].ToString());
                    mbody = mbody.Replace("_ERRRODATE", Application["errortime"].ToString());
                    mbody = mbody.Replace("_ERRORBROWSER", Application["browser"].ToString());
                    mbody = mbody.Replace("_ERRORDETAILS", Application["Exception"].ToString());
                    mbody = mbody.Replace("_ERRORIP", Application["clientip"].ToString());
                    mbody = mbody.Replace("_YELLOWPAGE", Application["actualerrorpage"].ToString());


                    if (Application["actualerrorpage"].ToString().IndexOf("Validation of viewstate MAC failed") <= 0 && Application["errorurl"].ToString().IndexOf("ScriptResource.axd") <= 0 && Application["errorurl"].ToString().IndexOf("WebResource.axd") <= 0 && Application["actualerrorpage"].ToString().IndexOf("The state information is invalid for this page and might be corrupted") <= 0)
                        MailToSendSite("testing@yourwebsitepreview.com", "Error in bankersheart", "forms@yourwebsitepreview.com", mbody.ToString(), null, null, "bankersheart");
                    //testing@yourwebsitepreview.com
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static int MailToSendSite(string tomail, string mailsubject, string frommail, string bodymail, string ccmail, string bccmail, string fromname)
        {
            try
            {
                string HostName = "mail.yourwebsitepreview.com";
                string User = "forms@yourwebsitepreview.com";
                string password = "AsjYHqUj]w6Eq5&quot(";
                //string HostName = ConfigurationManager.AppSettings["HostName"].ToString();
                //string User = ConfigurationManager.AppSettings["UserName"].ToString();
                //string password = ConfigurationManager.AppSettings["Password"].ToString();
                if (tomail == "")
                    tomail = ConfigurationManager.AppSettings["ContactEmail"].ToString();
                if (frommail == "")
                    frommail = ConfigurationManager.AppSettings["ContactEmail"].ToString();

                
                if (tomail == "")
                    tomail = ConfigurationManager.AppSettings["ContactEmail"].ToString();
                if (tomail == "")
                    tomail = ConfigurationManager.AppSettings["ContactEmail"].ToString();
                if (frommail == "")
                    frommail = ConfigurationManager.AppSettings["ContactEmail"].ToString();

                SmtpClient smtpClientC = new SmtpClient();
                MailMessage objMailC = new MailMessage();
                MailAddress objMailC_fromaddress = new MailAddress(frommail, fromname);
                MailAddress objMailC_toaddress = new MailAddress(tomail);
                MailAddress objMailC_replyto = new MailAddress(frommail);


                objMailC.From = objMailC_fromaddress;
                objMailC.To.Add(objMailC_toaddress);
                objMailC.ReplyToList.Add(objMailC_replyto);

                objMailC.IsBodyHtml = true;

                objMailC.Subject = mailsubject;

                objMailC.Body = bodymail;

                if (ccmail != null && ccmail != "")
                {
                    objMailC.CC.Add(ccmail);
                }

                if (bccmail != null & bccmail != "")
                {
                    objMailC.Bcc.Add(bccmail);
                }
                smtpClientC.Host = HostName;
                smtpClientC.Port = 99;
                //smtpClientC.EnableSsl = true;
                smtpClientC.Credentials = new System.Net.NetworkCredential(User, password);
                smtpClientC.Send(objMailC);
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}