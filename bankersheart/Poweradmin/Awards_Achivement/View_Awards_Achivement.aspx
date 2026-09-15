<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="View_Awards_Achivement.aspx.cs" Inherits="bankersheart.Poweradmin.Awards_Achivement.View_Awards_Achivement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <a href="<%= ConfigurationManager.AppSettings["CMSPath"] %>/dashboard.aspx">Home</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Awards & Achivement Management</span>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span>Awards_Achivement</span>
            </li>
        </ul>

    </div>
    <!-- END PAGE BAR -->
    <!-- BEGIN PAGE TITLE-->
    <br />
    <div class="row">
        <div class="col-sm-12">
            <div id="div_Error" runat="server" class="alert alert-danger" visible="false">
                <asp:Literal ID="ltr_Error" runat="server"></asp:Literal>
            </div>
            <div id="div_Success" runat="server" class="alert alert-success" visible="false">
                <asp:Literal ID="ltr_Success" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <!-- END PAGE TITLE-->
    <!-- END PAGE HEADER-->

    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN SAMPLE TABLE PORTLET-->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        View Awards_Achivement List
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                         <%--   <a class="btn white" href="javascript:;" data-toggle="dropdown">
                                <i class="fa fa-share"></i>
                                <span class="hidden-xs">Tools </span>
                                <i class="fa fa-angle-down"></i>
                            </a>--%>
                            <ul class="dropdown-menu pull-right">

                                <li>

                                    <asp:Button ID="btnDeleteSelected" runat="server" Text="Delete Selected" CssClass="link-button" OnClick="btnDeleteSelected_Click" />

                                </li>
                            </ul>
                        </div>
                        <asp:LinkButton ID="Awards_Achivement" runat="server" class="btn sbold white btn-sm" PostBackUrl="~/Poweradmin/Awards_Achivement/Manage_Awards_Achivement.aspx"><i class="fa fa-plus"></i> Add Awards_Achivement</asp:LinkButton>
                    </div>
                    <%--  <div class="tools">
                                            <a href="javascript:;" class="collapse" data-original-title="" title=""> </a>
                                            <a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""> </a>
                                            <a href="javascript:;" class="reload" data-original-title="" title=""> </a>
                                            <a href="javascript:;" class="remove" data-original-title="" title=""> </a>
                                        </div>--%>
                </div>
                <div class="portlet-body" style="display: block;">
                    <table class="table table-striped table-bordered table-hover table-checkable order-column" id="sample_1_2">
                        <thead>
                            <tr>
                                <th style="display: none;">#</th>
                              <%--  <th style="width: 30px; text-align: center;" data-sortable="false">
                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                        <input type="checkbox" id="ckbCheckAll" onchange="checkAllCheckboxes(this)" />
                                        <span></span>
                                    </label>
                                </th>--%>
                                <%-- <th style="width: 5%" class="">
                                            <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                <input type="checkbox" class="group-checkable" data-set="#sample_1_2 .checkboxes" />
                                                <span></span>
                                            </label>
                                        </th>--%>

                                <th style="width: 20%">Title</th>
                                <th style="width: 10%">Visible</th>
                                <th style="width: 30%">Images</th>
                                <th style="width: 15%">Sort</th>
                                <th style="width: 15%">Actions </th>
                                <%--<th>Delete </th>--%>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpt_data" runat="server" OnItemCommand="rpt_data_ItemCommand" OnItemDataBound="rpt_data_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td style="display: none;">#</td>

                                       <%-- <td style="text-align: center;">
                                            <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                <asp:CheckBox ID="checkboxDelete" runat="server"
                                                    Value='<%# Eval("id") %>' />
                                                <span></span>
                                            </label>
                                        </td>--%>
                                        <td><%# Eval("title") %></td>
                                        <td>
                                            <%# Eval("visible") != DBNull.Value && Convert.ToBoolean(Eval("visible")) ? "Yes" : "No" %>
                                        </td>



                                        <td>
                                            <img src="../webfiles/Awards_Achivement/<%# Eval("banner_image") %>" width="200" />
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
                </div>
            </div>
            <!-- END SAMPLE TABLE PORTLET-->
        </div>
    </div>

    <!-- /.modal -->

    <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('ul.page-sidebar-menu > li.nav-item').removeClass("start active open");
            $('#Awards_Achivement').addClass("start active");
            $('#Awards_Achivement').addClass("open");
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#sample_1_2').dataTable({
                "aLengthMenu": [[50, 100, 500], [50, 100, 500]],
                "iDisplayLength": 50,
                "order": [[0, 'asc']]
            });


        });
    </script>


<%--<script>
    // Function to check/uncheck all checkboxes when the main checkbox (ckbCheckAll) is clicked
    function checkAllCheckboxes(source) {
        // Get all checkboxes inside the table with the class 'checkboxDelete'
        var checkboxes = document.querySelectorAll(".checkboxDelete");

        // Loop through the checkboxes and set their checked property based on the 'ckbCheckAll' checkbox
        checkboxes.forEach(function (checkbox) {
            checkbox.checked = source.checked;
        });
    }
</script>--%>
</asp:Content>


