using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Media.Downloads
{
    public partial class Manage_Downloads : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Downloads]";

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
                string downloadName = dt.Rows[0]["download_name"].ToString();
                if (!string.IsNullOrEmpty(downloadName))
                {
                    ddl_DownloadName.SelectedValue = downloadName;
                }
                // Fetch the PDF file name from the database
                string pdfFileName = dt.Rows[0]["PDF"].ToString();  // Assuming the column name is 'PDF'

                if (!string.IsNullOrEmpty(pdfFileName))
                {
                    // Generate the URL for the PDF file
                    string pdfUrl = "~/poweradmin/WebFiles/Downloads/" + pdfFileName;

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
                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/Downloads/" + dt.Rows[0]["image"].ToString();
                }
            }
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (ddl_DownloadName.SelectedValue == "")
            {
                ltr_Error.Text = "Please select a download name.";
                div_Error.Visible = true;
                return;
            }
            // Validate the PDF file
            if (!FileUploadPDF.HasFile)
            {
                ltr_Error.Text = "Please upload a PDF file.";
                div_Error.Visible = true;
                return;
            }

            double filesize = FileUploadPDF.PostedFile.ContentLength;
            string fileName = FileUploadPDF.FileName;
            string fileExtension = Path.GetExtension(fileName).ToLower();
            string downloadName = ddl_DownloadName.SelectedValue;

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

            // Validate the Image file
            string imageFileName = "";
            if (FileUploadImage.HasFile)  // Check if image is uploaded
            {
                string imageExtension = Path.GetExtension(FileUploadImage.FileName).ToLower();
                if (imageExtension != ".jpg" && imageExtension != ".jpeg" && imageExtension != ".png")
                {
                    ltr_Error.Text = "Only image files (.png, .jpg, .jpeg) are allowed.";
                    div_Error.Visible = true;
                    return;
                }

                double imageSize = FileUploadImage.PostedFile.ContentLength;
                if (imageSize > (5242880 * int.Parse(ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"].ToString())))
                {
                    ltr_Error.Text = "Image size exceeds the maximum size limit. Please upload a file below " + ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"].ToString() + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                // Save the image file
                imageFileName = FileUploadImage.FileName;
                string imagePath = "~/poweradmin/WebFiles/Downloads/" + imageFileName;
                FileUploadImage.SaveAs(MapPath(imagePath));
            }

            // Retrieve the title from the input control
            string title = txt_Title.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                ltr_Error.Text = "Title cannot be empty.";
                div_Error.Visible = true;
                return;
            }

            // Save the PDF file
            string pdfPath = "~/poweradmin/WebFiles/Downloads/" + fileName;
            FileUploadPDF.SaveAs(MapPath(pdfPath));

            // Insert the record into the database
            string query = @"INSERT INTO [bankers_usr].[Downloads] (title, image,download_name, PDF, added_date, added_ip) 
                     VALUES (@title, @image, @DownloadName,  @PDF, @AddedDate, @AddedIP)";

            List<SqlParameter> parameters = new List<SqlParameter>
    {

        new SqlParameter("@title", title),
        new SqlParameter("@image", imageFileName), // Image file name saved in database
                new SqlParameter("@DownloadName", downloadName), // Add this parameter

        new SqlParameter("@PDF", fileName),
        new SqlParameter("@AddedDate", DateTime.Now),
        new SqlParameter("@AddedIP", DAL.getIP())
    };

            int result = new DAL().ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());

            if (result > 0)
            {
                string msg = "PDF and image uploaded successfully.";
                Response.Redirect("View_Downloads.aspx?msg=" + msg);
            }
            else
            {
                ltr_Error.Text = "Error uploading PDF and image.";
                div_Error.Visible = true;
            }
        }




        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (ddl_DownloadName.SelectedValue == "")
            {
                ltr_Error.Text = "Please select a download name.";
                div_Error.Visible = true;
                return;
            }
            string pdfFileName = "";
            string imageFileName = "";
            string downloadName = ddl_DownloadName.SelectedValue;

            // Check if a new PDF file is uploaded
            if (FileUploadPDF.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUploadPDF.FileName).ToLower();
                if (fileExtension != ".pdf")
                {
                    ltr_Error.Text = "Only PDF files are allowed.";
                    div_Error.Visible = true;
                    return;
                }

                double filesize = FileUploadPDF.PostedFile.ContentLength;
                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"].ToString())))
                {
                    ltr_Error.Text = $"File size exceeds the maximum limit of {ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"]} MB.";
                    div_Error.Visible = true;
                    return;
                }

                // Save the PDF file
                pdfFileName = FileUploadPDF.FileName;
                string pdfFilePath = "~/poweradmin/WebFiles/Downloads/" + pdfFileName;
                FileUploadPDF.SaveAs(MapPath(pdfFilePath));
            }
            else
            {
                // If no new PDF is uploaded, use the existing file name from the database (from QueryString or DB)
                pdfFileName = Request.QueryString["PDF"];
            }

            // Check if a new Image file is uploaded
            if (FileUploadImage.HasFile)
            {
                string imageExtension = Path.GetExtension(FileUploadImage.FileName).ToLower();
                if (imageExtension != ".jpg" && imageExtension != ".jpeg" && imageExtension != ".png")
                {
                    ltr_Error.Text = "Only image files (.png, .jpg, .jpeg) are allowed.";
                    div_Error.Visible = true;
                    return;
                }

                double imageSize = FileUploadImage.PostedFile.ContentLength;
                if (imageSize > (5242880 * int.Parse(ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"].ToString())))
                {
                    ltr_Error.Text = "Image size exceeds the maximum limit.";
                    div_Error.Visible = true;
                    return;
                }

                // Save the image file
                imageFileName = FileUploadImage.FileName;
                string imagePath = "~/poweradmin/WebFiles/Downloads/" + imageFileName;
                FileUploadImage.SaveAs(MapPath(imagePath));
            }
            else
            {
                // If no new image is uploaded, use the existing file name from the database
                imageFileName = Request.QueryString["Image"];
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
            string query = "UPDATE [bankers_usr].[Downloads] SET download_name = @DownloadName,Title = @Title";

            // Initialize list of SQL parameters
            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@ID", id),
                new SqlParameter("@DownloadName", downloadName), // Add this parameter

        new SqlParameter("@Title", title)
    };

            // Add PDF condition if a file was uploaded
            if (!string.IsNullOrEmpty(pdfFileName))
            {
                query += ", PDF = @PDF";
                parameters.Add(new SqlParameter("@PDF", pdfFileName));
            }

            // Add image condition if a file was uploaded
            if (!string.IsNullOrEmpty(imageFileName))
            {
                query += ", Image = @Image";
                parameters.Add(new SqlParameter("@Image", imageFileName));
            }

            // Add the WHERE condition
            query += " WHERE ID = @ID";

            // Execute the query
            int result = new DAL().ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());

            if (result > 0)
            {
                Response.Redirect("View_Downloads.aspx?msg=Record updated successfully");
            }
            else
            {
                ltr_Error.Text = "Error updating the record.";
                div_Error.Visible = true;
            }
        }





        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_Downloads.aspx");
        }
    }
}
