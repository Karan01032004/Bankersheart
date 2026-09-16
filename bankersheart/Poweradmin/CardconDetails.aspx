<%@ Page Title="Cardcon Registration Details" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="CardconDetails.aspx.cs" Inherits="bankersheart.Poweradmin.CardconDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-control[readonly] {
            background-color: #f9f9f9;
            cursor: not-allowed;
        }
        .badge-status {
            font-size: 13px;
            padding: 5px 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="icon-home"></i>
                <a href="dashboard.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="ViewCardcon.aspx">Cardcon Registrations</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <span>Registration Details</span>
            </li>
        </ul>
    </div>
    <br />

    <div class="row">
        <div id="div_Error" runat="server" class="alert alert-danger" visible="false">
            <asp:Literal ID="ltr_Error" runat="server"></asp:Literal>
        </div>
        <div id="div_Success" runat="server" class="alert alert-success" visible="false">
            <asp:Literal ID="ltr_Success" runat="server"></asp:Literal>
        </div>

        <div class="col-md-12">
            <!-- BEGIN SAMPLE FORM PORTLET-->
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption font-blue-sharp">
                        <i class="icon-user font-blue-sharp"></i>
                        <span class="caption-subject font-blue-sharp bold uppercase">Cardcon Registration Details</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn sbold blue-sharp" href="ViewCardcon.aspx">
                                <i class="fa fa-arrow-left"></i> Back to List
                            </a>
                        </div>
                    </div>
                </div>

                <div class="portlet-body">
                    <!-- Row 1: Personal Names -->
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bold">First Name</label>
                                <asp:TextBox ID="txt_FirstName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        
                    </div>

                    <!-- Row 2: Qualification & Birth Date -->
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bold">Qualification</label>
                                <asp:TextBox ID="txt_Qualification" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bold">Birth Date</label>
                                <asp:TextBox ID="txt_BirthDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Row 3: Contact Info -->
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bold">Phone No</label>
                                <asp:TextBox ID="txt_PhoneNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bold">Mobile No</label>
                                <asp:TextBox ID="txt_MobileNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bold">Email Address</label>
                                <asp:TextBox ID="txt_Email" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bold">City</label>
                                <asp:TextBox ID="txt_City" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bold">Area</label>
                                <asp:TextBox ID="txt_Area" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Row 4: Address -->
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="bold">Clinic / Hospital / Residence Address</label>
                                <asp:TextBox ID="txt_Address" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Row 5: Accommodation & Submission Date -->
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bold">Accommodation Requested</label>
                                <div>
                                    <asp:Literal ID="ltr_Accommodation" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
    <div class="form-group">
        <label class="bold">Payment Status (Is Paid?)</label>
        <div>
            <asp:Literal ID="ltr_IsPaid" runat="server"></asp:Literal>
        </div>
    </div>
</div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bold">Registered Date</label>
                                <asp:TextBox ID="txt_CreatedDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions text-center" style="margin-top: 30px; border-top: 1px solid #e7ecf1; padding-top: 20px;">
                        <asp:Button ID="btn_Back" runat="server" CssClass="btn default" Text="Back" OnClick="btn_Back_Click" />
                    </div>
                </div>
            </div>
            <!-- END SAMPLE FORM PORTLET-->
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
    <script>
        $(document).ready(function () {
            $('ul.page-sidebar-menu > li.nav-item').removeClass("start active open");
            $('#cardcon').addClass("start active open");
        });
    </script>
</asp:Content>