<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="Manage_InfrastructureGalleryaspx.aspx.cs" Inherits="bankersheart.Poweradmin.Media.Infrastructure.Manage_InfrastructureGalleryaspx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Include Bootstrap CSS -->


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
                <a href="dashboard.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <i class="icon-home"></i>
                <a href="view_InfrastructureGallery.aspx">Infrastructure Gallery</a>
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
                        <span class="caption-subject font-blue-sharp bold uppercase">Manage Infrastructure Gallery</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn sbold blue-sharp" href="javascript:;" onclick="location.href='view_InfrastructureGallery.aspx'">Back</a>

                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="col-md-12">
                 <div class="row">
    <div class="col-md-6">
        <div class="form-group">
            <label>Infrastructure Name</label><span style="color: red">*</span>
            <asp:DropDownList ID="ddlInfrastructureName" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvInfrastructureName" runat="server" 
                ControlToValidate="ddlInfrastructureName" InitialValue="0"
                ErrorMessage="Please select an Infrastructure Name." ForeColor="Red" Display="Dynamic" 
                ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
        </div>
    </div>
                        <br />
                        <div class="row">

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Image Name</label><span style="color: red">*</span>&nbsp&nbsp[Note: Title which is going to display on About_Awards_Achivement Page]
                                    <asp:TextBox ID="txt_Title" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvtitle" runat="server" ControlToValidate="txt_Title" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>    
                        
 
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Infrastructure Image</label><span style="color: red">*</span>&nbsp&nbsp[Note: Medical Camp which is going to display on Home Page]<br />
                                    <span class="btn blue-steel btn-outline btn-file">
                                        <asp:FileUpload ID="fpbannerimage" runat="server" Width="100%" accept=".png, .jpg, .jpeg"/>
                                    </span>
                                    <br />
                                    <small>[File with .png, .jpg and .jpeg extention / format only.]<br />
                                        [Maximum Image Size: <%=ConfigurationManager.AppSettings["MedicalCampImageSize"]%> MB]<br />
                                        [Recommended Dimension for Desktop - Width : <%=ConfigurationManager.AppSettings["MedicalCampWidth"]%>px - Height : <%=ConfigurationManager.AppSettings["MedicalCampHeight"]%>px].<br />
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
                        <div class="col-md-12">
                            <br />
                        </div>
                    </div>
                    <div class="form-actions text-center">
                        <asp:Button ID="btn_submit" runat="server" CssClass="btn blue-sharp" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="UserDetails" />
                        <asp:Button ID="btn_Update" runat="server" Text="Submit" CssClass="btn blue-sharp" ValidationGroup="vgValidate" OnClick="btn_Update_Click" OnClientClick="return confirm('Are you sure want to update Infrastructure Gallery details?');" />
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
<%--        <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />--%>

<%--<!-- Include Bootstrap-datepicker CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet">

<!-- Include jQuery -->
<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

<!-- Include Bootstrap JS -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>--%>

<!-- Include Bootstrap-datepicker JS -->
<%--<script src="https://cdn.jsdelivr.net/npm/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>--%>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
<script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>

    <script>
        $(document).ready(function () {
            $('ul.page-sidebar-menu > li.nav-item').removeClass("start active open");
            $('#li_enquiries').addClass("start active");
            $('#li_enquiries').addClass("open");
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
