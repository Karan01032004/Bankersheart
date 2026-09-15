using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace bankersheart.App_Code
{
    public class DAL
    {
        private readonly static string dbconnectionstring = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public DAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string EnCrypt(string Data)
        {
            if (Data != "" && Data != null)
            {
                byte[] key = Encoding.ASCII.GetBytes("~!@#$%^&*()_+}{?");
                byte[] iv = Encoding.ASCII.GetBytes(",.;'[]=-");
                byte[] data = Encoding.ASCII.GetBytes(Data);
                byte[] enc = new byte[0];
                TripleDES tdes = TripleDES.Create();
                tdes.IV = iv;
                tdes.Key = key;
                tdes.Mode = CipherMode.CFB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform ict = tdes.CreateEncryptor();
                enc = ict.TransformFinalBlock(data, 0, data.Length);
                return ByteArrayToString(enc);
            }
            else
                return "";
        }

        public string DeCrypt(string Data)
        {

            if (Data != null && Data != "")
            {
                byte[] key = Encoding.ASCII.GetBytes("~!@#$%^&*()_+}{?");
                byte[] iv = Encoding.ASCII.GetBytes(",.;'[]=-");
                byte[] data = StringToByteArray(Data);
                byte[] enc = new byte[0];
                TripleDES tdes = TripleDES.Create();
                tdes.IV = iv;
                tdes.Key = key;
                tdes.Mode = CipherMode.CFB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform ict = tdes.CreateDecryptor();
                enc = ict.TransformFinalBlock(data, 0, data.Length);
                return Encoding.ASCII.GetString(enc);
            }
            else
            {
                return "";
            }
        }

        public byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
        /// <summary>
        /// Use null for Parameters if you dont have any parameters to pass
        /// </summary>
        public DataSet GetDataSet(String cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            try
            {
                DataSet ds;
                string conString = dbconnectionstring;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // if (con.State == ConnectionState.Closed)
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                if (null != parameter) cmd.Parameters.Add(parameter);
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DateTime CurrCountryTime()
        {
            return DateTime.UtcNow.AddHours(10);
        }

        public string GetMailTemplates(string templatePath)
        {
            string mailTemplate = "";
            if (System.IO.File.Exists(GetRootPath() + templatePath))
            {
                mailTemplate = System.IO.File.ReadAllText(GetRootPath() + templatePath);
            }
            return mailTemplate;
        }

        /// <summary>
        /// Use null for Parameters if you dont have any parameters to pass
        /// </summary>
        public DataTable GetDataTable(String cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            try
            {
                DataTable dt;
                string conString = dbconnectionstring;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // if (con.State == ConnectionState.Closed)
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                if (null != parameter) cmd.Parameters.Add(parameter);
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Use null for Parameters if you dont have any parameters to pass
        /// </summary>    
        public int ExecuteNonQuery(String cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            //SqlCommand cmd = null;
            SqlCommand cmd = null;
            int queryResult = 0;
            try
            {
                string conString = dbconnectionstring;
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    con.Open();
                //    cmd = new SqlCommand(cmdText, con);
                //    cmd.CommandType = cmdType;
                //    if (parameters != null)
                //    {
                //        foreach (SqlParameter parameter in parameters)
                //        {
                //            if (null != parameter) cmd.Parameters.Add(parameter);
                //        }
                //    }
                //    return (queryResult = cmd.ExecuteNonQuery());
                //}
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // if (con.State == ConnectionState.Closed)
                    con.Open();
                    //cmd = new SqlCommand(cmdText, con);
                    cmd = new SqlCommand(cmdText, con);
                    cmd.CommandType = cmdType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (null != parameter) cmd.Parameters.Add(parameter);
                        }
                    }
                    queryResult = cmd.ExecuteNonQuery();
                }
                return queryResult;
            }
            catch (Exception ex)
            {
                //HttpContext.Current.Response.Write(ex.StackTrace + "<BR>" + ex.Message);
                //return -100;
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        /// <summary>
        /// Use null for Parameters if you dont have any parameters to pass
        /// </summary>
        public string ExecuteScalar(String cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            try
            {
                string RetStr = "";
                string conString = dbconnectionstring;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    // if (con.State == ConnectionState.Closed)
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                if (null != parameter) cmd.Parameters.Add(parameter);
                            }
                        }

                        object obj = cmd.ExecuteScalar();
                        if (obj != null) RetStr = obj.ToString();
                    }
                }
                return RetStr;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }

        }

        //public int MailToSendSite(string tomail, string mailsubject, string frommail, string bodymail, string ccmail, string bccmail, string fromname)
        //{

        //    try
        //    {
        //        bool adminflag = false;
        //        DataTable dt = new DataTable();
        //        string HostName = "", User = "", password = "", DBCCEmail = "", DBBCCEmail = "";
        //        dt = (new DAL()).GetDataTable("select * from siteprofile", CommandType.Text, null);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            HostName = dt.Rows[0]["mshost"].ToString();
        //            User = dt.Rows[0]["msusername"].ToString();
        //            password = dt.Rows[0]["mspass"].ToString();
        //            DBCCEmail = dt.Rows[0]["contccemail"].ToString();
        //            DBBCCEmail = dt.Rows[0]["contbccemail"].ToString();
        //            if (tomail == "")
        //            {
        //                adminflag = true;
        //                tomail = dt.Rows[0]["contemail"].ToString();
        //            }
        //            if (frommail == "")
        //                frommail = "donotreply@bestveggies.co.in";
        //            if (fromname == "")
        //                fromname = ConfigurationManager.AppSettings["SiteName"].ToString();
        //        }
        //        bodymail = bodymail.Replace("_LOGOURL_", ConfigurationManager.AppSettings["Logo"].ToString());
        //        SmtpClient smtpClientC = new SmtpClient();
        //        MailMessage objMailC = new MailMessage();
        //        MailAddress objMailC_fromaddress = new MailAddress(frommail, fromname);
        //        MailAddress objMailC_toaddress = new MailAddress(tomail);


        //        objMailC.From = objMailC_fromaddress;
        //        objMailC.To.Add(objMailC_toaddress);


        //        objMailC.IsBodyHtml = true;

        //        objMailC.Subject = mailsubject;

        //        objMailC.Body = bodymail;


        //        if (ccmail != null)
        //            objMailC.CC.Add(ccmail);
        //        else if (DBCCEmail != null && DBCCEmail != "" && adminflag == true)
        //            objMailC.CC.Add(DBCCEmail);

        //        if (bccmail != null)
        //            objMailC.Bcc.Add(bccmail);
        //        else if (DBBCCEmail != null && DBBCCEmail != "" && adminflag == true)
        //            objMailC.Bcc.Add(DBBCCEmail);


        //        smtpClientC.Host = HostName;
        //        smtpClientC.Credentials = new System.Net.NetworkCredential(User, password);
        //        smtpClientC.Port = 25;
        //            smtpClientC.Send(objMailC);

        //        return 1;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }


        //}

        //public int MailToSendSite(string tomail, string mailsubject, string frommail, string bodymail, string ccmail, string bccmail, string fromname)
        //{

        //    try
        //    {
        //        bool adminflag = false;
        //        DataTable dt = new DataTable();
        //        string HostName = "", User = "", password = "", DBCCEmail = "", DBBCCEmail = "";
        //        dt = (new DAL()).GetDataTable("select * from admin", CommandType.Text, null);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            HostName = ConfigurationManager.AppSettings["HostName"].ToString();
        //            User = ConfigurationManager.AppSettings["User"].ToString();
        //            password = ConfigurationManager.AppSettings["Password"].ToString();
        //            //DBCCEmail = dt.Rows[0]["contccemail"].ToString();
        //            //DBBCCEmail = dt.Rows[0]["contbccemail"].ToString();
        //            if (tomail == "")
        //            {
        //                adminflag = true;
        //                tomail = ConfigurationManager.AppSettings["ContactEmail"].ToString();
        //            }
        //            if (frommail == "")
        //                frommail = ConfigurationManager.AppSettings["ContactEmail"].ToString();
        //            //frommail = "";
        //            if (fromname == "")
        //                fromname = ConfigurationManager.AppSettings["SiteName"].ToString();
        //        }
        //        SmtpClient smtpClientC = new SmtpClient();
        //        MailMessage objMailC = new MailMessage();
        //        MailAddress objMailC_fromaddress = new MailAddress(frommail, fromname);
        //        MailAddress objMailC_toaddress = new MailAddress(tomail);


        //        objMailC.From = objMailC_fromaddress;
        //        objMailC.To.Add(objMailC_toaddress);


        //        objMailC.IsBodyHtml = true;

        //        objMailC.Subject = mailsubject;

        //        objMailC.Body = bodymail;


        //        if (ccmail != null)
        //            objMailC.CC.Add(ccmail);
        //        else if (DBCCEmail != null && DBCCEmail != "" && adminflag == true)
        //            objMailC.CC.Add(DBCCEmail);

        //        if (bccmail != null)
        //            objMailC.Bcc.Add(bccmail);
        //        else if (DBBCCEmail != null && DBBCCEmail != "" && adminflag == true)
        //            objMailC.Bcc.Add(DBBCCEmail);


        //        smtpClientC.Host = HostName;
        //        //smtpClientC.EnableSsl = true;
        //        smtpClientC.Credentials = new System.Net.NetworkCredential(User, password);
        //        smtpClientC.Port = 99;
        //        smtpClientC.Send(objMailC);

        //        return 1;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }


        //}
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
        //public static int MailToSendSite(string tomail, string mailsubject, string frommail, string bodymail, string ccmail, string bccmail, string fromname, string replyToMail)
        //{
        //    try
        //    {
        //        DataTable dt = new DAL().GetDataTable("select * from siteprofile", CommandType.Text, null);

        //        string HostName = dt.Rows[0]["mshost"].ToString();
        //        string User = dt.Rows[0]["msusername"].ToString();
        //        string password = dt.Rows[0]["mspass"].ToString();
        //        if (tomail == "")
        //            tomail = dt.Rows[0]["contemail"].ToString();
        //        if (frommail == "")
        //            frommail = dt.Rows[0]["msusername"].ToString();

        //        //string HostName = "mail.yourwebsitepreview.com";
        //        //string User = "forms@yourwebsitepreview.com";
        //        //string password = "forms@123";

        //        SmtpClient smtpClientC = new SmtpClient();
        //        MailMessage objMailC = new MailMessage();
        //        MailAddress objMailC_fromaddress = new MailAddress(frommail, fromname);
        //        MailAddress objMailC_toaddress = new MailAddress(tomail);
        //        //MailAddress objMailC_replyto = new MailAddress(frommail);


        //        objMailC.From = objMailC_fromaddress;
        //        objMailC.To.Add(objMailC_toaddress);
        //        // objMailC.ReplyToList.Add(objMailC_replyto);

        //        objMailC.IsBodyHtml = true;

        //        objMailC.Subject = mailsubject;

        //        objMailC.Body = bodymail;
        //        // Add ReplyTo address
        //        if (!string.IsNullOrEmpty(replyToMail))
        //        {
        //            objMailC.ReplyToList.Add(new MailAddress(replyToMail));
        //        }
        //        if (ccmail != null && ccmail != "")
        //        {
        //            objMailC.CC.Add(ccmail);
        //        }

        //        if (bccmail != null & bccmail != "")
        //        {
        //            objMailC.Bcc.Add(bccmail);
        //        }
        //        //objMailC.Bcc.Add("websitetesting99@gmail.com");

        //        smtpClientC.Host = HostName;
        //        //smtpClientC.Port = 587;
        //        //smtpClientC.Port = 465;
        //        smtpClientC.Port = 25;
        //        smtpClientC.EnableSsl = false;
        //        smtpClientC.Credentials = new System.Net.NetworkCredential(User, password);
        //        smtpClientC.Send(objMailC);
        //        return 1;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }


        //}
        public static string GetCMSPath()
        {
            return ConfigurationManager.AppSettings["CMSPath"].ToString();
        }

        public static string GetPostBackControl(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control.ID;
        }

        public string GetRootPath()
        {
            string completePath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath).Replace("/", "\\");
            string rootPath = completePath + "\\";
            return rootPath;
        }

        public static string getIP()
        {
            string strHostName = "";
            strHostName = HttpContext.Current.Request.UserHostAddress;
            return strHostName;
        }
    }
}