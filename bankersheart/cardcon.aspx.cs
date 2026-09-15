using bankersheart.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class cardcon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPlayCard();
            int pageIndex = 1;
            if (!string.IsNullOrEmpty(Request.QueryString["awardsPage"]))
            {
                int.TryParse(Request.QueryString["awardsPage"], out pageIndex);
            }
            BindAwards(pageIndex);
        }
        private void BindPlayCard()
        {
            string query = "SELECT [id], [title], [image], [description] " +
                        "FROM [bankers_usr].[PlayCard]";

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            PlayCard.DataSource = dt;
            PlayCard.DataBind();

        }
        private void BindAwards(int pageIndex)
        {
            int pageSize = 12; // Display only 3 records per page
            int startRow = (pageIndex - 1) * pageSize;

            string query = $@"
    WITH PlayCard_Images_CTE AS
    (
        SELECT [id], [image], 
               ROW_NUMBER() OVER (ORDER BY id DESC) AS RowNum
        FROM [bankers_usr].[PlayCard_Images]
    )
    SELECT * FROM PlayCard_Images_CTE 
    WHERE RowNum BETWEEN {startRow + 1} AND {startRow + pageSize}";

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            rptAwards.DataSource = dt;
            rptAwards.DataBind();

            // Fetch total record count
            string countQuery = "SELECT COUNT(*) FROM [bankers_usr].[PlayCard_Images]";
            int totalRecords = Convert.ToInt32(new DAL().ExecuteScalar(countQuery, CommandType.Text, null));
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Generate pagination controls
            GenerateAwardsPaginationControls(pageIndex, totalPages);
        }
        private void GenerateAwardsPaginationControls(int currentPage, int totalPages)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='col-12 carousal-arrow'>");

            // Previous Button
            if (currentPage > 1)
            {
                sb.Append($"<a href='?awardsPage={currentPage - 1}'><i class='fa fa-long-arrow-left'></i></a>");
            }
            else
            {
                sb.Append("<a href='javascript:void(0)'><i class='fa fa-long-arrow-left text-muted'></i></a>");
            }

            // Page Numbers (1, 2, 3, etc.)
            for (int i = 1; i <= totalPages; i++)
            {
                if (i == currentPage)
                    sb.Append($"<a href='javascript:void(0)' class='px-3 active'>{i}</a>");
                else
                    sb.Append($"<a href='?awardsPage={i}' class='px-3'>{i}</a>");
            }

            // Next Button
            if (currentPage < totalPages)
            {
                sb.Append($"<a href='?awardsPage={currentPage + 1}'><i class='fa fa-long-arrow-right'></i></a>");
            }
            else
            {
                sb.Append("<a href='javascript:void(0)'><i class='fa fa-long-arrow-right text-muted'></i></a>");
            }

            sb.Append("</div>");

            PaginationAwardsPlaceholder.Controls.Clear();
            PaginationAwardsPlaceholder.Controls.Add(new Literal { Text = sb.ToString() });
        }
    }
}