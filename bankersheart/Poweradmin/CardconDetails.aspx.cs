using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace bankersheart.Poweradmin
{
    public partial class CardconDetails : System.Web.UI.Page
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int recordId))
                {
                    LoadRecordDetails(recordId);
                }
                else
                {
                    Response.Redirect("ViewCardcon.aspx");
                }
            }
        }

        private void LoadRecordDetails(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT 
                                        Id,
                                        FirstName,
                                        MiddleName,
                                        LastName,
                                        Qualification,
                                        BirthDate,
                                        [Address],
IsPaidBill,
City,
Area,
                                        PhoneNo,
                                        MobileNo,
                                        Email,
                                        AccommodationReq,
                                        CreatedDate
                                     FROM bankers_usr.Cardcondetails 
                                     WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_FirstName.Text = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : "";
                             
                                txt_Qualification.Text = reader["Qualification"] != DBNull.Value ? reader["Qualification"].ToString() : "";

                                if (reader["BirthDate"] != DBNull.Value)
                                {
                                    txt_BirthDate.Text = Convert.ToDateTime(reader["BirthDate"]).ToString("dd-MM-yyyy");
                                }

                                txt_Address.Text = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "";
                                txt_City.Text = reader["City"] != DBNull.Value ? reader["City"].ToString() : "";
                                txt_Area.Text = reader["Area"] != DBNull.Value ? reader["Area"].ToString() : "";
                                txt_PhoneNo.Text = reader["PhoneNo"] != DBNull.Value ? reader["PhoneNo"].ToString() : "";
                                txt_MobileNo.Text = reader["MobileNo"] != DBNull.Value ? reader["MobileNo"].ToString() : "";
                                txt_Email.Text = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";

                                if (reader["CreatedDate"] != DBNull.Value)
                                {
                                    txt_CreatedDate.Text = Convert.ToDateTime(reader["CreatedDate"]).ToString("dd-MM-yyyy hh:mm tt");
                                }

                                // Accommodation status badge
                                bool accommodationRequested = reader["AccommodationReq"] != DBNull.Value && Convert.ToBoolean(reader["AccommodationReq"]);
                                if (accommodationRequested)
                                {
                                    ltr_Accommodation.Text = "<span class='badge badge-danger badge-status'>Yes [Chargeable]</span>";
                                }
                                else
                                {
                                    ltr_Accommodation.Text = "<span class='badge badge-default badge-status'>No</span>";
                                }
                                bool isPaid = reader["IsPaidBill"] != DBNull.Value && Convert.ToBoolean(reader["IsPaidBill"]);
                                ltr_IsPaid.Text = isPaid
                                    ? "<span class='badge badge-success badge-status'>Paid</span>"
                                    : "<span class='badge badge-danger badge-status'>Unpaid</span>";
                            }
                            else
                            {
                                div_Error.Visible = true;
                                ltr_Error.Text = "Record not found.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                div_Error.Visible = true;
                ltr_Error.Text = "Error fetching details: " + ex.Message;
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCardcon.aspx");
        }
    }
}