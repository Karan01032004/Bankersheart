using bankersheart.App_Code;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart.Poweradmin.Awards_Achivement
{
    public partial class Manage_Awards_Achivement : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[Awards_Achivement]";
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
            DataTable dt = new DAL().GetDataTable("select * from " + TableName + " where id='" + id + "' order by sortorder asc", CommandType.Text, null);

            if (dt.Rows.Count > 0)
            {
                txt_Title.Text = dt.Rows[0]["title"].ToString();

                string visibleValue = dt.Rows[0]["visible"].ToString().Trim().ToLower();

                // Ensure the correct radio button is selected based on the database value
                if (visibleValue == "true" || visibleValue == "1")
                {
                    rbl_visible.SelectedValue = "1"; // Select 'Yes'
                }
                else
                {
                    rbl_visible.SelectedValue = "0"; // Select 'No'
                }

                // Display current banner images (if any)
                if (dt.Rows[0]["banner_image"].ToString() != "")
                {
                    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/Awards_Achivement/" + dt.Rows[0]["banner_image"].ToString();
                }
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            List<string> uploadedFileNames = new List<string>();

            foreach (HttpPostedFile uploadedFile in fpbannerimage.PostedFiles)
            {
                string fileName = Path.GetFileName(uploadedFile.FileName);
                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                {
                    string filepath = "~/poweradmin/WebFiles/Awards_Achivement/" + fileName;
                    uploadedFile.SaveAs(MapPath(filepath));
                    uploadedFileNames.Add(fileName);

                    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Awards_Achivement/"));
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

                    using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            imageFactory.Load(uploadedFile.InputStream)
                                        .Format(new WebPFormat())
                                        .Quality(80)
                                        .Save(webPFileStream);
                        }
                    }
                }
                else
                {
                    flag = 1;
                    ltr_Error.Text = "Upload Only png, jpg or jpeg File.";
                    div_Error.Visible = true;
                    return;
                }
            }

            int sortorder = 1;
            string strQuery = "update " + TableName + " set sortorder = sortorder + 1";
            new DAL().ExecuteNonQuery(strQuery, CommandType.Text, null);

            foreach (string fileName in uploadedFileNames)
            {
                string query = @"insert into " + TableName + " (visible, title, banner_image, sortorder, added_date, added_ip) values (" +
                              (string.IsNullOrEmpty(rbl_visible.SelectedValue) ? "NULL" : rbl_visible.SelectedValue) + ", " +
                              "'" + (txt_Title.Text.Replace("'", "''")) + "', " +
                              "'" + (string.IsNullOrEmpty(fileName) ? "NULL" : fileName) + "', " +
                              "'" + sortorder + "', " +
                              "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                              "'" + DAL.getIP() + "')";

                new DAL().ExecuteNonQuery(query, CommandType.Text, null);
                sortorder++;
            }

            string msg = "Awards_Achivement added successfully";
            Response.Redirect("view_Awards_Achivement.aspx?msg=" + msg);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int flag = 0; string fileName = "";
            if (fpbannerimage.HasFile)
            {
                fileName = fpbannerimage.FileName;
                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
                {
                    string filepath = "~/poweradmin/WebFiles/Awards_Achivement/" + fileName;
                    fpbannerimage.SaveAs(MapPath(filepath));

                    string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Awards_Achivement/"));
                    string webPFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
                    string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

                    using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            imageFactory.Load(fpbannerimage.FileContent)
                                        .Format(new WebPFormat())
                                        .Quality(80)
                                        .Save(webPFileStream);
                        }
                    }
                }
                else
                {
                    flag = 1;
                    ltr_Error.Text = "Upload Only png, jpg or jpeg File.";
                    div_Error.Visible = true;
                    return;
                }
            }
            string id = Request.QueryString["id"].ToString();

            string query = @"UPDATE [bankers_usr].[Awards_Achivement] SET visible=" + rbl_visible.SelectedValue + ", " +
                "title='" + txt_Title.Text.Replace("'", "''") + "', " +
                "modified_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                "modified_ip='" + DAL.getIP() + "'";

            if (fileName != "")
            {
                query += " ,banner_image='" + fileName + "'";
            }
            query += " where id='" + id + "'";

            int a = new DAL().ExecuteNonQuery(query, CommandType.Text, null);
            string msg = "Awards_Achivement updated successfully";
            Response.Redirect("view_Awards_Achivement.aspx?msg=" + msg);
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_Awards_Achivement.aspx");
        }
    }
}
