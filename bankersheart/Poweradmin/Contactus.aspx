<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="Contactus.aspx.cs" Inherits="bankersheart.Poweradmin.Contactus" %>

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
                <i class="icon-home"></i>
                <a href="Contactus.aspx">Contact Us</a>
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
                        View Contact Us
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <%-- <a class="btn white" href="javascript:;" data-toggle="dropdown">
                <i class="fa fa-share"></i>
                <span class="hidden-xs">Tools </span>
                <i class="fa fa-angle-down"></i>
            </a>--%>
                            <ul class="dropdown-menu pull-right">

                                <li>

                                    <asp:Button ID="btnDeleteSelected" runat="server" Text="Delete Selected" CssClass="link-button" />

                                </li>
                            </ul>
                        </div>
                        <%--        <asp:LinkButton ID="Awards_Achivement" runat="server" class="btn sbold white btn-sm" PostBackUrl="~/PowerAdmin/PatientCare/Manage_PatientsSay.aspx"><i class="fa fa-plus"></i> Add What Our Patients Say</asp:LinkButton>--%>
                    </div>
                    <%--  <div class="tools">
                            <a href="javascript:;" class="collapse" data-original-title="" title=""> </a>
                            <a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""> </a>
                            <a href="javascript:;" class="reload" data-original-title="" title=""> </a>
                            <a href="javascript:;" class="remove" data-original-title="" title=""> </a>
                        </div>--%>
                </div>
                <div class="portlet-body">
                    <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <table class="table table-striped table-bordered table-hover table-checkable order-column" id="sample_1_2">

                                <thead>
                                    <tr>
                                        <th style="width: 5%" class="hidden">
                                            <%--     <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                <input type="checkbox" class="group-checkable" data-set="#sample_1_2 .checkboxes" />
                                                <span></span>
                                            </label>
                                        </th>--%>
                                        <th style="width: 12%">Name</th>
                                        <th style="width: 15%">Email</th>
                                        <th style="width: 15%">Mobile No</th>
                                        <th style="width: 25%">Message</th>
                                        <%--                    <th style="width: 15%">Added Date</th>--%>


                                        <th style="width: 15%">Actions </th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="rpt_data" runat="server" OnItemCommand="rpt_data_ItemCommand" OnItemDataBound="rpt_data_ItemDataBound">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td class="hidden"></td>
                                                <%--  <td class="hidden">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="checkboxes" value="1" />
                                                        <span></span>
                                                    </label>
                                                    <%--<asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("id") %>' />--%>
                                                <%-- </td>--%>
                                                <td><%# Eval("firstname") %></td>
                                                <td><%# Eval("email") %></td>
                                                <td><%# Eval("phoneno") %></td>
                                                <td><%# Eval("Message") %></td>

                                                <%--                                                                            <td><%# Eval("added_date", "{0:dd/MM/yyyy}") %></td>--%>




                                                <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("id") %>' />



                                                <td>
                                                    <%--                                                    <asp:LinkButton ID="lnk_edit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex") %>' CssClass="btn btn-info"><i class="fa fa-edit"></i></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lnk_delete" runat="server" CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex") %>' CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this item?');">Delete</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </ContentTemplate>
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
            $('#contactus').addClass("start active");
            $('#contactus').addClass("open");
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#sample_1_2').dataTable({
                "aLengthMenu": [[50, 100, 500], [50, 100, 500]],
                "iDisplayLength": 50,
                "order": [[0, 'desc']]
            });


        });
    </script>
</asp:Content>
