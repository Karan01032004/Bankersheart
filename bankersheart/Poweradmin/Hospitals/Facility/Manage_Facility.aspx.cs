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

namespace bankersheart.Poweradmin.Hospitals.Facility
{
    public partial class Manage_Facility : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Facility]";

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
                string downloadName = dt.Rows[0]["HospitalName"].ToString();
                if (!string.IsNullOrEmpty(downloadName))
                {
                    ddl_DownloadName.SelectedValue = downloadName;
                }


                // Display current banner image
                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/Facility/" + dt.Rows[0]["image"].ToString();
                }
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();
            string downloadName = ddl_DownloadName.SelectedValue;

            //foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
            //{
            //    double filesize = uploadedFile.ContentLength;
            //    if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
            //    {
            //        ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
            //        div_Error.Visible = true;
            //        return;
            //    }

            //    string fileName = Path.GetFileName(uploadedFile.FileName);
            //    string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

            //    if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
            //    {
            //        string filepath = "~/poweradmin/WebFiles/Facility/" + fileName;
            //        uploadedFile.SaveAs(MapPath(filepath));
            //        uploadedFileNames.Add(fileName);

            //        // Convert to WebP format
            //        string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Facility/"));
            //        string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
            //        string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

            //        using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
            //        {
            //            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
            //            {
            //                imageFactory.Load(uploadedFile.InputStream)
            //                            .Format(new WebPFormat())
            //                            .Quality(80)
            //                            .Save(webPFileStream);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        flag = 1;
            //        ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
            //        div_Error.Visible = true;
            //        return;
            //    }
            //}
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
                    string folderPath = Server.MapPath("~/poweradmin/WebFiles/Facility/");
                    string originalFilePath = Path.Combine(folderPath, fileName);

                    // 1. Original file save karo
                    uploadedFile.SaveAs(originalFilePath);
                    uploadedFileNames.Add(fileName);

                    // 2. WebP destination path banao
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                    string webPImagePath = Path.Combine(folderPath, webPFileName);

                    // 3. Magick.NET se WebP convert karo
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

            foreach (string fileName in uploadedFileNames)
            {
                string query = @"INSERT INTO " + TableName + " (title, image, HospitalName, added_date, added_ip) VALUES (@Title, @Image, @DownloadName, @AddedDate, @AddedIP)";

                SqlParameter[] parameters = {
            new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName },
            new SqlParameter("@DownloadName", downloadName),
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
            new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        };

                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
            }

            string msg = "Facility added successfully.";
            Response.Redirect("view_Facility.aspx?msg=" + msg);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string fileName = "";
            string downloadName = ddl_DownloadName.SelectedValue;

            //if (fpbannerimage.HasFile)
            //{
            //    double filesize = fpbannerimage.PostedFile.ContentLength;
            //    if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
            //    {
            //        ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
            //        div_Error.Visible = true;
            //        return;
            //    }

            //    fileName = fpbannerimage.FileName;
            //    string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

            //    if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
            //    {
            //        string filepath = "~/poweradmin/WebFiles/Facility/" + fileName;
            //        fpbannerimage.SaveAs(MapPath(filepath));

            //        string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Facility/"));
            //        string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
            //        string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

            //        using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
            //        {
            //            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
            //            {
            //                imageFactory.Load(fpbannerimage.FileContent)
            //                            .Format(new WebPFormat())
            //                            .Quality(80)
            //                            .Save(webPFileStream);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        flag = 1;
            //        ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
            //        div_Error.Visible = true;
            //        return;
            //    }
            //}
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
                    string folderPath = Server.MapPath("~/poweradmin/WebFiles/Facility/");
                    string originalFilePath = Path.Combine(folderPath, fileName);

                    // 1. Original file save karo
                    fpbannerimage.SaveAs(originalFilePath);

                    // 2. WebP destination path banao
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                    string webPImagePath = Path.Combine(folderPath, webPFileName);

                    // 3. Magick.NET se WebP convert karo
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

            string id = Request.QueryString["ID"].ToString();
            string query = @"UPDATE " + TableName + " SET HospitalName=@Facility, title=@Title, modified_date=@ModifiedDate, modified_ip=@ModifiedIP";

            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", image=@Image";
            }
            query += " WHERE id=@ID";

            SqlParameter[] parameters = {
        new SqlParameter("@Facility", downloadName),
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

            if (!string.IsNullOrEmpty(fileName))
            {
                parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
            }

            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            string msg = "Facility updated successfully.";
            Response.Redirect("view_Facility.aspx?msg=" + msg);
        }

        //    protected void btn_submit_Click(object sender, EventArgs e)
        //    {
        //        int flag = 0;
        //        List<string> uploadedFileNames = new List<string>();
        //        string downloadName = ddl_DownloadName.SelectedValue;

        //        foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
        //        {
        //            double filesize = uploadedFile.ContentLength;
        //            if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
        //            {
        //                ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
        //                div_Error.Visible = true;
        //                return;
        //            }

        //            Bitmap uploadedImage = new Bitmap(uploadedFile.InputStream);
        //            if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampWidth"].ToString()))
        //            {
        //                string fileName = Path.GetFileName(uploadedFile.FileName);
        //                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

        //                if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
        //                {
        //                    string filepath = "~/poweradmin/WebFiles/Facility/" + fileName;
        //                    uploadedFile.SaveAs(MapPath(filepath));
        //                    uploadedFileNames.Add(fileName);

        //                    // Convert to WebP format
        //                    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Facility/"));
        //                    string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
        //                    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

        //                    using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
        //                    {
        //                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
        //                        {
        //                            imageFactory.Load(uploadedImage)
        //                                        .Format(new WebPFormat())
        //                                        .Quality(80)
        //                                        .Save(webPFileStream);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    flag = 1;
        //                    ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
        //                    div_Error.Visible = true;
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                ltr_Error.Text = "Image resolution does not match. Please upload an image with width: " + ConfigurationManager.AppSettings["MedicalCampWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MedicalCampHeight"] + "px.";
        //                div_Error.Visible = true;
        //                return;
        //            }
        //        }

        //        // Insert new record using parameterized query
        //        foreach (string fileName in uploadedFileNames)
        //        {
        //            string query = @"INSERT INTO " + TableName + " (title, image,HospitalName, added_date, added_ip)  VALUES(@Title, @Image,@DownloadName, @AddedDate, @AddedIP)";


        //            SqlParameter[] parameters = {
        //        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //        new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
        //                      new SqlParameter("@DownloadName", downloadName), // Add this parameter

        //        new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //        new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        //    };

        //            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
        //        }

        //        string msg = "Facility added successfully.";
        //        Response.Redirect("view_Facility.aspx?msg=" + msg);
        //    }


        //    protected void btn_Update_Click(object sender, EventArgs e)
        //    {
        //        int flag = 0;
        //        string fileName = "";
        //        if (ddl_DownloadName.SelectedValue == "")
        //        {
        //            ltr_Error.Text = "Please select a Hospital Name.";
        //            div_Error.Visible = true;
        //            return;
        //        }
        //        string downloadName = ddl_DownloadName.SelectedValue;

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
        //                string filepath = "~/poweradmin/WebFiles/Facility/" + fileName;
        //                fpbannerimage.SaveAs(MapPath(filepath));

        //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Facility/"));
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
        //                       "HospitalName=@Facility, " +
        //                       "title=@Title, " +
        //                       "modified_date=@ModifiedDate, " +
        //                       "modified_ip=@ModifiedIP";

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            query += ", image=@Image";
        //        }
        //        query += " WHERE id=@ID";

        //        SqlParameter[] parameters = {
        //                            new SqlParameter("@Facility", downloadName), // Add this parameter

        //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //    new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        //    new SqlParameter("@ID", SqlDbType.Int) { Value = id }
        //};

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
        //        }

        //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

        //        string msg = "Facility updated successfully.";
        //        Response.Redirect("view_Facility.aspx?msg=" + msg);
        //    }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_Facility.aspx");
        }
    }
}
