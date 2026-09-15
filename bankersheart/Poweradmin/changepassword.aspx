<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="bankersheart.Poweradmin.changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="https://www.bankersheart.com/Poweradmin/dashboard.aspx">Home</a>
<%--                <a href="https://channelbecho.com/PowerAdmin/dashboard.aspx">Home</a>--%>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Change Password</span>
            </li>
        </ul>
    </div>
    <br />
    <br />
    <div class="card border-top border-0 border-4 border-info">
        <div class="card-title">
            <div class="row">
                <div class="col-md-6" style="text-align: left">
                    <h1 class="page-title">Change Password</h1>
                </div>
            </div>
        </div>
        <div class="card-body">

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label>Email</label><span style="color: red">*</span>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label>Current Password</label><span style="color: red">*</span>
                        <%--<div class="input-icon right" id="show_hide_password">
                            <i class="fa fa-eye"></i>
                            <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="10"></asp:TextBox>
                        </div>--%>
                        <div class="input-group" id="show_hide_password">
                            <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <a class="input-group-addon">
                                <i class="fa fa-eye"></i>
                            </a>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentPassword" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtCurrentPassword" Display="Dynamic" ValidationGroup="UserDetails" ErrorMessage="Password does not exists." ForeColor="Red"></asp:CompareValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label>New Password</label><span style="color: red">*</span>
                        <div class="input-group" id="show_hide_password1">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <a class="input-group-addon">
                                <i class="fa fa-eye"></i>
                            </a>
                        </div>
                        <asp:RegularExpressionValidator ID="rev2" runat="server" Display="Dynamic" ValidationGroup="UserDetails" ControlToValidate="txtPassword" ForeColor="Red" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label>Re-type New Password</label><span style="color: red">*</span>
                        <div class="input-group" id="show_hide_password2">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <a class="input-group-addon">
                                <i class="fa fa-eye"></i>
                            </a>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" Display="Dynamic" ValidationGroup="UserDetails" ErrorMessage="Password does not match." ForeColor="Red"></asp:CompareValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="text-center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn dark" OnClick="btnSubmit_Click" ValidationGroup="UserDetails" />
                    <a href="javascript:void(0)" onclick="location.href='<%= ConfigurationManager.AppSettings["cmspath"] + "dashboard.aspx" %>'" class="btn btn-default">Cancel</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
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

            $("#show_hide_password1 a").on('click', function (event) {
                event.preventDefault();
                if ($('#show_hide_password1 input').attr("type") == "text") {
                    $('#show_hide_password1 input').attr('type', 'password');
                    $('#show_hide_password1 i').addClass("bx-hide");
                    $('#show_hide_password1 i').removeClass("bx-show");
                } else if ($('#show_hide_password1 input').attr("type") == "password") {
                    $('#show_hide_password1 input').attr('type', 'text');
                    $('#show_hide_password1 i').removeClass("bx-hide");
                    $('#show_hide_password1 i').addClass("bx-show");
                }
            });

            $("#show_hide_password2 a").on('click', function (event) {
                event.preventDefault();
                if ($('#show_hide_password2 input').attr("type") == "text") {
                    $('#show_hide_password2 input').attr('type', 'password');
                    $('#show_hide_password2 i').addClass("bx-hide");
                    $('#show_hide_password2 i').removeClass("bx-show");
                } else if ($('#show_hide_password2 input').attr("type") == "password") {
                    $('#show_hide_password2 input').attr('type', 'text');
                    $('#show_hide_password2 i').removeClass("bx-hide");
                    $('#show_hide_password2 i').addClass("bx-show");
                }
            });
        });
    </script>
</asp:Content>
