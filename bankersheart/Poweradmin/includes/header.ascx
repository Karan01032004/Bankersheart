<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="bankersheart.Poweradmin.includes.header" %>

<div class="page-header navbar navbar-fixed-top">

    <!-- BEGIN HEADER INNER -->
    <div class="page-header-inner ">
        <!-- BEGIN LOGO -->
        <div class="page-logo">
            <div class="col-md-10 col-sm-10 col-lg-10 col-xs-10">
                <br />
         <a href="dashboard.aspx">
<p style="margin-top: -10px; color:white;">Bankers Group Of Hospitals</p>
<%--    <img src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/pages/img/bankerslogo.png" alt="logo" class="logo-default" style="width: 170px;  margin-left: -10px;" />--%>
    <%--<img src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/pages/img/logo-big.png" alt="" class="logo-default" />--%>
</a>

            </div>
            <div class="col-md-2">
                <div class="menu-toggler sidebar-toggler">
                    <span></span>
                </div>
            </div>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN RESPONSIVE MENU TOGGLER -->
        <a href="javascript:;" class="menu-toggler responsive-toggler" data-toggle="collapse" data-target=".navbar-collapse">
            <span></span>
        </a>
        <!-- END RESPONSIVE MENU TOGGLER -->
        <!-- BEGIN TOP NAVIGATION MENU -->
        <div class="top-menu">
            <ul class="nav navbar-nav pull-right">
                <!-- BEGIN NOTIFICATION DROPDOWN -->

                <li class="dropdown dropdown-user">
                    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                        <%--<img alt="" class="img-circle" src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/layouts/layout/img/avatar3_small.jpg" />--%>
<span class="username username-hide-on-mobile" id="spanUsername" runat="server"></span>
                        <i class="fa fa-angle-down"></i>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-default">
                        <li class="divider"></li>
                        <li>
                            <a href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>changepassword.aspx">
                                <i class="fa fa-user"></i>Change Password
                            </a>
                        </li>
                        <li>
                            <a href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>email-settings.aspx">
                                <i class="fa fa-user"></i>Email Settings
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>logout.aspx">
                                <i class="icon-key"></i>Log Out
                            </a>
                        </li>
                    </ul>
                </li>
                <!-- END USER LOGIN DROPDOWN -->
                <!-- BEGIN QUICK SIDEBAR TOGGLER -->
                <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->

                <!-- END QUICK SIDEBAR TOGGLER -->
            </ul>
        </div>
        <!-- END TOP NAVIGATION MENU -->
    </div>
    <!-- END HEADER INNER -->
</div>
