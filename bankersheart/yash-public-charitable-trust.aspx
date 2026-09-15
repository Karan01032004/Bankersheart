<%@ Page Title="Yash Public Charitable Trust | Bankers Heart" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="yash-public-charitable-trust.aspx.cs" Inherits="bankersheart.yash_public_charitable_trust" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta name="description" content="Yash Public Charitable Trust offers healthcare, education, and community welfare programs to support underprivileged communities.">
    <meta name="keywords" content="Yash Public Charitable Trust, Bankers Heart CSR, medical camps, community welfare, disaster relief, educational support, women empowerment, Multi-specialty Hospital Gujarat">
    <link rel="canonical" href="https://www.bankersheart.com/yash-public-charitable-trust">
    <style>
        iframe {
            width: 100%;
            height: 600px;
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="sr-only">Charitable Trust</h1>

                    <h2 class="text-white text-center mb-0">Yash Public Charitable Trust</h2>
                    <h3></h3>
                    <h4></h4>
                    <h5></h5>
                </div>
            </div>
        </div>
    </section>
    <div id="charitable-trust">
        <div class="container py-5">
            <div class="row py-5 justify-content-center">
                <%--  <div class="col-9">
                    <iframe id="pdfViewer" src="https://www.bankersheart.com/assets/pdf/yesh-charitabl-book-final.pdf#page=1&view=fit"></iframe>
                </div>--%>
                <div class="col-9 d-md-block d-none">
                    <iframe id="pdfViewer" runat="server" src=""></iframe>
                </div>
                <div class="col-sm-6 d-md-none d-block">
                    <div class="box-shadow-date h-100">

                        <picture>
                            <source srcset="https://www.bankersheart.com/assets/img/yash-pdf-img.webp" type="image/webp">
                            <source srcset="https://www.bankersheart.com/assets/img/yash-pdf-img.png" type="image/png">
                            <img class="img-fluid object-fit-cover" src="https://www.bankersheart.com/assets/img/yash-pdf-img.png" alt="yash">
                        </picture>

                        <div class="my-5 text-center">
                            <a href="https://www.bankersheart.com/assets/pdf/yash-charitabl-book-final.pdf" class="btn-theme btn-blue" target="_blank" download="">Download Pdf</a>
                        </div>
                    </div>

                </div>


            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
</asp:Content>
