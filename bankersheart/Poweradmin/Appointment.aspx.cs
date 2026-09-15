using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin
{
    public partial class Appointment : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Appointment]";
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

        protected string GetHospitalEmail(string hospitalName)
        {
            switch (hospitalName)
            {
                case "Bankers Heart Institute, Vadodara":
                    return "opd.bhi@gmail.com";
                case "Bankers Superspeciality Hospital, Manjalpur":
                    return "opd.bssh@gmail.com";
                case "Bankers Heart and Multi Specialty Hospital, Warasia":
                    return "bhmh.chc@gmail.com";
                case "Bankers Heart Institute, Surat":
                    return "opd.bhis@gmail.com";
                default:
                    return ConfigurationManager.AppSettings["ContactEmail"].ToString();
            }
        }



        protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            //int rowIndex = int.Parse(e.CommandArgument.ToString());
            //HiddenField hdnID = (HiddenField)rpt_data.Items[rowIndex].FindControl("hdnID");
            //TextBox txt_displayorder = (TextBox)rpt_data.Items[rowIndex].FindControl("txt_displayorder");

            //if (e.CommandName == "edit")
            //{
            //    Response.Redirect("Manage_PatientsSay.aspx?id=" + hdnID.Value);
            //}

            if (e.CommandName == "delete")
            {
                string sQuery = @"delete from [bankers_usr].[Appointment] where id='" + id + "'";
                new DAL().ExecuteNonQuery(sQuery, CommandType.Text, null);

                ltr_Success.Text = "Appointment deleted.";
                div_Success.Visible = true;

                fill_data();
            }
            else if (e.CommandName == "markseen")
            {
                string markSeenQuery = "UPDATE [bankers_usr].[Appointment] SET IsNew = 0 WHERE id = " + id;
                new DAL().ExecuteNonQuery(markSeenQuery, CommandType.Text, null);

                ltr_Success.Text = "Marked as seen.";
                div_Success.Visible = true;
                fill_data();
            }

        }

        protected void rpt_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}