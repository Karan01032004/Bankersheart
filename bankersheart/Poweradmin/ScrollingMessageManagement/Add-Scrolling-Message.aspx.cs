using bankersheart.App_Code;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.ScrollingMessageManagement
{

    public partial class Add_Scrolling_Message : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[scrollingmanagement]";
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



                string visibleValue = dt.Rows[0]["IsVisible"].ToString().Trim().ToLower();

                // Ensure the correct radio button is selected based on the database value
                if (visibleValue == "true" || visibleValue == "1")
                {
                    rbl_visible.SelectedValue = "1"; // Select 'Yes'
                }
                else
                {
                    rbl_visible.SelectedValue = "0"; // Select 'No'
                }

                //if (dt.Rows[0]["banner_type"].ToString() == "True")
                //{
                //    chk_type.Checked = true;
                //}

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from the form
                string title = txt_Title.Text.Trim();
                bool isVisible = rbl_visible.SelectedValue == "1";

                // Prepare the SQL query
                string query = "INSERT INTO [bankers_usr].[scrollingmanagement] (IsVisible, Title) VALUES (@IsVisible, @Title)";

                // Create a list of parameters
                List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@IsVisible", isVisible),
            new SqlParameter("@Title", title)
        };

                // Execute the query using DAL
                DAL dal = new DAL();
                int rowsAffected = dal.ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());

                if (rowsAffected > 0)
                {
                    // Show success message
                    div_Success.Visible = true;
                    string msg = "Scrolling message added successfully.";
                    Response.Redirect("view-Scrolling-Message.aspx?msg=" + msg);
                }
                else
                {
                    // Show error message
                    div_Error.Visible = true;
                    ltr_Error.Text = "Failed to add scrolling message.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and show error message
                div_Error.Visible = true;
                ltr_Error.Text = "An error occurred: " + ex.Message;
            }
        }
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["ID"];
                string title = txt_Title.Text.Trim();
                bool isVisible = rbl_visible.SelectedValue == "1";

                string query = "UPDATE [bankers_usr].[scrollingmanagement] SET IsVisible=@IsVisible, Title=@Title WHERE id=@id";

                List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@IsVisible", isVisible),
            new SqlParameter("@Title", title),
            new SqlParameter("@id", id)
        };

                DAL dal = new DAL();
                int rowsAffected = dal.ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());

                if (rowsAffected > 0)
                {
                    div_Success.Visible = true;
                    string msg = "Scrolling message updated successfully.";
                    Response.Redirect("view-Scrolling-Message.aspx?msg=" + msg);
                }
                else
                {
                    div_Error.Visible = true;
                    ltr_Error.Text = "Failed to update scrolling message.";
                }
            }
            catch (Exception ex)
            {
                div_Error.Visible = true;
                ltr_Error.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            // Redirect to the view-Scrolling-Message.aspx page
            Response.Redirect("view-Scrolling-Message.aspx");
        }


    }
}