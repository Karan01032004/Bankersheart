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
    public partial class cme_journal_club : System.Web.UI.Page
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

                // Case-sensitive query string check
                if (!string.IsNullOrEmpty(Request.QueryString["JournalClubPage"]))
                {
                    int.TryParse(Request.QueryString["JournalClubPage"], out pageIndex);
                }

                BindAwards(pageIndex);

                // --- Canonical Link ---
                canonicalLink.Attributes["rel"] = "canonical";
                canonicalLink.Attributes["href"] = "https://www.bankersheart.com/cme-journal-club"; // base URL only

                // --- SEO Meta Tags ---
                string baseTitle = "Journal Club Awards";
                string baseKeywords = "awards, journal club, research, publications";
                string baseDescription = "Explore the latest updates and recognitions from our Journal Club.";

                string pageSuffix = pageIndex > 1 ? " - Page " + pageIndex : "";

                // Set Page Title
                Page.Title = baseTitle + pageSuffix;

                // ✅ Set H1 dynamically
                pageH1.InnerText = pageIndex > 1 ? $"CMEE - Page {pageIndex}" : "CMEE";

                // Set Meta Keywords
                HtmlMeta metaKeywords = new HtmlMeta();
                metaKeywords.Name = "keywords";
                metaKeywords.Content = baseKeywords;
                Page.Header.Controls.Add(metaKeywords);

                // Set Meta Description
                HtmlMeta metaDescription = new HtmlMeta();
                metaDescription.Name = "description";
                metaDescription.Content = pageIndex > 1 ? baseDescription + pageSuffix : baseDescription;
                Page.Header.Controls.Add(metaDescription);
            }
        }


        private void BindAwards(int pageIndex)
        {
            int pageSize = 9; // Number of records per page
            int startRow = (pageIndex - 1) * pageSize;

            string query = $@"
    WITH JournalClubDetial_CTE AS
    (
        SELECT  [id], [title], [Speaker], [YoutubeLink], [Journal_Date], [image] , 
               ROW_NUMBER() OVER (ORDER BY Journal_Date DESC) AS RowNum
        FROM [bankers_usr].[JournalClubDetial]
    )
    SELECT * FROM JournalClubDetial_CTE 
    WHERE RowNum BETWEEN {startRow + 1} AND {startRow + pageSize}";

            DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
            rptJournalClub.DataSource = dt;
            rptJournalClub.DataBind();

            // Fetch total record count
            string countQuery = "SELECT COUNT(*) FROM [bankers_usr].[JournalClubDetial]";
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
                sb.Append($"<a href='?journalclubpage={currentPage - 1}'><i class='fa fa-long-arrow-left'></i></a>");
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
                    sb.Append($"<a href='?journalclubpage={i}' class='px-3'>{i}</a>");
            }

            // Next Button
            if (currentPage < totalPages)
            {
                sb.Append($"<a href='?journalclubpage={currentPage + 1}'><i class='fa fa-long-arrow-right'></i></a>");
            }
            else
            {
                sb.Append("<a href='javascript:void(0)'><i class='fa fa-long-arrow-right text-muted'></i></a>");
            }

            sb.Append("</div>");

            PaginationJournalClubPlaceholder.Controls.Clear();
            PaginationJournalClubPlaceholder.Controls.Add(new Literal { Text = sb.ToString() });
        }

        //private void BindAwards()
        //{
        //    string query = @"SELECT  id, title, Speaker, YoutubeLink, Journal_Date, image 
        //                     FROM [bankers_usr].[JournalClubDetial] 
        //                     ORDER BY Journal_Date DESC";

        //    DataTable dt = new DAL().GetDataTable(query, CommandType.Text, null);
        //    rptJournalClub.DataSource = dt;
        //    rptJournalClub.DataBind();

        //}
    }
}