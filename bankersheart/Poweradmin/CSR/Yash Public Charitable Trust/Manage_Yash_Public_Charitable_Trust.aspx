<%@ Page Title="" Language="C#" MasterPageFile="~/Poweradmin/bankersheartMaster.Master" AutoEventWireup="true" CodeBehind="Manage_Yash_Public_Charitable_Trust.aspx.cs" Inherits="bankersheart.Poweradmin.CSR.Yash_Public_Charitable_Trust.Manage_Yash_Public_Charitable_Trust" %>

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
                <a href="https://www.bankersheart.com/Poweradmin/CSR/Yash%20Public%20Charitable%20Trust/View_Yash_Public_Charitable_Trust.aspx">Yash Public Charitable Trust</a>
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
                        <span class="caption-subject font-blue-sharp bold uppercase">Manage Yash Public Charitable Trust</span>
                    </div>
                    <div class="actions">
                        <div class="btn-group">
                            <a class="btn sbold blue-sharp" href="javascript:;" onclick="location.href='View_Yash_Public_Charitable_Trust.aspx'">Back</a>

                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                              
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
                                    <label>Title</label><span style="color: red">*</span>
                                    <asp:TextBox ID="txt_Title" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvtitle" runat="server" ControlToValidate="txt_Title" ErrorMessage="Please fill out this field." ForeColor="Red" Display="Dynamic" ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    <br />
                    <br />
                   
                     <div class="row">
    <div class="col-md-12">
        <div class="form-group">
            <label>Yash Public Charitable Trust PDF</label><span style="color: red">*</span>&nbsp&nbsp[Note: Only PDF files are allowed]<br />
            <span class="btn blue-steel btn-outline btn-file">
                <asp:FileUpload ID="fpbannerimage" runat="server" Width="100%" accept=".pdf" />
            </span>
            <br />
            <small>[File with .pdf extension only.]<br />
                [Maximum File Size: <%=ConfigurationManager.AppSettings["YashPublicCharitableTrustSize"]%> MB].
            </small>
            <br />
            <div style="text-align: left; margin-left: 0px;">
                <asp:RequiredFieldValidator ID="rvdocument" runat="server" ControlToValidate="fpbannerimage"
                    ErrorMessage="Please upload a PDF file." ForeColor="Red" Display="Dynamic"
                    ValidationGroup="UserDetails"></asp:RequiredFieldValidator>
            </div>
            <div style="text-align: left; margin-left: 0px;">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="fpbannerimage"
                    ErrorMessage="Only PDF file format is allowed." ForeColor="Red"
                    ValidationExpression="^.+(.pdf|.PDF)$"
                    ValidationGroup="UserDetails" SetFocusOnError="true"></asp:RegularExpressionValidator>
            </div>
        </div>
    </div>
</div>
   <div class="row">
    <div class="col-md-12">
        <div class="form-group">
          <asp:Label ID="label_PDF" runat="server" Visible="false" Text="Uploaded PDF:" />

           
       
            <!-- HyperLink to download/view PDF -->
            <asp:HyperLink ID="lnkDownloadPdf" runat="server" Text="" NavigateUrl="" Target="_blank" Visible="false" />
        </div>
    </div>
</div>

                        <div class="col-md-12">
                            <br />
                        </div>
                    </div>
                    <div class="form-actions text-center">
                        <asp:Button ID="btn_submit" runat="server" CssClass="btn blue-sharp" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="UserDetails" />
                        <asp:Button ID="btn_Update" runat="server" Text="Submit" CssClass="btn blue-sharp" ValidationGroup="vgValidate" OnClick="btn_Update_Click" OnClientClick="return confirm('Are you sure want to update Yash Public Charitable Trust details?');" />
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
            $('#li_enquiries').addClass("start active");
            $('#li_enquiries').addClass("open");
        });
    </script>



      
</asp:Content>
