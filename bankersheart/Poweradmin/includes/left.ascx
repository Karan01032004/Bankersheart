<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left.ascx.cs" Inherits="bankersheart.Poweradmin.includes.left" %>

<div class="page-sidebar-wrapper">
    <!-- BEGIN SIDEBAR -->
    <!-- DOC: Set data-auto-scroll="false" to disable the sidebar from auto scrolling/focusing -->
    <!-- DOC: Change data-auto-speed="200" to adjust the sub menu slide up/down speed -->
    <div class="page-sidebar navbar-collapse collapse">
        <!-- BEGIN SIDEBAR MENU -->

        <ul class="page-sidebar-menu  page-header-fixed " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200" style="padding-top: 20px">
            <!-- DOC: To remove the sidebar toggler from the sidebar you just need to completely remove the below "sidebar-toggler-wrapper" LI element -->
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
            <li class="sidebar-toggler-wrapper hide">
                <div class="sidebar-toggler">
                    <span></span>
                </div>
            </li>
            <!-- END SIDEBAR TOGGLER BUTTON -->
            <!-- DOC: To remove the search box from the sidebar you just need to completely remove the below "sidebar-search-wrapper" LI element -->

            <li class="nav-item start " id="dashboard">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Dashboard.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-home"></i>
                    <span class="title">Dashboard</span>
                    <span class="selected"></span>
                </a>
            </li>
              <li class="nav-item start" id="Appointment">
      <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Appointment.aspx" %>'" class="nav-link nav-toggle">
          <i class="icon-layers"></i>
          <span class="title">Appointment</span>
          <span class="selected"></span>
      </a>
  </li>
            <li class="nav-item start" id="banner">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Banner/view-banner.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Banner Management</span>
                    <span class="selected"></span>
                </a>
            </li>
            <li class="nav-item start" id="ScrollingMessage">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "ScrollingMessageManagement/view-Scrolling-Message.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Scrolling Message &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Management</span>
                    <span class="selected"></span>
                </a>
            </li>
            <li class="nav-item start" id="PageContent">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "PageContentManagement/view_PageContent.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Page Content Management</span>
                    <span class="selected"></span>
                </a>
            </li>
    <%--        <li class="nav-item start" id="BlogManagement">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "BlogManagement/view_Blog.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Blog Management</span>
                    <span class="selected"></span>
                </a>
            </li>--%>
<li class="nav-item start" id="BlogManagement" style="pointer-events: none; opacity: 0.5;" title="Temporarily disabled">
    <a href="javascript:void(0)" class="nav-link nav-toggle">
        <i class="icon-layers"></i>
        <span class="title">Blog Management</span>
        <span class="selected"></span>
        <span style="font-size: 11px; color: darkgrey; margin-left: 10px;">(Temporarily disabled)</span>
    </a>
</li>



            <li class="nav-item start" id="DoctorsDetail">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Doctors Details/view_DoctorsDetails.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Doctors Details</span>
                    <span class="selected"></span>
                </a>
            </li>
            <li class="nav-item start" id="Awards_Achivement">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Awards_Achivement/view_Awards_Achivement.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Awards & Achivement</span>
                    <span class="selected"></span>
                </a>
            </li>
            <li class="nav-item start" id="insurance">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Empanelment/View_empanelment_partners.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Empanelment</span>
                    <span class="selected"></span>
                </a>
            </li>
            <li class="nav-item" id="li_Hospitals">
                <a href="javascript:;" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Hospitals/HospitalDetail/View_Hospitals.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>Hospitals                                                  
                <span class="arrow" id="span_Hospitals"></span>
                </a>
                <ul class="sub-menu" id="ul_HospitalsDetails">
                    <li class="nav-item" id="li_HospitalsDetails">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Hospitals/HospitalDetail/View_Hospitals.aspx" %>'">
                            <i class="fa fa-bars"></i>Hospitals Details</a>
                    </li>

                    <li class="nav-item" id="li_Facility">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Hospitals/Facility/View_Facility.aspx" %>'">
                            <i class="fa fa-bars"></i>Facility</a>
                    </li>
                    <%--     <li class="nav-item" id="li_Service">
            <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Hospitals/Service/View_Service.aspx" %>'">
                <i class="fa fa-bars"></i>Services</a>
        </li>--%>
                    <li class="nav-item" id="li_Service">
                        <a href="javascript:;" onclick="location.href='" class="nav-link nav-toggle">
                            <i class="icon-layers"></i>Services                                                  
                <span class="arrow" id="span_Service"></span>
                        </a>
                        <ul class="sub-menu" id="ul_Service1">
                            <li class="nav-item" id="li_Service1">
                                <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Hospitals/Service/ViewServiceName.aspx" %>'">
                                    <i class="fa fa-bars"></i>Add Service Name</a>
                            </li>
                            <li class="nav-item" id="li_Service2">
                                <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Hospitals/Service/View_Service.aspx" %>'">
                                    <i class="fa fa-bars"></i>Add Service</a>
                            </li>



                        </ul>

                    </li>


                </ul>

            </li>
            <li class="nav-item" id="li_Education">
                <a href="javascript:;" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Education/View_JournalClubDetial.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>Education                                                  
                <span class="arrow" id="span_Educaion"></span>
                </a>
                <ul class="sub-menu" id="ul_JournalClubDetial">
                    <li class="nav-item" id="li_JournalClubDetial">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Education/View_JournalClubDetial.aspx" %>'">
                            <i class="fa fa-bars"></i>Journal Club Detail</a>
                    </li>

                    <li class="nav-item" id="li_InterestingCases">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Education/View_InterestingCases.aspx" %>'">
                            <i class="fa fa-bars"></i>Interesting Cases</a>
                    </li>

                </ul>

            </li>

            <li class="nav-item" id="li_PatientCare">
                <a href="javascript:;" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "PatientCare/View_PatientsSay.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>Patient Care                                                   
                  <span class="arrow" id="span_PatientCare"></span>
                </a>
                <ul class="sub-menu" id="ul_PatientsSay">
                    <li class="nav-item" id="li_PatientsSay">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "PatientCare/View_PatientsSay.aspx" %>'">
                            <i class="fa fa-bars"></i>What Our Patients Say</a>
                    </li>

                </ul>

            </li>
            <li class="nav-item" id="li_enquiries">
                <a href="javascript:;" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "CSR/Yash Public Charitable Trust/View_Yash_Public_Charitable_Trust.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>CSR                                                   
                            <span class="arrow" id="span_enquiries"></span>
                </a>
                <ul class="sub-menu" id="ul_enquiries">
                    <li class="nav-item" id="li_notattended">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "CSR/Yash Public Charitable Trust/View_Yash_Public_Charitable_Trust.aspx" %>'">
                            <i class="fa fa-bars"></i>Yash Public Charitable &nbsp;&nbsp;&nbsp;&nbsp; Trust</a>
                    </li>
                    <li class="nav-item" id="li_MedicalCamp">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "CSR/Medicalcamp/View_MedicalCamp.aspx" %>'">
                            <i class="fa fa-bars"></i>Medical Camps</a>
                    </li>
                    <li class="nav-item" id="li_Exhibitions">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "CSR/Exhibition/View_Exhibition.aspx" %>'">
                            <i class="fa fa-bars"></i>Exhibitions</a>
                    </li>
                    <li class="nav-item" id="li_CSR_Activity">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "CSR/CSR_Activity/View_CSR_Activity.aspx" %>'">
                            <i class="fa fa-bars"></i>CSR Activity</a>
                    </li>
                </ul>

            </li>
            <li class="nav-item" id="li_Media">
                <a href="javascript:;" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/PressReleases/View_PressReleases.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>Media                                                   
                            <span class="arrow" id="span_Media"></span>
                </a>
                <ul class="sub-menu" id="ul_Media">
                    <li class="nav-item" id="li_PressReleases">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/PressReleases/View_PressReleases.aspx" %>'">
                            <i class="fa fa-bars"></i>Press Releases</a>
                    </li>
                    <li class="nav-item" id="li_EventsatBankers">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/EventsatBankers/View_EventsatBankers.aspx" %>'">
                            <i class="fa fa-bars"></i>Events at Bankers</a>
                    </li>
                    <li class="nav-item" id="li_Lectures">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/Lectures/View_Lectures.aspx" %>'">
                            <i class="fa fa-bars"></i>Lectures</a>
                    </li>
                    <li class="nav-item" id="li_Rally">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/Rally/View_Rally.aspx" %>'">
                            <i class="fa fa-bars"></i>Rally</a>
                    </li>
                    <li class="nav-item" id="li_Conference">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/Conference/View_Conference.aspx" %>'">
                            <i class="fa fa-bars"></i>Conference</a>
                    </li>
                    <li class="nav-item" id="li_NewsatBankers">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/NewsatBankers/View_NewsatBankers.aspx" %>'">
                            <i class="fa fa-bars"></i>News at Bankers</a>
                    </li>
                    <%--    <li class="nav-item" id="li_Infrastructure">
    <a href="javascript:;" class="nav-link nav-toggle">
        <i class="fa fa-bars"></i>
        <span class="title">Infrastructure</span>
        <span class="arrow"></span>
    </a>
    <ul class="sub-menu" id="ul_Infrastructure">
        <li class="nav-item" id="li_InfrastructureName">
            <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] +"Media/Infrastructure/View_InfrastructureName.aspx" %>'">
                <i class="fa fa-bars"></i>Infrastructure Name</a>
        </li>
        <li class="nav-item" id="li_InfrastructureGallery">
            <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/Infrastructure/View_InfrastructureGallery.aspx" %>'">
                <i class="fa fa-bars"></i>Infrastructure Gallery</a>
        </li>
    </ul>
</li>--%>

                    <li class="nav-item" id="li_Playcard">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/Playcard/ViewPlaycard.aspx" %>'">
                            <i class="fa fa-bars"></i>Card Con</a>
                    </li>

                    <%--<li class="nav-item" id="li_View_YouTubeVideo">
        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/YouTubeVideo/View_YouTubeVideo.aspx" %>'" >
            <i class="fa fa-bars"></i>YouTube Video</a>
    </li>--%>
                    <li class="nav-item" id="li_Downloads">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Media/Downloads/View_Downloads.aspx" %>'">
                            <i class="fa fa-bars"></i>Downloads</a>
                    </li>

                </ul>

            </li>
            <%--             <li class="nav-item start" id="career">
       <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Career.aspx" %>'" class="nav-link nav-toggle">
           <i class="icon-layers"></i>
           <span class="title">Career</span>
           <span class="selected"></span>
       </a>
   </li>--%>
            <li class="nav-item" id="li_career">
                <a href="javascript:;" onclick="location.href='" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>Career                                                  
                <span class="arrow" id="span_career"></span>
                </a>
                <ul class="sub-menu" id="ul_career">
                <%--    <li class="nav-item" id="li_career1">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "View_Position.aspx" %>'">
                            <i class="fa fa-bars"></i>Add Position</a>
                    </li>--%>
                    <li class="nav-item" id="li_career1" style="pointer-events: none; opacity: 0.5;" title="Temporarily disabled">
    <a href="javascript:void(0)" class="nav-link">
        <i class="fa fa-bars"></i> Add Position
      &nbsp  <span style="font-size: 11px; color: darkgray; margin-left: 10px;">(Temporarily disabled)</span>
    </a>
</li>

                    <li class="nav-item" id="li_career2">
                        <a href="javascript:void(0)" class="nav-link" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Career.aspx" %>'">
                            <i class="fa fa-bars"></i>View Career</a>
                    </li>



                </ul>

            </li>
            <li class="nav-item start" id="contactus">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Contactus.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Contact Us</span>
                    <span class="selected"></span>
                </a>
            </li>
          
            <%--    <li class="nav-item start " id="li_investor">
                <a href="javascript:;" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Investor Zone</span>
                    <span class="arrow" id="span_investor"></span>
                </a>
                <ul class="sub-menu" id="ul_investor">
                    <li class="nav-item" id="li_financialrelease">
                        <a href="javascript:;" target="_blank" class="nav-link nav-toggle">
                            <i class="icon-layers"></i>Financial Releases                                                   
                            <span class="arrow" id="span_financialrelease"></span>
                        </a>
                        <ul class="sub-menu" id="ul_financialrelease">
                            <li class="nav-item" id="li_category">
                                <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/financial-releases-category.aspx" %>'">
                                    <i class="fa fa-bars"></i>Category</a>
                            </li>
                            <li class="nav-item" id="li_financial">
                                <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/financial-releases.aspx" %>'">
                                    <i class="fa fa-bars"></i>Financial Releases</a>
                            </li>
                        </ul>
                    </li>

                    <li class="nav-item start " id="li_letterstoshareholders">
                        <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/letters-to-shareholders.aspx" %>'">
                            <i class="fa fa-bars"></i>
                            <span class="title">Letters to Shareholders</span>
                        </a>
                    </li>
                    <li class="nav-item start " id="li_annualreport">
                        <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/annual-reports.aspx" %>'">
                            <i class="fa fa-bars"></i>
                            <span class="title">Annual Report</span>
                        </a>
                    </li>
                    <li class="nav-item start " id="li_corporategovernance">
                        <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/corporate-governance.aspx" %>'">
                            <i class="fa fa-bars"></i>
                            <span class="title">Corporate Governance</span>
                        </a>
                    </li>
                    <%-- <li class="nav-item start " id="li_complaintsandregistrar">
                        <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/complaints-and-registrar.aspx" %>'">
                            <i class="fa fa-bars"></i>
                            <span class="title">Complaints and Registrar</span>
                        </a>
                    </li>--%>
            <%--<li class="nav-item start " id="li_shareholdingpattern">
                        <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/shareholding-pattern.aspx" %>'">
                            <i class="fa fa-bars"></i>
                            <span class="title">Share Holding Pattern</span>
                        </a>
                    </li>--%>
            <%--   <li class="nav-item" id="li_shareholdingpatterns">
                        <a href="javascript:;" target="_blank" class="nav-link nav-toggle">
                            <i class="icon-layers"></i>Share Holding Pattern                                                   
                            <span class="arrow" id="span_shareholdingpatterns"></span>
                        </a>
                        <ul class="sub-menu" id="ul_shareholdingpatterns">
                            <li class="nav-item" id="li_table">
                                <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/shareholding-pattern-table.aspx" %>'">
                                    <i class="fa fa-bars"></i>Table</a>
                            </li>
                            <li class="nav-item start " id="li_shareholdingpattern">
                                <a href="javascript:void(0)" class="nav-link " onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "Investor/shareholding-pattern.aspx" %>'">
                                    <i class="fa fa-bars"></i>
                                    <span class="title">Share Holding Pattern</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </li>--%>

            <%--<li class="nav-item start" id="photogallery">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "news-and-events.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">News and Events</span>
                    <span class="selected"></span>
                </a>
            </li>
            <li class="nav-item start" id="360category">
                <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "employee-of-month.aspx" %>'" class="nav-link nav-toggle">
                    <i class="icon-layers"></i>
                    <span class="title">Employee of Month</span>
                    <span class="selected"></span>
                </a>
            </li>--%>
        </ul>
        <!-- END SIDEBAR MENU -->
        <!-- END SIDEBAR MENU -->
    </div>
    <!-- END SIDEBAR -->
</div>
