<%@ Page Title="CardCon | Annual Heart Conference Vadodara" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="cardcon.aspx.cs" Inherits="bankersheart.cardcon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="CardCon, cardiology conference, Bankers Heart Institute, medical symposium, cardiologists, healthcare professionals, clinical cardiology, cardiac advancements">
<meta name="description" content="CardCon by Bankers Heart Institute showcases new ideas in cardiology through expert talks, case studies, and discussions.">
<link rel="canonical" href="https://www.bankersheart.com/cardcon" />

    <style>
        .blogs-content p {
    text-align: justify;       /* Align both left and right edges */
    text-justify: inter-word;  /* Proper spacing between words */
  
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="text-white h2 text-center mb-0">CardCon  <%--<span class="invisible position-absolute">Bankers</span>--%></h1>
                    <h2 class="invisible position-absolute">Bankers Group of Hospital CardCon</h2>
                    <h3></h3>
                    <h4></h4>
                    <h5></h5>

                </div>
            </div>
        </div>
    </section>

    <section id="hospital-details" class="py-5">
         <asp:Repeater ID="PlayCard" runat="server">
            <ItemTemplate>
                <div class="container py-lg-4">
                    <div class="mb-5 d-lg-flex align-items-center justify-content-center">
                        <div>
                            <a href="https://www.bankersheart.com/cardcon-registration" class="btn-theme btn-blue">CardCon 2026 </a>
                        </div>
                    </div>

                    <div class="blog-container text-lg-start text-center pt-lg-3">

                        <div class="inner-img mb-lg-0 mb-4">
                            <%--<picture>
                        <source srcset="https://www.bankersheart.com/assets/img/cardcon-img-bankers.webp" type="image/webp">
                        <source srcset="https://www.bankersheart.com/assets/img/cardcon-img-bankers.png" type="image/png">
                        <img class="img-fluid  rounded-4 pb-4" src="https://www.bankersheart.com/assets/img/cardcon-img-bankers.png" alt="CardCon">
                    </picture>--%>
                            <picture>
                                <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/PlayCard/") + Eval("image") %>' type="image/webp">
                                <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/PlayCard/") + Eval("image") %>' type="image/png">
                                <img class="img-fluid  rounded-4 pb-4"
                                    src='<%# ResolveUrl("~/poweradmin/webfiles/PlayCard/") + Eval("image") %>'
                                    alt='<%# Eval("title") %>' loading="lazy">
                            </picture>
                        </div>
                        <div class="blogs-content">
                            <%# Eval("description") %>


                            <%--  <p><b>Banker's Group Of Hospitals</b> is successfully organizing Cardiac Conferences 
                        since 2005. This is our humble attempt towards clinical cardiology training and updates.</p>

                    <p><b>The Bankers Group of Hospitals</b> has been organizing a symposium to discuss various 
                        cardiological advances, as well as challenges, since many years. The aim of this Cardiological 
                        Conference is to provide a platform for cardiologists, cardiac surgeons and doctors of other
                        specialities to deliberate over various topics pertaining to cardiac health.</p>
                    <p><b>The CardCon 2015</b> aimed at studying the gaps in clinical cardiology and trying to
                        arrive at a solution to bridge those gaps. This year's conference was attended by over 
                        650 doctors from Gujarat, Madhya Pradesh and Uttar Pradesh. The conference covered basic 
                        subjects like emergencies, ECGs, Echocardiography and the daily clinical challenges faced
                        by the surgeons. Renowned surgeons and doctors shared their real life experiences and 
                        learnings with other participants of the conference. The enthused crowd appreciated each
                        session organized by the hospital and there were lively discussions 
                        throughout the conference.</p>
                    <p>This year's CardCon felicitated Dr Darshan Banker and his outstanding academic
                        performance. It is a matter of great pride for us that his article has been published in
                        the most prestigious medical journal, The New England Journal of Medicine.</p>--%>
                        </div>


                    </div>

                </div>
                                                          </ItemTemplate>
</asp:Repeater>
                </section>
        <div id="press-release">
        <div class="container pb-5">
            <div class="row">
                                        <asp:Repeater ID="rptAwards" runat="server">
<ItemTemplate>
                <%--<h3 class="clr-black fw-semibold text-center">Honoured with awards for Excellence and Innovation</h3>--%>
                <div class="col-lg-3 col-sm-6  pt-5">
      
                    <div class="press-box h-100 position-relative text-center">
                         <a href='<%# ResolveUrl("~/poweradmin/webfiles/PlayCard/") + Eval("image") %>' data-fancybox="gallery">
                      <%--   <picture>
                            <source srcset="https://www.bankersheart.com/assets/img/press-relase-img.webp" type="image/webp">
                            <source srcset="https://www.bankersheart.com/assets/img/press-relase-img.png" type="image/png">
                            <img class="img-fluid p-3" src="https://www.bankersheart.com/assets/img/press-relase-img.png"  alt="Bankers group of hospital press release">
                        </picture>--%>
                               <picture>
      <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/PlayCard/") + Eval("image") %>' type="image/webp">
      <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/PlayCard/") + Eval("image") %>' type="image/png">
      <img class="img-fluid  media-img"
          src='<%# ResolveUrl("~/poweradmin/webfiles/PlayCard/") + Eval("image") %>'
           alt='<%# "GalleryImage " + (Container.ItemIndex + 1).ToString() + " - Bankers Heart Institute" %>' loading="lazy">
  </picture>
                             </a>
                 <%--       <div class="ribbon ribbon-top-left">
                            <span class="avail"><%# Eval("PressReleases_Date", "{0:dd MMM yyyy}") %></span>

                            </div>
                        <div class="bg-red py-3 px-2 h-100">
                            <p class="text-center text-white mb-0"> <%# Eval("title") %></p>
                        </div>--%>
                        
                    </div>
                </div>
                            </ItemTemplate>
</asp:Repeater>
     
            </div>
                                    <div class="row pt-5 mt-3 justify-content-center text-center">
    <asp:PlaceHolder ID="PaginationAwardsPlaceholder" runat="server"></asp:PlaceHolder>
</div>
        </div>
    </div>

</asp:Content>
                <asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
                </asp:Content>
