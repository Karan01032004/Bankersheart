<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="email-settings.aspx.cs" Inherits="bankersheart.Poweradmin.email_settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="<%=ConfigurationManager.AppSettings["CMSPath"].ToString() %>dashboard.aspx">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Email Settings</span>
            </li>
        </ul>
    </div>

    <!-- /.row -->
    <div class="row" id="career" runat="server">
        <div class="col-lg-12">
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class="portlet light bordered">
                <div class="portlet-title">
                    <div class="caption font-dark">
                        <i class="icon-settings font-black font-dark"></i>
                        <span class="caption-subject font-black bold uppercase">Email Settings</span>
                    </div>

                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label>Hostname <span class="font-red">*</span></label>
                                <asp:TextBox ID="txt_Hostname" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Hostname" ErrorMessage="Hostname" SetFocusOnError="True" ValidationGroup="vgValidate" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label>Username <span class="font-red">*</span></label>
                                <div class="input-icon right">
                                    <i class="fa fa-user"></i>
                                    <asp:TextBox ID="txt_Username" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Username" ErrorMessage="Username" SetFocusOnError="True" ValidationGroup="vgValidate" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-12">
                            
                            <div class="col-md-6">
                                <label>Password <span class="font-red">*</span></label>
                                <div class="input-icon right input-group" id="show_hide_password">
                                    <%--<i class="fa fa-eye" onmouseover="showpassword();" onmouseout="hidepassword();"></i>--%>
                                    <asp:TextBox ID="txt_Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <a class="input-group-addon">
                                        <i class="fa fa-eye"></i>
                                    </a>

                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Password" ErrorMessage="Password" SetFocusOnError="True" ValidationGroup="vgValidate" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label>To Email <span class="font-red">*</span></label>
                                <div class="input-icon right">
                                    <i class="fa fa-envelope"></i>
                                    <asp:TextBox ID="txt_Tomail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Tomail" ErrorMessage="Invalid Email Address" ValidationGroup="vgValidate" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Tomail" ErrorMessage="To Email" SetFocusOnError="True" ValidationGroup="vgValidate" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label>CC Email</label>
                                <div class="input-icon right">
                                    <i class="fa fa-envelope"></i>
                                    <asp:TextBox ID="txt_Ccmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Ccmail" ErrorMessage="Invalid Email Address" ValidationGroup="vgValidate" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-6">
                                <label>BCC Email</label>
                                <div class="input-icon right">
                                    <i class="fa fa-envelope"></i>
                                    <asp:TextBox ID="txt_Bccmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Bccmail" ErrorMessage="Invalid Email Address" ValidationGroup="vgValidate" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row text-center">
                    <div class="form-group">
                        <div class="col-md-12">                            
                            <asp:Button ID="btnSave" runat="server" CssClass="btn dark" Text="Submit" OnClick="btnSave_Click" ValidationGroup="Careerform" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" class="btn default" Text="Cancel" />
                        </div>
                    </div>
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
        });
    </script>
</asp:Content>


