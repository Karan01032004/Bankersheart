using bankersheart.App_Code;
using ImageMagick;
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace bankersheart.Poweradmin.Media.Playcard
{
    public partial class Manage_Playcard : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[PlayCard]";

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
            DataTable dt = new DAL().GetDataTable("select * from " + TableName + " where id='" + id + "' order by id asc", CommandType.Text, null);

            if (dt.Rows.Count > 0)
            {
                txt_Title.Text = dt.Rows[0]["title"].ToString();
                txt_description.Text = dt.Rows[0]["description"].ToString();

                DataTable dt1 = new DAL().GetDataTable("SELECT image FROM [bankers_usr].[PlayCard_Images] WHERE PlayCard_id = '" + id + "' ORDER BY added_date DESC", CommandType.Text, null);

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

                // Display current banner image
                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/PlaycardCategory/" + dt.Rows[0]["image"].ToString();
                }
            }
        }
        protected void RemoveImage(object sender, CommandEventArgs e)
        {
            string imageToRemove = e.CommandArgument.ToString();

            // Remove the image from the database
            string deleteImageQuery = @"DELETE FROM [bankers_usr].[PlayCard_Images] WHERE image = @Image AND PlayCard_id = @NewsatBankersId";
            SqlParameter[] deleteParameters = {
        new SqlParameter("@Image", SqlDbType.NVarChar) { Value = imageToRemove },
        new SqlParameter("@NewsatBankersId", SqlDbType.Int) { Value = Request.QueryString["ID"].ToString() }
    };
            new DAL().ExecuteNonQuery(deleteImageQuery, CommandType.Text, deleteParameters);

            // Remove the image file from the server
            string filePath = Server.MapPath("~/poweradmin/WebFiles/PlayCard/" + imageToRemove);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Set the message to be displayed
            string msg = "Image removed successfully.";

            // Reload images
            fill_data(Request.QueryString["ID"].ToString());

            // Redirect to the same page or to a different page with the message
            Response.Redirect("Manage_Playcard.aspx?ID=" + Request.QueryString["ID"].ToString() + "&msg=" + Server.UrlEncode(msg));
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();
            string categoryImageFileName = string.Empty;

            int maxFileSize = 5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"]); // Convert MB to bytes

            // Upload and process images for gallery
            foreach (HttpPostedFile uploadedFile in fpbannerimagegallery.PostedFiles)
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
                string filepath = "~/poweradmin/WebFiles/PlayCard/" + fileName;
                uploadedFile.SaveAs(MapPath(filepath));
                uploadedFileNames.Add(fileName);
            }

            // **Upload Category Image**
            //if (fpbannerimage.HasFile)
            //{
            //    double fileSize = fpbannerimage.PostedFile.ContentLength;

            //    // Check file size
            //    if (fileSize > maxFileSize)
            //    {
            //        ltr_Error.Text = "Category Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
            //        div_Error.Visible = true;
            //        return;
            //    }

            //    string categoryFileName = Path.GetFileNameWithoutExtension(fpbannerimage.PostedFile.FileName);
            //    string categoryFileExtension = Path.GetExtension(fpbannerimage.PostedFile.FileName);
            //    string categoryFilePathOriginal = "~/poweradmin/WebFiles/PlaycardCategory/" + categoryFileName + categoryFileExtension;
            //    string categoryFilePathWebP = "~/poweradmin/WebFiles/PlaycardCategory/" + categoryFileName + ".webp";

            //    string fullPathOriginal = MapPath(categoryFilePathOriginal);
            //    string fullPathWebP = MapPath(categoryFilePathWebP);

            //    // Save original file
            //    fpbannerimage.PostedFile.SaveAs(fullPathOriginal);

            //    // Convert to WebP
            //    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
            //    {
            //        imageFactory.Load(fullPathOriginal)
            //                    .Format(new WebPFormat())
            //                    .Quality(100)
            //                    .Save(fullPathWebP);
            //    }

            //    // Assign filename for DB insertion (store only original file name, as WebP will be inferred)
            //    categoryImageFileName = categoryFileName + categoryFileExtension;
            //}
            if (fpbannerimage.HasFile)
            {
                double fileSize = fpbannerimage.PostedFile.ContentLength;

                // Check file size
                if (fileSize > maxFileSize)
                {
                    ltr_Error.Text = "Category Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                string categoryFileName = Path.GetFileNameWithoutExtension(fpbannerimage.PostedFile.FileName);
                string categoryFileExtension = Path.GetExtension(fpbannerimage.PostedFile.FileName);
                string categoryFilePathOriginal = "~/poweradmin/WebFiles/PlaycardCategory/" + categoryFileName + categoryFileExtension;
                string categoryFilePathWebP = "~/poweradmin/WebFiles/PlaycardCategory/" + categoryFileName + ".webp";

                string fullPathOriginal = MapPath(categoryFilePathOriginal);
                string fullPathWebP = MapPath(categoryFilePathWebP);

                // 1. Save original file
                fpbannerimage.PostedFile.SaveAs(fullPathOriginal);

                // 2. Convert to WebP using Magick.NET
                using (var image = new MagickImage(fullPathOriginal))
                {
                    image.Format = MagickFormat.WebP;
                    image.Quality = 80; // Standard 80 for web (100 agar lossless chahiye)
                    image.Strip();      // Metadata/EXIF remove karne ke liye

                    image.Write(fullPathWebP);
                }

                // Assign filename for DB insertion (store only original file name, as WebP will be inferred)
                categoryImageFileName = categoryFileName + categoryFileExtension;
            }
            // Insert new record into `Medical_Camp`
            string query = @"INSERT INTO " + TableName + " (title,  description, added_date, added_ip, image)   VALUES(@Title,  @Description, @AddedDate, @AddedIP, @Image); SELECT SCOPE_IDENTITY(); ";

            SqlParameter[] parameters = {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@Image", SqlDbType.NVarChar) { Value = categoryImageFileName } // Save category image filename
    };

            // Execute the insert and get the inserted ID
            int insertedId = Convert.ToInt32(new DAL().ExecuteScalar(query, CommandType.Text, parameters));

            // Insert multiple images into `Medical_Camp_Images`
            foreach (string fileName in uploadedFileNames)
            {
                string imageQuery = @"INSERT INTO [bankers_usr].[PlayCard_Images] (PlayCard_id, image, added_date) 
                              VALUES (@MedicalCampId, @Image, @AddedDate)";

                SqlParameter[] imageParameters = {
            new SqlParameter("@MedicalCampId", SqlDbType.Int) { Value = insertedId },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now }
        };

                // Execute Insert for each image
                new DAL().ExecuteNonQuery(imageQuery, CommandType.Text, imageParameters);
            }

            string msg = "Playcard added successfully.";
            Response.Redirect("ViewPlaycard.aspx?msg=" + msg);
        }
        //protected void btn_submit_Click(object sender, EventArgs e)
        //{
        //    int flag = 0;
        //    List<string> uploadedFileNames = new List<string>();
        //    string categoryImageFileName = string.Empty;

        //    foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
        //    {
        //        double filesize = uploadedFile.ContentLength;
        //        if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
        //        {
        //            ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
        //            div_Error.Visible = true;
        //            return;
        //        }

        //        Bitmap uploadedImage = new Bitmap(uploadedFile.InputStream);
        //        if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampWidth"].ToString()))
        //        {
        //            string fileName = Path.GetFileName(uploadedFile.FileName);
        //            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

        //            if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
        //            {
        //                string filepath = "~/poweradmin/WebFiles/PlayCard/" + fileName;
        //                uploadedFile.SaveAs(MapPath(filepath));
        //                uploadedFileNames.Add(fileName);

        //                // Convert to WebP format
        //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/PlayCard/"));
        //                string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
        //                string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

        //                using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
        //                {
        //                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
        //                    {
        //                        imageFactory.Load(uploadedImage)
        //                                    .Format(new WebPFormat())
        //                                    .Quality(80)
        //                                    .Save(webPFileStream);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                flag = 1;
        //                ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
        //                div_Error.Visible = true;
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            ltr_Error.Text = "Image resolution does not match. Please upload an image with width: " + ConfigurationManager.AppSettings["MedicalCampWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MedicalCampHeight"] + "px.";
        //            div_Error.Visible = true;
        //            return;
        //        }
        //    }

        //    // Insert new record using parameterized query
        //    foreach (string fileName in uploadedFileNames)
        //    {
        //        string query = @"INSERT INTO " + TableName + " (title,description, image,   added_date, added_ip)  VALUES(@Title,@description, @Image, @AddedDate, @AddedIP)";


        //        SqlParameter[] parameters = {
        //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //    new SqlParameter("@description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        //    new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
        //    new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        //};

        //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
        //    }

        //    string msg = "Play Cards added successfully.";
        //    Response.Redirect("ViewPlaycard.aspx?msg=" + msg);
        //}
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();  // To store all uploaded filenames
            string categoryImageFileName = string.Empty; // Store new category image filename
            int maxFileSize = 5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString()); // Get max size in bytes

            // Handling multiple image uploads
            if (fpbannerimagegallery.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in fpbannerimagegallery.PostedFiles)
                {
                    double filesize = uploadedFile.ContentLength;
                    if (filesize > maxFileSize)
                    {
                        ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
                        div_Error.Visible = true;
                        return;
                    }

                    string fileName = uploadedFile.FileName;
                    string filepath = "~/poweradmin/WebFiles/Playcard/" + fileName;
                    uploadedFile.SaveAs(MapPath(filepath));
                    uploadedFileNames.Add(fileName);  // Store the uploaded file names
                }
            }


            //if (fpbannerimage.HasFile)
            //{
            //    double fileSize = fpbannerimage.PostedFile.ContentLength;

            //    // Check file size
            //    if (fileSize > maxFileSize)
            //    {
            //        ltr_Error.Text = "Category Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
            //        div_Error.Visible = true;
            //        return;
            //    }

            //    string categoryFileName = Path.GetFileNameWithoutExtension(fpbannerimage.PostedFile.FileName);
            //    string categoryFileExtension = Path.GetExtension(fpbannerimage.PostedFile.FileName);
            //    string categoryFilePathOriginal = "~/poweradmin/WebFiles/PlayCardCategory/" + categoryFileName + categoryFileExtension;
            //    string categoryFilePathWebP = "~/poweradmin/WebFiles/PlayCardCategory/" + categoryFileName + ".webp";

            //    string fullPathOriginal = MapPath(categoryFilePathOriginal);
            //    string fullPathWebP = MapPath(categoryFilePathWebP);

            //    // Save original file
            //    fpbannerimage.PostedFile.SaveAs(fullPathOriginal);

            //    // Convert to WebP
            //    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
            //    {
            //        imageFactory.Load(fullPathOriginal)
            //                    .Format(new WebPFormat())
            //                    .Quality(100)
            //                    .Save(fullPathWebP);
            //    }

            //    // Assign filename for DB insertion (store only original file name, as WebP will be inferred)
            //    categoryImageFileName = categoryFileName + categoryFileExtension;
            //}

            if (fpbannerimage.HasFile)
            {
                double fileSize = fpbannerimage.PostedFile.ContentLength;

                // Check file size
                if (fileSize > maxFileSize)
                {
                    ltr_Error.Text = "Category Image size has exceeded the maximum limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"] + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                string categoryFileName = Path.GetFileNameWithoutExtension(fpbannerimage.PostedFile.FileName);
                string categoryFileExtension = Path.GetExtension(fpbannerimage.PostedFile.FileName);
                string categoryFilePathOriginal = "~/poweradmin/WebFiles/PlayCardCategory/" + categoryFileName + categoryFileExtension;
                string categoryFilePathWebP = "~/poweradmin/WebFiles/PlayCardCategory/" + categoryFileName + ".webp";

                string fullPathOriginal = MapPath(categoryFilePathOriginal);
                string fullPathWebP = MapPath(categoryFilePathWebP);

                // 1. Save original file
                fpbannerimage.PostedFile.SaveAs(fullPathOriginal);

                // 2. Convert to WebP using Magick.NET
                using (var image = new MagickImage(fullPathOriginal))
                {
                    image.Format = MagickFormat.WebP;
                    image.Quality = 80; // Standard 80 for web (100 agar exact lossless chahiye)
                    image.Strip();      // Metadata/EXIF remove karne ke liye

                    image.Write(fullPathWebP);
                }

                // Assign filename for DB insertion (store only original file name, as WebP will be inferred)
                categoryImageFileName = categoryFileName + categoryFileExtension;
            }

            string id = Request.QueryString["ID"].ToString();

            // Update the Medical_Camp record
            string query = @"UPDATE " + TableName + " SET " +
                           "title=@Title, " +
                           "description=@Description, " +
                      
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
        new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
  
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
                string imageQuery = @"INSERT INTO [bankers_usr].[PlayCard_Images] (Playcard_id, image, added_date) VALUES (@MedicalCampId, @Image, @AddedDate)";
                SqlParameter[] imageParameters = {
            new SqlParameter("@MedicalCampId", SqlDbType.Int) { Value = id },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now }
        };
                new DAL().ExecuteNonQuery(imageQuery, CommandType.Text, imageParameters);
            }

            string msg = "Play card updated successfully.";
            Response.Redirect("ViewPlaycard.aspx?msg=" + msg);
        }
    //    protected void btn_Update_Click(object sender, EventArgs e)
    //    {
    //        int flag = 0;
    //        string fileName = "";

    //        if (fpbannerimage.HasFile)
    //        {
    //            double filesize = fpbannerimage.PostedFile.ContentLength;
    //            if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
    //            {
    //                ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
    //                div_Error.Visible = true;
    //                return;
    //            }

    //            fileName = fpbannerimage.FileName;
    //            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

    //            if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
    //            {
    //                string filepath = "~/poweradmin/WebFiles/PlayCard/" + fileName;
    //                fpbannerimage.SaveAs(MapPath(filepath));

    //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/PlayCard/"));
    //                string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
    //                string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

    //                using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
    //                {
    //                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
    //                    {
    //                        imageFactory.Load(fpbannerimage.FileContent)
    //                                    .Format(new WebPFormat())
    //                                    .Quality(80)
    //                                    .Save(webPFileStream);
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                flag = 1;
    //                ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
    //                div_Error.Visible = true;
    //                return;
    //            }
    //        }

    //        string id = Request.QueryString["ID"].ToString();

    //        string query = @"UPDATE " + TableName + " SET " +
    //                       "title=@Title, " +
    //                       "description=@description, " +
    //                       "modified_date=@ModifiedDate, " +
    //                       "modified_ip=@ModifiedIP";

    //        if (!string.IsNullOrEmpty(fileName))
    //        {
    //            query += ", image=@Image";
    //        }
    //        query += " WHERE id=@ID";

    //        SqlParameter[] parameters = {
    //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
    //    new SqlParameter("@description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
    //    new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
    //    new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
    //    new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    //};

    //        if (!string.IsNullOrEmpty(fileName))
    //        {
    //            parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
    //        }

    //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

    //        string msg = "Play Cards updated successfully.";
    //        Response.Redirect("ViewPlaycard.aspx?msg=" + msg);
    //    }

        //    protected void btn_Update_Click(object sender, EventArgs e)
        //    {
        //        int flag = 0;
        //        string fileName = "";

        //        if (fpbannerimage.HasFile)
        //        {
        //            double filesize = fpbannerimage.PostedFile.ContentLength;
        //            if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
        //            {
        //                ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
        //                div_Error.Visible = true;
        //                return;
        //            }

        //            Bitmap uploadedImage = new Bitmap(fpbannerimage.FileContent);

        //            if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampWidth"].ToString()))
        //            {
        //            }
        //            else
        //            {
        //                ltr_Error.Text = "Image resolution does not match. Please upload an image with width: " + ConfigurationManager.AppSettings["MedicalCampWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MedicalCampHeight"] + "px.";
        //                div_Error.Visible = true;
        //                return;
        //            }

        //            fileName = fpbannerimage.FileName;
        //            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

        //            if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
        //            {
        //                string filepath = "~/poweradmin/WebFiles/PlayCard/" + fileName;
        //                fpbannerimage.SaveAs(MapPath(filepath));

        //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/PlayCard/"));
        //                string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
        //                string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

        //                using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
        //                {
        //                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
        //                    {
        //                        imageFactory.Load(uploadedImage)
        //                                    .Format(new WebPFormat())
        //                                    .Quality(80)
        //                                    .Save(webPFileStream);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                flag = 1;
        //                ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
        //                div_Error.Visible = true;
        //                return;
        //            }
        //        }

        //        string id = Request.QueryString["ID"].ToString();

        //        string query = @"UPDATE " + TableName + " SET " +
        //                       "title=@Title, " +
        //                       "description=@description, " +
        //                       "modified_date=@ModifiedDate, " +
        //                       "modified_ip=@ModifiedIP";

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            query += ", image=@Image";
        //        }
        //        query += " WHERE id=@ID";

        //        SqlParameter[] parameters = {
        //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //    new SqlParameter("@description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },

        //    new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        //    new SqlParameter("@ID", SqlDbType.Int) { Value = id }
        //};

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
        //        }

        //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

        //        string msg = "Play Cards updated successfully.";
        //        Response.Redirect("ViewPlaycard.aspx?msg=" + msg);
        //    }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPlaycard.aspx");
        }

    }
}
