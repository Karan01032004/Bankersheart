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
namespace bankersheart.Poweradmin.Doctors_Details
{
    public partial class Manage_DoctorsDetails : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[DoctorDetails]";

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
                txt_Title.Text = dt.Rows[0]["Name"].ToString();
                txt_Summary.Text = dt.Rows[0]["profession"].ToString();
                txt_specialties.Text = dt.Rows[0]["specialties"].ToString();
                txt_description.Text = dt.Rows[0]["description"].ToString();


                if (!string.IsNullOrEmpty(dt.Rows[0]["hospitals"].ToString()))
                {
                    string[] selectedHospitals = dt.Rows[0]["hospitals"].ToString().Split(';')
                                                        .Select(h => h.Trim()) 
                                                        .ToArray();

                    foreach (ListItem item in chkHospitals.Items)
                    {
                        if (selectedHospitals.Contains(item.Value.Trim()))
                        {
                            item.Selected = true;
                        }
                    }
                }




                // Display current banner image
                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/DoctorDetails/" + dt.Rows[0]["image"].ToString();
                }
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();

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
            //        string filepath = "~/poweradmin/WebFiles/DoctorDetails/" + fileName;
            //        uploadedFile.SaveAs(MapPath(filepath));
            //        uploadedFileNames.Add(fileName);

            //        // Convert to WebP format
            //        string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/DoctorDetails/"));
            //        string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
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
                    string folderPath = Server.MapPath("~/poweradmin/WebFiles/DoctorDetails/");
                    string originalFilePath = Path.Combine(folderPath, fileName);

                    // 1. Original file save karo
                    uploadedFile.SaveAs(originalFilePath);
                    uploadedFileNames.Add(fileName);

                    // 2. WebP destination path
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                    string webPImagePath = Path.Combine(folderPath, webPFileName);

                    // 3. Magick.NET se WebP convert karo
                    using (var image = new MagickImage(originalFilePath))
                    {
                        image.Format = MagickFormat.WebP;
                        image.Quality = 80;
                        image.Strip(); // EXIF metadata hatane ke liye
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
            string selectedHospitals = string.Join(";", chkHospitals.Items.Cast<ListItem>()
                                  .Where(i => i.Selected)
                                  .Select(i => i.Value));

            if (string.IsNullOrEmpty(selectedHospitals))
            {
                ltr_Error.Text = "Please select at least one hospital.";
                div_Error.Visible = true;
                return;
            }

            // Insert new record using parameterized query
            foreach (string fileName in uploadedFileNames)
            {
                string query = @"INSERT INTO " + TableName + " (Name,profession,hospitals,specialties, description, image,  added_date, added_ip)  VALUES(@Title, @Summary,@Hospitals, @specialties, @Description, @Image, @AddedDate, @AddedIP)";
        
        SqlParameter[] parameters = {
            new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
            new SqlParameter("@Summary", SqlDbType.NVarChar) { Value = txt_Summary.Text.Replace("'", "''") },
                        new SqlParameter("@Hospitals", SqlDbType.NVarChar) { Value = selectedHospitals },

            new SqlParameter("@specialties", SqlDbType.NVarChar) { Value = txt_specialties.Text.Replace("'", "''") },
            new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
            new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        };

                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
            }

            string msg = "Doctors Details added successfully.";
            Response.Redirect("view_DoctorsDetails.aspx?msg=" + msg);
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
        //                string filepath = "~/poweradmin/WebFiles/DoctorDetails/" + fileName;
        //                uploadedFile.SaveAs(MapPath(filepath));
        //                uploadedFileNames.Add(fileName);

        //                // Convert to WebP format
        //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/DoctorDetails/"));
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
        //        string query = @"INSERT INTO " + TableName + " (Name,profession,specialties, description, image,  added_date, added_ip)  VALUES(@Title,@Summary,@specialties,@Description, @Image,  @AddedDate, @AddedIP)";


        //        SqlParameter[] parameters = {
        //    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        //    new SqlParameter("@Summary", SqlDbType.NVarChar) { Value = txt_Summary.Text.Replace("'", "''") },
        //    new SqlParameter("@specialties", SqlDbType.NVarChar) { Value = txt_specialties.Text.Replace("'", "''") },
        //                  new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },

        //            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
        //    new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        //};

        //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
        //    }

        //    string msg = "Doctors Details added successfully.";
        //    Response.Redirect("view_DoctorsDetails.aspx?msg=" + msg);
        //}

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string fileName = "";

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
            //        string filepath = "~/poweradmin/WebFiles/DoctorDetails/" + fileName;
            //        fpbannerimage.SaveAs(MapPath(filepath));

            //        string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/DoctorDetails/"));
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
                    string folderPath = Server.MapPath("~/poweradmin/WebFiles/DoctorDetails/");
                    string originalFilePath = Path.Combine(folderPath, fileName);

                    // 1. Original image save karo
                    fpbannerimage.SaveAs(originalFilePath);

                    // 2. WebP file path banao
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
            List<string> selectedHospitals = new List<string>();
            foreach (ListItem item in chkHospitals.Items)
            {
                if (item.Selected)
                {
                    selectedHospitals.Add(item.Value);
                }
            }
            string hospitalNames = string.Join(";", selectedHospitals);

            string query = @"UPDATE " + TableName + " SET " +
                           "Name=@Title, " +
                           "profession=@Summary, " +
                           "specialties=@specialties, " +
                            "hospitals = @HospitalName," + // Add hospital_name field
                           "description = @Description," +
                           "modified_date=@ModifiedDate, " +
                           "modified_ip=@ModifiedIP";

            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", image=@Image";
            }
            query += " WHERE id=@ID";

            SqlParameter[] parameters = {
        new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        new SqlParameter("@Summary", SqlDbType.NVarChar) { Value = txt_Summary.Text.Replace("'", "''") },
      
                new SqlParameter("@specialties", SqlDbType.NVarChar) { Value = txt_specialties.Text.Replace("'", "''") },
               new SqlParameter("@HospitalName", SqlDbType.NVarChar) { Value = hospitalNames }, // Pass selected hospitals

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

            string msg = "Doctors Details updated successfully.";
            Response.Redirect("view_DoctorsDetails.aspx?msg=" + msg);
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
        //                string filepath = "~/poweradmin/WebFiles/DoctorDetails/" + fileName;
        //                fpbannerimage.SaveAs(MapPath(filepath));

        //                string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/DoctorDetails/"));
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
        //                       "Name=@Title, " +
        //                       "profession=@Summary, " +
        //                       "specialties=@specialties, " +
        //                       "description = @Description,"+

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
        //    new SqlParameter("@specialties", SqlDbType.NVarChar) { Value = txt_specialties.Text.Replace("'", "''") },
        //                    new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },

        //    new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        //    new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        //    new SqlParameter("@ID", SqlDbType.Int) { Value = id }
        //};

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
        //        }

        //        new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

        //        string msg = "Doctors Details updated successfully.";
        //        Response.Redirect("view_DoctorsDetails.aspx?msg=" + msg);
        //    }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_DoctorsDetails.aspx");
        }
    }
}
