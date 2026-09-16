<%@ Page Title="FAQ | Bankers Heart | Best Hospital Vadodara" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="bankersheart.faq" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content=" Bankers Group of Hospitals FAQ, best heart hospital in Vadodara, cardiology hospital Gujarat, heart specialist Vadodara, cardiac surgery hospital Gujarat, angioplasty Vadodara, heart checkup packages Vadodara, PMJAY hospital Gujarat, Ayushman Bharat hospital Vadodara, multi specialty hospital Gujarat, emergency cardiac care Vadodara">
    <meta name="description" content="Find answers to frequently asked questions about Bankers Group of Hospitals, the best heart hospital in Vadodara. Learn about cardiology treatments, cardiac surgery, emergency care, PMJAY services, and multi-specialty healthcare solutions in Gujarat.">
    <link rel="canonical" href="https://www.bankersheart.com/faq"/>
    <style>
        
        .faq-banner {
            background: linear-gradient(rgba(0,0,0,.3), rgba(0,0,0,.3)), url(https://www.bankersheart.com/assets/img/inner-page-banner-img.png) top center no-repeat;
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
        /* FAQ list styling */
/* FAQ list styling - FINAL */
#faq .accordion-body ul.faq-list {
    list-style-type: disc;
    padding-left: 22px;
    margin-top: 10px;
}

/* Force SAME typography as paragraph */
#faq .accordion-body ul.faq-list li {
    font-family: "Poppins", serif !important;
    font-size: clamp(15px, 2vw, 18px) !important;
    line-height: 1.7;
    color: #555;
    margin-bottom: 6px;
    display: list-item;
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

            <h2 class="mb-4">About Bankers Group of Hospitals</h2>

            <!-- 1 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq1">
            What is Bankers Group of Hospitals?
            </button>
            </h2>
            <div id="faq1" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Bankers Group of Hospitals is a premier healthcare institution in Gujarat, widely recognized as the best heart hospital in Vadodara. We provide a comprehensive continuum of care, integrating world-class infrastructure with advanced clinical expertise to treat complex cardiovascular and multispecialty conditions.
            </div>
            </div>
            </div>

            <!-- 2 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq2">
            Is Bankers Group of Hospitals a multi-specialty institution?
            </button>
            </h2>
            <div id="faq2" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. While we are celebrated as a top cardiology hospital in Gujarat, we operate as a full-scale multi-specialty facility. Our collaborative care model includes nephrology, critical care, advanced diagnostics, and internal medicine, ensuring patients receive holistic treatment under one roof.
            </div>
            </div>
            </div>

            <!-- 3 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq3">
            Why is Bankers Group of Hospitals considered the best hospital in Vadodara for cardiac care?
            </button>
            </h2>
            <div id="faq3" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Our reputation is built on a foundation of elite clinical outcomes, a team of the best heart specialists in Vadodara, and state-of-the-art technology. We prioritize early intervention and precision diagnostics, making us the trusted choice for thousands of families across Western India.
            </div>
            </div>
            </div>

            <!-- 4 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq4">
            What medical specialties are available at your facilities?
            </button>
            </h2>
            <div id="faq4" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            We offer a wide array of specialized services, including Interventional Cardiology, Cardiothoracic Surgery, Critical Care Medicine, Nephrology (Dialysis), Advanced Diagnostics, and Cardiac Rehabilitation.
            </div>
            </div>
            </div>
            <h2 class="mb-4 mt-5">Cardiology & Heart Care Services</h2>

            <!-- 5 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq5">
            What heart treatments are available at Bankers Group of Hospitals?
            </button>
            </h2>
            <div id="faq5" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            As a leading heart hospital, we provide treatments for coronary artery disease, heart failure management, cardiac rhythm disorders (arrhythmia), and hypertension. Each patient receives a customized clinical pathway designed for long-term recovery.
            </div>
            </div>
            </div>

            <!-- 6 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq6">
            Does the hospital offer advanced interventional cardiology?
            </button>
            </h2>
            <div id="faq6" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. Our interventional suite is equipped for complex procedures, including coronary angiography, primary angioplasty, and stent implantations, performed by some of the best cardiologists in Vadodara.
            </div>
            </div>
            </div>

            <!-- 7 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq7">
            Are non-invasive cardiac diagnostic services provided?
            </button>
            </h2>
            <div id="faq7" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Absolutely. We offer a full range of non-invasive assessments, including 2D Echocardiography, Stress Testing (TMT), ECG, and advanced cardiac imaging to ensure accurate diagnosis without the need for initial surgery.
            </div>
            </div>
            </div>

            <!-- 8 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq8">
            Does Bankers Group of Hospitals offer preventive heart check-up packages?
            </button>
            </h2>
            <div id="faq8" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. We believe prevention is the highest form of care. We offer structured heart check-up packages in Vadodara tailored for various age groups and risk profiles, including those with a family history of heart disease.
            </div>
            </div>
            </div>
            <h2 class="mb-4 mt-5">Cardiac Surgery & Advanced Procedures</h2>

            <!-- 9 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq9">
            Is Bankers Group of Hospitals a dedicated heart surgery hospital?
            </button>
            </h2>
            <div id="faq9" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes, we are a premier destination for cardiac surgery in Gujarat. Our surgical teams specialize in both traditional and advanced procedures, ensuring the highest safety standards and post-operative success rates.
            </div>
            </div>
            </div>

            <!-- 10 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq10">
            What types of cardiac surgeries are performed?
            </button>
            </h2>
            <div id="faq10" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Our expertise covers a broad spectrum, including Coronary Artery Bypass Grafting (CABG), heart valve repair and replacement, and corrective surgeries for congenital heart defects.
            </div>
            </div>
            </div>

            <!-- 11 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq11">
            Is minimally invasive cardiac surgery offered?
            </button>
            </h2>
            <div id="faq11" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Whenever clinically viable, our surgeons employ minimally invasive techniques. These "keyhole" procedures result in less scarring, reduced pain, and a significantly faster return to daily activities.
            </div>
            </div>
            </div>


            <h2 class="mb-4 mt-5">24/7 Emergency & Critical Care</h2>

            <!-- 12 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq12">
            Is Bankers Group of Hospitals a 24/7 emergency heart hospital?
            </button>
            </h2>
            <div id="faq12" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. We operate a 24/7 Cardiac Emergency Unit in Vadodara. Our "Code Blue" teams are always on standby to provide immediate life-saving interventions for heart attacks and other acute cardiac events.
            </div>
            </div>
            </div>

            <!-- 13 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq13">
            Does the hospital provide urgent chest pain treatment?
            </button>
            </h2>
            <div id="faq13" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Time is muscle in cardiac care. We offer an Emergency Chest Pain Clinic where patients are triaged and treated immediately to minimize heart muscle damage.
            </div>
            </div>
            </div>

            <!-- 14 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq14">
            Are heart specialists available round-the-clock?
            </button>
            </h2>
            <div id="faq14" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. Unlike many facilities, Bankers Group ensures that expert cardiologists and intensive care staff are physically present 24/7 to manage emergencies at a moment’s notice.
            </div>
            </div>
            </div>


            <h2 class="mb-4 mt-5">Specialized Care & Support Services</h2>

            <!-- 15 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq15">
            Is the hospital equipped for elderly patients with complex heart issues?
            </button>
            </h2>
            <div id="faq15" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Geriatric cardiac care is one of our core strengths. We specialize in managing age-related heart conditions alongside co-morbidities like diabetes and kidney disease, ensuring gentle yet effective treatment for senior citizens.
            </div>
            </div>
            </div>

            <!-- 16 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq16">
            Does the hospital provide integrated care for heart and kidney patients?
            </button>
            </h2>
            <div id="faq16" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. We are one of the few centers offering integrated Cardio-Renal care. With on-site advanced dialysis and nephrology support, we safely manage patients who suffer from both heart and kidney ailments.
            </div>
            </div>
            </div>

            <!-- 17 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq17">
            Is cardiac rehabilitation available after surgery or angioplasty?
            </button>
            </h2>
            <div id="faq17" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. Our comprehensive rehabilitation program helps patients regain strength through supervised exercise, nutritional counseling, and lifestyle modification to prevent future cardiac events.
            </div>
            </div>
            </div>

            <h2 class="mb-4 mt-5">Locations & Accessibility</h2>

            <!-- 18 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq18">
            Do you serve patients from outside Vadodara, such as Surat or Ahmedabad?
            </button>
            </h2>
            <div id="faq18" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. While we are the best hospital in Vadodara, we regularly treat patients from Surat, Ahmedabad, Bharuch, and across Gujarat and MP who seek our specialized expertise and high success rates.
            </div>
            </div>
            </div>

            <h2 class="mb-4 mt-5">Why Choose Bankers Group of Hospitals</h2>

            <!-- 19 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq19">
            Why is Bankers Group recognized as the best heart hospital in Gujarat?
            </button>
            </h2>
            <div id="faq19" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Our distinction comes from combining the three pillars of healthcare: Expertise (highly experienced doctors), Technology (modern Cath labs and OTs), and Empathy (patient-centric care).
            </div>
            </div>
            </div>

            <!-- 20 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq20">
            Does the hospital provide affordable healthcare services?
            </button>
            </h2>
            <div id="faq20" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            We are committed to "Quality Care with Accessibility." We offer various tiers of services to ensure that world-class heart care remains affordable for all segments of society without compromising on clinical standards.
            </div>
            </div>
            </div>


            <h2 class="mb-4 mt-5">Comprehensive Multi-Specialty Care</h2>

            <!-- 21 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq21">
            Is Bankers Group of Hospitals strictly a cardiac-only center?
            </button>
            </h2>
            <div id="faq21" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            While we are widely recognized as the best heart hospital in Vadodara, Bankers Group of Hospitals is a network of full-service multi-specialty hospitals. We are equipped to diagnose and treat a comprehensive range of medical conditions across various clinical departments, moving far beyond just cardiac care.
            </div>
            </div>
            </div>

            <!-- 22 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq22">
            What other medical conditions are treated at Bankers Group of Hospitals?
            </button>
            </h2>
            <div id="faq22" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Our facilities operate as top multi-specialty hospitals in Gujarat, providing expert care in:
                <div class="accordion-body">
                    <ul class="faq-list">
                        <li >General Medicine & Internal Medicine: Management of chronic diseases, infections, and metabolic disorders.</li>
                        <li>General & Laparoscopic Surgery: Advanced surgical interventions for various abdominal and soft tissue conditions.</li>
                        <li >Orthopedics: Treatment for bone, joint, and spine-related issues.</li>
                        <li > Nephrology & Urology: Comprehensive kidney care and dialysis services.</li>
                        <li> Critical Care & Pulmonology: Expert management of respiratory and life-threatening emergencies.</li>
                    </ul> 
                </div>
            </div>
            </div>
            </div>

            <!-- 23 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq23">
            Why choose Bankers Group for non-cardiac medical needs?
            </button>
            </h2>
            <div id="faq23" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Patients choose us because we apply the same rigor, advanced technology, and clinical excellence found in our cardiac department to all our specialties. Whether you require a routine consultation or a complex multi-disciplinary surgery, we are the preferred multi-specialty hospital in Vadodara for holistic family healthcare.
            </div>
            </div>
            </div>


            <h2 class="mb-4 mt-5">PMJAY (Ayushman Bharat) & Government Schemes</h2>

            <!-- 24 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq24">
            Does Bankers Group of Hospitals treat PMJAY (Ayushman Bharat) patients?
            </button>
            </h2>
            <div id="faq24" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. We are a proud empanelled provider for the PMJAY (Pradhan Mantri Jan Arogya Yojana) scheme, also known as Ayushman Bharat. We believe that high-quality healthcare should be accessible to all, and we provide cashless treatment to eligible cardholders as per government guidelines.
            </div>
            </div>
            </div>

            <!-- 25 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq25">
            Which treatments are covered under PMJAY at your hospitals?
            </button>
            </h2>
            <div id="faq25" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            A vast array of procedures—ranging from life-saving cardiac surgeries and angioplasties to various multi-specialty medical and surgical treatments—are covered under the PMJAY scheme at our facilities. Our dedicated helpdesk is available at each hospital to assist you with eligibility and the enrollment process.
            </div>
            </div>
            </div>

            <!-- 26 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq26">
            Is the quality of care the same for PMJAY patients?
            </button>
            </h2>
            <div id="faq26" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Absolutely. At Bankers Group, we maintain a singular standard of clinical excellence. PMJAY patients receive the same access to our expert doctors, advanced medical technology, and sterilized operating theaters as every other patient, ensuring the best possible outcomes for everyone.
            </div>
            </div>
            </div>


            <h2 class="mb-4 mt-5">Hospital Network & Infrastructure</h2>

            <!-- 27 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq27">
            Are all Bankers Group locations multi-specialty?
            </button>
            </h2>
            <div id="faq27" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes, every hospital under the Bankers Group umbrella is designed as a comprehensive healthcare hub. Each location is equipped with the diagnostic tools, intensive care units (ICUs), and specialist teams necessary to handle a wide spectrum of medical and surgical cases.
            </div>
            </div>
            </div>

            <!-- 28 -->
            <div class="accordion-item">
            <h2 class="accordion-header">
            <button type="button" class="accordion-button collapsed" data-bs-toggle="collapse" data-bs-target="#faq28">
            Do you have emergency services for non-cardiac issues?
            </button>
            </h2>
            <div id="faq28" class="accordion-collapse collapse" data-bs-parent="#dotsAccordion">
            <div class="accordion-body">
            Yes. Our emergency departments are staffed 24/7 to handle all types of medical crises, including trauma, respiratory distress, and acute surgical emergencies, making us a top emergency hospital in Vadodara for any medical necessity.
            </div>
            </div>
            </div>


            </div>
            </div>
</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
</asp:Content>
