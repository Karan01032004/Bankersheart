using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.includes
{
    public partial class header : System.Web.UI.UserControl
    {
        string TableName = "[bankers_usr].[admin]";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fill_data();
            }
        }
        private void fill_data()
        {
            string query = "select * from " + TableName + " order by id asc";
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Log or debug to check data is being fetched correctly.
                string fetchedName = dt.Rows[0]["name"].ToString();
                spanUsername.InnerText = fetchedName; // Bind the value to the span
            }
            else
            {
                spanUsername.InnerText = "Guest"; // Handle cases where no data is available
            }
        }

    }
}