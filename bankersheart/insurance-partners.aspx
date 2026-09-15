<%@ Page Title="" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="insurance-partners.aspx.cs" Inherits="bankersheart.insurance_partners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="canonical" href="https://www.bankersheart.com/insurance-partners">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h2 class="text-white text-center mb-0">Insurance Partners</h2>
                </div>
            </div>
        </div>
    </section>
    <div id="partners-ship">
        <div class="container py-5">
            <div class="row pb-5">
                   <asp:Repeater ID="rptAwards" runat="server">
    <ItemTemplate>
                <div class="col-lg-3 col-sm-4 col-6 pt-5">
                    <div class="press-box text-center h-100">
                <a href='<%# ResolveUrl("~/poweradmin/webfiles/insurance_partners/") + Eval("image") %>' data-fancybox="gallery">

                    
              <%--      <picture>
                        <source srcset="https://www.bankersheart.com/assets/img/insurence-logo-1.webp" type="image/webp">
                        <source srcset="https://www.bankersheart.com/assets/img/insurence-logo-1.png" type="image/png">
                        <img class="img-fluid p-3" src="https://www.bankersheart.com/assets/img/insurence-logo-1.png" alt="medical-support-img">
                    </picture>--%>
                             <picture>
     <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/insurance_partners/") + Eval("image") %>' type="image/webp">
     <source srcset='<%# ResolveUrl("~/poweradmin/webfiles/insurance_partners/") + Eval("image") %>' type="image/png">
     <img class="img-fluid p-3"
          src='<%# ResolveUrl("~/poweradmin/webfiles/insurance_partners/") + Eval("image") %>' 
          alt='<%# Eval("title") %>'>
 </picture>
                            <div class="bg-red py-2 px-2 h-100">

                          
                    <h6 class="clr-black fw-semibold  text-center text-white mb-0"> <%# Eval("title") %></h6>
                                  </div>
                            </a>
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
