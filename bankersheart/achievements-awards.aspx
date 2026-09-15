<%@ Page Title="Bankers Heart Institute – Awards & Recognition" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="achievements-awards.aspx.cs" Inherits="bankersheart.achievements_awards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="Bankers Heart Institute, healthcare awards, hospital achievements, cardiac care excellence, best hospital in Gujarat, medical innovation, IMA awards, Times of India recognition, hospital CSR awards, Dr. Darshan Banker">
<%--<meta name="description" content="Award-winning cardiac care and medical excellence at Bankers Heart Institute, Surat.">--%>
        <!-- ✅ Description made server-side -->
    <meta id="metaDescription" runat="server" name="description" content="" />
        <link id="canonicalLink" runat="server" rel="canonical" href="https://www.bankersheart.com/achievements-awards" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
            <!-- Hidden SEO H1 -->
                <h1 id="pageH1" runat="server" class="sr-only"></h1>
                    <h2 class="text-white text-center mb-0">Achievements and Awards</h2>
                </div>
            </div>
        </div>
    </section>
    <div id="press-release">
        <div class="container py-5">
            <div class="row py-5">
                <h3 class="clr-black fw-semibold text-center">Honoured with awards for Excellence and Innovation</h3>
                <h4></h4>
                <h5></h5>
              <%--  <div class="col-lg-3 col-sm-6  pt-5">
                    <div class="press-box h-100">
                         <picture>
                            <source srcset="https://www.bankersheart.com/assets/img/press-relase-img.webp" type="image/webp">
                            <source srcset="https://www.bankersheart.com/assets/img/press-relase-img.png" type="image/png">
                            <img class="img-fluid p-3" src="https://www.bankersheart.com/assets/img/press-relase-img.png"  alt="Bankers group of hospital press release">
                        </picture>
                        <div class="bg-red py-3 px-2 h-100">
                            <p class="text-center text-white mb-0">Dr. darshan banker felicitated clinical excellence award by FFPAI</p>
                        </div>
                        
                    </div>
                </div>--%>

   <asp:Repeater ID="rptAwards" runat="server">
    <ItemTemplate>
        <div class="col-lg-3 col-sm-6 pt-5">
            <div class="press-box h-100">
                <a href='<%# ResolveUrl("~/poweradmin/webfiles/Awards_Achivement/") + Eval("banner_image") %>' data-fancybox="gallery">
                <picture>
                    <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Awards_Achivement/") + Eval("banner_image") %>' type="image/webp">
                    <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Awards_Achivement/") + Eval("banner_image") %>' type="image/png">
                    <img class="img-fluid p-3 media-img" 
                         src='<%# ResolveUrl("~/poweradmin/webfiles/Awards_Achivement/") + Eval("banner_image") %>' 
                         alt='<%# Eval("title") %>'>
                </picture>
                    </a>
                <div class="bg-red py-3 px-2 h-100">
                    <p class="text-center text-white mb-0">
                        <%# Eval("title") %>
                    </p>
                </div>
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
