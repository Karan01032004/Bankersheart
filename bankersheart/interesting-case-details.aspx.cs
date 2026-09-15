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
    public partial class interesting_case_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Request.QueryString["id"] != null)
            //    {
            //        rptExhibitionsGallery.DataSource = null;
            //        rptExhibitionsGallery.DataBind();
            //        Bindexhibition();
            //        BindAwards();
            //    }
            //    else
            //    {
            //        Response.Redirect("default.aspx");
            //    }
            //}
            if (!IsPostBack)
            {
                string titlelink = Page.RouteData.Values["titlelink"] as string;
                if (!string.IsNullOrEmpty(titlelink))
                {

                    Bindexhibition(titlelink);   // Now handles lecture titlelink too
                    BindAwards(titlelink);
                    pageH1.InnerText = titlelink + "s";  // Added 's' here

                }



                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        //private void Bindexhibition()
        //{
        //    string query = "SELECT e.id AS InterestingCasesId,e.title,e.description,e.InterestingCases_Date,i.image AS InterestingCasesImage " +
        //        "FROM [bankers_usr].[InterestingCases] e " +
        //        "LEFT JOIN [bankers_usr].[InterestingCases_Images] i ON e.id = i.InterestingCases_id " +
        //        "WHERE e.id =" + Request.QueryString["id"];  // Ensure only images for the correct exhibition are retrieved

        //    DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

        //    // Bind data to the Repeater
        //    rptExhibitionsGallery.DataSource = dt;
        //    rptExhibitionsGallery.DataBind();

        //    // Display the description if data exists

        //}
        private void Bindexhibition(string titlelink)
        {
            string query = @"
        SELECT e.id AS InterestingCasesId, e.title, e.description,  e.InterestingCases_Date, i.image AS InterestingCasesImage, e.Browsertitle,
           e.MetaTag
        FROM [bankers_usr].[InterestingCases] e
        LEFT JOIN [bankers_usr].[InterestingCases_Images] i ON e.id = i.InterestingCases_id
        WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = titlelink }
            };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            rptExhibitionsGallery.DataSource = dt;
            rptExhibitionsGallery.DataBind();
            if (dt.Rows.Count > 0)
            {
                // Set browser title
                Page.Title = dt.Rows[0]["Browsertitle"].ToString();

                // Inject the full <meta> HTML as-is into the page <head>
                string metaHtml = dt.Rows[0]["MetaTag"].ToString();
                Page.Header.Controls.Add(new LiteralControl(metaHtml));
            }


        }
        private void BindAwards(string titlelink)
        {
            string query = "SELECT [id], [title], [description], [image], [InterestingCases_Date] " +
                           "FROM [bankers_usr].[InterestingCases] WHERE titlelink = @titlelink";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = titlelink }
            };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);
            rptExhibitionscategory.DataSource = dt;
            rptExhibitionscategory.DataBind();
        }


        //private void BindAwards()
        //{
        //    string query = "SELECT [id], [title],[description], [image], [InterestingCases_Date] " +
        //                "FROM [bankers_usr].[InterestingCases]   WHERE id = " + Request.QueryString["id"]; // Filtering by ID";

        //    DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
        //    rptExhibitionscategory.DataSource = dt;
        //    rptExhibitionscategory.DataBind();
        //    // Display the description if data exists


        //}

    }
}