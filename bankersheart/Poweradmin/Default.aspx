<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="bankersheart.Poweradmin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Bankersheart</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #1 for " name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/pages/css/login.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<body class=" login">
    <!-- BEGIN LOGO -->
    <div class="logo">
      <%-- <a href="default.aspx">
                <img src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/pages/img/bankerslogo.png" alt="" />
       </a>--%>
    </div>
    <!-- END LOGO -->
    <!-- BEGIN LOGIN -->
    <div class="content">

        <form runat="server">
            <!-- BEGIN LOGIN FORM -->

            <div class="login-form" method="post" runat="server">
                <br />
                
              <%--  <h3 class="form-title font-green bg-gradient">Sign In</h3>--%>
   <a href="default.aspx" style="display: block; text-align: center;">
    <img src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/pages/img/bankerslogo.png" alt="" style="width:300px; display: inline-block;"/>
</a>

                <br />
                <br />
               
                <div id="div_Error" runat="server" class="alert alert-danger" visible="false">
                    <asp:Literal ID="ltr_Error" runat="server"></asp:Literal>
                </div>
                <div id="div_Success" runat="server" class="alert alert-success" visible="false">
                    <asp:Literal ID="ltr_Success" runat="server"></asp:Literal>
                </div>
                <div class="alert alert-danger display-hide">
                    <button class="close" data-close="alert"></button>
                    <span>Enter any username and password. </span>
                </div>
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">Username</label>
                    <asp:TextBox ID="txt_username" runat="server" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rv_username" runat="server" ControlToValidate="txt_username" ErrorMessage="Username" ForeColor="Red" ValidationGroup="login" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="input-group" id="show_hide_password">
                        <asp:TextBox ID="txt_password" runat="server" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <a class="input-group-addon">
                            <i class="fa fa-eye"></i>
                        </a>
                    </div>
                    <asp:RequiredFieldValidator ID="rv_password" runat="server" ControlToValidate="txt_password" ErrorMessage="Password" ForeColor="Red" ValidationGroup="login" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btn_submit" runat="server" Text="Login" CssClass="btn green uppercase"  OnClick="btn_submit_Click"/>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a value in the following fields:" ShowMessageBox="True" ShowSummary="False" ValidationGroup="log_1" />
                    <label class="rememberme check mt-checkbox mt-checkbox-outline">
                        <asp:CheckBox ID="chkRemember" runat="server" value="1" />Remember
                        <span></span>
                    </label>
                    <a href="javascript:;" id="forget-password" class="forget-password">Forgot Password?</a>
                </div>
            </div>
            <!-- END LOGIN FORM -->
            <!-- BEGIN FORGOT PASSWORD FORM -->
            <div class="forget-form" action="default.aspx" method="post">
                <h3 class="font-green">Forget Password ?</h3>
                <p>Enter your e-mail address below to reset your password. </p>
                <div class="form-group">
                    <asp:TextBox ID="txt_email" runat="server" CssClass="form-control placeholder-no-fix" autocomplete="off" placeholder="Email"></asp:TextBox>
                </div>
                <div class="form-actions">
                    <button type="button" id="back-btn" class="btn green btn-outline">Back</button>
                    <asp:Button ID="btn_send" runat="server" CssClass="btn btn-success uppercase pull-right" Text="Submit"  OnClick="btn_send_Click"/>
                </div>
            </div>
            <!-- END FORGOT PASSWORD FORM -->
            <!-- BEGIN REGISTRATION FORM -->

            <!-- END REGISTRATION FORM -->
        </form>
    </div>
    <!--[if lt IE 9]>
<script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/respond.min.js"></script>
<script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/excanvas.min.js"></script> 
<script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/ie8.fix.min.js"></script> 
<![endif]-->
    <!-- BEGIN CORE PLUGINS -->
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/pages/scripts/login.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME LAYOUT SCRIPTS -->
    <!-- END THEME LAYOUT SCRIPTS -->
    <script>
        $(document).ready(function () {
            $('#clickmewow').click(function () {
                $('#radio1003').attr('checked', 'checked');
            });
        })
    </script>
    <script>
        $(document).ready(function () {
            $("#show_hide_password a").on('click', function (event) {
                event.preventDefault();
                if ($('#show_hide_password input').attr("type") == "text") {
                    $('#show_hide_password input').attr('type', 'password');
                    $('#show_hide_password i').addClass("bx-hide");
                    $('#show_hide_password i').removeClass("bx-show");
                } else if ($('#show_hide_password input').attr("type") == "password") {
                    $('#show_hide_password input').attr('type', 'text');
                    $('#show_hide_password i').removeClass("bx-hide");
                    $('#show_hide_password i').addClass("bx-show");
                }
            });
        });
    </script>
</body>
</html>
