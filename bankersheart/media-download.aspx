<%@ Page Title="Health Resources | Media - Bankers Heart" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="media-download.aspx.cs" Inherits="bankersheart.media_download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="description" content="Bankers Heart offers free downloads of health tips, brochures, and care charts for heart and diabetes management.">
    <meta name="keywords" content="Bankers Heart, COVID care guidelines, medical brochures, heart disease diet, heart disease treatment, medical resources online">
    <link rel="canonical" href="https://www.bankersheart.com/media-download">
    <style>
        .tittle-height {
            height: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="sr-only">media-download </h1>
                    <h2 class="text-white text-center mb-0">Downloads</h2>
                    <h3></h3>
                    <h4></h4>
                    <h5></h5>
                </div>
            </div>
        </div>
    </section>

    <div id="events-bankers">
        <div class="container py-5">
            <div class="row py-5">
                <div class="col-12">
                    <ul class="nav nav-tabs justify-content-center" id="myTab" role="tablist">
                        <li class="nav-item nav-item-2" role="presentation">
                            <button class="nav-link active" id="health-tab" data-bs-toggle="tab" data-bs-target="#health" type="button" role="tab" aria-controls="home" aria-selected="true">Health Tips</button>
                        </li>
                        <li class="nav-item" role="presentation" style="">
                            <button class="nav-link" id="corp-tab" data-bs-toggle="tab" data-bs-target="#corp" type="button" role="tab" aria-controls="profile" aria-selected="false" tabindex="-1">Corporate Brochure</button>
                        </li>
                        <li class="nav-item" role="presentation" style="">
                            <button class="nav-link" id="brouchure-tab" data-bs-toggle="tab" data-bs-target="#brouchure" type="button" role="tab" aria-controls="contact" aria-selected="false" tabindex="-1">Events Brochure</button>
                        </li>
                        <li class="nav-item" role="presentation" style="">
                            <button class="nav-link" id="conference-tab" data-bs-toggle="tab" data-bs-target="#present" type="button" role="tab" aria-controls="contact" aria-selected="false" tabindex="-1">Presentations</button>
                        </li>



                    </ul>

                    <div class="tab-content py-3" id="myTabContent">
                        <div class="tab-pane fade active show" id="health" role="tabpanel" aria-labelledby="events-tab">
                            <div class="row">
                                <asp:Repeater ID="rpt_health" runat="server">
                                    <ItemTemplate>
                                        <div class="col-lg-4 col-md-6 pt-5">

                                            <div class="box-shadow-date text-center p-3 h-100">

                                                <a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' data-fancybox="gallery">
                                                    <%--      <picture>
                                         <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
                                         <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
                                         <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
                                     </picture>--%>
                                                    <picture>
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/webp">
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/png">
                                                        <img class="img-fluid  rounded-4 pdf-img"
                                                            src='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>'
                                                            alt='<%# Eval("title") %>'>
                                                    </picture>
                                                </a>




                                                <div class="pb-4">
                                                    <div class="tittle-height">
                                                        <h6 class="pt-3  clr-black fw-semibold clamped-text"><%# Eval("title") %><%--Bankers Home Based - COVID Care - Guide Lines--%></h6>
                                                    </div>

                                                    <div class="mt-4"><a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("PDF") %>' <%--"assets/pdf/bankers-home-base-covid-guide-lines.pdf"--%> class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                                </div>

                                            </div>


                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>


                        </div>
                        <div class="tab-pane fade" id="corp" role="tabpanel" aria-labelledby="lecture-tab">
                            <div class="row">
                                <asp:Repeater ID="rpt_corporate" runat="server">
                                    <ItemTemplate>
                                        <div class="col-lg-4 col-md-6 pt-5">

                                            <div class="box-shadow-date text-center p-3 h-100">
                                                <a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' data-fancybox="gallery">
                                                    <%--      <picture>
    <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
    <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
    <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
</picture>--%>
                                                    <picture>
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/webp">
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/png">
                                                        <img class="img-fluid  rounded-4 pdf-img"
                                                            src='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>'
                                                            alt='<%# Eval("title") %>'>
                                                    </picture>
                                                </a>
                                                <%-- <a href="assets/img/covid-img-pdf-1.png" data-fancybox="gallery">
                                            <picture>
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
                                                <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
                                            </picture>
                                        </a>--%>


                                                <div class="pb-4">
                                                    <div class="tittle-height">
                                                        <h6 class="pt-3  clr-black fw-semibold clamped-text"><%# Eval("title") %><%--Bankers Home Based - COVID Care - Guide Lines--%></h6>
                                                    </div>
                                                    <div class="mt-4"><a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("PDF") %>' <%--"assets/pdf/bankers-home-base-covid-guide-lines.pdf"--%> class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                                </div>

                                                <%--   <div class="pb-4">
                                            <h6 class="pt-3  clr-black fw-semibold clamped-text">Bankers Home Based - COVID Care - Guide Lines</h6>
                                            <div class="mt-4"><a href="https://www.bankersheart.com/assets/pdf/bankers-home-base-covid-guide-lines.pdf" class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                        </div>--%>
                                            </div>


                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                        </div>
                        <div class="tab-pane fade" id="brouchure" role="tabpanel" aria-labelledby="rally-tab">
                            <div class="row">
                                <asp:Repeater ID="rpt_events" runat="server">
                                    <ItemTemplate>
                                        <div class="col-lg-4 col-md-6 pt-5">
                                            <div class="box-shadow-date text-center p-3 h-100">
                                                <a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' data-fancybox="gallery">
                                                    <%--      <picture>
    <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
    <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
    <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
</picture>--%>
                                                    <picture>
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/webp">
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/png">
                                                        <img class="img-fluid  rounded-4 pdf-img"
                                                            src='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>'
                                                            alt='<%# Eval("title") %>'>
                                                    </picture>
                                                </a>
                                                <%-- <a href="assets/img/covid-img-pdf-1.png" data-fancybox="gallery">
                                            <picture>
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
                                                <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
                                            </picture>
                                        </a>--%>


                                                <div class="pb-4">
                                                    <div class="tittle-height">
                                                        <h6 class="pt-3  clr-black fw-semibold clamped-text"><%# Eval("title") %><%--Bankers Home Based - COVID Care - Guide Lines--%></h6>
                                                    </div>
                                                    <div class="mt-4"><a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("PDF") %>' <%--"assets/pdf/BANKERS-HOME-BASE-COVID-GUIDE-LINES.pdf"--%> class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                                </div>

                                                <%--   <div class="pb-4">
                                            <h6 class="pt-3  clr-black fw-semibold clamped-text">Bankers Home Based - COVID Care - Guide Lines</h6>
                                            <div class="mt-4"><a href="https://www.bankersheart.com/assets/pdf/bankers-home-base-covid-guide-lines.pdf" class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                        </div>--%>
                                            </div>

                                            <%--  <div class="box-shadow-date text-center p-3 h-100">

                                                <a href="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" data-fancybox="gallery">
                                                    <picture>
                                                        <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
                                                        <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
                                                        <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
                                                    </picture>
                                                </a>




                                                <div class="pb-4">
                                                    <h6 class="pt-3  clr-black fw-semibold clamped-text">Bankers Home Based - COVID Care - Guide Lines</h6>
                                                    <div class="mt-4"><a href="https://www.bankersheart.com/assets/pdf/bankers-home-base-covid-guide-lines.pdf" class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                                </div>

                                            </div>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                        </div>
                        <div class="tab-pane fade" id="present" role="tabpanel" aria-labelledby="conference">
                            <div class="row">
                                <asp:Repeater ID="rpt_Presentation" runat="server">
                                    <ItemTemplate>
                                        <div class="col-lg-4 col-md-6 pt-5">
                                            <div class="box-shadow-date text-center p-3 h-100">
                                                <a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' data-fancybox="gallery">
                                                    <%--      <picture>
    <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
    <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
    <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
</picture>--%>
                                                    <picture>
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/webp">
                                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>' type="image/png">
                                                        <img class="img-fluid  rounded-4 pdf-img"
                                                            src='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("image") %>'
                                                            alt='<%# Eval("title") %>'>
                                                    </picture>
                                                </a>
                                                <%-- <a href="assets/img/covid-img-pdf-1.png" data-fancybox="gallery">
                                            <picture>
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
                                                <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
                                            </picture>
                                        </a>--%>


                                                <div class="pb-4">
                                                    <div class="tittle-height">
                                                        <h6 class="pt-3  clr-black fw-semibold clamped-text"><%# Eval("title") %><%--Bankers Home Based - COVID Care - Guide Lines--%></h6>
                                                    </div>
                                                    <div class="mt-4"><a href='<%# ResolveUrl("~/poweradmin/webfiles/Downloads/") + Eval("PDF") %>' <%--"assets/pdf/bankers-home-base-covid-guide-lines.pdf"--%> class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                                </div>

                                                <%--   <div class="pb-4">
                                            <h6 class="pt-3  clr-black fw-semibold clamped-text">Bankers Home Based - COVID Care - Guide Lines</h6>
                                            <div class="mt-4"><a href="https://www.bankersheart.com/assets/pdf/bankers-home-base-covid-guide-lines.pdf" class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                        </div>--%>
                                            </div>

                                            <%--  <div class="box-shadow-date text-center p-3 h-100">

                                                <a href="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" data-fancybox="gallery">
                                                    <picture>
                                                        <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
                                                        <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
                                                        <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
                                                    </picture>
                                                </a>




                                                <div class="pb-4">
                                                    <h6 class="pt-3  clr-black fw-semibold clamped-text">Bankers Home Based - COVID Care - Guide Lines</h6>
                                                    <div class="mt-4"><a href="https://www.bankersheart.com/assets/pdf/bankers-home-base-covid-guide-lines.pdf" class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                                </div>

                                            </div>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <%--    <div class="col-lg-4 col-md-6 pt-5">

                                    <div class="box-shadow-date text-center p-3 h-100">

                                        <a href="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" data-fancybox="gallery">
                                            <picture>
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.webp" type="image/webp">
                                                <source srcset="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" type="image/png">
                                                <img class="img-fluid  rounded-4 pdf-img" src="https://www.bankersheart.com/assets/img/covid-img-pdf-1.png" alt="Blog-details">
                                            </picture>
                                        </a>




                                        <div class="pb-4">
                                            <h6 class="pt-3  clr-black fw-semibold clamped-text">Bankers Home Based - COVID Care - Guide Lines</h6>
                                            <div class="mt-4"><a href="https://www.bankersheart.com/assets/pdf/bankers-home-base-covid-guide-lines.pdf" class="btn-theme btn-blue" download="" target="_blank">Download <i class="fa fa-download" aria-hidden="true"></i></a></div>

                                        </div>

                                    </div>


                                </div>--%>
                            </div>
                        </div>




                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
</asp:Content>
