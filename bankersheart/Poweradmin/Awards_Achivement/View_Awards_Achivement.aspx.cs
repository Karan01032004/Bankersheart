using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Awards_Achivement
{
    public partial class View_Awards_Achivement : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Awards_Achivement]";
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
            string query = "select * from " + TableName + " order by sortorder asc";
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

            rpt_data.DataSource = dt;
            rpt_data.DataBind();
        }

        protected void btn_sortorder_Click(object sender, EventArgs e)
        {
            RepeaterItem ri = (RepeaterItem)((Button)sender).Parent;
            int rowIndex1 = ri.ItemIndex;

            HiddenField hdnProId1 = (HiddenField)(rpt_data.Items[rowIndex1].FindControl("hdnID"));
            string id1 = hdnProId1.Value;

            TextBox ddl = (TextBox)ri.FindControl("txt_displayorder");
            int selectedOrder;

            if (int.TryParse(ddl.Text, out selectedOrder) && selectedOrder >= 0)
            {
                string strsort = "update " + TableName + " set sortorder=" + selectedOrder + " where id=" + id1 + "";
                new DAL().ExecuteNonQuery(strsort, CommandType.Text, null);
                div_Error.Visible = false;
                div_Success.Visible = true;
                ltr_Success.Text = "Sort order updated.";

                fill_data();
            }
            else
            {
                div_Success.Visible = false;
                div_Error.Visible = true;
                ltr_Error.Text = "Sort order must be integer positive number.";
            }
        }

        protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnID = (HiddenField)rpt_data.Items[rowIndex].FindControl("hdnID");
            TextBox txt_displayorder = (TextBox)rpt_data.Items[rowIndex].FindControl("txt_displayorder");

            if (e.CommandName == "edit")
            {
                Response.Redirect("manage_Awards_Achivement.aspx?id=" + hdnID.Value);
            }

            if (e.CommandName == "delete")
            {
                string sQuery = @"delete from [bankers_usr].[Awards_Achivement] where id='" + hdnID.Value + "'";
                new DAL().ExecuteNonQuery(sQuery, CommandType.Text, null);

                ltr_Success.Text = "Awards_Achivement deleted.";
                div_Success.Visible = true;

                fill_data();
            }
            if (e.CommandName == "Sort")
            {
                string strsort = "update " + TableName + " set sortorder=" + txt_displayorder.Text + " where id=" + hdnID.Value + "";
                new DAL().ExecuteNonQuery(strsort, CommandType.Text, null);
                div_Error.Visible = false;
                div_Success.Visible = true;
                ltr_Success.Text = "Sort order updated.";

                fill_data();
            }
        }

    protected void btnDeleteSelected_Click(object sender, EventArgs e)
{
    // List to store selected IDs
    List<string> selectedIds = new List<string>();

    // Loop through the Repeater items
    foreach (RepeaterItem item in rpt_data.Items)
    {
        // Find the checkbox control
        CheckBox checkbox = (CheckBox)item.FindControl("checkboxDelete");

        // If the checkbox is checked, add its value (ID) to the list
        if (checkbox != null && checkbox.Checked)
        {
            selectedIds.Add(checkbox.Attributes["Value"]);
        }
    }

    // If there are selected IDs, proceed with deletion
    if (selectedIds.Count > 0)
    {
        foreach (string id in selectedIds)
        {
            string deleteQuery = "DELETE FROM " + TableName + " WHERE id = @id";
            
            // Convert the List<SqlParameter> to SqlParameter[]
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };

            // Convert List to array
            new DAL().ExecuteNonQuery(deleteQuery, CommandType.Text, parameters.ToArray());
        }

        // Display success message
        div_Success.Visible = true;
        ltr_Success.Text = "Selected records deleted successfully.";
        fill_data(); // Refresh the data to reflect the changes
    }
    else
    {
        // No records selected
        div_Error.Visible = true;
        ltr_Error.Text = "No records selected for deletion.";
    }
}

        protected void rpt_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}