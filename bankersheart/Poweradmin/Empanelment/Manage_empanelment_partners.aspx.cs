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

namespace bankersheart.Poweradmin.Insurance_Partners
{
    public partial class Manage_insurance_partners : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[insurance_partners]";

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
               

                //txt_CampDate.Text = Convert.ToDateTime(dt.Rows[0]["Patient_Date"]).ToString("dd-MM-yyyy");


                // Display current banner image
                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/insurance_partners/" + dt.Rows[0]["image"].ToString();
                }
            }
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
                    string filepath = "~/poweradmin/WebFiles/insurance_partners/" + fileName;
                    uploadedFile.SaveAs(MapPath(filepath));
                    uploadedFileNames.Add(fileName);
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
                string query = @"INSERT INTO " + TableName + " (title, image,  added_date, added_ip)  VALUES(@Title, @Image,  @AddedDate, @AddedIP)";

                SqlParameter[] parameters = {
            new SqlParameter("@Title", SqlDbType.NVarChar) { Value = txt_Title.Text.Replace("'", "''") },
            new SqlParameter("@Image", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName },
     
            new SqlParameter("@AddedDate", SqlDbType.DateTime) { Value = DateTime.Now },
            new SqlParameter("@AddedIP", SqlDbType.NVarChar) { Value = DAL.getIP() }
        };

                new DAL().ExecuteNonQuery(query, CommandType.Text, parameters);
            }

            string msg = "Insurance Partners added successfully.";
            Response.Redirect("View_empanelment_partners.aspx?msg=" + msg);
        }

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
                    string filepath = "~/poweradmin/WebFiles/insurance_partners/" + fileName;
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
                          
                           "modified_date=@ModifiedDate, " +
                           "modified_ip=@ModifiedIP";

            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", image=@Image";
            }
            query += " WHERE id=@ID";

            SqlParameter[] parameters = {
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

            string msg = "Insurance Partners updated successfully.";
            Response.Redirect("View_empanelment_partners.aspx?msg=" + msg);
        }

     

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_empanelment_partners.aspx");
        }
    }
}
