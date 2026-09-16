using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin
{
    public partial class ViewCardcon : System.Web.UI.Page
    {
        // Web.config connection string
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCardconData();
              
            }
        }

        private void BindCardconData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    // Full Name combine karke fetch kar rahe hain
                    string query = @"SELECT 
                                        Id,
                                        LTRIM(RTRIM(CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName))) AS FullName,
                                        Email,
                                        MobileNo,
 Qualification,
 CASE 
                        WHEN IsPaidBill = 1 THEN 'Yes'
                        ELSE 'No'
                    END AS IsPaidBill,
City,
      CASE 
                        WHEN AccommodationReq = 1 THEN 'Yes'
                        ELSE 'No'
                    END AS AccommodationReq,
                                        CreatedDate 
                                     FROM bankers_usr.Cardcondetails 
                                     ORDER BY Id DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            rpt_data.DataSource = dt;
                            rpt_data.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Error loading data: " + ex.Message);
            }
        }

        protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("delete", StringComparison.OrdinalIgnoreCase))
            {
                int recordId = Convert.ToInt32(e.CommandArgument);
                DeleteRecord(recordId);
            }
        }

        private void DeleteRecord(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM bankers_usr.Cardcondetails WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ShowSuccess("Record deleted successfully.");
                            BindCardconData();
                        }
                        else
                        {
                            ShowError("Record not found or already deleted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Error deleting record: " + ex.Message);
            }
        }

        private void ShowSuccess(string message)
        {
            div_Error.Visible = false;
            div_Success.Visible = true;
            ltr_Success.Text = message;
        }

        private void ShowError(string message)
        {
            div_Success.Visible = false;
            div_Error.Visible = true;
            ltr_Error.Text = message;
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT 
                                Id,
                                FirstName,
                                MiddleName,
                                LastName,
                                Qualification,
                                CONVERT(VARCHAR(10), BirthDate, 105) AS [Birth Date],
                                [Address],
                                City,
                                Area,
                                PhoneNo AS [Phone],
                                MobileNo AS [Mobile],
                                Email,
                                CASE WHEN AccommodationReq = 1 THEN 'Yes' ELSE 'No' END AS [Accommodation Requested],
                                CASE WHEN IsPaidBill = 1 THEN 'Yes' ELSE 'No' END AS [Is Paid],
                                CONVERT(VARCHAR(20), CreatedDate, 120) AS [Registered Date]
                             FROM bankers_usr.Cardcondetails 
                             ORDER BY Id DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    string filename = "Cardcon_Registrations_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                    Response.Charset = "UTF-8";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentEncoding = Encoding.UTF8;

                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            GridView gv = new GridView();
                            gv.DataSource = dt;
                            gv.DataBind();

                            // Header styling
                            gv.HeaderRow.Style.Add("background-color", "#3598dc");
                            gv.HeaderRow.Style.Add("color", "#ffffff");
                            gv.HeaderRow.Style.Add("font-weight", "bold");

                            // Numbers & text proper format me dikhane ke liye border & style
                            for (int i = 0; i < gv.Rows.Count; i++)
                            {
                                gv.Rows[i].Style.Add("mso-number-format", @"\@"); // Forces text format so phone numbers don't lose leading zero
                            }

                            gv.RenderControl(hw);
                            Response.Output.Write(sw.ToString());
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
                else
                {
                    ShowError("No data available to export.");
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                // Response.End() throws ThreadAbortException which is normal during download
            }
            catch (Exception ex)
            {
                ShowError("Error exporting data: " + ex.Message);
            }
        }
    }
}