<%@ Page Title="Cardcon-2026 Registration Form"
    Language="C#"
    MasterPageFile="~/bankers.Master"
    AutoEventWireup="true"
    CodeBehind="cardcon-registration.aspx.cs" Inherits="bankersheart.cardcon_registration" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">

    <meta name="description" content="CARDCon-2026 Registration Form" />
    <style>
        .city-select-wrapper {
    position: relative;


    /* jQuery UI Datepicker Styling Fix */
.ui-datepicker {
    background-color: #ffffff !important;
    border: 1px solid #c5d0dc !important;
    box-shadow: 0 4px 16px rgba(0, 0, 0, 0.15) !important;
    z-index: 99999 !important; /* Calendar ko baaki sabhi inputs ke upar lane ke liye */
    padding: 10px !important;
    font-family: inherit;
    border-radius: 6px;
}

.ui-datepicker .ui-datepicker-header {
    background: #007bff;
    color: #fff;
    border-radius: 4px;
    padding: 5px;
    position: relative;
}

.ui-datepicker .ui-datepicker-title select {
    color: #333;
    padding: 2px 4px;
    margin: 0 2px;
    border-radius: 3px;
    border: 1px solid #ddd;
}

.ui-datepicker table {
    width: 100%;
    margin-top: 8px;
    border-collapse: collapse;
}

.ui-datepicker th {
    text-align: center;
    padding: 6px;
    color: #555;
    font-size: 13px;
}

.ui-datepicker td {
    text-align: center;
    padding: 2px;
}

.ui-datepicker td a {
    display: block;
    padding: 5px;
    text-decoration: none;
    color: #333;
    border-radius: 4px;
}

.ui-datepicker td a:hover {
    background-color: #e9ecef;
}

/* Aaj ke baad ki disabled future dates ko halka gray dikhane ke liye */
.ui-datepicker .ui-state-disabled span {
    color: #ccc !important;
    cursor: not-allowed;
}

}

.city-select-wrapper .city-select {
    appearance: none;
    -webkit-appearance: none;
    -moz-appearance: none;

    padding-right: 45px;

    background-image: none;
}

.city-select-wrapper::after {
    content: "";
    position: absolute;
    top: 50%;
    right: 18px;

    width: 8px;
    height: 8px;

    border-right: 2px solid #6c757d;
    border-bottom: 2px solid #6c757d;

    transform: translateY(-65%) rotate(45deg);

    pointer-events: none;
}

.city-select-wrapper .city-select:focus + label {
    z-index: 2;
}

/* Remove browser/autofill styling from form fields */
.form-control,
.form-select {
    background-color: #fff !important;
    background-image: none !important;
}

/* Remove autofill background */
input:-webkit-autofill,
input:-webkit-autofill:hover,
input:-webkit-autofill:focus,
input:-webkit-autofill:active {
    -webkit-box-shadow: 0 0 0 1000px #fff inset !important;
    box-shadow: 0 0 0 1000px #fff inset !important;
    -webkit-text-fill-color: #212529 !important;
}

/* Specifically remove any background/icon from email input */
input[type="email"] {
    background-image: none !important;
    background-color: #fff !important;
}
    </style>

</asp:Content>


<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder2"
    runat="server">

    <!-- Inner Banner -->
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="text-white h2 text-center mb-0">
                        Cardcon Registration
                    </h1>
                </div>
            </div>
        </div>
    </section>


    <!-- CARDCon Registration Form -->
    <div id="cardcon">

        <div class="container py-5">

            <div class="row py-5 justify-content-center">

                <div class="col-md-8 col-sm-11">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />

                    <!-- Same form container style as Career page -->
                    <div class="bg_contact px-2 px-sm-4 py-5 rounded-3">

                        <h2 class="text-center text-black h3">
                            Registration Form
                        </h2>
                        <asp:Label ID="lblMessage" runat="server" EnableViewState="false" />
                        <div class="mt-4">


                            <!-- =========================================
                                 PERSONAL DETAILS
                            ========================================== -->

                            <div class="row g-md-3">

                                <!-- Name -->
                                <div class="col-md mb-3">

                                    <div class="form-floating">

                                      <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Name" autocomplete="off" />
                                        <label for="<%= txtName.ClientID %>">Full Name</label>
                            
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                        ErrorMessage="Full name is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />

                                    </div>

                                </div>

                          
                            </div>  
                            <div class="row g-2">

                                <div class="col-12 mb-3">

                                    <div class="form-floating">
<asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Qualification" autocomplete="off" />
                                        <label for="<%= txtQualification.ClientID %>">Qualification</label>
                                 
                                    <asp:RequiredFieldValidator ID="rfvQualification" runat="server" ControlToValidate="txtQualification"
                                        ErrorMessage="Qualification is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />
                                    </div>

                                </div>

                            </div>


                            <!-- Birth Date -->
                            <div class="row g-2">

                                <div class="col-12 mb-3">

                                    <div class="form-floating">
<asp:TextBox ID="txtBirthDate" runat="server" TextMode="Date"  CssClass="form-control" placeholder="Birth Date" autocomplete="off" />
                                        <label for="<%= txtBirthDate.ClientID %>">Birth Date</label>
                                  
                                   
                                    </div>

                                </div>

                            </div>

                            <!-- City & Area -->
<div class="row g-2">

    <!-- City -->
    <div class="col-sm-6 mb-3">

        <div class="form-floating city-select-wrapper">

         <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-select city-select" onchange="toggleOtherCity(this.value)">
               <asp:ListItem Text="Select City" Value="" />

<asp:ListItem Text="Ahmedabad" Value="Ahmedabad" />
<asp:ListItem Text="Anand" Value="Anand" />
<asp:ListItem Text="Ankleshwar" Value="Ankleshwar" />
<asp:ListItem Text="Balasinor" Value="Balasinor" />
<asp:ListItem Text="Bardoli" Value="Bardoli" />
<asp:ListItem Text="Bharuch" Value="Bharuch" />
<asp:ListItem Text="Bodeli" Value="Bodeli" />
<asp:ListItem Text="Borsad" Value="Borsad" />
<asp:ListItem Text="Dahod" Value="Dahod" />
<asp:ListItem Text="Gandhinagar" Value="Gandhinagar" />
<asp:ListItem Text="Godhra" Value="Godhra" />
<asp:ListItem Text="Mumbai" Value="Mumbai" />
<asp:ListItem Text="Nadiad" Value="Nadiad" />
<asp:ListItem Text="Rajkot" Value="Rajkot" />
<asp:ListItem Text="Rajpipla" Value="Rajpipla" />
<asp:ListItem Text="Ratlam" Value="Ratlam" />
<asp:ListItem Text="Surat" Value="Surat" />
<asp:ListItem Text="Vadodara" Value="Vadodara" />

<asp:ListItem Text="Other" Value="Other" />
            </asp:DropDownList>
            <label for="<%= ddlCity.ClientID %>">City</label>
       
        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
            InitialValue="" ErrorMessage="Please select a city." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />

        </div>

    </div>


    <!-- Other City Textbox -->
    <div
        class="col-sm-6 mb-3"
        id="otherCityWrapper"
        style="display:none;">

        <div class="form-floating">

          <asp:TextBox ID="txtOtherCity" runat="server" CssClass="form-control" placeholder="Enter City" autocomplete="off" />
            <label for="<%= txtOtherCity.ClientID %>">Enter City</label>

        </div>

    </div>


    <!-- Area -->
    <div
        class="col-sm-6 mb-3"
        id="areaWrapper">

        <div class="form-floating">

           <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" placeholder="Area" autocomplete="off" />
            <label for="<%= txtArea.ClientID %>">Area</label>
 
        <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="txtArea"
            ErrorMessage="Area is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />

        </div>

    </div>

</div>


                            <!-- =========================================
                                 ADDRESS
                            ========================================== -->

                            <div class="row g-2">

    <div class="col-12 mb-3">

        <div class="form-floating">

            <asp:TextBox
                ID="txtAddress"
                runat="server"
                TextMode="MultiLine"
                CssClass="form-control"
                placeholder="Clinic/Hospital/Residence Address"
                autocomplete="off"
                Style="height: 120px;" />

            <label for="<%= txtAddress.ClientID %>">
                Clinic/Hospital/Residence Address
            </label>

            <asp:RequiredFieldValidator
                ID="rfvAddress"
                runat="server"
                ControlToValidate="txtAddress"
                ErrorMessage="Address is required."
                CssClass="text-danger small"
                Display="Dynamic"
                ValidationGroup="CardconGroup" />

        </div>

    </div>

</div>


                            <!-- =========================================
                                 CONTACT DETAILS
                            ========================================== -->

                            <div class="row g-2">

                                <!-- Phone -->
                                <div class="col-sm-6 mb-3">

                                    <div class="form-floating">

                                      <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Phone" autocomplete="off" />
                                        <label for="<%= txtPhone.ClientID %>">Phone</label>
 
                               
                                    </div>

                                </div>

        
                                <!-- Mobile -->
                                <div class="col-sm-6 mb-3">

                                    <div class="form-floating">
<asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Mobile" autocomplete="off" />
                                        <label for="<%= txtMobile.ClientID %>">Mobile</label>
                              
                                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile"
                                        ErrorMessage="Mobile number is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />
                                    </div>

                                </div>

                            </div>


                            <!-- E-mail -->
                            <div class="row g-2">

                                <div class="col-12 mb-3">

                                    <div class="form-floating">
<asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="E-mail" autocomplete="off" />
                                        <label for="<%= txtEmail.ClientID %>">E-mail</label>
                           
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Email address is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                        ValidationExpression="^[\w\.-]+@([\w-]+\.)+[\w-]{2,4}$"
                                        ErrorMessage="Enter a valid email address." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />
                                    </div>

                                </div>

                            </div>
                            <div class="row g-2">

                                <!-- Enter Captcha -->
                                <div class="col-sm-6 mb-3">

                                    <div class="form-floating">
<asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control" placeholder="Enter Captcha" autocomplete="off" />
                                        <label for="<%= txtCaptcha.ClientID %>">Enter Captcha</label>
                                 
                                    <asp:RequiredFieldValidator ID="rfvCaptcha" runat="server" ControlToValidate="txtCaptcha"
                                        ErrorMessage="Captcha is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="CardconGroup" />
                                    </div>

                                </div>


                                <!-- Captcha Question -->
                                <div class="col-sm-6 mb-3">
                                    <div class="form-floating">
                                    

                                        <asp:TextBox ID="txtCaptchaQuestion" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Captcha" autocomplete="off" />
                                        <label for="<%= txtCaptchaQuestion.ClientID %>">
                                          
                                        </label>
                                    </div>

                                </div>

                            </div>


                            <!-- =========================================
                                 REGISTRATION FEES
                            ========================================== -->

                            <div class="row">

                                <div class="col-12 text-center mt-2 mb-4">

                                    <p class="mb-0 text-danger fs-5">

                                        Registration Fees 1000/-
                                        (Pay by DD/Cheque in favour of
                                        <strong>Cardcon</strong>)

                                    </p>

                                </div>

                            </div>

                            <!-- =========================================
     IS PAID?
========================================== -->

<div class="row g-2">

    <div class="col-12 mb-4">

        <div class="d-flex justify-content-center align-items-center">

            <div class="me-3">
                Is Paid?
            </div>

            <!-- Yes -->
            <div class="d-flex align-items-center me-3">
                <label class="me-1" for="<%= rbPaidYes.ClientID %>">
                    Yes
                </label>

                <asp:RadioButton
                    ID="rbPaidYes"
                    runat="server"
                    GroupName="paymentStatus"
                    CssClass="mt-0" />
            </div>

            <!-- No -->
            <div class="d-flex align-items-center">
                <label class="me-1" for="<%= rbPaidNo.ClientID %>">
                    No
                </label>

                <asp:RadioButton
                    ID="rbPaidNo"
                    runat="server"
                    GroupName="paymentStatus"
                    Checked="true"
                    CssClass="mt-0" />
            </div>

        </div>

    </div>

</div>


                            <!-- =========================================
                                 ACCOMMODATION
                            ========================================== -->

                                <div class="row g-2">

    <div class="col-12 mb-4">

        <div class="d-flex justify-content-center">

            <!-- Label -->
            <div class="me-2">
                Accommodation requested :
            </div>

            <!-- Options -->
            <div>

                <!-- Yes -->
             <!-- Yes -->
<div class="d-flex align-items-center mb-2">
    <label class="me-1" for="<%= rbAccYes.ClientID %>">
        Yes
    </label>

    <asp:RadioButton
        ID="rbAccYes"
        runat="server"
        GroupName="accommodation"
        CssClass="mt-1 me-2" />

    <span class="text-danger">[Chargeable]</span>
</div>

<!-- No -->
<div class="ms-2 d-flex align-items-center">
    <label class="me-1" for="<%= rbAccNo.ClientID %>">
        No
    </label>

    <asp:RadioButton
        ID="rbAccNo"
        runat="server"
        GroupName="accommodation"
        Checked="true"
        CssClass="mt-1" />
</div>

            </div>

        </div>

    </div>

</div>


                            <!-- =========================================
                                 FURTHER INFORMATION
                            ========================================== -->

                            <div class="row">

                                <div class="col-12">

                                    <h2 class="text-danger h4 mb-4 border-bottom pb-2">
                                        For Further Information Contact:
                                    </h2>

                                </div>

                            </div>


                            <!-- =========================================
                                 CONTACT PERSONS
                            ========================================== -->

                          <div class="row g-2">

    <div class="col-6 col-md-4 mb-3">
        <div>
            Jignesh Patel
        </div>

        <a href="tel:9898587867"
            class="text-dark text-decoration-none">
            98985 87867
        </a>
    </div>

    <div class="col-6 col-md-4 mb-3">
        <div>
            Kaushal Shah
        </div>

        <a href="tel:9898994011"
            class="text-dark text-decoration-none">
            98989 94011
        </a>
    </div>

    <div class="col-6 col-md-4 mb-3">
        <div>
            Hardik K. Modi
        </div>

        <a href="tel:7043074880"
            class="text-dark text-decoration-none">
            70430 74880
        </a>
    </div>

</div>


                            <!-- Second Contact Row -->
                           <div class="row g-2">
                               <div class="col-6 col-md-4 mb-3">
    <div>
        Divyang Patel
    </div>

    <a href="tel:9016133947"
        class="text-dark text-decoration-none">
        90161 33947
    </a>
</div>

                                <div class="col-6 col-md-4 mb-3">
                                    <div>
                                        Ravindra Rathod
                                    </div>

                                    <a href="tel:9898994010"
                                        class="text-dark text-decoration-none">
                                        98989 94010
                                    </a>
                                </div>



                                <div class="col-6 col-md-4 mb-3">
                                    <div>
                                        Akhilesh Jha
                                    </div>

                                    <a href="tel:8511174106"
                                        class="text-dark text-decoration-none">
                                        85111 74106
                                    </a>
                                </div>

                            </div>

                            <!-- =========================================
                                 SUBMIT
                            ========================================== --> 

                            <div class="mt-4 text-lg-start text-center">

                               <asp:Button ID="btnSubmit" runat="server" Text="Submit Registration"
                                     class="btn-theme btn-blue" ValidationGroup="CardconGroup" OnClick="btnSubmit_Click" />
                                <div class="mt-3 text-start">
        <asp:ValidationSummary ID="vsCardcon" runat="server"
            ValidationGroup="CardconGroup"
            HeaderText="<strong>Please fill all fields:</strong>"
            DisplayMode="BulletList"
            ShowSummary="true"
            ShowMessageBox="false"
            CssClass="alert alert-danger mb-0" />
    </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>


<asp:Content ID="Content3"
    ContentPlaceHolderID="extrajs"
    runat="server">

    <script>
        function toggleOtherCity(value) {

            const otherCityWrapper = document.getElementById("otherCityWrapper");
            const otherCity = document.getElementById("otherCity");
            const areaWrapper = document.getElementById("areaWrapper");

            if (value === "Other") {

                // Show Other City textbox
                otherCityWrapper.style.display = "block";

                // Make Area full width
                areaWrapper.classList.remove("col-sm-6");
                areaWrapper.classList.add("col-12");

                otherCity.focus();

            } else {

                // Hide Other City textbox
                otherCityWrapper.style.display = "none";
                otherCity.value = "";

                // Restore Area to half width
                areaWrapper.classList.remove("col-12");
                areaWrapper.classList.add("col-sm-6");
            }
        }
    </script>
    <script type="text/javascript">
        function toggleOtherCity(val) {
            var wrapper = document.getElementById('otherCityWrapper');
            if (val === 'Other') {
                wrapper.style.display = 'block';
            } else {
                wrapper.style.display = 'none';
                document.getElementById('<%= txtOtherCity.ClientID %>').value = '';
        }
    }

    // Page reload hone par agar 'Other' selected ho toh textbox visible rahe
    window.addEventListener('DOMContentLoaded', function () {
        var ddl = document.getElementById('<%= ddlCity.ClientID %>');
        if (ddl) {
            toggleOtherCity(ddl.value);
        }
    });

       
</script>
 
    
</asp:Content>

