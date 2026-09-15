<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="bankersheart.Poweradmin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
    <script>
    $(document).ready(function () {
        $('ul.page-sidebar-menu > li.nav-item').removeClass("start active open");
        $('#dashboard').addClass("start active");
        $('#dashboard').addClass("open");
    });
    </script>
</asp:Content>
