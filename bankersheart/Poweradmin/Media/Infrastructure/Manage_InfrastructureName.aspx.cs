using bankersheart.App_Code;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Media.Infrastructure
{
    public partial class Manage_InfrastructureName : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[InfrastructureName]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["cmspath"].ToString() + "default.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        btn_Update.Visible = true;
                        btn_submit.Visible = false;

                        // Set button text for edit
                        btn_Update.Text = "Update";

                        string id = Request.QueryString["ID"].ToString();
                        fill_data(id);
                    }
                    else
                    {
                        btn_Update.Visible = false;
                        btn_submit.Visible = true;

                        // Set button text for add
                        btn_submit.Text = "Submit";
                    }

                }
            }
        }

        private void fill_data(string id)
        {
            DataTable dt = new DAL().GetDataTable("select * from " + TableName + " where id='" + id + "' order by id asc", CommandType.Text, null);

            if (dt.Rows.Count > 0)
            {
                txt_Title.Text = dt.Rows[0]["InfrastructureName"].ToString();
                               // Display current banner image
          
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
         
         
                string query = @"INSERT INTO " + TableName + " (InfrastructureName, added_date, added_ip)  VALUES(@Title,  @AddedDate, @AddedIP)";


            SqlParameter[] parameters = {
            new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
            new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }

            };
                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
            

            string msg = "InfrastructureName added successfully.";
            Response.Redirect("View_InfrastructureName.aspx?msg=" + msg);
        }


        protected void btn_Update_Click(object sender, EventArgs e)
        {
  
            string id = Request.QueryString["ID"].ToString();

            string query = @"UPDATE " + TableName + " SET " +
                           "InfrastructureName=@Title, " +
                          
                           "modified_date=@ModifiedDate, " +
                           "modified_ip=@ModifiedIP";

        
            query += " WHERE id=@ID";

            SqlParameter[] parameters = {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
       
        new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

       

            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            string msg = "Infrastructure Name updated successfully.";
            Response.Redirect("view_InfrastructureName.aspx?msg=" + msg);
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_InfrastructureName.aspx");
        }
    }
}
