using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls; // <-- Add this


namespace bankersheart
{
    public partial class exhibitions_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string titlelink = Page.RouteData.Values["titlelink"] as string;
                if (!string.IsNullOrEmpty(titlelink))
                {
                    rptExhibitions.DataSource = null;
                    rptExhibitions.DataBind();
                    Bindexhibition(titlelink);
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        private void Bindexhibition(string titlelink)
        {
            string query = "SELECT e.id AS ExhibitionId, e.title, e.description, e.Exhibition_Date, i.image AS ExhibitionImage " +
                           "FROM [bankers_usr].[Exhibition] e " +
                           "LEFT JOIN [bankers_usr].[Exhibition_Images] i ON e.id = i.Exhibition_id " +
                           "WHERE e.titlelink = @titlelink";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = titlelink }
            };

            // 'null' ko replace karke 'parameters' pass karein
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);

            rptExhibitions.DataSource = dt;
            rptExhibitions.DataBind();

            if (dt.Rows.Count > 0)
            {
                string exhibitionTitle = dt.Rows[0]["title"].ToString();
                string exhibitionDesc = dt.Rows[0]["description"].ToString();

                // Page Title
                Page.Title = exhibitionTitle + " - Bankers Heart";

                // Meta Description
                HtmlMeta metaDescription = new HtmlMeta();
                metaDescription.Name = "description";
                metaDescription.Content = exhibitionTitle;
                Page.Header.Controls.Add(metaDescription);

                // Meta Keywords
                HtmlMeta metaKeywords = new HtmlMeta();
                metaKeywords.Name = "keywords";
                metaKeywords.Content = exhibitionTitle + ", Exhibition, Events, Bankers Heart";
                Page.Header.Controls.Add(metaKeywords);

                // Canonical
                HtmlLink canonical = new HtmlLink();
                canonical.Attributes.Add("rel", "canonical");
                canonical.Href = Request.Url.AbsoluteUri;
                Page.Header.Controls.Add(canonical);

                // H1 and description label
                pageH1.InnerText = exhibitionTitle + " | Bankers Heart";
                lblCampDescription.Text = exhibitionDesc;
            }
        }


    }
}