<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="View_DoctorsDetails.aspx.cs" Inherits="bankersheart.Poweradmin.Doctors_Details.View_DoctorsDetails" %>


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
                <a href="https://www.bankersheart.com/Poweradmin/dashboard.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <i class="icon-home"></i>
                <a href="https://www.bankersheart.com/Poweradmin/Doctors%20Details/view_DoctorsDetails.aspx">Doctors Details</a>
                <i class="fa fa-angle-right"></i>
            </li>
        </ul>
    </div>
    <br />
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="div_Error" runat="server" class="alert alert-danger" visible="false">
            <asp:Literal ID="ltr_Error" runat="server"></asp:Literal>
        </div>
        <div id="div_Success" runat="server" class="alert alert-success" visible="false">
            <asp:Literal ID="ltr_Success" runat="server"></asp:Literal>
        </div>
         </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rpt_data" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>
        <div class="col-md-12">
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        View Doctors Details
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
                        <asp:LinkButton ID="Awards_Achivement" runat="server" class="btn sbold white btn-sm" PostBackUrl="~/PowerAdmin/Doctors Details/Manage_DoctorsDetails.aspx"><i class="fa fa-plus"></i> Add Doctor Details</asp:LinkButton>
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
                                        <th style="width: 20%">Doctor Name</th>
                                        <th style="width: 15%">Doctor Profession</th>
                                        <th style="width: 20%">Doctor specialties</th>
                                        <th style="width: 15%">Image</th>
                                        <th style="width: 15%">Sort</th>

                                        <th style="width: 20%">Actions </th>
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
                                                <td><%# Eval("Name") %></td>
                                                <td><%# Eval("profession") %></td>
                                                <td><%# Eval("specialties") %></td>



                                                <td>
                                                    <img src='<%# ResolveUrl("~/Poweradmin/Webfiles/DoctorDetails/" + Eval("image")) %>' width="200" />

                                                    <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("id") %>' />
                                                </td>

                                                <td>
                                                    <asp:HiddenField ID="hdnDisId" runat="server" Value='<%#Eval("sortorder") %>' />
                                                    <div style="display: flex; align-items: center;">
                                                        <asp:TextBox ID="txt_displayorder" CssClass="form-control" runat="server" Text='<%#Eval("sortorder") %>' Width="70%"></asp:TextBox>
                                                        <asp:Button ID="btn_sortorder" CssClass="btn btn-primary btn-sm" Text="Go" CommandName="Sort" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex") %>' runat="server" Style="height: 35px;" />
                                                    </div>
                                                </td>

                                                <td>
                                                    <asp:LinkButton ID="lnk_edit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex") %>' CssClass="btn btn-info"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnk_delete" runat="server" CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex") %>' CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this item?');"><i class="fa fa-trash"></i></asp:LinkButton>
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
            $('#DoctorsDetail').addClass("start active");
            $('#DoctorsDetail').addClass("open");
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

