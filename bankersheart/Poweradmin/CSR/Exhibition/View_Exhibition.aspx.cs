using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.CSR.Exhibition
{
    public partial class View_Exhibition : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Exhibition]";
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
            string query = "select * from " + TableName + " order by id desc";
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

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
                Response.Redirect("Manage_Exhibition.aspx?id=" + hdnID.Value);
            }

            if (e.CommandName == "delete")
            {
                string idToDelete = hdnID.Value;

                // First, delete related images from EventsatBankers_Images
                string deleteImagesQuery = @"DELETE FROM [bankers_usr].[Exhibition_Images] WHERE Exhibition_id = @Eventsatbankers_id";
                SqlParameter[] imageDeleteParameters = {
            new SqlParameter("@Eventsatbankers_id", SqlDbType.Int) { Value = idToDelete }
        };
                new DAL().ExecuteNonQuery(deleteImagesQuery, CommandType.Text, imageDeleteParameters);

                // Then, delete the record from EventsatBankers table
                string deleteQuery = @"DELETE FROM Exhibition WHERE id = @id";
                SqlParameter[] deleteParameters = {
            new SqlParameter("@id", SqlDbType.Int) { Value = idToDelete }
        };
                new DAL().ExecuteNonQuery(deleteQuery, CommandType.Text, deleteParameters);

                ltr_Success.Text = "Exhibition deleted successfully.";
                div_Success.Visible = true;

                fill_data();
            }
        }
        protected void rpt_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}