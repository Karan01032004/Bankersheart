<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="Manage_Downloads.aspx.cs" Inherits="bankersheart.Poweradmin.Media.Downloads.Manage_Downloads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
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
                <a href="View_Downloads.aspx">Downloads</a>
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
                        <span class="caption-subject font-blue-sharp bold uppercase">Manage Downloads</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn sbold blue-sharp" href="javascript:;" onclick="location.href='View_Downloads.aspx'">Back</a>

                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                              <div class="form-group">
            <label>Download Name</label><span style="color: red">*</span><br />
            <asp:DropDownList ID="ddl_DownloadName" runat="server" CssClass="form-control" ValidationGroup="UserDetails">
                <asp:ListItem Text="Select Download Name" Value="" />
                <asp:ListItem Text="Health Tips" Value="Health Tips" />
                <asp:ListItem Text="Corporate Brochure" Value="CorporateBrochure" />
                <asp:ListItem Text="Events Brochure" Value="EventsBrochure" />
                <asp:ListItem Text="Presentation" Value="Presentation" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvDownloadName" runat="server" ControlToValidate="ddl_DownloadName"
                InitialValue="" ErrorMessage="Please select a download name." ForeColor="Red"
                Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
        </div>
                                <br />
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
                                    <label>Title</label><span style="color: red">*</span>&nbsp&nbsp[Note: Title which is going to display on media-download Page]
                                    <asp:TextBox ID="txt_Title" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvtitle" runat="server" ControlToValidate="txt_Title" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    <br />
                    <br />
      <div class="row">
    <!-- Image Upload Column -->
    <div class="col-md-6">
        <div class="form-group">
            <label>Thumb Image</label><span style="color: red">*</span>&nbsp&nbsp[Note:Thumb Image to display on media-download Page]<br />
            <span class="btn blue-steel btn-outline btn-file">
                <asp:FileUpload ID="FileUploadImage" runat="server" Width="100%" accept=".png, .jpg, .jpeg"/>
            </span>
            <br />
            <small>[Allowed formats: .png, .jpg, .jpeg]<br />
                [Maximum size: <%= ConfigurationManager.AppSettings["MedicalCampImageSize"] %> MB].<br />
            </small>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorImage" runat="server" ControlToValidate="FileUploadImage"
                ErrorMessage="Please upload an image." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorImage" runat="server" ControlToValidate="FileUploadImage"
                ErrorMessage="Only .png, .jpg and .jpeg file formats are allowed." ForeColor="Red"
                ValidationExpression="^.+(.png|.jpg|.jpeg)$" ValidationGroup="UserDetails"></asp:RegularExpressionValidator>
            <asp:Image ID="img_banner" runat="server" Width="200" />
        </div>
    </div>

    <!-- PDF Upload Column -->
    <div class="col-md-6">
        <div class="form-group">
            <label>Downloads PDF</label><span style="color: red">*</span>&nbsp&nbsp[Note: Only PDF files are allowed]<br />
            <span class="btn blue-steel btn-outline btn-file">
                <asp:FileUpload ID="FileUploadPDF" runat="server" Width="100%" accept=".pdf" />
            </span>
            <br />
            <small>[Only .pdf files are allowed.]<br />
                [Maximum size: <%= ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"] %> MB].</small>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPDF" runat="server" ControlToValidate="FileUploadPDF"
                ErrorMessage="Please upload a PDF file." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPDF" runat="server" ControlToValidate="FileUploadPDF"
                ErrorMessage="Only PDF file format is allowed." ForeColor="Red"
                ValidationExpression="^.+(.pdf)$" ValidationGroup="UserDetails"></asp:RegularExpressionValidator>
        </div>
    </div>
          
        <div class="form-group">
            <asp:Label ID="label_PDF" runat="server" Visible="false" Text="Uploaded PDF:" />
            <!-- HyperLink to download/view PDF -->
            <asp:HyperLink ID="lnkDownloadPdf" runat="server" Text="" NavigateUrl="" Target="_blank" Visible="false" />
        </div>
 

</div>



                        <div class="col-md-12">
                            <br />
                        </div>
                    </div>
                    <div class="form-actions text-center">
                        <asp:Button ID="btn_submit" runat="server" CssClass="btn blue-sharp" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="UserDetails" />
                        <asp:Button ID="btn_Update" runat="server" Text="Submit" CssClass="btn blue-sharp" ValidationGroup="vgValidate" OnClick="btn_Update_Click" OnClientClick="return confirm('Are you sure want to update Downloads details?');" />
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
            $('#li_Media').addClass("start active");
            $('#li_Media').addClass("open");
        });
    </script>



      
</asp:Content>
