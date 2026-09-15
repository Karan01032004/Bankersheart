using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using bankersheart.App_Code;
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

namespace bankersheart.Poweradmin.Banner
{
    public partial class manage_banner : System.Web.UI.Page
    {
        string TableName = "[bankers_usr].[banner]";
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
                txt_description.Text = dt.Rows[0]["description"].ToString();


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

                //if (dt.Rows[0]["banner_type"].ToString() == "True")
                //{
                //    chk_type.Checked = true;
                //}
                //if (dt.Rows[0]["banner_image"].ToString() != "")
                //{
                //    img_banner.ImageUrl = ConfigurationManager.AppSettings["siteurl"].ToString() + "poweradmin/WebFiles/Banner/" + dt.Rows[0]["banner_image"].ToString();
                //}
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int sortorder = 1;
            string strQuery = "update " + TableName + " set sortorder = sortorder + 1";
            new DAL().ExecuteNonQuery(strQuery, CommandType.Text, null);

            string query = @"insert into banner (visible,title,description,sortorder,added_date,added_ip) 
                    values (" + rbl_visible.SelectedValue + ",'" + txt_Title.Text.Replace("'", "''") + "','" + txt_description.Text.Replace("'", "''") + "','" + sortorder + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "','" + DAL.getIP() + "')";

            int a = new DAL().ExecuteNonQuery(query, CommandType.Text, null);
            string msg = "Banner added successfully";
            Response.Redirect("view-banner.aspx?msg=" + msg);
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            string query = @"update [bankers_usr].[banner] set visible=" + rbl_visible.SelectedValue + ",title='" + txt_Title.Text.Replace("'", "''") + "'," +
                            "description='" + txt_description.Text.Replace("'", "''") + "'," +
                            "modified_date='" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                            "modified_ip='" + DAL.getIP() + "' where id='" + id + "'";

            int a = new DAL().ExecuteNonQuery(query, CommandType.Text, null);
            string msg = "Banner updated successfully";
            Response.Redirect("view-banner.aspx?msg=" + msg);
        }

        //protected void btn_submit_Click(object sender, EventArgs e)
        //{
        //    int flag = 0;
        //    if (fpbannerimage.HasFile)
        //    {
        //        double filesize = fpbannerimage.PostedFile.ContentLength;
        //        if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["BannerSize"].ToString())))
        //        {
        //            ltr_Error.Text = "Image size have exceeded the maximum size limit. Please upload image below " + ConfigurationManager.AppSettings["BannerSize"].ToString() + " MB size.";
        //            div_Error.Visible = true;

        //            return;
        //        }

        //        Bitmap uploadedImage = new Bitmap(fpbannerimage.FileContent);
        //        if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["BannerHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["BannerWidth"].ToString()))
        //        {

        //        }
        //        else
        //        {
        //            ltr_Error.Text = "Image resolution does not match. Please upload image with width: " + ConfigurationManager.AppSettings["BannerWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["BannerHeight"] + "px.";
        //            div_Error.Visible = true;

        //            return;
        //        }

        //        string fileName = fpbannerimage.FileName;
        //        string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

        //        if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
        //        {
        //            string filepath = "~/poweradmin/WebFiles/Banner/" + fileName;
        //            fpbannerimage.SaveAs(MapPath(filepath));

        //            string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Banner/"));
        //            string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
        //            string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

        //            string webpimagesPath2 = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Banner/"));
        //            string webPImagePath2 = Path.Combine(webpimagesPath2, webPFileName);

        //            using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
        //            {
        //                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
        //                {
        //                    imageFactory.Load(uploadedImage)
        //                                .Format(new WebPFormat())
        //                                .Quality(80)
        //                                .Save(webPFileStream);
        //                }
        //            }
        //            File.Move(webPImagePath, webPImagePath2);
        //        }
        //        else
        //        {
        //            flag = 1;
        //            ltr_Error.Text = "Upload Only png, jpg or jpeg File.";
        //            div_Error.Visible = true;
        //            return;
        //        }

        //        //bool mobilebanner = false;
        //        //if (chk_type.Checked == true)
        //        //{
        //        //    mobilebanner = true;
        //        //}
        //        int sortorder = 1;
        //        string strQuery = "update " + TableName + " set sortorder = sortorder + 1";
        //        new DAL().ExecuteNonQuery(strQuery, CommandType.Text, null);

        //        string query = @"insert into banner (visible,title,description,banner_image,sortorder,added_date,added_ip) 
        //                        values (" + rbl_visible.SelectedValue + ",'" + txt_Title.Text.Replace("'", "''") + "','" + txt_description.Text.Replace("'", "''") + "','" + fileName + "','" + sortorder + "','" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "','" +    DAL.getIP() + "')";

        //        int a = new DAL().ExecuteNonQuery(query, CommandType.Text, null);
        //        string msg = "Banner added successfully";
        //        Response.Redirect("view-banner.aspx?msg=" + msg);
        //    }
        //}

        //protected void btn_Update_Click(object sender, EventArgs e)
        //{
        //    int flag = 0; string fileName = "";
        //    if (fpbannerimage.HasFile)
        //    {
        //        double filesize = fpbannerimage.PostedFile.ContentLength;
        //        if (filesize > (5242880 * int.Parse(ConfigurationManager.AppSettings["BannerSize"].ToString())))
        //        {
        //            ltr_Error.Text = "Image size have exceeded the maximum size limit. Please upload image below " + ConfigurationManager.AppSettings["BannerSize"].ToString() + " MB size.";
        //            div_Error.Visible = true;

        //            return;
        //        }

        //        Bitmap uploadedImage = new Bitmap(fpbannerimage.FileContent);

        //        //if (chk_type.Checked)
        //        //{
        //        //    if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["MobileBannerHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["MobileBannerWidth"].ToString()))
        //        //    {

        //        //    }
        //        //    else
        //        //    {
        //        //        ltr_Error.Text = "Image resolution does not match. Please upload image with width: " + ConfigurationManager.AppSettings["MobileBannerWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["MobileBannerHeight"] + "px.";
        //        //        div_Error.Visible = true;

        //        //        return;
        //        //    }
        //        //}
        //      //  else
        //       // {
        //            if (uploadedImage.Height == Convert.ToInt32(ConfigurationManager.AppSettings["BannerHeight"].ToString()) && uploadedImage.Width == Convert.ToInt32(ConfigurationManager.AppSettings["BannerWidth"].ToString()))
        //            {

        //            }
        //            else
        //            {
        //                ltr_Error.Text = "Image resolution does not match. Please upload image with width: " + ConfigurationManager.AppSettings["BannerWidth"].ToString() + "px and Height: " + ConfigurationManager.AppSettings["BannerHeight"] + "px.";
        //                div_Error.Visible = true;

        //                return;
        //            }
        //      //  }

        //        fileName = fpbannerimage.FileName;
        //        string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

        //        if (FileExtension == "png" || FileExtension == "jpg" || FileExtension == "jpeg")
        //        {
        //            string filepath = "~/poweradmin/WebFiles/Banner/" + fileName;
        //            fpbannerimage.SaveAs(MapPath(filepath));

        //            string webpimagesPath = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Banner/"));
        //            string webPFileName = Path.GetFileNameWithoutExtension(fileName.Split('.')[0].ToString()) + ".webp";
        //            string webPImagePath = Path.Combine(webpimagesPath, webPFileName);

        //            string webpimagesPath2 = Path.Combine(Server.MapPath("~/poweradmin/WebFiles/Banner/"));
        //            string webPImagePath2 = Path.Combine(webpimagesPath2, webPFileName);

        //            using (var webPFileStream = new FileStream(webPImagePath, FileMode.Create))
        //            {
        //                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
        //                {
        //                    imageFactory.Load(uploadedImage)
        //                                .Format(new WebPFormat())
        //                                .Quality(80)
        //                                .Save(webPFileStream);
        //                }
        //            }
        //            File.Move(webPImagePath, webPImagePath2);
        //        }
        //        else
        //        {
        //            flag = 1;
        //            ltr_Error.Text = "Upload Only png, jpg or jpeg File.";
        //            div_Error.Visible = true;
        //            return;
        //        }
        //    }
        //    string id = Request.QueryString["id"].ToString();

        //    //bool mobilebanner = false;
        //    //if (chk_type.Checked == true)
        //    //{
        //    //    mobilebanner = true;
        //    //}
        //    string query = @"update banner set visible=" + rbl_visible.SelectedValue + ",title='" + txt_Title.Text.Replace("'", "''") + "'," +
        //                    "description='" + txt_description.Text.Replace("'", "''") + "'," +
        //                    "modified_date='" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "'," +
        //                    "modified_ip='" + DAL.getIP() + "'"; // Removed the banner_type part

        //    if (fileName!="")
        //    {
        //        query += " ,banner_image='" + fileName + "'";
        //    }
        //    query += " where id='" + id + "'";

        //    int a = new DAL().ExecuteNonQuery(query, CommandType.Text, null);
        //    string msg = "Banner updated successfully";
        //    Response.Redirect("view-banner.aspx?msg=" + msg);
        //}

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("view-banner.aspx");
        }
    }
}