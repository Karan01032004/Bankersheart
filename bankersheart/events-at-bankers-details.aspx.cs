using bankersheart.App_Code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class events_at_bankers_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string titlelink = Page.RouteData.Values["titlelink"] as string;
                if (!string.IsNullOrEmpty(titlelink))
                {
                    Bindexhibition(titlelink);
                    BindLectures(titlelink);   // Now handles lecture titlelink too
                    BindRally(titlelink);   // Now handles lecture titlelink too
                    BindConference(titlelink);   // Now handles lecture titlelink too

                    // Dynamic H1 for SEO
                    litHeading.Text = $"<h1 class='sr-only'>Bankers Events - {titlelink}</h1>";

                }



                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        private void Bindexhibition(string titlelink)
        {
            string query = @"
        SELECT e.id AS EventsatBankersId, e.title, e.description, e.shortdescription, e.EventsatBankers_Date, i.image AS EventsatBankersImage,  e.Browsertitle,
        e.MetaTag
        FROM [bankers_usr].[EventsatBankers] e
        LEFT JOIN [bankers_usr].[EventsatBankers_Images] i ON e.id = i.EventsatBankers_id
        WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = titlelink }
            };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            rptExhibitions.DataSource = dt;
            rptExhibitions.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCampDescription.Text = dt.Rows[0]["description"].ToString();
                // Set browser title
                Page.Title = dt.Rows[0]["Browsertitle"].ToString();

                // Inject the full <meta> HTML as-is into the page <head>
                string metaHtml = dt.Rows[0]["MetaTag"].ToString();
                Page.Header.Controls.Add(new LiteralControl(metaHtml));


            }
        }

        private void BindLectures(string titlelink)
        {
            string query = @"
        SELECT e.id AS LecturesId, e.title, e.description, e.shortdescription, e.Lectures_Date, 
               i.image AS LecturesImage,e.Browsertitle,
       e.MetaTag
        FROM [bankers_usr].[Lectures] e
        LEFT JOIN [bankers_usr].[Lectures_Images] i ON e.id = i.Lectures_id
        WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = {
        new SqlParameter("@titlelink", titlelink)
    };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            Lectures.DataSource = dt;
            Lectures.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCampDescription.Text = dt.Rows[0]["description"].ToString();

                // Set browser title
                Page.Title = dt.Rows[0]["Browsertitle"].ToString();

                // Inject the full <meta> HTML as-is into the page <head>
                string metaHtml = dt.Rows[0]["MetaTag"].ToString();
                Page.Header.Controls.Add(new LiteralControl(metaHtml));
            }
        }

        private void BindRally(string titlelink)
        {
            string query = @"
        SELECT e.id AS RallyId, e.title, e.description, e.shortdescription, e.Rally_Date, 
               i.image AS RallyImage,e.Browsertitle,
       e.MetaTag
        FROM [bankers_usr].[Rally] e
        LEFT JOIN [bankers_usr].[Rally_Images] i ON e.id = i.Rally_id
        WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = {
        new SqlParameter("@titlelink", titlelink)
    };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            Rally.DataSource = dt;
            Rally.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCampDescription.Text = dt.Rows[0]["description"].ToString();

                // Set browser title
                Page.Title = dt.Rows[0]["Browsertitle"].ToString();

                // Inject the full <meta> HTML as-is into the page <head>
                string metaHtml = dt.Rows[0]["MetaTag"].ToString();
                Page.Header.Controls.Add(new LiteralControl(metaHtml));
            }
        }


        private void BindConference(string titlelink)
        {
            string query = @"
        SELECT e.id AS ConferenceId, e.title, e.description, e.shortdescription, e.Conference_Date, 
               i.image AS ConferenceImage,e.Browsertitle,
       e.MetaTag
        FROM [bankers_usr].[Conference] e
        LEFT JOIN [bankers_usr].[Conference_Images] i ON e.id = i.Conference_id
        WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = {
        new SqlParameter("@titlelink", titlelink)
    };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            Conference.DataSource = dt;
            Conference.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCampDescription.Text = dt.Rows[0]["description"].ToString();

                // Set browser title
                Page.Title = dt.Rows[0]["Browsertitle"].ToString();

                // Inject the full <meta> HTML as-is into the page <head>
                string metaHtml = dt.Rows[0]["MetaTag"].ToString();
                Page.Header.Controls.Add(new LiteralControl(metaHtml));
            }
        }

    }
}
