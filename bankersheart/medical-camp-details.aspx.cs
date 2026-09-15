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
    public partial class medical_camp_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string titlelink = Page.RouteData.Values["titlelink"] as string;
                if (!string.IsNullOrEmpty(titlelink))
                {
                    // Set dynamic H1 and H2 text
                    pageH1.InnerText = titlelink;   // Hidden for SEO

                    Bindexhibition(titlelink);   // Now handles lecture titlelink too
                }



                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        //private void Bindexhibition()
        //{
        //    string query = "SELECT e.id AS Medical_CampId,e.title,e.description,e.shortdescription,e.Camp_Date,i.image AS Medical_CampImage " +
        //        "FROM [bankers_usr].[Medical_Camp] e " +
        //        "LEFT JOIN [bankers_usr].[Medical_Camp_Images] i ON e.id = i.Medical_Camp_id " +
        //        "WHERE e.id =" + Request.QueryString["id"];  // Ensure only images for the correct exhibition are retrieved

        //    DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

        //    // Bind data to the Repeater
        //    rpt_MedicalCamps.DataSource = dt;
        //    rpt_MedicalCamps.DataBind();

        //    // Display the description if data exists
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblCampDescription.Text = dt.Rows[0]["description"].ToString();
        //    }
        //}
        private void Bindexhibition(string titlelink)
        {
            string query = @"
        SELECT e.id AS Medical_CampId, e.title, e.description, e.shortdescription, e.Camp_Date, i.image AS Medical_CampImage,e.Browsertitle,
       e.MetaTag
        FROM [bankers_usr].[Medical_Camp] e
        LEFT JOIN [bankers_usr].[Medical_Camp_Images] i ON e.id = i.Medical_Camp_id
        WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = titlelink }
            };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            rpt_MedicalCamps.DataSource = dt;
            rpt_MedicalCamps.DataBind();

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