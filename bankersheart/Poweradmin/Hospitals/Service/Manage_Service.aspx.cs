using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bankersheart.App_Code;
using System.Linq;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using ImageProcessor;
using System.IO;

namespace bankersheart.Poweradmin.Hospitals.Service
{
    public partial class Manage_Service : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Service]";

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
                    BindServiceNames(); // Bind service names to dropdown

                    if (Request.QueryString["ID"] != null)
                    {
                        btn_Update.Visible = true;
                        btn_submit.Visible = false;
                        btn_Update.Text = "Update";

                        string id = Request.QueryString["ID"].ToString();
                        fill_data(id);
                    }
                    else
                    {
                        btn_Update.Visible = false;
                        btn_submit.Visible = true;
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

             //   txt_Title.Text = dt.Rows[0]["title"].ToString();
                txt_description.Text = dt.Rows[0]["description"].ToString();

                string hospitalNames = dt.Rows[0]["HospitalName"].ToString();
                if (!string.IsNullOrEmpty(hospitalNames))
                {
                    string[] selectedHospitals = hospitalNames.Split('|');
                    foreach (ListItem item in cbl_HospitalNames.Items)
                    {
                        if (selectedHospitals.Contains(item.Value))
                        {
                            item.Selected = true;
                        }
                    }
                }
                //// Display current banner image
                //if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                //{
                //    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/Service/" + dt.Rows[0]["image"].ToString();
                //}
                string serviceNameID = dt.Rows[0]["ServiceNameID"].ToString();
                if (!string.IsNullOrEmpty(serviceNameID))
                {
                    ddl_ServiceName.SelectedValue = serviceNameID;
                }

            }
        }
        private void BindServiceNames()
        {
            string query = "SELECT id, title FROM bankers_usr.ServiceName ORDER BY title ASC";
            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);

            if (dt.Rows.Count > 0)
            {
                ddl_ServiceName.DataSource = dt;
                ddl_ServiceName.DataTextField = "title";
                ddl_ServiceName.DataValueField = "id";
                ddl_ServiceName.DataBind();
            }

            // Add default "Select Service Name" option
            ddl_ServiceName.Items.Insert(0, new ListItem("Select Service Name", ""));
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            // Get selected hospital names as a comma-separated string
            List<string> selectedHospitals = new List<string>();
            foreach (ListItem item in cbl_HospitalNames.Items)
            {
                if (item.Selected)
                {
                    selectedHospitals.Add(item.Value);
                }
            }
            string hospitalNames = string.Join("|", selectedHospitals); // Store as "Hospital1|Hospital2"

            string serviceNameID = ddl_ServiceName.SelectedValue;  // Get ServiceName ID


            //int flag = 0;
            //List<string> uploadedFileNames = new List<string>();

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
            //        string filepath = "~/poweradmin/WebFiles/Service/" + fileName;
            //        uploadedFile.SaveAs(MapPath(filepath));
            //        uploadedFileNames.Add(fileName);

            //        // Convert to WebP format
            //        string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Service/"));
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

            //foreach (string fileName in uploadedFileNames)
            //{
                string query = @"INSERT INTO " + TableName + " (description, HospitalName, ServiceNameID,sortorder, added_date, added_ip)  VALUES(@Description, @HospitalNames,@ServiceNameID,@SortOrder, @AddedDate, @AddedIP)";

                SqlParameter[] parameters = {
              //  new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
                new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        new SqlParameter("@HospitalNames", SqlDbType.NVarChar) { Value = hospitalNames },
                    //new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName },
        new SqlParameter("@ServiceNameID", SqlDbType.NVarChar) { Value = serviceNameID },
            new SqlParameter("@SortOrder", SqlDbType.Int) { Value = 1 },  // Set SortOrder to 1

                new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
                new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
            };

                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
          //  }
                string msg = "Service added successfully.";
                Response.Redirect("view_Service.aspx?msg=" + msg);
           
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            // Collect selected hospital names
            List<string> selectedHospitals = new List<string>();
            foreach (ListItem item in cbl_HospitalNames.Items)
            {
                if (item.Selected)
                {
                    selectedHospitals.Add(item.Value);
                }
            }

            if (selectedHospitals.Count == 0)
            {
                ltr_Error.Text = "Please select at least one Hospital Name.";
                div_Error.Visible = true;
                return;
            }

            string hospitalNames = string.Join("|", selectedHospitals); // Store as "Hospital1|Hospital2"
            string serviceNameID = ddl_ServiceName.SelectedValue;

            if (string.IsNullOrEmpty(serviceNameID))
            {
                ltr_Error.Text = "Please select a Service Name.";
                div_Error.Visible = true;
                return;
            }
            string id = Request.QueryString["ID"].ToString();
            //int flag = 0;
            //string fileName = "";

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
            //        string filepath = "~/poweradmin/WebFiles/Service/" + fileName;
            //        fpbannerimage.SaveAs(MapPath(filepath));

            //        string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Service/"));
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
            string query = @"UPDATE " + TableName + " SET HospitalName = @HospitalNames,   description = @Description, ServiceNameID = @ServiceNameID, modified_date = @ModifiedDate, modified_ip = @ModifiedIP";
            //if (!string.IsNullOrEmpty(fileName))
            //{
            //    query += ", image=@Image";
            //}
            query += " WHERE id=@ID";

            SqlParameter[] parameters = {
        new SqlParameter("@HospitalNames", SqlDbType.NVarChar) { Value = hospitalNames },
        //new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
        new SqlParameter("@Description", SqlDbType.NVarChar) { Value = txt_description.Text.Replace("'", "''") },
        new SqlParameter("@ServiceNameID", SqlDbType.NVarChar) { Value = serviceNameID },

                new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@ModifiedIP", SqlDbType.NVarChar) { Value = DAL.getIP() },
        new SqlParameter("@ID", SqlDbType.Int) { Value = id }
    };

            //if (!string.IsNullOrEmpty(fileName))
            //{
            //    parameters = parameters.Append(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = fileName }).ToArray();
            //}
            new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);

            string msg = "Service updated successfully.";
            Response.Redirect("view_Service.aspx?msg=" + msg);
        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_Service.aspx");
        }
    }
}