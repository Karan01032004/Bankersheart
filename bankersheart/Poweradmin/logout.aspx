<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="bankersheart.Poweradmin.logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">LOGOUT</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
     <div class="row">
        <div class="col-lg-12" style="text-align:center;">
            
         <h4>   You have successfully logout.<br /><br />
           
             You are being redirected to login page. Please wait....<br /><br />

               <img src="<%=ConfigurationManager.AppSettings["siteurl"].ToString() %>assets/img/wait.gif" /><br /><br />
         </h4>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
</asp:Content>
