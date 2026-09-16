<%@ Page Title="Cardiac & Medical Services | Best Hospital Vadodara" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="all-services.aspx.cs" Inherits="bankersheart.all_services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta name="keywords" content=" heart surgery hospital vadodara, best hospital vadodara, best heart hospital vadodara, best cardiologist vadodara, angioplasty in vadodara, heart check up vadodara, top hospital vadodara">
    <meta name="description" content="Explore services at Bankers Heart Institute, a best heart hospital Vadodara providing advanced cardiac treatments including angioplasty in Vadodara, heart surgery, and preventive heart check up Vadodara.">
    <link rel="canonical" href="https://www.bankersheart.com/heart-surgery-angioplasty-services-vadodara" />
    <meta property="og:title" content="All Services | Bankers Heart Institute – Comprehensive Cardiac & Multispecialty Care" />
    <meta property="og:description" content="Explore expert cardiac services and advanced heart care at Bankers Heart Institute." />
    <meta property="og:url" content="https://www.bankersheart.com/heart-surgery-angioplasty-services-vadodara" />
    <meta property="og:type" content="website" />
    <meta property="og:site_name" content="Bankers Group of Hospitals" />
    <meta property="og:image" content="https://www.bankersheart.com/bankers-group-of-hospitals-og.png" />
    <meta property="og:image:alt" content="Bankers Heart Institute - Cardiac & Multispecialty Services" />
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:title" content="All Services | Bankers Heart Institute – Comprehensive Cardiac & Multispecialty Care" />
    <meta name="twitter:description" content="Explore expert cardiac services and advanced heart care at Bankers Heart Institute." />
    <meta name="twitter:image" content="https://www.bankersheart.com/bankers-group-of-hospitals-og.png" />
    <meta name="twitter:image:alt" content="Bankers Heart Institute - Cardiac & Multispecialty Services" />
    <meta name="twitter:site" content="@BankersHospitals" />

    <style>
        .services-title {
            position: absolute;
            bottom: -8px;
            background: #cd00018f;
            width: 100%;
        }

        .services-box {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #CD0001;
            border-radius: 8px;
        }

        .service-img {
            height: 280px;
            object-fit: cover;
            width: 100%;
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
        }

        .services-box ul li {
            line-height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="h2 text-white text-center mb-0">Expert Heart Surgery & Emergency Care in Vadodara <%--<span>Bankers</span>--%></h1>
                    <h2 class="invisible position-absolute text-white text-center mb-0">MA YOJANA Services</h2>
                    <h3></h3>
                    <h4></h4>
                    <h5></h5>
                </div>
            </div>
        </div>
    </section>
    <div id="services-available">
        <div class="container py-5">
            <div class="row py-5">
                <asp:Repeater ID="rpt_Services" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 pt-5">

                            <div class="services-box h-100">

                                <div class="position-relative">


                                    <%--     <picture>
                            <source srcset="https://www.bankersheart.com/assets/img/medical-support.webp" type="image/webp">
                            <source srcset="https://www.bankersheart.com/assets/img/medical-support.png" type="image/png">
                            <img class="img-fluid service-img" src="https://www.bankersheart.com/assets/img/medical-support.png"  alt="MEDICAL SUPPORT">
                         <picture>
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Service/") + Eval("image") %>' type="image/webp">
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Service/") + Eval("image") %>' type="image/png">
                                        <img class="img-fluid rounded-4"
                                            src='<%# ResolveUrl("~/poweradmin/webfiles/Service/") + Eval("image") %>'
                                            alt='<%# Eval("title") %>'>
                                    </picture>
                        </picture>--%>
                                    <%--                        <h6 class="py-3 fw-semibold services-title text-center text-white">Medical Support</h6>--%>
                                    <picture>
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Service/") + Eval("image") %>' type="image/webp">
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Service/") + Eval("image") %>' type="image/png">
                                        <img class="img-fluid service-img"
                                            src='<%# ResolveUrl("~/poweradmin/webfiles/Service/") + Eval("image") %>'
                                            alt='<%# Eval("ServiceName") %>'>
                                    </picture>
                                    <h6 class="py-3 fw-semibold services-title text-center text-white"><%# Eval("ServiceName") %></h6>

                                </div>

                                <div class="p-3">
                                    <h6>Service Available in:- </h6>

                                    <ul style="list-style: disc;" class="ps-4">


                                        <%# GenerateHospitalLinks(Eval("HospitalNames").ToString()) %>
                                    </ul>
                                    <%--                            <li><a href="bankers-superspeciality-hospital-manjalpur-vadodara.aspx#heading0"> <%# Eval("HospitalName") %></a></li>
<%--                            <li><a href="bankers-heart-institute-old-padra-road-vadodara.aspx#heading0">Bankers Heart Institute, Old Padra Road - Vadodara</a></li>
                            <li><a href="bankers-heart-multispeciality-hospital-warasia-vadodara.aspx#heading0">Bankers Heart and Multi Specialty Hospital, Warasia - Vadodara</a></li>--%>
                                    <%--   <li>Bankers Heart Institute, Surat - 395007, Gujarat, India</li>--%>
                                </div>
                                <%--   <asp:Repeater ID="rpt_Hospitals" runat="server" OnItemDataBound="rpt_Services_ItemDataBound">
                        <ItemTemplate>
                            <li>
                                <a href='<%# "hospital-details.aspx?name=" + Server.UrlEncode(Eval("HospitalName").ToString()) %>'>
                                    <%# Eval("HospitalName") %>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                                --%>
                            </div>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </div>
    <div class="container pb-5">
        <div class="row">
            <div class="col-12">
                <h2 class="clr-black fw-semibold text-lg-start text-center"></h2>
                <p class="text-lg-start text-center pt-3">
                    Our hospital is trusted as a top heart surgery hospital in Vadodara and the best emergency hospital for heart care. With advanced cath-lab technology, dedicated cardiac surgery theatres, and 24/7 emergency response, we deliver life-saving treatment with expertise and compassion. Patients rely on us for comprehensive cardiac care, from emergency interventions to complex surgeries, supported by modern ICU and diagnostic facilities.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
</asp:Content>
