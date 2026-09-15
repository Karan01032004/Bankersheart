using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class media_download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAwards();
                Bindcorporate();
                Bindevents();
                BindPresentation();
            }
        }
        private void BindAwards()
        {
            string query = @"SELECT id, title, image, PDF 
               FROM [bankers_usr].[Downloads] 
               WHERE download_name = 'Health Tips' 
               ORDER BY id DESC";


            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            if (dt.Rows.Count > 0)
            {
                rpt_health.DataSource = dt;
                rpt_health.DataBind();
            }
        }
        private void Bindcorporate()
        {
            string query = @"SELECT id, title, image, PDF 
               FROM [bankers_usr].[Downloads] 
               WHERE download_name = 'CorporateBrochure' 
               ORDER BY id DESC";


            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            if (dt.Rows.Count > 0)
            {
                rpt_corporate.DataSource = dt;
                rpt_corporate.DataBind();
            }
        }   
        private void Bindevents()
        {
            string query = @"SELECT id, title, image, PDF 
               FROM [bankers_usr].[Downloads] 
               WHERE download_name = 'EventsBrochure' 
               ORDER BY id DESC";


            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            if (dt.Rows.Count > 0)
            {
                rpt_events.DataSource = dt;
                rpt_events.DataBind();
            }
        } 
        private void BindPresentation()
        {
            string query = @"SELECT id, title, image, PDF 
               FROM [bankers_usr].[Downloads] 
               WHERE download_name = 'Presentation' 
               ORDER BY id DESC";


            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            if (dt.Rows.Count > 0)
            {
                rpt_Presentation.DataSource = dt;
                rpt_Presentation.DataBind();
            }
        }
    }
}