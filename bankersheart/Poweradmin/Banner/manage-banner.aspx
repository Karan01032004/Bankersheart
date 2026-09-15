<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="manage-banner.aspx.cs" Inherits="bankersheart.Poweradmin.Banner.manage_banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input[type=radio] {
            margin: 4px 5px 0;
        }

        input[type=checkbox], input[type=radio] {
            margin: 4px 5px 0;
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
                <a href="https://www.bankersheart.com/Poweradmin/Banner/view-banner.aspx">Banner</a>
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
        <div class="col-md-12 ">
            <!-- BEGIN SAMPLE FORM PORTLET-->
            <div class="portlet light ">
                <div class="portlet-title">
                    <div class="caption font-red-sunglo">
                        <i class="icon-social-dribbble font-blue-sharp"></i>
                        <span class="caption-subject font-blue-sharp bold uppercase">Manage Banner</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn sbold blue-sharp" href="javascript:;" onclick="location.href='https://www.bankersheart.com/Poweradmin/Banner/view-banner.aspx'">Back</a>

                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Visible on front end?</label><span style="color: red">*</span>
                                     <asp:RadioButtonList ID="rbl_visible" runat="server" RepeatDirection="vertical" class="custom-radio-list" >
                                        <asp:ListItem Value="1" Text="Yes" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                           <%-- <div class="col-md-6">
                                <div class="form-group">
                                    <label>Is Mobile Banner?</label><span style="color: red">*</span><br />
                                   <asp:CheckBox ID="chk_type" runat="server" />
                                <label>Yes</label>
                                </div>
                            </div>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Title</label><span style="color: red">*</span>&nbsp&nbsp[Note: Title which is going to display on Home Page]
                                    <asp:TextBox ID="txt_Title" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvtitle" runat="server" ControlToValidate="txt_Title" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                             <div class="form-group">
                                    <div class="row">
                                    
                                       

                          <div class="col-md-12">
                              <div class="form-group">
                                  <label>Description</label><span style="color: red">*</span>&nbsp&nbsp[Note: Description which is going to display on Home Page]
                                  <asp:TextBox ID="txt_description" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine" ></asp:TextBox>
<%--                               <asp:RequiredFieldValidator ID="rvdescription" runat="server" ControlToValidate="txt_description" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>--%>
                              </div>
                          </div>                                            <%--<br />
                                            <small style="color: grey">[Maximum 500 Characters allowed]
                                            </small>--%>
                                        </div>
                                   
                                </div>
                        <!--
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Banner Image</label><span style="color: red">*</span>&nbsp&nbsp[Note: Banner which is going to display on Home Page]<br />
                                    <span class="btn blue-steel btn-outline btn-file">
                                        <asp:FileUpload ID="fpbannerimage" runat="server" Width="100%" accept=".png, .jpg, .jpeg"/>
                                    </span>
                                    <br />
                                    <small>[File with .png, .jpg and .jpeg extention / format only.]<br />
                                        [Maximum Image Size: <%=ConfigurationManager.AppSettings["BannerSize"]%> MB]<br />
                                        [Recommended Dimension for Desktop - Width : <%=ConfigurationManager.AppSettings["BannerWidth"]%>px - Height : <%=ConfigurationManager.AppSettings["BannerHeight"]%>px].<br />
<%--                                        [Recommended Dimension for Mobile - Width : <%=ConfigurationManager.AppSettings["MobileBannerWidth"]%>px - Height : <%=ConfigurationManager.AppSettings["MobileBannerHeight"]%>px].--%>
                                    </small>
                                    <br />
                               
                                       <div style="text-align: left; margin-left: 0px;">
       <asp:RequiredFieldValidator ID="rvdocument" runat="server" ControlToValidate="fpbannerimage"
           ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic"
           ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
   </div>
                                    <div style="text-align: left; margin-left: 0px;">
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="fpbannerimage"
            ErrorMessage="Only .png, .jpg and .jpeg file formats are allowed." ForeColor="Red"
            ValidationExpression="^.+(.png|.PNG|.jpg|.JPG|.jpeg|.JPEG)$"
            ValidationGroup="UserDetails" SetFocusOnError="true"></asp:RegularExpressionValidator>
    </div>

   <asp:Image ID="img_banner" runat="server" Width="200" />
                                </div>
                            </div>
                        </div>
             -->
                        <div class="col-md-12">
                            <br />
                        </div>
                    </div>
                    <div class="form-actions text-center">
                        <asp:Button ID="btn_submit" runat="server" CssClass="btn blue-sharp" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="UserDetails" />
                        <asp:Button ID="btn_Update" runat="server" Text="Submit" CssClass="btn blue-sharp" ValidationGroup="vgValidate" OnClick="btn_Update_Click" OnClientClick="return confirm('Are you sure want to update banner details?');" />
                        <asp:Button ID="btn_cancel" runat="server" CssClass="btn default" Text="Cancel" OnClick="btn_cancel_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
      <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
  <script src="<%= ConfigurationManager.AppSettings["CMSPath"].ToString() %>/ckeditor/ckeditor.js"" type="text/javascript"></script>
 <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

    <script>
        $(document).ready(function () {
            $('ul.page-sidebar-menu > li.nav-item').removeClass("start active open");
            $('#banner').addClass("start active");
            $('#banner').addClass("open");
        });
    </script>

  <script>
      $(document).ready(function () {
          // Initialize CKEditor for the description field with custom height
          CKEDITOR.replace('txt_description', {
              height: 200  // You can change this value to set the height you prefer (in pixels)
          });
      });
  </script>

      
</asp:Content>
