<%@ Page Title=" Best Cardiologist Vadodara | Meet Our Doctors" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="meet-our-doctors.aspx.cs" Inherits="bankersheart.meet_our_doctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content=" best cardiologist vadodara, best heart hospital vadodara, heart surgery hospital vadodara, best hospital vadodara, angioplasty in vadodara, heart check up vadodara, top hospital vadodara">
    <meta name="description" content="Meet the best cardiologist Vadodara at Bankers Heart Institute, a top hospital Vadodara offering advanced cardiac care, angioplasty in Vadodara, heart surgery services, and heart check up Vadodara.">
    <link rel="canonical" href="https://www.bankersheart.com/best-cardiologist-vadodara" />
    <style>
        .doctor-img-size {
            height: 240px;
            object-fit: contain;
            width: 100%;
        }

        .btn-theme {
            color: #fff !important;
            padding: 15px 30px;
            background: #CD0001 !important;
            border-radius: 5px;
            transition: transform 0.3sease, background 0.3sease, box-shadow 0.3sease;
            outline: 2px solid #fff;
            outline-offset: -5px;
        }

        .dropdown-item.active {
            background: unset;
            color: #656565;
        }

        .dropdown-2 .dropdown-toggle {
            word-wrap: break-word !important;
            white-space: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="sr-only">Doctors</h1>

                    <h2 class="text-white text-center mb-0">Meet our Doctors</h2>
                </div>
            </div>
        </div>
    </section>
    <div id="meet-doctors" class="py-5">
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-lg-10 text-center">
                    <h3 class="clr-black fw-bold">Meet Our Expert Team of Doctors Dedicated to Your Heart Health and Well-Being</h3>
                    <h4></h4>
                    <h5></h5>
                    <p>
                       Our team of highly skilled and compassionate specialists at Bankers Heart Institute is committed to providing exceptional cardiac care tailored to every patient. Recognized as the best heart hospital in Vadodara, our doctors focus on accurate diagnosis, advanced treatment, and personalized care.
                    </p>
                    <p>
                        Led by some of the best cardiologists of Vadodara, our medical experts provide comprehensive heart care including angioplasty, advanced cardiac procedures, and preventive heart check up programs. At our hospital, we combine medical expertise with modern technology to ensure every patient receives safe, effective, and compassionate treatment for better heart health and long-term well-being.
                    </p>
                </div>
            </div>
            <div class="row justify-content-lg-end justify-content-center">
                <div class="col-lg-5  col-sm-8 col-12 text-lg-end text-center dropdown-2">
                    <div class="dropdown">
                        <%--     <asp:DropDownList ID="ddlHospitals" runat="server" AutoPostBack="true" class="btn btn-theme dropdown-toggle" OnSelectedIndexChanged="ddlHospitals_SelectedIndexChanged" style="width:200px;">
                            <asp:ListItem Text="Select Hospital" Value=""/>
                            <asp:ListItem Text="Bankers Superspeciality Hospital, Manjalpur" Value="Bankers Superspeciality Hospital, Manjalpur" />
                            <asp:ListItem Text="Bankers Heart Institute, Vadodara" Value="Bankers Heart Institute, Vadodara" />
                            <asp:ListItem Text="Bankers Heart and Multi Specialty Hospital, Warasia" Value="Bankers Heart and Multi Specialty Hospital, Warasia" />
                            <asp:ListItem Text="Bankers Heart Institute, Surat" Value="Bankers Heart Institute, Surat" />
                        </asp:DropDownList>--%>

                        <!-- Bootstrap Dropdown Button -->
                        <!-- Hidden Field to store selected hospital -->
                        <asp:HiddenField ID="hfSelectedHospital" runat="server" />

                        <!-- Bootstrap Dropdown Button -->
                        <!-- Bootstrap Dropdown -->
                        <div class="dropdown">
                            <button type="button" class="btn btn-theme dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
                                <asp:Label ID="lblSelectedHospital" runat="server" Text="Select Hospital"></asp:Label>
                            </button>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:LinkButton runat="server" ID="lnkHospital1" CssClass="dropdown-item" CommandArgument="" OnCommand="Hospital_Selected">Select Hospital</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton runat="server" ID="lnkHospital3" CssClass="dropdown-item" CommandArgument="Bankers Heart Institute, Vadodara" OnCommand="Hospital_Selected">Bankers Heart Institute, Vadodara</asp:LinkButton></li>

                                <li>
                                    <asp:LinkButton runat="server" ID="lnkHospital2" CssClass="dropdown-item" CommandArgument="Bankers Superspeciality Hospital, Manjalpur" OnCommand="Hospital_Selected">Bankers Superspeciality Hospital, Manjalpur</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton runat="server" ID="lnkHospital4" CssClass="dropdown-item" CommandArgument="Bankers Heart and Multi Specialty Hospital, Warasia" OnCommand="Hospital_Selected">Bankers Heart and Multi Specialty Hospital, Warasia</asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton runat="server" ID="lnkHospital5" CssClass="dropdown-item" CommandArgument="Bankers Heart Institute, Surat" OnCommand="Hospital_Selected">Bankers Heart Institute, Surat</asp:LinkButton></li>
                            </ul>
                        </div>

                    </div>
                </div>
            </div>

            <div class="row pb-5">
                <asp:Repeater ID="rpt_MedicalCamps" runat="server">
                    <ItemTemplate>

                        <div class="col-lg-6 col-12 pt-5">

                            <div class="box-shadow-date p-3 h-100">
                                <div class="row align-items-center">
                                    <div class="col-sm-5">
                                        <picture>
                                            <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/DoctorDetails/") + Eval("image") %>' type="image/webp">
                                            <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/DoctorDetails/") + Eval("image") %>' type="image/png">
                                            <img class="img-fluid doctor-img-size p-3"
                                                src='<%# ResolveUrl("~/poweradmin/webfiles/DoctorDetails/") + Eval("image") %>'
                                                alt='<%# Eval("Name") %>'>
                                        </picture>
                                    </div>
                                    <div class="col-sm-7 text-lg-start text-center">
                                        <p class="red mb-0 pt-3"><%# Eval("profession") %> <%--Family Physician--%></p>
                                        <h6 class="fw-semibold cnt-black"><%# Eval("Name") %><%--Dr. Elizabeth Foster--%></h6>
                                        <p class="mb-0 d-none"><%# Eval("specialties") %> <%--Compassionate care for all ages.--%></p>
                                        <%--  <div class="mt-4"><a href='doctors-details.aspx?id=<%# Eval("id") %>' class="btn-theme btn-blue">Know More</a></div>--%>
                                    </div>
                                </div>

                                <%-- <a href='doctors-details.aspx?id=<%# Eval("id") %>'>

                                     <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/doctors-img.webp" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/doctors-img.png" type="image/png">
                                <img class="img-fluid  rounded-4 px-3 pt-3" src="https://www.bankersheart.com/assets/img/doctors-img.png" alt="Blog-details">
                            </picture>

                                    
                                    <div class="pb-4 " style="border-top: 1px solid #CD0001;">
                                       

                                    </div>
                                </a>--%>
                            </div>


                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
    <script>
        function filterDoctors() {
            var hospital = document.getElementById("ddlHospitals").value;
            __doPostBack('ddlHospitals', hospital);
        }
    </script>

</asp:Content>
