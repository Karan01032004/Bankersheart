<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="view-Scrolling-Message.aspx.cs" Inherits="bankersheart.Poweradmin.ScrollingMessageManagement.view_Scrolling_Message" %>
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
                <a href="https://www.bankersheart.com/Poweradmin/ScrollingMessageManagement/View-Scrolling-Message.aspx">Scrolling Message</a>
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
        View Scrolling-Message
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
<%--        <asp:LinkButton ID="Awards_Achivement" runat="server" class="btn sbold white btn-sm" PostBackUrl="~/PowerAdmin/ScrollingMessageManagement/Add-Scrolling-Message.aspx"><i class="fa fa-plus"></i> Add Scrolling-Message</asp:LinkButton>--%>
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
                                            <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                <input type="checkbox" class="group-checkable" data-set="#sample_1_2 .checkboxes" />
                                                <span></span>
                                            </label>
                                        </th>
                                        <th style="width: 20%">Message</th>
                                        <th style="width: 15%">Visible</th>
                                       
                                        <th style="width: 10%">Actions </th>
                                    </tr>
                                </thead>

                                <tbody>
                                  <asp:Repeater ID="rpt_data" runat="server" OnItemCommand="rpt_data_ItemCommand" OnItemDataBound="rpt_data_ItemDataBound">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td class="hidden">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="checkboxes" value="1" />
                                                        <span></span>
                                                    </label>
                                                <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("Id") %>' />-
                                                </td>
                                                <td><%# Eval("title") %></td>
                                                <td>
                                                    <%# Eval("IsVisible") != DBNull.Value && Convert.ToBoolean(Eval("IsVisible")) ? "Yes" : "No" %>
                                                </td>

                                                <td>
                                                    <asp:LinkButton ID="lnk_edit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex") %>' CssClass="btn btn-info"><i class="fa fa-edit"></i></asp:LinkButton>
<%--                                                    <asp:LinkButton ID="lnk_delete" runat="server" CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container,"ItemIndex") %>' CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this item?');"><i class="fa fa-trash"></i></asp:LinkButton>--%>
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
             $('#sample_1_2').dataTable({
                 "aLengthMenu": [[50, 100, 500], [50, 100, 500]],
                 "iDisplayLength": 50,
                 "order": [[0, 'desc']]
             });

             $('ul.page-sidebar-menu > li.nav-item').removeClass("start active open");
             $('#ScrollingMessage').addClass("start active");
             $('#ScrollingMessage').addClass("open");
         });
     </script>
</asp:Content>

