using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.CSR.Yash_Public_Charitable_Trust
{
    public partial class Manage_Yash_Public_Charitable_Trust : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[YashPublicCharitableTrust]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["cmspath"].ToString() + "default.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        btn_Update.Visible = true;
                        btn_submit.Visible = false;
                        btn_Update.Text = "Update";
                        string id = Request.QueryString["ID"].ToString();
                        fill_data(id);
                        label_PDF.Visible = true;
                    }
                    else
                    {
                        
                        btn_Update.Visible = false;
                        btn_submit.Visible = true;
                        btn_submit.Text = "Submit";
                        label_PDF.Visible = false;  // Hides the label during the add operation

                    }
                }
            }
        }

        private void fill_data(string id)
        {
            DataTable dt = new DAL().GetDataTable($"select * from {TableName} where id='{id}' ", CommandType.Text, null);

            if (dt.Rows.Count > 0)
            {
                txt_Title.Text = dt.Rows[0]["title"].ToString();

                // Fetch the PDF file name from the database
                string pdfFileName = dt.Rows[0]["PDF"].ToString();  // Assuming the column name is 'PDF'

                if (!string.IsNullOrEmpty(pdfFileName))
                {
                    // Generate the URL for the PDF file
                    string pdfUrl = "~/poweradmin/WebFiles/CSR/YashPublicCharitableTrust/" + pdfFileName;

                    // Set the HyperLink control's text and URL dynamically
                    lnkDownloadPdf.Text = pdfFileName;  // Set the file name as link text
                    lnkDownloadPdf.NavigateUrl = ResolveUrl(pdfUrl);  // Generate the correct URL for the link
                    lnkDownloadPdf.Visible = true;  // Make the hyperlink visible
                }
                else
                {
                    // If no PDF file, show a message
                  //  lblPdfFile.Text = "No PDF uploaded.";
                    lnkDownloadPdf.Visible = false;  // Hide the hyperlink if no file exists
                }
            }
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!fpbannerimage.HasFile)
            {
                ltr_Error.Text = "Please upload a PDF file.";
                div_Error.Visible = true;
                return;
            }

            // Validate the uploaded file
            double filesize = fpbannerimage.PostedFile.ContentLength;
            string fileName = fpbannerimage.FileName;
            string fileExtension = Path.GetExtension(fileName).ToLower();

            if (fileExtension != ".pdf")
            {
                ltr_Error.Text = "Only PDF files are allowed.";
                div_Error.Visible = true;
                return;
            }

            if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"].ToString())))
            {
                ltr_Error.Text = "PDF size exceeds the maximum size limit. Please upload a file below " + ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"].ToString() + " MB.";
                div_Error.Visible = true;
                return;
            }

            // Retrieve the title from the input control
            string title = txt_Title.Text.Trim(); // Replace txtTitle with your actual TextBox control ID

            if (string.IsNullOrEmpty(title))
            {
                ltr_Error.Text = "Title cannot be empty.";
                div_Error.Visible = true;
                return;
            }

            // Save the uploaded file
            string pdfPath = "~/poweradmin/WebFiles/CSR/YashPublicCharitableTrust/" + fileName;
            fpbannerimage.SaveAs(MapPath(pdfPath));

            // Insert the record into the database
            string query = @"INSERT INTO YashPublicCharitableTrust (title, PDF, added_date, added_ip) 
                     VALUES (@title, @PDF, @AddedDate, @AddedIP)";

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@title", title),
        new SqlParameter("@PDF", fileName),
        new SqlParameter("@AddedDate", DateTime.Now),
        new SqlParameter("@AddedIP", DAL.getIP())
    };

            int result = new DAL().ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());

            if (result > 0)
            {
                string msg = "PDF uploaded successfully.";
                Response.Redirect("View_Yash_Public_Charitable_Trust.aspx?msg=" + msg);
            }
            else
            {
                ltr_Error.Text = "Error uploading PDF.";
                div_Error.Visible = true;
            }
        }


        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string fileName = "";

            // Check if a file is uploaded
            if (fpbannerimage.HasFile)
            {
                // Validate the file type
                string fileExtension = Path.GetExtension(fpbannerimage.FileName).ToLower();
                if (fileExtension != ".pdf")
                {
                    ltr_Error.Text = "Only PDF files are allowed.";
                    div_Error.Visible = true;
                    return;
                }

                // Validate file size
                // double fileSize = fpbannerimage.PostedFile.ContentLength / 1024.0 / 1024.0; // Convert to MB
                double filesize = fpbannerimage.PostedFile.ContentLength;

                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"].ToString())))
                {
                    ltr_Error.Text = $"File size exceeds the maximum limit of {ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"]} MB.";
                    div_Error.Visible = true;
                    return;
                }

                // Save the file
                fileName = fpbannerimage.FileName;
                string filePath = "~/poweradmin/WebFiles/CSR/YashPublicCharitableTrust/" + fileName;
                fpbannerimage.SaveAs(MapPath(filePath));
            }
            else
            {
                // If no new file is uploaded, use the existing file name from the database
                fileName = Request.QueryString["PDF"];
            }

            // Retrieve the record ID from the query string
            string id = Request.QueryString["ID"];
            if (string.IsNullOrEmpty(id))
            {
                ltr_Error.Text = "Invalid record ID.";
                div_Error.Visible = true;
                return;
            }

            // Get the title from the TextBox (Assuming you have a TextBox for the title)
            string title = txt_Title.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                ltr_Error.Text = "Title cannot be empty.";
                div_Error.Visible = true;
                return;
            }

            // Start building the SQL query
            string query = "UPDATE [bankers_usr].[YashPublicCharitableTrust] SET Title = @Title";

            // Initialize list of SQL parameters
            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@ID", id),
        new SqlParameter("@Title", title)
    };

            // Add PDF condition if a file was uploaded
            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", PDF = @PDF";
                parameters.Add(new SqlParameter("@PDF", fileName));
            }

            // Add the WHERE condition
            query += " WHERE id = @ID";

            // Execute the query
            int result = new DAL().ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());

            if (result > 0)
            {
                Response.Redirect("View_Yash_Public_Charitable_Trust.aspx?msg=Record updated successfully");
            }
            else
            {
                ltr_Error.Text = "Error updating the record.";
                div_Error.Visible = true;
            }
        }




        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_Yash_Public_Charitable_Trust.aspx");
        }
    }
}
