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
    public partial class interesting_cases : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        BindAwards();
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int pageIndex = 1;
                if (!string.IsNullOrEmpty(Request.QueryString["interesting_casesPage"]))
                {
                    int.TryParse(Request.QueryString["interesting_casesPage"], out pageIndex);
                }

                BindAwards(pageIndex);
            }
        }
        private void BindAwards(int pageIndex)
        {
            int pageSize = 9; // Number of records per page
            int startRow = (pageIndex - 1) * pageSize;

            string query = $@"
    WITH InterestingCases_CTE AS
    (
        SELECT [id], [title],[titlelink], [image], [shortdescription], [InterestingCases_Date], 
               ROW_NUMBER() OVER (ORDER BY InterestingCases_Date DESC) AS RowNum
        FROM [bankers_usr].[InterestingCases]
    )
    SELECT * FROM InterestingCases_CTE 
    WHERE RowNum BETWEEN {startRow + 1} AND {startRow + pageSize}";

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            rpt_Exhibitions.DataSource = dt;
            rpt_Exhibitions.DataBind();

            // Fetch total record count
            string countQuery = "SELECT COUNT(*) FROM [bankers_usr].[InterestingCases]";
            int totalRecords = Convert.ToInt32(new DAL().ExecuteScalar(countQuery, CommandType.Text, null));
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Generate pagination controls
            Generateinteresting_casesPaginationControls(pageIndex, totalPages);
        }
        private void Generateinteresting_casesPaginationControls(int currentPage, int totalPages)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='col-12 carousal-arrow'>");

            // Previous Button
            if (currentPage > 1)
            {
                sb.Append($"<a href='?interesting_casesPage={currentPage - 1}'><i class='fa fa-long-arrow-left'></i></a>");
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
                    sb.Append($"<a href='?interesting_casesPage={i}' class='px-3'>{i}</a>");
            }

            // Next Button
            if (currentPage < totalPages)
            {
                sb.Append($"<a href='?interesting_casesPage={currentPage + 1}'><i class='fa fa-long-arrow-right'></i></a>");
            }
            else
            {
                sb.Append("<a href='javascript:void(0)'><i class='fa fa-long-arrow-right text-muted'></i></a>");
            }

            sb.Append("</div>");

            Paginationinteresting_casesPlaceholder.Controls.Clear();
            Paginationinteresting_casesPlaceholder.Controls.Add(new Literal { Text = sb.ToString() });
        }

        //private void BindAwards()
        //{
        //    string query = "SELECT [id], [title], [image],[shortdescription], [InterestingCases_Date] " +
        //                "FROM [bankers_usr].[InterestingCases]";

        //    DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
        //    rpt_Exhibitions.DataSource = dt;
        //    rpt_Exhibitions.DataBind();

        //}
    }
}