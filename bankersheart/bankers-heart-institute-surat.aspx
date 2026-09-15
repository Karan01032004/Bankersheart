<%@ Page Title="Bankers Heart Institute Surat" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="bankers-heart-institute-surat.aspx.cs" Inherits="bankersheart.bankers_heart_institute_surat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="keywords" content="Bankers Heart Institute, 24X7 Emergency Cardiac Care, Siemens Catheterization Lab, Colour Doppler Machine Surat, Pathology Radiology Ambulance Surat">
<meta name="description" content="Expert heart care in Surat with modern ICUs, advanced diagnostics, and affordable cardiac treatments at Bankers Heart Institute.">
	<link rel="canonical" href="https://www.bankersheart.com/bankers-heart-institute-surat" />
	<meta property="og:title" content="Bankers Heart Institute, Surat | Advanced & Affordable Cardiac Care" />
	<meta property="og:description" content="Expert heart care in Surat with modern ICUs, advanced diagnostics, and affordable cardiac treatments at Bankers Heart Institute." />
	<meta property="og:url" content="https://www.bankersheart.com/bankers-heart-institute-surat" />
	<meta property="og:type" content="website" />
	<meta property="og:site_name" content="Bankers Group of Hospitals" />
	<meta property="og:image" content="https://www.bankersheart.com/bankers-group-of-hospitals-og.png" />
	<meta property="og:image:alt" content="Bankers Heart Institute in Surat - Advanced Cardiac Care" />
	<meta name="twitter:card" content="summary_large_image" />
	<meta name="twitter:title" content="Bankers Heart Institute, Surat | Advanced & Affordable Cardiac Care" />
	<meta name="twitter:description" content="Expert heart care in Surat with modern ICUs, advanced diagnostics, and affordable cardiac treatments at Bankers Heart Institute." />
	<meta name="twitter:image" content="https://www.bankersheart.com/bankers-group-of-hospitals-og.png" />
	<meta name="twitter:image:alt" content="Bankers Heart Institute in Surat - Advanced Cardiac Care" />
	<meta name="twitter:site" content="@BankersHospitals" />


            <style>
    .blogs-content p {
        text-align: justify;
        text-justify: inter-word;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="text-white h2 text-center mb-0">Banker Heart Institute Surat</h1>
                </div>
            </div>
        </div>
    </section>




    <asp:Repeater ID="rptHospitals" runat="server">
        <ItemTemplate>
            <section id="hospital-details" class="py-5">
                <div class="container py-lg-4">
                    <div class="blog-container text-lg-start text-center pt-lg-3">
                        <h1 class="clr-black fw-bold d-lg-none d-block">Bankers Heart Institute Surat <%--<span class="invisible position-absolute"> Superspeciality Cardiac Centre,</span>--%></h1>
                        <div class="inner-img mb-lg-0 mb-4">
                            <%--  <picture>
                        <source srcset="https://www.bankersheart.com/assets/img/multi-speciality-img-warasai.webp" type="image/webp">
                        <source srcset="https://www.bankersheart.com/assets/img/multi-speciality-img-warasai.png" type="image/png">
                        <img class="img-fluid  rounded-4" src="https://www.bankersheart.com/assets/img/multi-speciality-img-warasai.png" alt="Blog-details">
                    </picture>--%>
                            <picture>
                                <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Hospitals/") + Eval("image") %>' type="image/webp">
                                <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Hospitals/") + Eval("image") %>' type="image/png">
                                <img class="img-fluid rounded-4" style="width: 400px; height: 250px; object-fit: cover;"
                                    src='<%# ResolveUrl("~/poweradmin/webfiles/Hospitals/") + Eval("image") %>'
                                    alt='<%# Eval("title") %>'>
                            </picture>
                        </div>
                        <div class="blogs-content">
                            <%--                   <h2 class="clr-black fw-bold d-lg-block d-none">Bankers Heart and Multi Specialty Hospital, Warasia</h2>--%>
                            <h2 class="clr-black fw-bold d-lg-block d-none"><%# Eval("title") %><%--Bankers Superspeciality Hospital, Manjalpur--%></h2>
                                <h3></h3>
                            <p><%# Eval("description") %></p>

                            <%--<p>Banker’s Heart and Multispecialty Hospital is driven by its mission to provide the finest 
                        healthcare through innovative technologies. With this goal in mind, we have some of the most 
                        technologically advanced healthcare systems in the region. Our hospital is completely climatically
                        controlled to reduce chances of infections as well as increase comfort of our patients.</p>
                   <h6>In keeping with the times, we have integrated a completely wi-fi enabled hospital. This
                       technology has a two-fold advantage:</h6>
                    <p class="fw-medium">The Institute’s objectives are:</p>
                    <ul class="ps-3" style="list-style:disc;">
                        <li>We are able to provide remote consultation to patients who cannot
                            physically be on our premises.</li>
                        <li>Doctors throughout the hospital have immediate access to their patient’s reports and can monitor their progress from anywhere in the hospital, or in the world!</li>
                    </ul>
                    <p>Our ICU is one of the largest in the city, with 21 beds. The ICU is built so as 
                        to provide a panoramic view to the doctors and nurses from any corner of it. We
                        also have a tablet for each bed to connect the patients and the doctors. To increase 
                        the comfort of the patients in the ICU, we have bedside x-ray, sonography and echo test 
                        available. Headed by an intensivist, the ICU is constantly monitored by a team of nurses
                        and at least, 2 doctors, at any given time.</p>
                    <p>Our operations theatres are modularly designed to minimize any chances of infection.
                        Additionally, zonal boundaries have been established and are strictly followed to ensure 
                        the highest hygiene levels. We have linoleum floors in all our OTs and have hepa filters 
                        installed that purify air up to 99.99%. We have a separate OT according to the International
                        guidelines, to take care of infected and septic patients.</p>
                    <p>All our patient rooms are designed in such a way, that patients and their relatives, 
                        have a comfortable stay. Housekeeping ensures thorough cleaning of each and every room 
                        at regular intervals throughout the day. Our rooms are equipped with flat screen televisions, 
                        sofas and an additional air conditioner. We provide meals to the patients, as per the dietician’s
                        guidelines. The food is prepared up to the most hygienic standards by trained staff in the same
                        canteen in our premises. And a canteen is available for the benefit of any visitors.</p>--%>
                        </div>


                    </div>

                </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>


    <div id="facilities-hospital">
        <div class="container">
            <div class="container pb-5">
                <div class="row pb-5">
                    <div class="col-12">
                        <h2 class="clr-black fw-bold text-md-start text-center">Facilities in our Hospital</h2>
                        <div class="owl-carousel owl-theme pt-3">
                            <asp:Repeater ID="rptFacilities" runat="server">
                                <ItemTemplate>
                                    <div class="item">
                                        <div class="press-box h-100">
                                            <a href='<%# ResolveUrl("~/poweradmin/webfiles/Facility/") + Eval("image") %>' data-fancybox="gallery">
                                                <%--  <picture>
                                        <source srcset="https://www.bankersheart.com/assets/img/multi-delux-room.webp" type="image/webp">
                                        <source srcset="https://www.bankersheart.com/assets/img/multi-delux-room.png" type="image/png">
                                        <img class="img-fluid  facilities-img-size" src="https://www.bankersheart.com/assets/img/multi-delux-room.png" alt="Deluxe Room">
                                    </picture>--%>
                                                <picture>
                                                    <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Facility/") + Eval("image") %>' type="image/webp">
                                                    <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Facility/") + Eval("image") %>' type="image/png">
                                                    <img class="img-fluid  facilities-img-size"
                                                        src='<%# ResolveUrl("~/poweradmin/webfiles/Facility/") + Eval("image") %>'
                                                        alt='<%# Eval("title") %>'>
                                                </picture>
                                            </a>

                                            <div class="bg-red py-3 px-2 h-100">
                                                <p class="text-center text-white mb-0"><%# Eval("title") %></p>
                                            </div>

                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="hospital-services">
        <div class="container pb-5">
            <div class="row pb-5">
                <div class="col-lg-6">
                    <h2 class="fw-bold clr-black text-lg-start text-center">Our Services</h2>
                    <div class="accordion" id="accordionExample">
                        <asp:Repeater ID="rptServices" runat="server">
                            <ItemTemplate>
                                <div class="accordion-item accord mt-3">
                                    <h2 class="accordion-header" id="heading<%# Container.ItemIndex %>">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse<%# Container.ItemIndex %>" aria-expanded="true" aria-controls="collapse<%# Container.ItemIndex %>">
                                            <%--       <%# Eval("title") %>--%>
                                            <td><%# Eval("ServiceName") %></td>

                                        </button>
                                    </h2>
                                    <div id="collapse<%# Container.ItemIndex %>" class="accordion-collapse collapse" aria-labelledby="heading<%# Container.ItemIndex %>" data-bs-parent="#accordionExample">
                                        <div class="accordion-body">
                                            <p><%# Eval("description") %></p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="col-lg-6 contact-details px-0 mt-lg-0 mt-5">

                    <h4 class="fw-semibold text-center bg-red text-white py-3">Contact Details</h4>
                         <div class="text-center mt-3 mb-2">
         <strong>Opp. Lakeview Garden – Surat Bankers Heart Institute</strong>
     </div>
                    <div class="row pt-3 align-items-center px-sm-0 px-2">
                        <div class="col-2 text-center">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/red-location-icon.svg" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/red-location-icon.svg" type="image/png">
                                <img class="img-fluid" src="https://www.bankersheart.com/assets/img/red-location-icon.svg" alt="Lakeview Garden, Floral Park, Umra,">
                            </picture>
                        </div>
                        <div class="col-10 ps-0">
                            <p class="mb-0">
                                Opp. Lakeview Garden, Floral Park, Umra,
                                <br class="d-lg-inline-block d-none" />
                                Surat - 395007, Gujarat - India
                            </p>
                            <%--                                    <p class="mb-0">Opp. Lakeview garden, behind shardayatan school, floral park road, umra, Surat-395007, Gujarat - India</p>--%>
                        </div>
                    </div>

                    <div class="row pt-3 align-items-center px-sm-0 px-2">
                        <div class="col-2 text-center">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/red-call-icon.svg" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/red-call-icon.svg" type="image/png">
                                <img class="img-fluid" src="https://www.bankersheart.com/assets/img/red-call-icon.svg" alt="Call 91 261 2293000">
                            </picture>
                        </div>
                        <div class="col-10 ps-0">
                            <a href="tel:+91 261 2293000">+91 261 2293000</a><br class="d-md-none d-inline-block" />
                            <a href="tel:+91 265 2252123" class="ps-md-3">+91 265 2252123</a><br />
                            <a href="tel:+91 85111 74111">+91 85111 74111</a>
                        </div>
                    </div>
                    <div class="row pt-3 align-items-center mb-2 px-sm-0 px-2">
                        <div class="col-2 text-center">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/email-icon-img.svg" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/email-icon-img.svg" type="image/png">
                                <img class="img-fluid" src="https://www.bankersheart.com/assets/img/email-icon-img.svg" alt="Mail bhmh@bankersheart.com">
                            </picture>
                        </div>
                        <div class="col-10 ps-0">
                            <a href="mailto:bhmh@bankersheart.com">bhmh@bankersheart.com</a>

                        </div>
                    </div>
                    <div class="my-5 ps-3 text-lg-start text-center">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>appointment-bankers-group-of-hospitals" class="btn-theme btn-blue">Make An Appoinment </a>
                    </div>
                    <div>
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3720.6740280513327!2d72.77681307508485!3d21.165366980518385!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be04d936074ec79%3A0x1520b25265194c88!2sShardayatan%20School!5e0!3m2!1sen!2sin!4v1738737291656!5m2!1sen!2sin" width="100%" height="200" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    </div>


                </div>
            </div>
        </div>
    </div>
    </ItemTemplate>
    </asp:Repeater>
    <div id="other-hospital">
        <div class="container pb-5">
            <div class="row pb-5">
                <h2 class="clr-black fw-bold text-center">Other Location</h2>
                <div class="col-lg-4 col-sm-6 pt-4">
                    <div class="press-box h-100">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>bankers-heart-institute-old-padra-road-vadodara">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/heart-institute-img.webp" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/heart-institute-img.png" type="image/png">
                                <img class="img-fluid  facilities-img-size" src="https://www.bankersheart.com/assets/img/heart-institute-img.png" alt="Bankers Heart Institute Op Road">
                            </picture>

                            <div class="bg-red py-3 px-2 h-100">
                                <h6 class="text-center text-white mb-0">Bankers Heart Institute<br />
                                    Op Road, Vadodara</h6>
                            </div>
                        </a>

                    </div>
                </div>
                <div class="col-lg-4 col-sm-6 pt-4">
                    <div class="press-box h-100">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>bankers-superspeciality-hospital-manjalpur-vadodara">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/bankers-super-hospital-majalpur.webp" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/bankers-super-hospital-majalpur.png" type="image/png">
                                <img class="img-fluid  facilities-img-size" src="https://www.bankersheart.com/assets/img/bankers-super-hospital-majalpur.png" alt="Bankers Superspeciality Hospital, Manjalpur">
                            </picture>

                            <div class="bg-red py-3 px-2 h-100">
                                <h6 class="text-center text-white mb-0">Bankers Superspeciality Hospital, Manjalpur, Vadodara</h6>
                            </div>
                        </a>

                    </div>
                </div>

                <div class="col-lg-4 col-sm-6 pt-4">
                    <div class="press-box h-100">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>bankers-heart-multispeciality-hospital-warasia-vadodara">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/heart-hospital-img.webp" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/heart-hospital-img.png" type="image/png">
                                <img class="img-fluid  facilities-img-size" src="https://www.bankersheart.com/assets/img/heart-hospital-img.png" alt="Bankers Heart & Multi Specialty , Warasia">
                            </picture>

                            <div class="bg-red py-3 px-2 h-100">
                                <h6 class="text-center text-white mb-0">Bankers Heart & Multi Specialty
Hospital, Warasia, Vadodara</h6>
                            </div>
                        </a>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
    <script>
        $('#facilities-hospital .owl-carousel').owlCarousel({
            loop: true,
            margin: 20,
            nav: true,
            dots: true,
            navText: [
                '<i class="fa fa-step-backward red" aria-hidden="true"></i>', // Font Awesome left arrow icon
                '<i class="fa fa-step-forward red" aria-hidden="true"></i>' // Font Awesome right arrow icon
            ],
            responsive: {
                0: {
                    items: 1,
                    dots: true,
                    nav: false,
                    autoplay: true,
                    autoplayTimeout: 2500,
                },
                576: {
                    items: 2,
                    dots: true,
                    nav: false,
                    autoplay: true,
                    autoplayTimeout: 3000,
                },
                768: {
                    items: 2,
                    dots: true,
                    nav: false,
                    autoplay: true,
                    autoplayTimeout: 3000,
                },
                992: {
                    items: 3,
                    autoplay: true,
                    autoplayTimeout: 3000,
                    dots: true,


                },
                1200: {
                    items: 4,
                    autoplay: true,
                    autoplayTimeout: 3000,
                    dots: true,

                },
                1400: {
                    items: 4,
                    autoplay: true,
                    autoplayTimeout: 3000,
                    dots: true,

                }
            }
        });
    </script>
</asp:Content>
