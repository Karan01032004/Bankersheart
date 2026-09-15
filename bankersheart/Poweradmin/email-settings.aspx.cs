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
    public partial class email_settings : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            txt_Password.Attributes.Add("value", txt_Password.Text);
            base.OnPreRender(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["user_id"] == null)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    fill_data();
                }
            }
        }

        private void fill_data()
        {
            string sQuery = @"select * from bankers_usr.siteprofile";
            DataTable dt = new DAL().GetDataTable(sQuery, CommandType.Text, null);
            if (dt.Rows.Count > 0)
            {
                txt_Hostname.Text = dt.Rows[0]["mshost"].ToString();
                txt_Username.Text = dt.Rows[0]["msusername"].ToString();
                txt_Password.Text = dt.Rows[0]["mspass"].ToString();
                txt_Tomail.Text = dt.Rows[0]["contemail"].ToString();
                txt_Ccmail.Text = dt.Rows[0]["contccemail"].ToString();
                txt_Bccmail.Text = dt.Rows[0]["contbccemail"].ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sQuery = @"update bankers_usr.siteprofile set mshost='" + txt_Hostname.Text.Replace("'", "''") + "',msusername='" + txt_Username.Text.Replace("'", "''") + "',mspass='" + txt_Password.Text.Replace("'", "''") + "',contemail='" + txt_Tomail.Text.Replace("'", "''") + "',contccemail='" + txt_Ccmail.Text.Replace("'", "''") + "',contbccemail='" + txt_Bccmail.Text.Replace("'", "''") + "'";
            new DAL().ExecuteNonQuery(sQuery, CommandType.Text, null);

            Session["msg"] = "The mail authentication details has been successfully modified.";
            Response.Redirect("dashboard.aspx");
        }
    }
}