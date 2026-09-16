using bankersheart.App_Code;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace bankersheart
{
    public partial class all_services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindServiceDetails();
            }
        }

        private void BindServiceDetails()
        {
            string query = @"
                SELECT 
                    sn.id AS ServiceNameID, 
                    sn.title AS ServiceName, 
                    sn.image, 
                    STRING_AGG(s.HospitalName, '| ') AS HospitalNames
                FROM bankers_usr.ServiceName sn
                LEFT JOIN bankers_usr.Service s 
                    ON sn.id = s.ServiceNameID 
                GROUP BY sn.id, sn.title, sn.image
                ORDER BY sn.id";

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

            if (dt.Rows.Count > 0)
            {
                rpt_Services.DataSource = dt;
                rpt_Services.DataBind();
            }
        }

        // Helper method to generate dynamic hospital links
        protected string GenerateHospitalLinks(string hospitalNames)
        {
            if (string.IsNullOrEmpty(hospitalNames))
                return string.Empty;

            // Fetch hospital name and its dynamic link from the database
            string query = "SELECT hospitalname, link FROM bankers_usr.Hospitalname";
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

            // Store hospital names and links in a dictionary
            Dictionary<string, string> hospitalLinks = new Dictionary<string, string>();

            foreach (DataRow row in dt.Rows)
            {
                string hospitalName = row["hospitalname"].ToString().Trim();
                string hospitalLink = row["link"].ToString().Trim();
                hospitalLinks[hospitalName] = hospitalLink; // Store in dictionary
            }

            // Build the list of hospital links dynamically
            StringBuilder sb = new StringBuilder();
            string[] hospitals = hospitalNames.Split('|');

            foreach (string hospital in hospitals)
            {
                string hospitalNameTrimmed = hospital.Trim();
                string url = hospitalLinks.ContainsKey(hospitalNameTrimmed)
                    ? hospitalLinks[hospitalNameTrimmed]
                    : "#"; // If no link found, keep it on the same page

                sb.AppendFormat("<li><a href='{0}'>{1}</a></li>", url, hospitalNameTrimmed);
            }

            return sb.ToString();
        }
    }
}
