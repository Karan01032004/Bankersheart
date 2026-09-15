using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Doctors_Details
{
    public partial class View_DoctorsDetails : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[DoctorDetails]";
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
        //protected void btn_sortorder_Click(object sender, EventArgs e)
        //{
        //    RepeaterItem ri = (RepeaterItem)((Button)sender).Parent;
        //    int rowIndex1 = ri.ItemIndex;

        //    HiddenField hdnProId1 = (HiddenField)(rpt_data.Items[rowIndex1].FindControl("hdnID"));
        //    string id1 = hdnProId1.Value;

        //    TextBox ddl = (TextBox)ri.FindControl("txt_displayorder");
        //    if (string.IsNullOrWhiteSpace(ddl.Text))
        //    {
        //        div_Success.Visible = false;
        //        div_Error.Visible = true;
        //        ltr_Error.Text = "Sort order cannot be empty.";
        //        return;
        //    }
        //    int selectedOrder;

        //    if (int.TryParse(ddl.Text, out selectedOrder) && selectedOrder >= 0)
        //    {
        //        string strsort = "update " + TableName + " set sortorder=" + selectedOrder + " where id=" + id1 + "";
        //        new DAL().ExecuteNonQuery(strsort, CommandType.Text, null);
        //        div_Error.Visible = false;
        //        div_Success.Visible = true;
        //        ltr_Success.Text = "Sort order updated.";

        //        fill_data();
        //    }
        //    else
        //    {
        //        div_Success.Visible = false;
        //        div_Error.Visible = true;
        //        ltr_Error.Text = "Sort order must be integer positive number.";
        //    }

        //}
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
                Response.Redirect("Manage_DoctorsDetails.aspx?id=" + hdnID.Value);
            }

            if (e.CommandName == "delete")
            {
                string sQuery = @"delete from [bankers_usr].[DoctorDetails] where id='" + hdnID.Value + "'";
                new DAL().ExecuteNonQuery(sQuery, CommandType.Text, null);

                ltr_Success.Text = "Doctor Details deleted.";
                div_Success.Visible = true;

                fill_data();
            }
            if (e.CommandName == "Sort")
            {
                if (string.IsNullOrWhiteSpace(txt_displayorder.Text))
                {
                    div_Error.Visible = true;
                    div_Success.Visible = false;
                    ltr_Error.Text = "Sort order cannot be empty.";
                    return;
                }

                int selectedOrder;
                if (int.TryParse(txt_displayorder.Text, out selectedOrder) && selectedOrder >= 0)
                {
                    string strsort = "UPDATE " + TableName + " SET sortorder=" + selectedOrder + " WHERE id=" + hdnID.Value;
                    new DAL().ExecuteNonQuery(strsort, CommandType.Text, null);

                    div_Error.Visible = false;
                    div_Success.Visible = true;
                    ltr_Success.Text = "Sort order updated successfully.";

                    fill_data(); // Refresh data after sorting
                }
                else
                {
                    div_Error.Visible = true;
                    div_Success.Visible = false;
                    ltr_Error.Text = "Sort order must be a positive integer.";
                }
            }



        }

        protected void rpt_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}