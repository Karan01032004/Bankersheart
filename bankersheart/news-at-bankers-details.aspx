<%@ Page Title="" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="news-at-bankers-details.aspx.cs" Inherits="bankersheart.news_at_bankers_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <link rel="canonical" href="https://www.bankersheart.com/news-at-bankers-details">--%>
    <style>
        .fancybox-zoomIn {
            animation: zoomIn 0.3s ease;
        }

        .fancybox-zoomOut {
            animation: zoomOut 0.3s ease;
        }

        @keyframes zoomIn {
            from {
                transform: scale(0.8);
                opacity: 0;
            }

            to {
                transform: scale(1);
                opacity: 1;
            }
        }

        @keyframes zoomOut {
            from {
                transform: scale(1);
                opacity: 1;
            }

            to {
                transform: scale(0.8);
                opacity: 0;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <asp:Literal ID="litHeading" runat="server"></asp:Literal>
                    <h2 class="text-white text-center mb-0">News at Bankers</h2>
                    <h3></h3>
                    <h4></h4>
                    <h5></h5>
                </div>
            </div>
        </div>
    </section>
    <div id="events-release">
        <div class="container py-5">
            <div class="row py-5">
                <%-- <p class="text-center">A proud moment for Bankers Hospitals. Dr. Darshan Banker was felicitated 
                    by Pujya Gyanvatsal Swami at the Family Physician National Conference 2025 for his outstanding contributions in the 
                    field of Cardiology. This recognition reflects Bankers Hospital's unwavering commitment to delivering excellence in
                    healthcare.</p>--%>
                <div class="custom-center-label" style="text-align: justify; text-justify: inter-word;">
                    <asp:Label ID="lblCampDescription" runat="server" CssClass="custom-center-label"></asp:Label>
                </div>
                <asp:Repeater ID="rptExhibitions" runat="server">
                    <ItemTemplate>

                        <div class="col-lg-3 col-sm-6  pt-5">
                            <div class="press-box h-100 text-center">
                                <%--  <a href="assets/img/press-relase-img.png" data-fancybox="galler">

                       
                         <picture>
                            <source srcset="https://www.bankersheart.com/assets/img/press-relase-img.webp" type="image/webp">
                            <source srcset="https://www.bankersheart.com/assets/img/press-relase-img.png" type="image/png">
                            <img class="img-fluid p-3" src="https://www.bankersheart.com/assets/img/press-relase-img.png"  alt="Bankers group of hospital press release">
                        </picture>
                           </a>
                                                 <a href="https://www.bankersheart.com/assets/img/press-relase-img-2.png" data-fancybox="galler"> </a>
                                --%>
                                <a href='<%# ResolveUrl("~/poweradmin/webfiles/NewsatBankers/" + Eval("NewsatBankersImage")) %>' data-fancybox="galler">
                                    <picture>
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/NewsatBankers/") + Eval("NewsatBankersImage") %>' type="image/webp">
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/NewsatBankers/") + Eval("NewsatBankersImage") %>' type="image/png">
                                        <img class="img-fluid p-3 media-img"
                                            src='<%# ResolveUrl("~/poweradmin/webfiles/NewsatBankers/") + Eval("NewsatBankersImage") %>'
                                            alt='<%# Eval("title") + " " + String.Format("{0:D2}", Container.ItemIndex + 1) + " - Bankers Heart Institute" %>'>
                                    </picture>
                                </a>

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
        Fancybox.bind("[data-fancybox]", {
            // Enable zoom effect
            Images: {
                zoom: true,
            },
            // Optional: transition effect when opening/closing
            animated: true,
            showClass: "fancybox-zoomIn",
            hideClass: "fancybox-zoomOut",
        });
    </script>
</asp:Content>
