using bankersheart.App_Code;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.CSR.Exhibition
{
    public partial class Manage_Exhibition : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Exhibition]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["msg"]))
            {
                ltr_Success.Text = Request.QueryString["msg"].ToString();
                div_Success.Visible = true;
            }
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

                        // Set button text for edit
                        btn_Update.Text = "Update";

                        string id = Request.QueryString["ID"].ToString();
                        fill_data(id);
                    }
                    else
                    {
                        btn_Update.Visible = false;
                        btn_submit.Visible = true;

                        // Set button text for add
                        btn_submit.Text = "Submit";
                    }

                }
            }
        }

        private void fill_data(string id)
        {
            // Query for main record data
            DataTable dt = new DAL().GetDataTable("SELECT * FROM " + TableName + " WHERE id='" + id + "' ORDER BY Exhibition_Date ASC", CommandType.Text, null);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
            }
            // Query to fetch images
            DataTable dt1 = new DAL().GetDataTable("SELECT image FROM [bankers_usr].[Exhibition_Images] WHERE Exhibition_id = '" + id + "' ORDER BY added_date DESC", CommandType.Text, null);

            // Bind the Repeater with images
            if (dt1.Rows.Count > 0)
            {
                rptImages.DataSource = dt1;
                rptImages.DataBind();
            }
            else
            {
                rptImages.DataSource = null;
                rptImages.DataBind();
            }
            // Populate the form fields with data
            if (dt.Rows.Count > 0)
            {
                txt_Title.Text = dt.Rows[0]["title"].ToString();
                txt_description.Text = dt.Rows[0]["description"].ToString();
                txt_ShortDescription.Text = dt.Rows[0]["shortdescription"].ToString();
                txt_CampDate.Text = Convert.ToDateTime(dt.Rows[0]["Exhibition_Date"]).ToString("dd-MM-yyyy");
            }

            // Bind the Repeater with images

        }
        protected void RemoveImage(object sender, CommandEventArgs e)
        {
            string imageToRemove = e.CommandArgument.ToString();

            // Remove the image from the database
            string deleteImageQuery = @"DELETE FROM [bankers_usr].[Exhibition_Images] WHERE image = @Image AND Exhibition_id = @NewsatBankersId";
            SqlParameter[] deleteParameters = {
        new SqlParameter("@Image", SqlDbType.NVarChar) { Value = imageToRemove },
        new SqlParameter("@NewsatBankersId", SqlDbType.Int) { Value = Request.QueryString["ID"].ToString() }
    };
            new DAL().ExecuteNonQuery(deleteImageQuery, CommandType.Text, deleteParameters);

            // Remove the image file from the server
            string filePath = Server.MapPath("~/poweradmin/WebFiles/Exhibition/" + imageToRemove);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Set the message to be displayed
            string msg = "Image removed successfully.";

            // Reload images
            fill_data(Request.QueryString["ID"].ToString());

            // Redirect to the same page or to a different page with the message
            Response.Redirect("Manage_Exhibition.aspx?ID=" + Request.QueryString["ID"].ToString() + "&msg=" + Server.UrlEncode(msg));
        }
      
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();
            string categoryImageFileName = string.Empty;

            int maxFileSize = 5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"]); // Convert MB to bytes

            // Upload and process images for gallery
            foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
            {
                double fileSize = uploadedFile.ContentLength;

                // Check file size
                if (fileSize > maxFileSize)
                {
                    ltr_Error.Text = "Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                string fileName = Path.GetFileName(uploadedFile.FileName);
                string filepath = "~/poweradmin/WebFiles/Exhibition/" + fileName;
                uploadedFile.SaveAs(MapPath(filepath));
                uploadedFileNames.Add(fileName);
            }

            // **Upload Category Image**
            //if (Category.HasFile)
            //{
            //    double fileSize = Category.PostedFile.ContentLength;

            //    // Check file size
            //    if (fileSize > maxFileSize)
            //    {
            //        ltr_Error.Text = "Category Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
            //        div_Error.Visible = true;
            //        return;
            //    }

            //    string categoryFileName = Path.GetFileName(Category.PostedFile.FileName);
            //    string categoryFilePath = "~/poweradmin/WebFiles/ExhibitionCategory/" + categoryFileName;

            //    // Save file
            //    Category.PostedFile.SaveAs(MapPath(categoryFilePath));

            //    // Assign filename for DB insertion
            //    categoryImageFileName = categoryFileName;
            //}
            if (Category.HasFile)
            {
                double fileSize = Category.PostedFile.ContentLength;

                // Check file size
                if (fileSize > maxFileSize)
                {
                    ltr_Error.Text = "Category Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                string categoryFileName = Path.GetFileNameWithoutExtension(Category.PostedFile.FileName);
                string categoryFileExtension = Path.GetExtension(Category.PostedFile.FileName);
                string categoryFilePathOriginal = "~/poweradmin/WebFiles/ExhibitionCategory/" + categoryFileName + categoryFileExtension;
                string categoryFilePathWebP = "~/poweradmin/WebFiles/ExhibitionCategory/" + categoryFileName + ".webp";

                string fullPathOriginal = MapPath(categoryFilePathOriginal);
                string fullPathWebP = MapPath(categoryFilePathWebP);

                // Save original file
                Category.PostedFile.SaveAs(fullPathOriginal);

                // Convert to WebP
                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                {
                    imageFactory.Load(fullPathOriginal)
                                .Format(new WebPFormat())
                                .Quality(100)
                                .Save(fullPathWebP);
                }

                // Assign filename for DB insertion (store only original file name, as WebP will be inferred)
                categoryImageFileName = categoryFileName + categoryFileExtension;
            }

            // Insert new record into `Medical_Camp`
            string query = @"INSERT INTO " + TableName + " (title,titlelink, shortdescription, description, Exhibition_Date, added_date, added_ip, image)   VALUES(@Title,@titlelink, @ShortDescription, @Description, @EventsatBankersDate, @AddedDate, @AddedIP, @Image); SELECT SCOPE_IDENTITY(); ";

            SqlParameter[] parameters = {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
                new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = Regex.Replace(txt_Title.Text, @"[^0-9a-zA-Z]+", "-").ToLower()},

        new SqlParameter("@ShortDescription", SqlDbType.NVarChar) { Value = txt_ShortDescription.Text.Replace("'", "''") },
        new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        new SqlParameter("@EventsatBankersDate", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },
        new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@Image", SqlDbType.NVarChar) { Value = categoryImageFileName } // Save category image filename
    };

            // Execute the insert and get the inserted ID
            int insertedId = Convert.ToInt32(new DAL().ExecuteScalar(query, CommandType.Text, parameters));

            // Insert multiple images into `Medical_Camp_Images`
            foreach (string fileName in uploadedFileNames)
            {
                string imageQuery = @"INSERT INTO [bankers_usr].[Exhibition_Images] (Exhibition_id, image, added_date) 
                              VALUES (@MedicalCampId, @Image, @AddedDate)";

                SqlParameter[] imageParameters = {
            new SqlParameter("@MedicalCampId", SqlDbType.Int) { Value = insertedId },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now }
        };

                // Execute Insert for each image
                new DAL().ExecuteNonQuery(imageQuery, CommandType.Text, imageParameters);
            }

            string msg = "Exhibition added successfully.";
            Response.Redirect("View_Exhibition.aspx?msg=" + msg);
        }
        private DateTime ParseDate(string input)
        {
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            throw new FormatException("Invalid date format. Please use 'dd-MM-yyyy'.");
        }
     


        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();  // To store all uploaded filenames
            string categoryImageFileName = string.Empty; // Store new category image filename
            int maxFileSize = 5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString()); // Get max size in bytes

            // Handling multiple image uploads
            if (fpbannerimage.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
                {
                    double filesize = uploadedFile.ContentLength;
                    if (filesize > maxFileSize)
                    {
                        ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
                        div_Error.Visible = true;
                        return;
                    }

                    string fileName = uploadedFile.FileName;
                    string filepath = "~/poweradmin/WebFiles/Exhibition/" + fileName;
                    uploadedFile.SaveAs(MapPath(filepath));
                    uploadedFileNames.Add(fileName);  // Store the uploaded file names
                }
            }

            // **Handling Category Image Upload**
            //if (Category.HasFile)
            //{
            //    if (Category.PostedFile.ContentLength > maxFileSize)
            //    {
            //        ltr_Error.Text = "Category image size exceeds the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
            //        div_Error.Visible = true;
            //        return;
            //    }

            //    string categoryFileName = Path.GetFileName(Category.PostedFile.FileName);
            //    string categoryFilePath = "~/poweradmin/WebFiles/ExhibitionCategory/" + categoryFileName;

            //    // Save the new category image
            //    Category.PostedFile.SaveAs(MapPath(categoryFilePath));

            //    // Assign filename for DB update
            //    categoryImageFileName = categoryFileName;
            //}
            if (Category.HasFile)
            {
                double fileSize = Category.PostedFile.ContentLength;

                // Check file size
                if (fileSize > maxFileSize)
                {
                    ltr_Error.Text = "Category Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                string categoryFileName = Path.GetFileNameWithoutExtension(Category.PostedFile.FileName);
                string categoryFileExtension = Path.GetExtension(Category.PostedFile.FileName);
                string categoryFilePathOriginal = "~/poweradmin/WebFiles/ExhibitionCategory/" + categoryFileName + categoryFileExtension;
                string categoryFilePathWebP = "~/poweradmin/WebFiles/ExhibitionCategory/" + categoryFileName + ".webp";

                string fullPathOriginal = MapPath(categoryFilePathOriginal);
                string fullPathWebP = MapPath(categoryFilePathWebP);

                // Save original file
                Category.PostedFile.SaveAs(fullPathOriginal);

                // Convert to WebP
                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                {
                    imageFactory.Load(fullPathOriginal)
                                .Format(new WebPFormat())
                                .Quality(100)
                                .Save(fullPathWebP);
                }

                // Assign filename for DB insertion (store only original file name, as WebP will be inferred)
                categoryImageFileName = categoryFileName + categoryFileExtension;
            }

            string id = Request.QueryString["ID"].ToString();

            // Update the Medical_Camp record
            string query = @"UPDATE " + TableName + " SET " +
                           "title=@Title, " +
                           "titlelink=@Titlelink, " +

                           "description=@Description, " +
                           "shortdescription=@ShortDescription, " +
                           "Exhibition_Date=@CampDate, " +
                           "modified_date=@ModifiedDate, " +
                           "modified_ip=@ModifiedIP";

            // **Include category image update if a new image is uploaded**
            if (!string.IsNullOrEmpty(categoryImageFileName))
            {
                query += ", image=@Image";
            }

            query += " WHERE ID=@ID";

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
               new SqlParameter("@titlelink", SqlDbType.NVarChar) { Value = Regex.Replace(txt_Title.Text, @"[^0-9a-zA-Z]+", "-").ToLower()},

        new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        new SqlParameter("@ShortDescription", SqlDbType.NVarChar) { Value = txt_ShortDescription.Text.Replace("'", "''") },
        new SqlParameter("@CampDate", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },
        new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

            // **Add category image parameter if updated**
            if (!string.IsNullOrEmpty(categoryImageFileName))
            {
                parameters.Add(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = categoryImageFileName });
            }

            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters.ToArray());

            // Insert new images into `Medical_Camp_Images` table
            foreach (string fileName in uploadedFileNames)
            {
                string imageQuery = @"INSERT INTO [bankers_usr].[Exhibition_Images] (Exhibition_id, image, added_date) VALUES (@MedicalCampId, @Image, @AddedDate)";
                SqlParameter[] imageParameters = {
            new SqlParameter("@MedicalCampId", SqlDbType.Int) { Value = id },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now }
        };
                new DAL().ExecuteNonQuery(imageQuery, CommandType.Text, imageParameters);
            }

            string msg = "Exhibition updated successfully.";
            Response.Redirect("view_Exhibition.aspx?msg=" + msg);
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_Exhibition.aspx");
        }
    }
}
