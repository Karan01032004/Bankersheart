using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    string sQuery = "Select * from bankers_usr.admin where id='" + Session["user_id"].ToString() + "'";
                    DataTable dt = new DAL().GetDataTable(sQuery, CommandType.Text, null);
                    if (dt.Rows.Count > 0)
                    {
                        cvPassword.ValueToCompare = dt.Rows[0]["pwd"].ToString();
                    }

                    this.Profile_Details();
                }
            }
        }

        protected void Profile_Details()
        {
            DataTable dt = new DataTable();
            string strQuery;

            if (Session["user_id"] == null || Session["user_id"].ToString() == "")
            {
                Response.Redirect("default.aspx");
            }

            strQuery = "select * from bankers_usr.admin where id=" + Session["user_id"].ToString();

            dt = (new DAL()).GetDataTable(strQuery, CommandType.Text, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtemail.Text = dt.Rows[0]["email"].ToString();
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strQuery = "";
            #region//saving record in db
            try
            {
                strQuery = @"update bankers_usr.admin set pwd='" + txtPassword.Text + "' where id='" + Session["user_id"].ToString() + "'";
                new DAL().ExecuteNonQuery(strQuery, CommandType.Text, null);
                Session["msg"] = "Profile password has been successfully modified."; ;
                Response.Redirect("default.aspx");
            }
            catch (Exception ex)
            {

            }
            #endregion
        }
    }
}