using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using ImageProcessor;
using System.Drawing;
using System.IO;

namespace bankersheart.Poweradmin.Education
{
    public partial class Manage_JournalClubDetial : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[JournalClubDetial]";

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
                txt_speaker.Text = dt.Rows[0]["Speaker"].ToString();
                txt_YouTubeURL.Text = dt.Rows[0]["YoutubeLink"].ToString();
                ddl_Category.SelectedValue = dt.Rows[0]["Type"].ToString();
                txt_CampDate.Text = Convert.ToDateTime(dt.Rows[0]["Journal_Date"]).ToString("dd-MM-yyyy");

                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/JournalClubDetial/" + dt.Rows[0]["image"].ToString();
                }
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string youtubeURL = txt_YouTubeURL.Text.Trim();

            if (string.IsNullOrEmpty(youtubeURL))
            {
                ltr_Error.Text = "Please enter a valid YouTube URL.";
                div_Error.Visible = true;
                return;
            }
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
                    string filepath = "~/poweradmin/WebFiles/JournalClubDetial/" + fileName;
                    uploadedFile.SaveAs(MapPath(filepath));
                    uploadedFileNames.Add(fileName);

                    // Convert to WebP format
                    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/JournalClubDetial/"));
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
                    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

                    using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            imageFactory.Load(uploadedFile.InputStream)
                                        .Format(new WebPFormat())
                                        .Quality(100)
                                        .Save(webPFileStream);
                        }
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

            // Insert new record using parameterized query
            foreach (string fileName in uploadedFileNames)
            {
                // Insert new record using parameterized query
                string query = @"INSERT INTO " + TableName + " (title,image, Speaker, YoutubeLink, Type, Journal_Date, added_date, added_ip) VALUES(@Title,@Image, @Speaker, @YouTubeURL, @Type, @Journal_Date, @AddedDate, @AddedIP)";

                SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
                    new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
                    new SqlParameter("@Speaker", SqlDbType.NVarChar) { Value = txt_speaker.Text.Replace("'", "''") },
                    new SqlParameter("@YouTubeURL", SqlDbType.NVarChar) { Value = youtubeURL },
                    new SqlParameter("@Type", SqlDbType.NVarChar) { Value = ddl_Category.SelectedValue },
                    new SqlParameter("@Journal_Date", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },
                    new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
                    new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
                };

                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
            }
            string msg = "Journal Club Detial added successfully.";
            Response.Redirect("View_JournalClubDetial.aspx?msg=" + msg);
        }

        //        protected void btn_submit_Click(object sender, EventArgs e)
        //        {
        //            int flag = 0;
        //            string youtubeURL = txt_YouTubeURL.Text.Trim();

        //            if (string.IsNullOrEmpty(youtubeURL))
        //            {
        //                ltr_Error.Text = "Please enter a valid YouTube URL.";
        //                div_Error.Visible = true;
        //                return;
        //            }
        //            List<string> uploadedFileNames = new List<string>();

        //            foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
        //            {
        //                double filesize = uploadedFile.ContentLength;
        //                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
        //                {
        //                    ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
        //                    div_Error.Visible = true;
        //                    return;
        //                }

        //                Bitmap uploadedImage = new Bitmap(uploadedFile.InputStream);
        //                if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampWidth"].ToString()))
        //                {
        //                    string fileName = Path.GetFileName(uploadedFile.FileName);
        //                    string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

        //                    if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
        //                    {
        //                        string filepath = "~/poweradmin/WebFiles/JournalClubDetial/" + fileName;
        //                        uploadedFile.SaveAs(MapPath(filepath));
        //                        uploadedFileNames.Add(fileName);

        //                        // Convert to WebP format
        //                        string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/JournalClubDetial/"));
        //                        string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
        //                        string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

        //                        using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
        //                        {
        //                            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
        //                            {
        //                                imageFactory.Load(uploadedImage)
        //                                            .Format(new WebPFormat())
        //                                            .Quality(80)
        //                                            .Save(webPFileStream);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        flag = 1;
        //                        ltr_Error.Text = "Upload Only png, jpg or jpeg files.";
        //                        div_Error.Visible = true;
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    ltr_Error.Text = "Image resolution does not match. Please upload an image with width: " + ConfigurationManager.AppSettings["MedicalCampWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MedicalCampHeight"] + "px.";
        //                    div_Error.Visible = true;
        //                    return;
        //                }
        //            }

        //            // Insert new record using parameterized query
        //            foreach (string fileName in uploadedFileNames)
        //            {
        //                // Insert new record using parameterized query
        //                string query = @"INSERT INTO " + TableName + " (title,image, Speaker, YoutubeLink, Type, Journal_Date, added_date, added_ip) VALUES(@Title,@Image, @Speaker, @YouTubeURL, @Type, @Journal_Date, @AddedDate, @AddedIP)";

        //                SqlParameter[] parameters = {
        //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //                new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },

        //    new SqlParameter("@Speaker", SqlDbType.NVarChar) { Value = txt_speaker.Text.Replace("'", "''") },
        //    new SqlParameter("@YouTubeURL", SqlDbType.NVarChar) { Value = youtubeURL },
        //    new SqlParameter("@Type", SqlDbType.NVarChar) { Value = ddl_Category.SelectedValue },
        //    new SqlParameter("@Journal_Date", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },
        //    new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        //};


        //                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
        //            }
        //            string msg = "Journal Club Detial added successfully.";
        //            Response.Redirect("View_JournalClubDetial.aspx?msg=" + msg);
        //        }
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
            string youtubeURL = txt_YouTubeURL.Text.Trim();

            if (string.IsNullOrEmpty(youtubeURL))
            {
                ltr_Error.Text = "Please enter a valid YouTube URL.";
                div_Error.Visible = true;
                return;
            }
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
                    string filepath = "~/poweradmin/WebFiles/JournalClubDetial/" + fileName;
                    fpbannerimage.SaveAs(MapPath(filepath));
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
                           "Speaker=@Speaker," +
                           "YoutubeLink=@YouTubeURL, " +
                           "Type=@Type, " +
                           "Journal_Date=@Journal_Date, " +
                           "modified_date=@ModifiedDate, " +
                           "modified_ip=@ModifiedIP ";
            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", image=@Image";
            }
            query += " WHERE id=@ID";

            SqlParameter[] parameters = {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        new SqlParameter("@Speaker", SqlDbType.NVarChar) { Value = txt_speaker.Text.Replace("'", "''") },
        new SqlParameter("@YouTubeURL", SqlDbType.NVarChar) { Value = youtubeURL },
        new SqlParameter("@Type", SqlDbType.NVarChar) { Value = ddl_Category.SelectedValue },
        new SqlParameter("@Journal_Date", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },
        new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

            if (!string.IsNullOrEmpty(fileName))
            {
                parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
            }
            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            string msg = "Journal Club Detial updated successfully.";
            Response.Redirect("View_JournalClubDetial.aspx?msg=" + msg);
        }

        //        protected void btn_Update_Click(object sender, EventArgs e)
        //        {
        //            string youtubeURL = txt_YouTubeURL.Text.Trim();

        //            if (string.IsNullOrEmpty(youtubeURL))
        //            {
        //                ltr_Error.Text = "Please enter a valid YouTube URL.";
        //                div_Error.Visible = true;
        //                return;
        //            }
        //            int flag = 0;
        //            string fileName = "";

        //            if (fpbannerimage.HasFile)
        //            {
        //                double filesize = fpbannerimage.PostedFile.ContentLength;
        //                if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString())))
        //                {
        //                    ltr_Error.Text = "Image size has exceeded the maximum size limit. Please upload an image below " + ConfigurationManager.AppSettings["MedicalCampImageSize"].ToString() + " MB.";
        //                    div_Error.Visible = true;
        //                    return;
        //                }

        //                Bitmap uploadedImage = new Bitmap(fpbannerimage.FileContent);

        //                if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MedicalCampWidth"].ToString()))
        //                {
        //                }
        //                else
        //                {
        //                    ltr_Error.Text = "Image resolution does not match. Please upload an image with width: " + ConfigurationManager.AppSettings["MedicalCampWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MedicalCampHeight"] + "px.";
        //                    div_Error.Visible = true;
        //                    return;
        //                }

        //                fileName = fpbannerimage.FileName;
        //                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

        //                if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
        //                {
        //                    string filepath = "~/poweradmin/WebFiles/JournalClubDetial/" + fileName;
        //                    fpbannerimage.SaveAs(MapPath(filepath));

        //                    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/JournalClubDetial/"));
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
        //            string id = Request.QueryString["ID"].ToString();

        //            string query = @"UPDATE " + TableName + " SET " +
        //                           "title=@Title, " +
        //                           "Speaker=@Speaker," +
        //                           "YoutubeLink=@YouTubeURL, " +
        //                           "Type=@Type, " +
        //                            "Journal_Date=@Journal_Date, " +
        //                           "modified_date=@ModifiedDate, " +
        //                           "modified_ip=@ModifiedIP ";
        //                           if (!string.IsNullOrEmpty(fileName))
        //            {
        //                query += ", image=@Image";
        //            }
        //            query += " WHERE id=@ID";

        //            SqlParameter[] parameters = {
        //                new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //              new SqlParameter("@Speaker", SqlDbType.NVarChar) { Value = txt_speaker.Text.Replace("'", "''") },

        //                new SqlParameter("@YouTubeURL", SqlDbType.NVarChar) { Value = youtubeURL },
        //                    new SqlParameter("@Type", SqlDbType.NVarChar) { Value = ddl_Category.SelectedValue },
        //new SqlParameter("@Journal_Date", SqlDbType.Date) { Value = ParseDate(txt_CampDate.Text) },

        //                new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //                new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        //                new SqlParameter("@ID", SqlDbType.Int) { Value = id }
        //            };

        //            if (!string.IsNullOrEmpty(fileName))
        //            {
        //                parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
        //            }
        //            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

        //            string msg = "Journal Club Detial updated successfully.";
        //            Response.Redirect("View_JournalClubDetial.aspx?msg=" + msg);
        //        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_JournalClubDetial.aspx");
        }
    }
}
