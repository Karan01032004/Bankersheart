using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Media.YouTubeVideo
{
    public partial class Manage_YouTubeVideo : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[YouTubeVideo]";

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
                txt_Title.Text = dt.Rows[0]["title"].ToString();
                txt_YouTubeURL.Text = dt.Rows[0]["YouTubeVideo"].ToString();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string youtubeURL = txt_YouTubeURL.Text.Trim();

            if (string.IsNullOrEmpty(youtubeURL))
            {
                ltr_Error.Text = "Please enter a valid YouTube URL.";
                div_Error.Visible = true;
                return;
            }

            // Insert new record using parameterized query
            string query = @"INSERT INTO " + TableName + " (title, YoutubeVideo, added_date, added_ip) VALUES(@Title, @YouTubeURL, @AddedDate, @AddedIP)";

            SqlParameter[] parameters = {
                new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
                new SqlParameter("@YouTubeURL", SqlDbType.NVarChar) { Value = youtubeURL },
                new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
                new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
            };

            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            string msg = "YouTube Video added successfully.";
            Response.Redirect("View_YouTubeVideo.aspx?msg=" + msg);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string youtubeURL = txt_YouTubeURL.Text.Trim();

            if (string.IsNullOrEmpty(youtubeURL))
            {
                ltr_Error.Text = "Please enter a valid YouTube URL.";
                div_Error.Visible = true;
                return;
            }

            string id = Request.QueryString["ID"].ToString();

            string query = @"UPDATE " + TableName + " SET " +
                           "title=@Title, " +
                           "YoutubeVideo=@YouTubeURL, " +
                           "modified_date=@ModifiedDate, " +
                           "modified_ip=@ModifiedIP " +
                           "WHERE id=@ID";

            SqlParameter[] parameters = {
                new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
                new SqlParameter("@YouTubeURL", SqlDbType.NVarChar) { Value = youtubeURL },
                new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
                new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
                new SqlParameter("@ID", SqlDbType.Int) { Value = id }
            };

            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            string msg = "YouTube Video updated successfully.";
            Response.Redirect("View_YouTubeVideo.aspx?msg=" + msg);
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_YouTubeVideo.aspx");
        }
    }
}
