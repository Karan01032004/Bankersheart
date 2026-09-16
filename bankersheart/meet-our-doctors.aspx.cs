using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class meet_our_doctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAwards(""); // Load all doctors initially
            }
        }


        private void BindAwards(string hospitalName)
        {
            string query = "SELECT [id], [Name], [image], [profession], [specialties] " +
                           "FROM [bankers_usr].[DoctorDetails] " +
                          "WHERE (@hospital = '' OR hospitals LIKE @hospital) " +
                   "ORDER BY [sortorder] ASC"; // Sort doctors by sortorder

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@hospital", "%" + hospitalName + "%") // Using LIKE for partial matches
            };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters.ToArray());
            rpt_MedicalCamps.DataSource = dt;
            rpt_MedicalCamps.DataBind();
        }

        protected void Hospital_Selected(object sender, CommandEventArgs e)
        {
            string selectedHospital = e.CommandArgument.ToString();
            hfSelectedHospital.Value = selectedHospital;

            // Update the label inside the dropdown button
            lblSelectedHospital.Text = string.IsNullOrEmpty(selectedHospital) ? "Select Hospital" : selectedHospital;

            BindAwards(selectedHospital);
        }

    }
}