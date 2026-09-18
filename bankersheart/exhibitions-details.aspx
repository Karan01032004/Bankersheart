<%@ Page Title="" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="exhibitions-details.aspx.cs" Inherits="bankersheart.exhibitions_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Force justify all content inside ck-justify */
        .ck-justify,
        .ck-justify * {
            text-align: justify !important;
            text-justify: inter-word !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <!-- Invisible H1 for SEO -->
                    <h1 id="pageH1" runat="server" class="sr-only"></h1>
                    <h2 class="text-white text-center mb-0">Exhibitions</h2>
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
                <div class="custom-center-label ck-justify">
                    <asp:Label ID="lblCampDescription" runat="server" CssClass="custom-center-label"></asp:Label>

                </div>
                <asp:Repeater ID="rptExhibitions" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-sm-6 pt-5">
                            <div class="press-box h-100 text-center">
                                <a href='<%# ResolveUrl("~/poweradmin/webfiles/Exhibition/" + Eval("ExhibitionImage")) %>' data-fancybox="galler">
                                    <picture>
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Exhibition/") + Eval("ExhibitionImage") %>' type="image/webp">
                                        <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/Exhibition/") + Eval("ExhibitionImage") %>' type="image/png">
                                        <img class="img-fluid p-3 rounded-4 media-img"
                                            src='<%# ResolveUrl("~/poweradmin/webfiles/Exhibition/") + Eval("ExhibitionImage") %>'
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
</asp:Content>
