using bankersheart.App_Code;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;

namespace bankersheart.Poweradmin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["msg"] != null)
                {
                    ltr_Success.Text = Session["msg"].ToString();
                    div_Success.Visible = true;
                    Session["msg"] = null;
                }
                getRememberMe();
            }
        }

        private void getRememberMe()
        {
            try
            {
                if (Request.Cookies.Get("Bankersheart" + "Checked") != null)
                {
                    string ckRememberme = Request.Cookies.Get("Bankersheart" + "Checked").Value;
                    string[] chk = ckRememberme.Split('=');
                    if (chk.Length > 1)
                    {
                        if (chk[1] == "1")
                            chkRemember.Checked = true;
                    }
                }
            }
            catch (Exception ex1)
            {
                throw ex1;
            }

            try
            {
                if (Request.Cookies.Get("Bankersheart" + "Username") != null)
                {
                    string ckUsername = Request.Cookies.Get("Bankersheart" + "Username").Value;
                    string[] chk = ckUsername.Split('=');
                    if (chk.Length > 1)
                    {
                        txt_username.Text = chk[1];
                    }
                }
            }
            catch (Exception ex2) { throw ex2; }

            try
            {
                if (Request.Cookies.Get("Bankersheart" + "Password") != null)
                {
                    string ckPassword = Request.Cookies.Get("Bankersheart" + "Password").Value;
                    string[] chk = ckPassword.Split('=');
                    if (chk.Length > 1)
                    {
                        txt_password.Attributes.Add("value", chk[1]);
                    }
                }
            }
            catch (Exception ex3) { throw ex3; }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string sQuery = "Select * from [bankers_usr].[admin] where unm = '" + txt_username.Text.Replace("'", "''") + "' and pwd = '" + txt_password.Text.Replace("'", "''") + "'";
            DataTable dt = new DAL().GetDataTable(sQuery, CommandType.Text, null);
            if (dt.Rows.Count > 0)
            {
                Session["username"] = dt.Rows[0]["unm"].ToString();
                Session["user_id"] = dt.Rows[0]["id"].ToString();

                if (Request["page"] != null)
                    Response.Redirect(Request["page"].ToString());
                else
                {
                    remember();
                    Response.Redirect("dashboard.aspx");
                }
            }
            else
            {
                div_Success.Visible = false;
                div_Error.Visible = true;
                ltr_Error.Text = "Login credentials seems to be incorrect.";
            }
        }

        void remember()
        {
            if (chkRemember.Checked)
            {
                remembermefunction("Bankersheart" + "Username", txt_username.Text, 365);//Save Username
                remembermefunction("Bankersheart" + "Password", txt_password.Text, 365);//Save Password                    
                remembermefunction("Bankersheart" + "Checked", "1", 365);//Save rememberme
            }
            else
            {
                Response.Cookies["Bankersheart" + "Username"].Expires = DateTime.Now;
                Response.Cookies["Bankersheart" + "Password"].Expires = DateTime.Now;
                Response.Cookies["Bankersheart" + "Checked"].Expires = DateTime.Now;
            }
        }

        void remembermefunction(string cookiename, string cookievalue, int iDaysToExpire)
        {
            try
            {
                if (cookievalue != "")
                {
                    HttpCookie objCookie = new HttpCookie(cookiename);
                    HttpContext.Current.Response.Cookies.Add(objCookie);
                    objCookie.Values.Add(cookiename, cookievalue);
                    DateTime dtExpiry = DateTime.Now.AddDays(iDaysToExpire);
                    HttpContext.Current.Response.Cookies[cookiename].Expires = dtExpiry;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_email.Text))
            {
                string sQuery = "SELECT unm, pwd, Name FROM [bankers_usr].[admin] WHERE email = @Email";

                SqlParameter[] parameters = {
            new SqlParameter("@Email", SqlDbType.VarChar) { Value = txt_email.Text }
        };

                DataTable dt = new DAL().GetDataTable(sQuery, CommandType.Text, parameters);

                if (dt.Rows.Count > 0)
                {
                    string body;
                    using (StreamReader reader = new StreamReader(Server.MapPath("~/maintemplates/ForgetPasswordTemplate.htm")))
                    {
                        body = reader.ReadToEnd();
                    }

                    string userIpAddress = GetIpAddress();
                    body = body.Replace("_DATE_", DateTime.Now.ToString("dd-MM-yyyy"))
                               .Replace("_IP_ADDRESS_", userIpAddress)
                               .Replace("{UserName}", dt.Rows[0]["unm"].ToString())
                               .Replace("{Password}", dt.Rows[0]["pwd"].ToString());

                    string subject = "Greetings " + dt.Rows[0]["Name"].ToString() + " | Bankersheart";

                    int emailResult = DAL.MailToSendSite(
                        txt_email.Text,
                        subject,
                        ConfigurationManager.AppSettings["UserName"].ToString(),
                        body, "", "", "", txt_email.Text
                    );

                    if (emailResult > 0) // If emailResult > 0, email was sent successfully
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email sent successfully!')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to send email. Please try again.')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email Address is not Registered.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Email Address.')", true);
            }
        }





        private string GetIpAddress()
        {
            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            return ipAddress;
        }
        public static int MailToSendSite(string tomail, string mailsubject, string frommail, string bodymail, string ccmail, string bccmail, string fromname, string replyToMail)
        {
            try
            {

                string HostName = ConfigurationManager.AppSettings["HostName"].ToString();
                string User = ConfigurationManager.AppSettings["UserName"].ToString();
                string password = ConfigurationManager.AppSettings["Password"].ToString();
                if (tomail == "")
                    tomail = ConfigurationManager.AppSettings["ContactEmail"].ToString();
                if (frommail == "")
                    frommail = ConfigurationManager.AppSettings["UserName"].ToString();

                //string HostName = "mail.yourwebsitepreview.com";
                //string User = "forms@yourwebsitepreview.com";
                //string password = "forms@123";

                SmtpClient smtpClientC = new SmtpClient();
                MailMessage objMailC = new MailMessage();
                MailAddress objMailC_fromaddress = new MailAddress(frommail, fromname);
                MailAddress objMailC_toaddress = new MailAddress(tomail);
                //MailAddress objMailC_replyto = new MailAddress(frommail);


                objMailC.From = objMailC_fromaddress;
                objMailC.To.Add(objMailC_toaddress);
                // objMailC.ReplyToList.Add(objMailC_replyto);

                objMailC.IsBodyHtml = true;

                objMailC.Subject = mailsubject;

                objMailC.Body = bodymail;
                // Add ReplyTo address
                if (!string.IsNullOrEmpty(replyToMail))
                {
                    objMailC.ReplyToList.Add(new MailAddress(replyToMail));
                }
                if (ccmail != null && ccmail != "")
                {
                    objMailC.CC.Add(ccmail);
                }

                if (bccmail != null & bccmail != "")
                {
                    objMailC.Bcc.Add(bccmail);
                }
                //objMailC.Bcc.Add("websitetesting99@gmail.com");

                smtpClientC.Host = HostName;
                //smtpClientC.Port = 587;
                //smtpClientC.Port = 465;
                smtpClientC.Port = 587;
                smtpClientC.EnableSsl = true;
                smtpClientC.Credentials = new System.Net.NetworkCredential(User, password);
                smtpClientC.Send(objMailC);
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
        protected void lnk_forget_password_Click(object sender, EventArgs e)
        {

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {

        }
    }
}