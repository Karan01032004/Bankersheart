<%@ Page Title="Top 10 Hospital in Vadodara | Best Heart Hospital in Vadodara" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="top-10-hospital-old-padra-road-vadodara.aspx.cs" Inherits="bankersheart.bankers_heart_institutes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="Top 10 Hospital in Vadodara, Best Hospital in Vadodara, Top Hospital in Vadodara, Best Heart Hospital in Vadodara, Cardiology Hospital in Vadodara, Heart Specialist in Vadodara">
    <meta name="description" content="Bankers Heart Institute is recognized among the top 10 hospitals in Vadodara, offering advanced cardiac care, angioplasty, heart surgery, diagnostics, ICU, and 24/7 emergency services. ">

    <link rel="canonical" href="https://www.bankersheart.com/top-10-hospital-old-padra-road-vadodara " />

    <meta property="og:title" content="Top 10 Hospital in Vadodara | Best Heart Hospital in Vadodara" />
    <meta property="og:description" content="Bankers Heart Institute is recognized among the top 10 hospitals in Vadodara, offering advanced cardiac care, angioplasty, heart surgery, diagnostics, ICU, and 24/7 emergency services. " />
    <meta property="og:url" content="https://www.bankersheart.com/top-10-hospital-old-padra-road-vadodara " />
    <meta property="og:type" content="website" />
    <meta property="og:site_name" content="Bankers Group of Hospitals" />
    <meta property="og:image" content="https://www.bankersheart.com/bankers-group-of-hospitals-og.png" />
    <meta property="og:image:alt" content="Bankers Heart Institute in Vadodara - Cardiac Care & ICU" />
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:title" content="Top 10 Hospital in Vadodara | Best Heart Hospital in Vadodara" />
    <meta name="twitter:description" content="Bankers Heart Institute is recognized among the top 10 hospitals in Vadodara, offering advanced cardiac care, angioplasty, heart surgery, diagnostics, ICU, and 24/7 emergency services. " />
    <meta name="twitter:image" content="https://www.bankersheart.com/bankers-group-of-hospitals-og.png" />
    <meta name="twitter:image:alt" content="Bankers Heart Institute in Vadodara - Cardiac Care & ICU" />
    <meta name="twitter:site" content="@BankersHospitals" />

    <style>
        #facilities-hospital .owl-nav {
            position: relative;
            bottom: 27rem !important;
        }
    </style>
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
                    <h1 class="text-white h2 text-center mb-0">Bankers Heart Institute, Old Padra Road - Vadodara</h1>
                </div>
            </div>
        </div>
    </section>



    <asp:Repeater ID="rptHospitals" runat="server">
        <ItemTemplate>
            <section id="hospital-details" class="py-5">
                <div class="container py-lg-4">
                    <div class="blog-container text-lg-start text-center pt-lg-3">
                        <%--<h2 class="clr-black fw-bold d-lg-none d-block">Bankers Heart Institute, Vadodara</h2>--%>
                        <div class="inner-img mb-lg-0 mb-4">
                            <%--  <picture>
                        <source srcset="https://www.bankersheart.com/assets/img/heart-institute-img-vadodara.webp" type="image/webp">
                        <source srcset="https://www.bankersheart.com/assets/img/heart-institute-img-vadodara.png" type="image/png">
                        <img class="img-fluid  rounded-4" src="https://www.bankersheart.com/assets/img/heart-institute-img-vadodara.png" alt="Blog-details">
                    </picture>--%>
                            <picture>
                                <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Hospitals/") + Eval("image") %>' type="image/webp">
                                <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Hospitals/") + Eval("image") %>' type="image/png">
                                <img class="img-fluid rounded-4" style="height: 250px; object-fit: cover;"
                                    src='<%# ResolveUrl("~/poweradmin/webfiles/Hospitals/") + Eval("image") %>'
                                    alt='<%# Eval("title") %>'>
                            </picture>
                        </div>
                        <div class="blogs-content">
                            <h2 class="clr-black fw-bold d-lg-block d-none"><%# Eval("title") %><%--Bankers Superspeciality Hospital, Manjalpur--%></h2>


                            <p><%# Eval("description") %></p>
                            <%-- <h2 class="clr-black fw-bold d-lg-block d-none">Bankers Heart Institute, Vadodara</h2>
                   

                    <p>A Superspeciality Cardiac Centre that offers excellent Heart Care, is built with
                        highest standards at prime and quiet location on Old Padra Road, Vadodara.</p>
                    <p>The 57 bedded Cardiac Care Centre is climate controlled & offers facilities like 24X7
                        emergency Cardiac care, ICCU attended by Physician (MD), state of the art Operation Theatre, 
                        Siemens Flat Detector (Digital) Catheterisation lab, Vivid 7 Colour Doppler Machine, 
                        Computerised Treadmill Test Machine, Round the clock Pharmacy, Pathology, Radiology & 
                        Ambulance Services. It also has essential infrastructural amenities like Generator,
                        Sterlization system,Central Oxygen & Suction system, Canteen, Communication system,
                        Medical Record Keeping etc.</p>
                    <h6 class="clr-content fw-semibold"> <i>The Institute’s objectives are:</i></h6>
                    <ul class="ps-3" style="list-style:disc;">
                        <li>To provide state of the art Cardiac centre for diagnosis, management
                            and prevention of heart diseases.</li>
                        <li>To provide medical education, awareness regarding Cardiac problems and its prevention.</li>
                        <li>To provide advanced medical facilities at affordable cost.</li>
                    </ul>--%>
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
                                        <div class="press-box">
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
                                                        alt='<%# Eval("title") + " " + String.Format("{0:D2}", Container.ItemIndex + 1) + " - Bankers Heart Institute" %>'>
                                                </picture>
                                            </a>

                                            <div class="bg-red py-3 px-2 bg-height">
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
                    <h2 class="fw-bold clr-black">Our Services</h2>
                    <div class="accordion" id="accordionExample">
                        <asp:Repeater ID="rptServices" runat="server">
                            <ItemTemplate>
                                <div class="accordion-item accord mt-3">
                                    <h2 class="accordion-header" id="heading<%# Container.ItemIndex %>">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse<%# Container.ItemIndex %>" aria-expanded="true" aria-controls="collapse<%# Container.ItemIndex %>">
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
                        <strong>Old Padra Road – Vadodara Bankers Heart Institute</strong>
                    </div>
                    <div class="row pt-3 align-items-center px-sm-0 px-2">
                        <div class="col-2 text-center">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/red-location-icon.svg" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/red-location-icon.svg" type="image/png">
                                <img class="img-fluid" src="https://www.bankersheart.com/assets/img/red-location-icon.svg" alt="red-location-icon">
                            </picture>
                        </div>
                        <div class="col-10 ps-0">
                            <p class="mb-0">
                                Near Tagore Nagar, Old Padra Road,<br class="d-lg-inline-block d-none" />
                                Vadodara - 390015, Gujarat, India
                            </p>
                        </div>
                    </div>

                    <div class="row pt-3 align-items-center px-sm-0 px-2">
                        <div class="col-2 text-center">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/red-call-icon.svg" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/red-call-icon.svg" type="image/png">
                                <img class="img-fluid" src="https://www.bankersheart.com/assets/img/red-call-icon.svg" alt="red-call-icon">
                            </picture>
                        </div>
                        <div class="col-10 ps-0">
                            <a href="tel:+91 265 2607777">+91 265 2607777</a><br class="d-md-none d-inline-block" />
                            <a href="tel:+91 265 2324004" class="ps-md-3">+91 265 2324004</a><br />
                            <a href="tel:+91 98985 40444">+91 98985 40444</a><br class="d-md-none d-inline-block" />
                            <a href="tel:+91 265 2320404" class="ps-md-3">+91 265 2320404</a>
                        </div>
                    </div>
                    <div class="row pt-3 align-items-center mb-2 px-sm-0 px-2">
                        <div class="col-2 text-center">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/email-icon-img.svg" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/email-icon-img.svg" type="image/png">
                                <img class="img-fluid" src="https://www.bankersheart.com/assets/img/email-icon-img.svg" alt="email-icon-img">
                            </picture>
                        </div>
                        <div class="col-10 ps-0">
                            <a href="mailto:info@bankersheart.com">info@bankersheart.com</a>

                        </div>
                    </div>
                    <div class="my-5 ps-3 btn-responsive text-lg-start text-center">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>appointment-bankers-group-of-hospitals" class="btn-theme btn-blue">Make An Appoinment </a>
                    </div>
                    <div>
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3691.485105221112!2d73.16172727506924!3d22.297486179688626!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395fc8b16aaaaaab%3A0xe81dd0c96aa5014d!2sBankers%20Heart%20Institute!5e0!3m2!1sen!2sin!4v1738319229786!5m2!1sen!2sin" width="100%" height="200" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                    </div>


                </div>
            </div>
        </div>
    </div>

    <div id="other-hospital">
        <div class="container pb-5">
            <div class="row pb-5">
                <h2 class="clr-black fw-bold text-center">Other Location</h2>

                <div class="col-lg-4 col-sm-6 pt-4">
                    <div class="press-box h-100">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>bankers-heart-multispeciality-hospital-warasia-vadodara">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/heart-hospital-img.webp" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/heart-hospital-img.png" type="image/png">
                                <img class="img-fluid  facilities-img-size" src="https://www.bankersheart.com/assets/img/heart-hospital-img.png" alt="Bankers Heart & Multi Specialty">
                            </picture>

                            <div class="bg-red py-3 px-2 h-100">
                                <h6 class="text-center text-white mb-0">Bankers Heart & Multi Specialty
Hospital, Warasia, Vadodara</h6>
                            </div>
                        </a>

                    </div>
                </div>
                <div class="col-lg-4 col-sm-6 pt-4">
                    <div class="press-box h-100">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>best-multispeciality-hospital-manjalpur-vadodara">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/bankers-super-hospital-majalpur.webp" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/bankers-super-hospital-majalpur.png" type="image/png">
                                <img class="img-fluid  facilities-img-size" src="https://www.bankersheart.com/assets/img/bankers-super-hospital-majalpur.png" alt="Bankers Heart Institute">
                            </picture>

                            <div class="bg-red py-3 px-2 h-100">
                                <h6 class="text-center text-white mb-0">Bankers Superspeciality Hospital, Manjalpur, Vadodara</h6>
                            </div>
                        </a>

                    </div>
                </div>

                <div class="col-lg-4 col-sm-6 pt-4">
                    <div class="press-box h-100">
                        <a href="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>heart-specialist-in-surat">
                            <picture>
                                <source srcset="https://www.bankersheart.com/assets/img/bankers-heart-hospital-surat.webp" type="image/webp">
                                <source srcset="https://www.bankersheart.com/assets/img/bankers-heart-hospital-surat.png" type="image/png">
                                <img class="img-fluid  facilities-img-size" src="https://www.bankersheart.com/assets/img/bankers-heart-hospital-surat.png" alt="Bankers Heart & Multi Specialty">
                            </picture>

                            <div class="bg-red py-3 px-2 h-100">
                                <h6 class="text-center text-white mb-0">Bankers Heart Institute<br />
                                    Umra, Surat</h6>
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
        document.addEventListener("DOMContentLoaded", function () {
            let hash = window.location.hash.substring(1); // Get the hash without '#'
            console.log("Hash from URL:", hash);

            if (hash) {
                let heading = document.getElementById(hash); // Find the heading element
                console.log("Heading element:", heading);

                if (heading) {
                    let button = heading.querySelector(".accordion-button"); // Find the accordion button
                    console.log("Accordion button:", button);

                    if (button) {
                        let collapseId = button.getAttribute("data-bs-target"); // Get target collapse ID
                        console.log("Target collapse ID:", collapseId);

                        let collapseElement = document.querySelector(collapseId); // Find the target collapse element
                        console.log("Collapse element:", collapseElement);

                        if (collapseElement) {
                            // Open the accordion using Bootstrap API
                            let bsCollapse = new bootstrap.Collapse(collapseElement, {
                                toggle: true
                            });

                            // Ensure button is marked as expanded
                            button.classList.remove("collapsed");
                            button.setAttribute("aria-expanded", "true");

                            // Scroll smoothly 50px below the opened accordion
                            setTimeout(() => {
                                let offset = heading.getBoundingClientRect().top + window.scrollY - 50;
                                window.scrollTo({ top: offset, behavior: "smooth" });
                            }, 500);
                        }
                    }
                }
            }

            // Add click event to all accordion buttons for scrolling 50px below
            document.querySelectorAll(".accordion-button").forEach(button => {
                button.addEventListener("click", function () {
                    setTimeout(() => {
                        let heading = this.closest(".accordion-header");
                        let offset = heading.getBoundingClientRect().top + window.scrollY - 30;
                        window.scrollTo({ top: offset, behavior: "smooth" });
                    }, 300);
                });
            });
        });
    </script>

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
