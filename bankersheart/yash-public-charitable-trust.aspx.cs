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
    public partial class yash_public_charitable_trust : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPDF();
            }
        }

        private void LoadPDF()
        {
            string query = "SELECT PDF FROM bankers_usr.YashPublicCharitableTrust ORDER BY added_date DESC";
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

            if (dt.Rows.Count > 0)
            {
                string pdfFile = dt.Rows[0]["PDF"].ToString();
                string pdfPath = "https://bankersheart.com/poweradmin/webfiles/CSR/YashPublicCharitableTrust/" + pdfFile;
                pdfViewer.Attributes["src"] = pdfPath + "#page=1&view=fit";
            }
        }
    }
}