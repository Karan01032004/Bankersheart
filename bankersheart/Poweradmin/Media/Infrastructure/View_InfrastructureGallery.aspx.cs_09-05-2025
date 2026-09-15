using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Media.Infrastructure
{
    public partial class View_InfrastructureGallery : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[InfrastructureGallery]";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["cmspath"].ToString() + "default.aspx");
            }
            else
            {
                if (!String.IsNullOrEmpty(Request.QueryString["msg"]))
                {
                    ltr_Success.Text = Request.QueryString["msg"].ToString();
                    div_Success.Visible = true;
                }
                if (!Page.IsPostBack)
                {
                    fill_data();
                }
            }
        }

        private void fill_data()
        {
            string query = @"
        SELECT 
            ig.id, 
            ig.title, 
            ig.image, 
            ig.added_date, 
            ig.added_ip, 
            ig.modified_date, 
            ig.modified_ip, 
            iname.InfrastructureName
        FROM InfrastructureGallery ig
        INNER JOIN InfrastructureName iname ON ig.InfrastructureName_ID = iname.id
        ORDER BY ig.id ASC";

            // Execute the query to fetch data
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

            // Bind the data to the Repeater control
            rpt_data.DataSource = dt;
            rpt_data.DataBind();
        }




        protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnID = (HiddenField)rpt_data.Items[rowIndex].FindControl("hdnID");
            TextBox txt_displayorder = (TextBox)rpt_data.Items[rowIndex].FindControl("txt_displayorder");

            if (e.CommandName == "edit")
            {
                Response.Redirect("Manage_InfrastructureGalleryaspx.aspx?id=" + hdnID.Value);
            }

            if (e.CommandName == "delete")
            {
                string sQuery = @"delete from [bankers_usr].[InfrastructureGallery] where id='" + hdnID.Value + "'";
                new DAL().ExecuteNonQuery(sQuery, CommandType.Text, null);

                ltr_Success.Text = "InfrastructureGallery deleted.";
                div_Success.Visible = true;

                fill_data();
            }

        }

        protected void rpt_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}