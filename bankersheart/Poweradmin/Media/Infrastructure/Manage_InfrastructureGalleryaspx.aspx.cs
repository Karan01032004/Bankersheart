using bankersheart.App_Code;
using ImageMagick;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Media.Infrastructure
{
    public partial class Manage_InfrastructureGalleryaspx : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[InfrastructureGallery]";

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
                    BindInfrastructureDropdowns();  // Ensure this is only called on the first load, not after postbacks

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
        private void BindInfrastructureDropdowns()
        {
            DataTable dt = new DAL().GetDataTable("SELECT id, InfrastructureName FROM [bankers_usr].[InfrastructureName]", CommandType.Text, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                ddlInfrastructureName.DataSource = dt;
                ddlInfrastructureName.DataTextField = "InfrastructureName";
                ddlInfrastructureName.DataValueField = "id";
                ddlInfrastructureName.DataBind();

                // Add default item at the top
                ddlInfrastructureName.Items.Insert(0, new ListItem("-- Select Infrastructure Name --", "0"));
            }
            else
            {
                ddlInfrastructureName.Items.Insert(0, new ListItem("No data available", "0"));
            }
        }

        private void fill_data(string id)
        {
            // Use a JOIN query to fetch the required data including InfrastructureName
            string query = @" SELECT ig.*, iname.InfrastructureName FROM " + TableName + " ig   INNER JOIN InfrastructureName iname ON ig.InfrastructureName_ID = iname.id   WHERE ig.id = @ID";
   
    // Execute the query with the provided ID
    SqlParameter[] parameters = {
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, parameters);

            if (dt.Rows.Count > 0)
            {
                // Populate the form fields
                txt_Title.Text = dt.Rows[0]["title"].ToString();

                // Fetch the InfrastructureName_ID for the record
                int infrastructureNameID = Convert.ToInt32(dt.Rows[0]["InfrastructureName_ID"]);

                // Set the dropdown selection to the corresponding value
                ddlInfrastructureName.SelectedValue = infrastructureNameID.ToString();

                // Display the current banner image
                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/InfrastructureGallery/" + dt.Rows[0]["image"].ToString();
                }
            }
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();

            // Ensure the dropdown selection is valid
            int infrastructureNameID = Convert.ToInt32(ddlInfrastructureName.SelectedValue);
            ltr_Error.Text = "Selected Infrastructure ID: " + infrastructureNameID.ToString();  // Debugging line
            div_Error.Visible = true;
            if (infrastructureNameID == 0)
            {
                ltr_Error.Text = "Please select a valid Infrastructure Name.";
                div_Error.Visible = true;
                return;
            }


            foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
            {
                double filesize = uploadedFile.ContentLength;
                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
                {
                    ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                Bitmap uploadedImage = new Bitmap(uploadedFile.InputStream);
                if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampHeight"].ToString()) &&
                    uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampWidth"].ToString()))
                {
                    string fileName = Path.GetFileName(uploadedFile.FileName);
                    string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                    //if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                    //{
                    //    string filepath = "~/poweradmin/WebFiles/InfrastructureGallery/" + fileName;
                    //    uploadedFile.SaveAs(MapPath(filepath));
                    //    uploadedFileNames.Add(fileName);

                    //    // Convert to WebP format
                    //    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/InfrastructureGallery/"));
                    //    string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
                    //    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

                    //    using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
                    //    {
                    //        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                    //        {
                    //            imageFactory.Load(uploadedImage)
                    //                        .Format(new WebPFormat())
                    //                        .Quality(80)
                    //                        .Save(webPFileStream);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    flag = 1;
                    //    ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
                    //    div_Error.Visible = true;
                    //    return;
                    //}
                    if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                    {
                        string folderPath = Server.MapPath("~/poweradmin/WebFiles/InfrastructureGallery/");
                        string originalFilePath = Path.Combine(folderPath, fileName);

                        // 1. Save original file
                        uploadedFile.SaveAs(originalFilePath);
                        uploadedFileNames.Add(fileName);

                        // 2. Setup WebP file path
                        string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                        string webPImagePath = Path.Combine(folderPath, webPFileName);

                        // 3. Convert to WebP using Magick.NET
                        using (var image = new MagickImage(originalFilePath))
                        {
                            image.Format = MagickFormat.WebP;
                            image.Quality = 80;
                            image.Strip(); // Metadata/EXIF remove karne ke liye

                            image.Write(webPImagePath);
                        }
                    }
                    else
                    {
                        flag = 1;
                        ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
                        div_Error.Visible = true;
                        return;
                    }
                }
                else
                {
                    ltr_Error.Text = "Image resolution does not match. Please upload an image with width: " + ConfigurationManager.AppSettings["MedicalCampWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MedicalCampHeight"] + "px.";
                    div_Error.Visible = true;
                    return;
                }
            }

            foreach (string fileName in uploadedFileNames)
            {
                string query = @"INSERT INTO " + TableName +
                               " (InfrastructureName_ID, title, image, added_date, added_ip) " +
                               "VALUES (@InfrastructureNameID, @Title, @Image, @AddedDate, @AddedIP)";

                SqlParameter[] parameters = {
            new SqlParameter("@InfrastructureNameID", SqlDbType.Int) { Value = infrastructureNameID }, // Use selected value
            new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
            new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        };

                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
            }

            string msg = "InfrastructureGallery added successfully.";
            Response.Redirect("View_InfrastructureGallery.aspx?msg=" + msg);
        }




        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string fileName = "";

            // Ensure the dropdown selection is valid
            int infrastructureNameID = Convert.ToInt32(ddlInfrastructureName.SelectedValue);
            if (infrastructureNameID == 0)
            {
                ltr_Error.Text = "Please select a valid Infrastructure Name.";
                div_Error.Visible = true;
                return;
            }

            // Handle image upload if there is a file
            if (fpbannerimage.HasFile)
            {
                double filesize = fpbannerimage.PostedFile.ContentLength;
                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
                {
                    ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                Bitmap uploadedImage = new Bitmap(fpbannerimage.FileContent);

                if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampHeight"].ToString()) &&
                    uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampWidth"].ToString()))
                {
                    // Valid image, process it
                    fileName = fpbannerimage.FileName;
                    string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                    //if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                    //{
                    //    string filepath = "~/poweradmin/WebFiles/InfrastructureGallery/" + fileName;
                    //    fpbannerimage.SaveAs(MapPath(filepath));

                    //    // Convert to WebP format
                    //    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/InfrastructureGallery/"));
                    //    string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
                    //    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

                    //    using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
                    //    {
                    //        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                    //        {
                    //            imageFactory.Load(uploadedImage)
                    //                        .Format(new WebPFormat())
                    //                        .Quality(80)
                    //                        .Save(webPFileStream);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    flag = 1;
                    //    ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
                    //    div_Error.Visible = true;
                    //    return;
                    //}

                    if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                    {
                        string folderPath = Server.MapPath("~/poweradmin/WebFiles/InfrastructureGallery/");
                        string originalFilePath = Path.Combine(folderPath, fileName);

                        // 1. Original file save karo
                        fpbannerimage.SaveAs(originalFilePath);

                        // 2. WebP destination path prepare karo
                        string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                        string webPImagePath = Path.Combine(folderPath, webPFileName);

                        // 3. Magick.NET se WebP convert karo
                        using (var image = new MagickImage(originalFilePath))
                        {
                            image.Format = MagickFormat.WebP;
                            image.Quality = 80;
                            image.Strip(); // Metadata/EXIF strip karne ke liye

                            image.Write(webPImagePath);
                        }
                    }
                    else
                    {
                        flag = 1;
                        ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
                        div_Error.Visible = true;
                        return;
                    }
                }
                else
                {
                    ltr_Error.Text = "Image resolution does not match. Please upload an image with width: " + ConfigurationManager.AppSettings["MedicalCampWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MedicalCampHeight"] + "px.";
                    div_Error.Visible = true;
                    return;
                }
            }

            // Get the ID from the query string
            string id = Request.QueryString["ID"].ToString();

            // Prepare the update query
            string query = @"UPDATE " + TableName + " SET " +
                           "title = @Title, " +
                           "InfrastructureName_ID = @InfrastructureNameID, " +
                           "modified_date = @ModifiedDate, " +
                           "modified_ip = @ModifiedIP";

            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", image = @Image";
            }
            query += " WHERE id = @ID";

            // Prepare the parameters
            SqlParameter[] parameters = {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        new SqlParameter("@InfrastructureNameID", SqlDbType.Int) { Value = infrastructureNameID },
        new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

            // Add the image parameter if there's a new image
            if (!string.IsNullOrEmpty(fileName))
            {
                parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
            }

            // Execute the update query
            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            // Redirect with success message
            string msg = "Infrastructure Gallery updated successfully.";
            Response.Redirect("view_InfrastructureGallery.aspx?msg=" + msg);
        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_InfrastructureGallery.aspx");
        }
    }
}
