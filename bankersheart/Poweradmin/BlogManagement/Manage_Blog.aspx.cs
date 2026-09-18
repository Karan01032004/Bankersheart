using bankersheart.App_Code;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImageMagick;

namespace bankersheart.Poweradmin.BlogManagement
{
    public partial class Manage_Blog : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[BlogManagement]";

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
                txt_Summary.Text = dt.Rows[0]["Summary"].ToString();
                txt_description.Text = dt.Rows[0]["description"].ToString();

                txt_CampDate.Text = Convert.ToDateTime(dt.Rows[0]["Blog_Date"]).ToString("dd-MM-yyyy");


                // Display current banner image
                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/BlogManagement/" + dt.Rows[0]["image"].ToString();
                }
            }
        }

        private DateTime ParseDate(string input)
        {
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            throw new FormatException("Invalid date format. Please use 'dd-MM-yyyy'.");
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();

            foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
            {
                double filesize = uploadedFile.ContentLength;
                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
                {
                    ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                string fileName = Path.GetFileName(uploadedFile.FileName);
                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                {
                    string filepath = "~/poweradmin/WebFiles/BlogManagement/" + fileName;
                    uploadedFile.SaveAs(MapPath(filepath));
                    uploadedFileNames.Add(fileName);

                    // Convert to WebP format
                    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/BlogManagement/"));
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

                    uploadedFile.InputStream.Position = 0;

                    // 4. Magick.NET se WebP convert karo
                    using (var image = new MagickImage(uploadedFile.InputStream))
                    {
                        image.Format = MagickFormat.WebP;
                        image.Quality = 80;
                        image.Strip(); // EXIF metadata remove karne ke liye
                        image.Write(webPImagePath);
                    }

                    //using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
                    //{
                    //    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                    //    {
                    //        imageFactory.Load(uploadedFile.InputStream)
                    //                    .Format(new WebPFormat())
                    //                    .Quality(80)
                    //                    .Save(webPFileStream);
                    //    }
                    //}
                }
                else
                {
                    flag = 1;
                    ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
                    div_Error.Visible = true;
                    return;
                }
            }

            // Insert new record using parameterized query
            foreach (string fileName in uploadedFileNames)
            {
                string query = @"INSERT INTO " + TableName + " (title,Summary,Blog_Date, image, description, added_date, added_ip)  VALUES(@Title,@Summary,@EventsatBankersDate, @Image, @Description, @AddedDate, @AddedIP)";

                SqlParameter[] parameters = {
            new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
            new SqlParameter("@Summary", SqlDbType.NVarChar) { Value = txt_Summary.Text.Replace("'", "''") },
                  new SqlParameter("@EventsatBankersDate", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },

                    new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
            new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
            new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        };

                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
            }

            string msg = "Blog added successfully.";
            Response.Redirect("view_Blog.aspx?msg=" + msg);
        }
        //protected void btn_submit_Click(object sender, EventArgs e)
        //{
        //    int flag = 0;
        //    List<string> uploadedFileNames = new List<string>();

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
        //                string filepath = "~/poweradmin/WebFiles/BlogManagement/" + fileName;
        //                uploadedFile.SaveAs(MapPath(filepath));
        //                uploadedFileNames.Add(fileName);

        //                // Convert to WebP format
        //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/BlogManagement/"));
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
        //        string query = @"INSERT INTO " + TableName + " (title,Summary, image, description, added_date, added_ip)  VALUES(@Title,@Summary, @Image, @Description, @AddedDate, @AddedIP)";


        //        SqlParameter[] parameters = {
        //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //    new SqlParameter("@Summary", SqlDbType.NVarChar) { Value = txt_Summary.Text.Replace("'", "''") },
        //    new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
        //    new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        //    new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        //};

        //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
        //    }

        //    string msg = "Blog added successfully.";
        //    Response.Redirect("view_Blog.aspx?msg=" + msg);
        //}

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string fileName = "";

            if (fpbannerimage.HasFile)
            {
                double filesize = fpbannerimage.PostedFile.ContentLength;
                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
                {
                    ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
                    div_Error.Visible = true;
                    return;
                }

                fileName = fpbannerimage.FileName;
                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                {
                    string filepath = "~/poweradmin/WebFiles/BlogManagement/" + fileName;
                    fpbannerimage.SaveAs(MapPath(filepath));

                    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/BlogManagement/"));
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
                    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

                    //using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
                    //{
                    //    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                    //    {
                    //        imageFactory.Load(new Bitmap(fpbannerimage.FileContent))
                    //                    .Format(new WebPFormat())
                    //                    .Quality(80)
                    //                    .Save(webPFileStream);
                    //    }
                    //}
                    fpbannerimage.FileContent.Position = 0;

                    // 4. Magick.NET se WebP convert karo
                    using (var image = new MagickImage(fpbannerimage.FileContent))
                    {
                        image.Format = MagickFormat.WebP;
                        image.Quality = 80;
                        image.Strip(); // EXIF metadata remove karne ke liye
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

            string id = Request.QueryString["ID"].ToString();

            string query = @"UPDATE " + TableName + " SET " +
                           "title=@Title, " +
                             "Blog_Date=@CampDate, " +
                           "Summary=@Summary, " +
                           "description=@Description, " +
                           "modified_date=@ModifiedDate, " +
                           "modified_ip=@ModifiedIP";

            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", image=@Image";
            }
            query += " WHERE id=@ID";

            SqlParameter[] parameters = {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
               new SqlParameter("@CampDate", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },

                new SqlParameter("@Summary", SqlDbType.NVarChar) { Value = txt_Summary.Text.Replace("'", "''") },
        new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

            if (!string.IsNullOrEmpty(fileName))
            {
                parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
            }

            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            string msg = "Blog updated successfully.";
            Response.Redirect("view_Blog.aspx?msg=" + msg);
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
        //                string filepath = "~/poweradmin/WebFiles/BlogManagement/" + fileName;
        //                fpbannerimage.SaveAs(MapPath(filepath));

        //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/BlogManagement/"));
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
        //                       "Summary=@Summary, " +
        //                       "description=@Description, " +


        //                       "modified_date=@ModifiedDate, " +
        //                       "modified_ip=@ModifiedIP";

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            query += ", image=@Image";
        //        }
        //        query += " WHERE id=@ID";

        //        SqlParameter[] parameters = {
        //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //    new SqlParameter("@Summary", SqlDbType.NVarChar) { Value = txt_Summary.Text.Replace("'", "''") },
        //    new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        //    new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        //    new SqlParameter("@ID", SqlDbType.Int) { Value = id }
        //};

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
        //        }

        //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

        //        string msg = "Blog updated successfully.";
        //        Response.Redirect("view_Blog.aspx?msg=" + msg);
        //    }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_Blog.aspx");
        }
    }
}
