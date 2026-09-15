using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class csr_activity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int pageIndex = 1;
                if (!string.IsNullOrEmpty(Request.QueryString["csrpage"]))
                {
                    int.TryParse(Request.QueryString["csrpage"], out pageIndex);
                }

                string metaDescription = "";

                // Title + H1 + Meta description handling
                if (pageIndex > 1)
                {
                    Page.Title = "CSR Activity - Page " + pageIndex + " | Bankers Group of Hospitals";
                    pageH1.InnerText = "CSR Activity - Page " + pageIndex;

                    metaDescription = "Explore CSR Activities - Page " + pageIndex +
                                      " by Bankers Group of Hospitals. Learn about our social responsibility and community initiatives.";
                }
                else
                {
                    Page.Title = "CSR Activity | Bankers Group of Hospitals";
                    pageH1.InnerText = "CSR Activities";

                    metaDescription = "Discover CSR Activities by Bankers Group of Hospitals. Learn about our community-driven initiatives and social responsibility efforts.";
                }

                // Add or update meta description
                HtmlMeta meta = new HtmlMeta();
                meta.Name = "description";
                meta.Content = metaDescription;
                Page.Header.Controls.Add(meta);

                BindAwards(pageIndex);

                // Update canonical link
                canonicalLink.Attributes["rel"] = "canonical";
                canonicalLink.Attributes["href"] = Request.Url.AbsoluteUri;
            }
        }

        private void BindAwards(int pageIndex)
        {
            int pageSize = 9; // Number of records per page
            int startRow = (pageIndex - 1) * pageSize;

            string query = $@"
    WITH CSR_Activity_CTE AS
    (
        SELECT [id], [title],  [titlelink], [image], [shortdescription], [CSR_Activity_Date], 
               ROW_NUMBER() OVER (ORDER BY CSR_Activity_Date DESC) AS RowNum
        FROM [bankers_usr].[CSR_Activity]
    )
    SELECT * FROM CSR_Activity_CTE 
    WHERE RowNum BETWEEN {startRow + 1} AND {startRow + pageSize}";

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            rpt_CSR_Activity.DataSource = dt;
            rpt_CSR_Activity.DataBind();

            // Fetch total record count
            string countQuery = "SELECT COUNT(*) FROM [bankers_usr].[CSR_Activity]";
            int totalRecords = Convert.ToInt32(new DAL().ExecuteScalar(countQuery, CommandType.Text, null));
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Generate pagination controls
            GenerateCSRActivityPaginationControls(pageIndex, totalPages);
        }
        private void GenerateCSRActivityPaginationControls(int currentPage, int totalPages)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='col-12 carousal-arrow'>");

            // Previous Button
            if (currentPage > 1)
            {
                sb.Append($"<a href='?csrpage={currentPage - 1}'><i class='fa fa-long-arrow-left'></i></a>");
            }
            else
            {
                sb.Append("<a href='javascript:void(0)'><i class='fa fa-long-arrow-left text-muted'></i></a>");
            }

            // Page Numbers
            for (int i = 1; i <= totalPages; i++)
            {
                if (i == currentPage)
                    sb.Append($"<a href='javascript:void(0)' class='px-3 active'>{i}</a>");
                else
                    sb.Append($"<a href='?csrpage={i}' class='px-3'>{i}</a>");
            }

            // Next Button
            if (currentPage < totalPages)
            {
                sb.Append($"<a href='?csrpage={currentPage + 1}'><i class='fa fa-long-arrow-right'></i></a>");
            }
            else
            {
                sb.Append("<a href='javascript:void(0)'><i class='fa fa-long-arrow-right text-muted'></i></a>");
            }

            sb.Append("</div>");

            PaginationCSRActivityPlaceholder.Controls.Clear();
            PaginationCSRActivityPlaceholder.Controls.Add(new Literal { Text = sb.ToString() });
        }

        //private void BindAwards()
        //{
        //    string query = "SELECT [id], [title], [image],[shortdescription], [CSR_Activity_Date] " +
        //                "FROM [bankers_usr].[CSR_Activity]";

        //    DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
        //    rpt_CSR_Activity.DataSource = dt;
        //    rpt_CSR_Activity.DataBind();

        //}
    }
}