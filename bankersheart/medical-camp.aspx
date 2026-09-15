<%@ Page Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="medical-camp.aspx.cs" Inherits="bankersheart.medical_camp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta id="metaDescription" runat="server" name="description" content="Bankers Group of Hospitals offers free cardiac and health checkups to improve community health." />
    <meta name="keywords" content="Medical camps in India, cardiac health awareness, preventive cardiac care, Cardiac care centre Vadodara, heart care centres Gujarat">
    <link id="canonicalLink" runat="server" rel="canonical" href="https://www.bankersheart.com/medical-camp" />

    <style>
        .tittle-height {
            height: 155px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <!-- Hidden SEO H1 -->
                    <h1 id="pageH1" runat="server" class="sr-only"></h1>
                    <h2 class="text-white text-center mb-0">Medical Camps</h2>
                    <h3></h3>
                    <h4></h4>
                    <h5></h5>
                </div>
            </div>
        </div>
    </section>

    <div id="medical-camp">
        <div class="container pt-5">
            <div class="row justify-content-center d-flex pt-5">
                <div class="col-10 text-center">
                    <picture>
                        <source srcset="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>assets/img/csr-medical-camp-img.webp" type="image/webp">
                        <source srcset="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>assets/img/csr-medical-camp-img.png" type="image/png">
                        <img class="img-fluid  rounded-4" src="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>assets/img/csr-medical-camp-img.png" alt="Medical Camps">
                    </picture>
                    <p class="pt-3">
                        Medical camps are an ongoing initiative by Bankers Group of Hospitals to raise awareness about cardiac diseases as well
                        as ensure medical attention is accessible to all. Till date, we have organized over 600 medical camps and more than 
                        1,25,000 patients have been screened and advised for any cardiac disorders.
                    </p>
                </div>
            </div>
        </div>
    </div>

    <div id="csr-bankers-section">
        <div class="container py-5">

            <div class="row">
                <%--  <div class="col-lg-4 col-md-6 pt-5">
                                 <a href="https://www.bankersheart.com/medical-camp-details">
                                 <div class="box-shadow-date text-center p-3 h-100">
                                     <div class="position-relative">
                                     <picture>
                                         <source srcset="https://www.bankersheart.com/assets/img/events-bankers-img-1.webp" type="image/webp">
                                         <source srcset="https://www.bankersheart.com/assets/img/events-bankers-img-1.png" type="image/png">
                                         <img class="img-fluid  rounded-4" src="https://www.bankersheart.com/assets/img/events-bankers-img-1.png" alt="Blog-details">
                                     </picture>
                            
                                         <p class="date-fix py-1 mb-0 px-3">17<br />sept</p>
                       
                                         </div>
                                     <div class="pb-4">
                                         <h6 class="pt-5  clr-black fw-semibold clamped-text">Republic Day Celebration at Bankers Group</h6>
                                         <div class="mt-4"><a href="https://www.bankersheart.com/medical-camp-details" class="btn-theme btn-blue">Know More</a></div>
                                     
                                     </div>
                                     
                                 </div>

                                     </a>
                             </div>
                --%>
                <asp:Repeater ID="rpt_MedicalCamps" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 pt-5">
                            <%--            <a href='medical-camp-details.aspx?id=<%# Eval("id") %>'>--%>
                            <a href="<%# GetRouteUrl("medical-camp", new { titlelink = Eval("titlelink") }) %>">

                                <div class="box-shadow-date text-center p-2 h-100">
                                    <div class="position-relative">
                                        <picture>
                                            <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/MedicalCampCategory/") + Eval("image") %>' type="image/webp">
                                            <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/MedicalCampCategory/") + Eval("image") %>' type="image/png">
                                            <img class="img-fluid p-3 media-img"
                                                src='<%# ResolveUrl("~/poweradmin/webfiles/MedicalCampCategory/") + Eval("image") %>'
                                                alt='<%# Eval("title") %>'>
                                        </picture>

                                        <div class="ribbon ribbon-top-left">
                                            <span class="avail"><%# Eval("Camp_Date", "{0:dd MMM yyyy}") %></span>

                                        </div>
                                        <%--  <p class="date-fix py-1 mb-0 px-3"><%# Convert.ToDateTime(Eval("Camp_Date")).ToString("dd") %><br />
                            <%# Convert.ToDateTime(Eval("Camp_Date")).ToString("MMM") %></p>--%>
                                    </div>
                                    <div class="pb-4 px-2">
                                        <div class="tittle-height">


                                            <h6 class="pt-4 clr-black fw-semibold clamped-text">
                                                <%# Eval("title") %>
                                                <p class="clamped-text" style="text-align: justify; text-justify: inter-word;"><%# Eval("shortdescription") %></p>
                                            </h6>
                                        </div>
                                        <div class="mt-4">
                                            <%--                            <a href='medical-camp-details.aspx?id=<%# Eval("id") %>' class="btn-theme btn-blue">Know More</a>--%>
                                            <a href='<%# GetRouteUrl("medical-camp", new { titlelink = Eval("titlelink") }) %>' class="btn-theme btn-blue">Know More</a>

                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>




            </div>
            <div class="row pt-5 mt-3 justify-content-center text-center">
                <asp:PlaceHolder ID="PaginationMedicalCampPlaceholder" runat="server"></asp:PlaceHolder>
            </div>

            <%--  <div class="row pt-5 mt-3 justify-content-center text-center">
              
                    <div class="col-12 carousal-arrow">
                    <a href="#" ><i class="fa fa-long-arrow-left "></i></a>

                     <a href="#" class="px-3 active" >1</a>
                        <a href="#" class="px-3">2</a>

                   <a href="#"> <i class="fa fa-long-arrow-right"></i></a>
                </div>
                
            </div>--%>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
</asp:Content>
