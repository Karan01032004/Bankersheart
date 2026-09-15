using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart
{
	public partial class about_bankers_group_of_hospitals : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAwards();
            }
        }
        private void BindAwards()
        {
            string query = "SELECT [id], [description] " +
                        "FROM [bankers_usr].[PageContent]";

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            rpt_data.DataSource = dt;
            rpt_data.DataBind();

        }
    }
}