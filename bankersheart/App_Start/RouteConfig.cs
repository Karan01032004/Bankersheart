using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace bankersheart
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.MapPageRoute(
             "event",
             "event/{titlelink}",
             "~/events-at-bankers-details.aspx"
            );

            routes.MapPageRoute(
             "lecture",
             "lecture/{titlelink}",
             "~/events-at-bankers-details.aspx"
            );

            routes.MapPageRoute(
             "rally",
             "rally/{titlelink}",
             "~/events-at-bankers-details.aspx"
            );

            routes.MapPageRoute(
             "conference",
             "conference/{titlelink}",
             "~/events-at-bankers-details.aspx"
            );

            routes.MapPageRoute(
     "newsatbankers",
     "news/{titlelink}",
     "~/news-at-bankers-details.aspx"
 );
            routes.MapPageRoute(
   "medical-camp",
   "csr/medical-camp/{titlelink}",
   "~/medical-camp-details.aspx"
);
            routes.MapPageRoute(
      "csr-activity",
      "csr/csr-activity/{titlelink}",
      "~/csr-activity-details.aspx"
  );
            routes.MapPageRoute(
     "interesting-cases",
     "education/interesting-cases/{titlelink}",
     "~/interesting-case-details.aspx"
 );

            routes.MapPageRoute(
                    "exhibitions",
                    "{titlelink}",
                    "~/exhibitions-details.aspx"
                   );
        }
    }
}
