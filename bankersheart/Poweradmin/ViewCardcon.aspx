<%@ Page Title="Cardcon Registrations" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="ViewCardcon.aspx.cs" Inherits="bankersheart.Poweradmin.ViewCardcon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .link-button {
            background: none;
            border: none;
            color: #007bff;
            text-decoration: none;
            cursor: pointer;
            padding: 0;
        }

        .link-button:hover {
            text-decoration: underline;
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
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        View Cardcon Registrations
                    </div>
                    <div class="actions">
        <asp:LinkButton ID="btnExportExcel" runat="server" CssClass="btn btn-sm green-jungle" OnClick="btnExportExcel_Click">
            <i class="fa fa-file-excel-o"></i> Export to Excel
        </asp:LinkButton>
    </div>
                </div>
                <div class="portlet-body">
                    <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <table class="table table-striped table-bordered table-hover table-checkable order-column" id="sample_1_2">
                                <thead>
                                    <tr>
                                        <th style="width: 25%">Full Name</th>
                                        <th style="width: 18%">Email</th>
                                        <th style="width: 15%">Mobile No</th>
                                        <th style="width: 15%">Qualification</th>
                                        <th style="width: 15%">City</th>
                                        <th style="width: 15%">Is Paid bill</th>
                                        <th style="width: 10%">Accomodation</th>
                                        <th style="width: 15%">Registered Date</th>
                                        <th style="width: 25%">Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpt_data" runat="server" OnItemCommand="rpt_data_ItemCommand">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td><%# Eval("FullName") %></td>
                                                <td><%# Eval("Email") %></td>
                                                <td><%# Eval("MobileNo") %></td>
                                                <td><%# Eval("Qualification") %></td>
                                                <td><%# Eval("City") %></td>
                                                <td><%# Eval("IsPaidBill") %></td>
                                                <td><%# Eval("AccommodationReq") %></td>
                                                <td><%# Eval("CreatedDate", "{0:dd/MM/yyyy hh:mm tt}") %></td>
                                                <td>
                                                    <!-- View Details Button -->
                                                    <a href='<%# "CardconDetails.aspx?id=" + Eval("Id") %>' class="btn btn-xs btn-info">
                                                        <i class="fa fa-eye"></i> View
                                                    </a>
                                                    
                                                    <!-- Delete Button -->
                                                    <asp:LinkButton ID="lnk_delete" runat="server" 
                                                        CommandName="delete" 
                                                        CommandArgument='<%# Eval("Id") %>' 
                                                        CssClass="btn btn-xs btn-danger" 
                                                        OnClientClick="return confirm('Are you sure you want to delete this registration?');">
                                                        <i class="fa fa-trash"></i> Delete
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
        <asp:PostBackTrigger ControlID="btnExportExcel" />
    </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <!-- END EXAMPLE TABLE PORTLET-->
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
    <script>
        function initDataTable() {
            if ($.fn.DataTable.isDataTable('#sample_1_2')) {
                $('#sample_1_2').DataTable().destroy();
            }
            $('#sample_1_2').dataTable({
                "aLengthMenu": [[50, 100, 500], [50, 100, 500]],
                "iDisplayLength": 50,
                "order": [[3, 'desc']] // Sort by Date descending
            });
        }

        $(document).ready(function () {
            initDataTable();
        });

        // Re-initialize DataTable after UpdatePanel async postback
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            initDataTable();
        });
    </script>
</asp:Content>