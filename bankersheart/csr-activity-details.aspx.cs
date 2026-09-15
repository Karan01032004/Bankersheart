using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class csr_activity_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string titlelink = Page.RouteData.Values["titlelink"] as string;
                if (!string.IsNullOrEmpty(titlelink))
                {

                    Bindexhibition(titlelink);   // Now handles lecture titlelink too
                                                 // ✅ Build dynamic title using titlelink
                    string formattedTitle = $"CSR Activity - {titlelink} | Bankers Group of Hospitals";

                    // ✅ Set Page Title
                    Page.Title = formattedTitle;

                    // ✅ Use same text in H1
                    pageH1.InnerText = formattedTitle;
                }



                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        //private void Bindexhibition()
        //{
        //    string query = "SELECT e.id AS CSR_ActivityId,e.title,e.description,e.CSR_Activity_Date,i.image AS CSR_ActivityImage " +
        //        "FROM [bankers_usr].[CSR_Activity] e " +
        //        "LEFT JOIN [bankers_usr].[CSR_Activity_Images] i ON e.id = i.CSR_Activity_id " +
        //        "WHERE e.id =" + Request.QueryString["id"];  // Ensure only images for the correct exhibition are retrieved

        //    DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

        //    // Bind data to the Repeater
        //    rptCSR_Activity.DataSource = dt;
        //    rptCSR_Activity.DataBind();

        //    // Display the description if data exists
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblCampDescription.Text = dt.Rows[0]["description"].ToString();
        //    }
        //}
        private void Bindexhibition(string titlelink)
        {
            string query = @"
        SELECT e.id AS CSR_ActivityId, e.title, e.description,  e.CSR_Activity_Date, i.image AS CSR_ActivityImage,e.Browsertitle,
       e.MetaTag
        FROM [bankers_usr].[CSR_Activity] e
        LEFT JOIN [bankers_usr].[CSR_Activity_Images] i ON e.id = i.CSR_Activity_id
        WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = titlelink }
            };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            rptCSR_Activity.DataSource = dt;
            rptCSR_Activity.DataBind();

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