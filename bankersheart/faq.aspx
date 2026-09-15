<%@ Page Title="" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="bankersheart.faq" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-control:focus {
            box-shadow: unset;
            border-color: #ff2e42;
        }

        .faq-banner {
            background: linear-gradient(rgba(0,0,0,.3), rgba(0,0,0,.3)), url(../../assets/images/dotsandcoms-web-and-app-developement-faq-in-india.png) top center no-repeat;
            margin-top: 120px;
            background-size: cover;
        }

        .accordion-button,
        .accordion-button:not(.collapsed) {
            background: #f5f5f5;
            color: #323232;
            box-shadow: unset !important;
            border-radius: 0 !important;
        }

        .accordion-item {
            margin-block: 20px;
            border-radius: 0 !important;
            border-left: 4px solid #ff2e42 !important;
            border: unset;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                    <h1 class="h2 text-white text-center mb-0">FAQs</h1>
                </div>
            </div>
        </div>
    </section>
    <section id="faq" class="py-5">
        <div class="container my-5">

            <div class="accordion" id="dotsAccordion">

                <!-- 1 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq1">
                            What is Bankers Group of Hospitals?
                        </button>
                    </h2>
                    <div id="faq1" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Bankers Group of Hospitals is a well-established healthcare group in Gujarat, known for its strong focus on cardiology, heart care, and critical medical services. The hospital group combines experienced doctors, modern infrastructure, and patient-centric care to support diagnosis, treatment, and long-term management of heart-related and associated health conditions.
                        </div>
                    </div>
                </div>

                <!-- 2 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq2">
                            Is Bankers Group of Hospitals a multi-specialty hospital?
                        </button>
                    </h2>
                    <div id="faq2" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, Bankers Group of Hospitals functions as a multi-specialty hospital with a primary emphasis on cardiac care supported by allied medical specialties.
                        </div>
                    </div>
                </div>

                <!-- 3 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq3">
                            Why is Bankers Group of Hospitals trusted for cardiac care in Gujarat?
                        </button>
                    </h2>
                    <div id="faq3" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            The hospital is trusted due to experienced cardiologists, advanced diagnostics, and strong cardiac treatment protocols.
                        </div>
                    </div>
                </div>

                <!-- 4 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq4">
                            What medical specialties are available at Bankers Group of Hospitals?
                        </button>
                    </h2>
                    <div id="faq4" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Services include cardiology, interventional cardiology, cardiac surgery support, diagnostics, dialysis services, and rehabilitation support.
                        </div>
                    </div>
                </div>

                <!-- 5 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq5">
                            Does Bankers Group of Hospitals provide advanced heart care services?
                        </button>
                    </h2>
                    <div id="faq5" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, services include advanced diagnostics, interventional cardiology procedures, surgical support, and intensive monitoring.
                        </div>
                    </div>
                </div>

                <!-- 6 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq6">
                            Does Bankers Group of Hospitals offer cardiology and heart care services?
                        </button>
                    </h2>
                    <div id="faq6" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, the hospital offers preventive cardiology, heart disease diagnosis, and long-term cardiac management.
                        </div>
                    </div>
                </div>

                <!-- 7 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq7">
                            What heart treatments are available at Bankers Group of Hospitals?
                        </button>
                    </h2>
                    <div id="faq7" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Treatments include coronary artery disease evaluation, heart rhythm disorder management, heart failure care, and hypertension-related heart conditions.
                        </div>
                    </div>
                </div>

                <!-- 8 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq8">
                            Is advanced interventional cardiology available?
                        </button>
                    </h2>
                    <div id="faq8" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, procedures such as angiography and angioplasty are available.
                        </div>
                    </div>
                </div>

                <!-- 9 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq9">
                            Are non-invasive cardiac diagnostic services provided?
                        </button>
                    </h2>
                    <div id="faq9" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, diagnostics include ECG, echocardiography, stress tests, and cardiac imaging.
                        </div>
                    </div>
                </div>

                <!-- 10 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq10">
                            Does Bankers Group of Hospitals offer heart check-up packages?
                        </button>
                    </h2>
                    <div id="faq10" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, structured heart check-up packages help detect cardiac risks early.
                        </div>
                    </div>
                </div>

                <!-- 11 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq11">
                            Is Bankers Group of Hospitals a heart surgery hospital?
                        </button>
                    </h2>
                    <div id="faq11" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            The hospital supports cardiac surgical care including evaluation, surgical coordination, and recovery.
                        </div>
                    </div>
                </div>

                <!-- 12 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq12">
                            What types of cardiac surgeries are performed?
                        </button>
                    </h2>
                    <div id="faq12" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Procedures include bypass surgery support, valve surgeries, and other heart surgeries.
                        </div>
                    </div>
                </div>

                <!-- 13 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq13">
                            Does the hospital perform angioplasty procedures?
                        </button>
                    </h2>
                    <div id="faq13" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, angioplasty is available to restore blood flow in blocked arteries.
                        </div>
                    </div>
                </div>

                <!-- 14 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq14">
                            Are non-coronary cardiac interventions available?
                        </button>
                    </h2>
                    <div id="faq14" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, treatments for valve disorders, rhythm issues, and structural heart conditions are available.
                        </div>
                    </div>
                </div>

                <!-- 15 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq15">
                            Is minimally invasive cardiac surgery offered?
                        </button>
                    </h2>
                    <div id="faq15" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Minimally invasive procedures may be recommended depending on patient condition.
                        </div>
                    </div>
                </div>

                <!-- 16 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq16">
                            Is the hospital a 24/7 emergency heart hospital?
                        </button>
                    </h2>
                    <div id="faq16" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, emergency cardiac care services are available 24/7.
                        </div>
                    </div>
                </div>

                <!-- 17 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq17">
                            Does the hospital provide urgent chest pain treatment?
                        </button>
                    </h2>
                    <div id="faq17" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, patients with chest pain receive immediate evaluation and emergency care.
                        </div>
                    </div>
                </div>

                <!-- 18 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq18">
                            Are heart specialists available round-the-clock?
                        </button>
                    </h2>
                    <div id="faq18" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, trained cardiac specialists and emergency teams are available 24/7.
                        </div>
                    </div>
                </div>

                <!-- 19 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq19">
                            Does the hospital have a cardiac ICU?
                        </button>
                    </h2>
                    <div id="faq19" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, a dedicated cardiac ICU is available for critically ill heart patients.
                        </div>
                    </div>
                </div>

                <!-- 20 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq20">
                            Is immediate cardiac treatment available in emergencies?
                        </button>
                    </h2>
                    <div id="faq20" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, immediate cardiac assessment and stabilization are provided during emergencies.
                        </div>
                    </div>
                </div>

                <!-- 21 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq21">
                            Is the hospital suitable for elderly heart patients?
                        </button>
                    </h2>
                    <div id="faq21" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, specialized care is available for elderly cardiac patients.
                        </div>
                    </div>
                </div>

                <!-- 22 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq22">
                            Does the hospital treat BP and heart conditions?
                        </button>
                    </h2>
                    <div id="faq22" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, patients with high blood pressure and heart conditions receive structured treatment.
                        </div>
                    </div>
                </div>

                <!-- 23 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq23">
                            Are long-term cardiac care plans available?
                        </button>
                    </h2>
                    <div id="faq23" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, long-term cardiac care plans include monitoring, medication management, and follow-up care.
                        </div>
                    </div>
                </div>

                <!-- 24 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq24">
                            Is cardiac rehabilitation available after surgery?
                        </button>
                    </h2>
                    <div id="faq24" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, cardiac rehabilitation programs support recovery after surgery or angioplasty.
                        </div>
                    </div>
                </div>

                <!-- 25 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq25">
                            Does the hospital offer pacemaker implantation?
                        </button>
                    </h2>
                    <div id="faq25" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, pacemaker implantation services are available.
                        </div>
                    </div>
                </div>

                <!-- 26 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq26">
                            Are dialysis services available?
                        </button>
                    </h2>
                    <div id="faq26" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, advanced dialysis services are available for patients with kidney and heart conditions.
                        </div>
                    </div>
                </div>

                <!-- 27 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq27">
                            Does the hospital provide integrated heart and kidney care?
                        </button>
                    </h2>
                    <div id="faq27" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, integrated cardiac and renal care is provided.
                        </div>
                    </div>
                </div>

                <!-- 28 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq28">
                            Are comprehensive support services available?
                        </button>
                    </h2>
                    <div id="faq28" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, services include diagnostics, pharmacy, nursing care, rehabilitation, and counseling.
                        </div>
                    </div>
                </div>

                <!-- 29 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq29">
                            Does the hospital serve patients in Vadodara?
                        </button>
                    </h2>
                    <div id="faq29" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, patients from Vadodara receive cardiac and multi-specialty healthcare services.
                        </div>
                    </div>
                </div>

                <!-- 30 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq30">
                            Do patients from Surat visit the hospital?
                        </button>
                    </h2>
                    <div id="faq30" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, patients from Surat and surrounding areas visit for heart care services.
                        </div>
                    </div>
                </div>

                <!-- 31 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq31">
                            Is the hospital accessible from Ahmedabad?
                        </button>
                    </h2>
                    <div id="faq31" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, many patients from Ahmedabad seek treatment here for cardiac care.
                        </div>
                    </div>
                </div>

                <!-- 32 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq32">
                            Does the hospital treat patients from across Gujarat?
                        </button>
                    </h2>
                    <div id="faq32" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, patients from across Gujarat visit for advanced cardiac care.
                        </div>
                    </div>
                </div>

                <!-- 33 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq33">
                            Why is the hospital considered one of the best heart hospitals in Gujarat?
                        </button>
                    </h2>
                    <div id="faq33" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Because of experienced cardiologists, modern infrastructure, and patient-focused care.
                        </div>
                    </div>
                </div>

                <!-- 34 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq34">
                            How experienced are the cardiologists?
                        </button>
                    </h2>
                    <div id="faq34" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Cardiologists have extensive clinical experience and advanced training.
                        </div>
                    </div>
                </div>

                <!-- 35 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq35">
                            What makes the hospital trusted for cardiac treatment?
                        </button>
                    </h2>
                    <div id="faq35" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Trust comes from ethical practices, transparent communication, and consistent patient outcomes.
                        </div>
                    </div>
                </div>

                <!-- 36 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq36">
                            Does the hospital provide affordable healthcare services?
                        </button>
                    </h2>
                    <div id="faq36" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Yes, the hospital focuses on cost-effective and accessible healthcare.
                        </div>
                    </div>
                </div>

                <!-- 37 -->
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq37">
                            How does the hospital ensure patient safety and quality care?
                        </button>
                    </h2>
                    <div id="faq37" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
                        <div class="accordion-body">
                            Patient safety is ensured through strict clinical protocols, infection control measures, and advanced monitoring systems.
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
</asp:Content>
