using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace bankersheart
{

    public partial class cardcon_registration : System.Web.UI.Page
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
                txtBirthDate.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        private void GenerateCaptcha()
        {
            Random rnd = new Random();
            int num1 = rnd.Next(1, 10);
            int num2 = rnd.Next(1, 10);

            Session["CaptchaAnswer"] = (num1 + num2).ToString();
            string question = $"{num1} + {num2} = ?";

            txtCaptchaQuestion.Text = question;
            //litCaptchaLabel.Text = question;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Validate Dynamic Math Captcha
            string sessionCaptcha = Session["CaptchaAnswer"]?.ToString();
            if (string.IsNullOrEmpty(sessionCaptcha) || txtCaptcha.Text.Trim() != sessionCaptcha)
            {
                lblMessage.Text = "<div class='alert alert-danger'>Incorrect captcha. Please try again.</div>";
                GenerateCaptcha();
                txtCaptcha.Text = string.Empty;
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string finalCity = ddlCity.SelectedValue == "Other" ? txtOtherCity.Text.Trim() : ddlCity.SelectedValue;
                    string query = @"INSERT INTO bankers_usr.Cardcondetails 
                                    (FirstName,  Qualification, BirthDate, [Address], City, Area, PhoneNo, MobileNo, Email, AccommodationReq, IsPaidBill) 
                                    VALUES 
                                    (@FirstName,  @Qualification, @BirthDate, @Address,@City, @Area,  @PhoneNo, @MobileNo, @Email, @AccommodationReq,@IsPaidBill)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = txtName.Text.Trim();
                      
                        cmd.Parameters.Add("@Qualification", SqlDbType.NVarChar, 100).Value = txtQualification.Text.Trim();
                       
                        DateTime birthDate;
                        if (DateTime.TryParse(txtBirthDate.Text, out birthDate))
                        {
                            cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = birthDate;
                        }
                        else
                        {
                            cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = DBNull.Value;
                        }

                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 255).Value = txtAddress.Text.Trim();
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(finalCity) ? (object)DBNull.Value : finalCity;
                        cmd.Parameters.Add("@Area", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(txtArea.Text.Trim()) ? (object)DBNull.Value : txtArea.Text.Trim();
                        cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar, 20).Value = txtPhone.Text.Trim();
                        cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 20).Value = txtMobile.Text.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = txtEmail.Text.Trim();
                        cmd.Parameters.Add("@AccommodationReq", SqlDbType.Bit).Value = rbAccYes.Checked;
                        cmd.Parameters.Add("@IsPaidBill", SqlDbType.Bit).Value = rbPaidYes.Checked;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.Text = "<div class='alert alert-success'>Form submitted successfully!</div>";
                ClearFields();
                GenerateCaptcha();
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"<div class='alert alert-danger'>An error occurred: {ex.Message}</div>";
            }
        }

        private void ClearFields()
        {
            txtName.Text = string.Empty;
          
            txtQualification.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            ddlCity.SelectedIndex = 0;
            txtOtherCity.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCaptcha.Text = string.Empty;
            rbAccYes.Checked = false;
            rbAccNo.Checked = true;
            rbPaidYes.Checked = false;
            rbPaidNo.Checked = true;
        }
    }
}