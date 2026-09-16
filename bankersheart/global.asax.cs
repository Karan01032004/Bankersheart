using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace bankersheart
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string rawUrl = Request.RawUrl.ToLower();

            // Block malformed or duplicated protocol URLs
            if (rawUrl.Contains("https:/") || rawUrl.Contains("http:/"))
            {
                Response.Clear();
                Response.StatusCode = 400;
                Response.End();
                return;
            }

            // Block common SQL injection probes (scanner traffic)
            string[] sqlPatterns =
           {
    " select ",
    " union ",
    " chr(",
    " msysaccessobjects",
    " information_schema",
    " tdesencrypt",
    ";"
};


            foreach (string pattern in sqlPatterns)
            {
                if (rawUrl.Contains(pattern))
                {
                    Response.Clear();
                    Response.StatusCode = 400;
                    Response.End();
                    return;
                }
            }
        }


        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            // Ignore bad requests & SQL injection probes
            if (ex is HttpException httpEx && httpEx.GetHttpCode() == 400)
            {
                Server.ClearError();
                return;
            }

            if (ex is System.Data.SqlClient.SqlException)
            {
                Server.ClearError();
                Response.StatusCode = 500;
                return;
            }
            HttpUnhandledException httpUnhandledException = new HttpUnhandledException(Server.GetLastError().Message, Server.GetLastError());

            Application["Exception"] = HttpContext.Current.Server.GetLastError();
            Application["actualerrorpage"] = httpUnhandledException.GetHtmlErrorMessage();

            Application["errortime"] = DateTime.Now.ToLocalTime().ToString();
            Application["errorurl"] = Request.Url.AbsoluteUri.ToString();
            Application["browser"] = Request.Browser.Browser.ToString() + " ( " + Request.Browser.Type.ToString() + " )";
            Application["clientip"] = Request.UserHostAddress.ToString();
            if (Request.UrlReferrer != null)
            {
                Application["referurl"] = Request.UrlReferrer.AbsoluteUri.ToString();
            }
            else
            {
                Application["referurl"] = "None";
            }

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}