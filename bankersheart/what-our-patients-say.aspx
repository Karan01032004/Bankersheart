<%@ Page Title="Patient Reviews | Best Heart Hospital Vadodara" Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="what-our-patients-say.aspx.cs" Inherits="bankersheart.what_our_patients_say" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta name="keywords" content="heart surgery hospital vadodara, best hospital vadodara, best heart hospital vadodara, best cardiologist vadodara, angioplasty in vadodara, heart check up vadodara, top hospital vadodara">
<meta name="description" content=" Read patient reviews about Bankers Heart Institute, a top hospital Vadodara known for angioplasty in Vadodara, heart surgery hospital Vadodara services, and treatment from the best cardiologist Vadodara.">
<link rel="canonical" href="https://www.bankersheart.com/what-our-patients-say" />
	<style>
		.testimonial-bg {
			/*   background: url(assets/img/quote.png) no-repeat bottom right;
    background-size: 70px;*/
			box-shadow: 0px 4px 25px 0px #00000026;
		}

		.user_image {
			min-width: 70px;
			height: 70px;
			width: 70px;
			border: 1px solid #CD0001
		}

		.test_box:hover {
			transform: scale(1.05)
		}

		.bg-comment {
			background: url('assets/img/comment-icon.svg');
			background-repeat: no-repeat;
			background-position: 2% 0%;
			background-size: 13%;
		}

		#bg-cmt {
			background: url('assets/img/comment-icon-2.svg');
			background-repeat: no-repeat;
			background-position: 100% 100%;
			background-size: 13%;
		}

		@media(min-width:992px) {
			.test-height {
				height: 250px;
			}
		}


		#testimonials .clamped-text {
			display: -webkit-box;
			-webkit-box-orient: vertical;
			overflow: hidden;
			text-overflow: ellipsis;
			-webkit-line-clamp: 7;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	  <section id="inner-banner" class="content-down">
		<div class="container">
			<div class="row">
				<div class="banner-heading">
                    						<h1 class="sr-only">Patients</h1>

					<h2 class="text-white text-center mb-0">What Our Patients Say</h2>
					    <h3></h3>
						<h4></h4>
						<h5></h5>
				</div>
			</div>
		</div>
	</section>
	<section id="testimonials">
		<div class="container pb-5 mb-5" >
			<div class="row row-cols-1 row-cols-sm-2 row-cols-lg-3 mb-5">
				           <asp:Repeater ID="rpt_MedicalCamps" runat="server">
               <ItemTemplate>
				<div class="col test_box  pt-5">
					<div class="testimonial-bg px-4 py-4 rounded-3 bg-comment test-height">
						<div id="bg-cmt">

						
						<p class="mb-0"> 
           <i class="clamped-text"
               style="text-align: justify; text-justify: inter-word; ">
                <%# Eval("description") %>
            </i>						</p>
							</div>
					</div>
					<div class="d-flex align-items-center gap-2 gap-sm-3 mt-3">
						
						
						<div class="row align-items-center w-100 justify-content-between" >
							 <div class="col-10 ps-3">
                                 <div>
<%--                            <h6 class="text-black mb-0">MS. JOSHI RAJU</h6>--%>
                         <h6 class="fw-semibold text-black"><%# Eval("title") %><%--MS. JOSHI RAJU--%></h6>

                            <i class="fa fa-star text-warning"></i>
									<i class="fa fa-star text-warning"></i>
									<i class="fa fa-star text-warning"></i>
									<i class="fa fa-star text-warning"></i>
									<i class="fa fa-star text-warning"></i>
                        </div>

                            </div>

                        <%--    <div class="col-2">
                                <ahref="javascript:void(0)" class="text-red" data-bs-toggle="modal" data-bs-target="#myModal-2"><i class="fa fa-eye fs-4" aria-hidden="true"></i></a>
                            </div>--%>
							<div class="col-2">
    <ahref="javascript:void(0)" class="text-red viewImage" data-bs-toggle="modal" data-bs-target="#myModal-2" 
       data-image='<%# ResolveUrl("~/poweradmin/webfiles/PatientsSay/") + Eval("image") %>'
       data-title='<%# Eval("title") %>'>
        <i class="fa fa-eye fs-4" aria-hidden="true"></i>
    </a>
</div>

							
							
						</div>
					</div>
				</div>

		             </ItemTemplate>
         </asp:Repeater>
			</div>
			                        <div class="row pt-5 mt-3 justify-content-center text-center">
    <asp:PlaceHolder ID="PaginationPatientsSayPlaceholder" runat="server"></asp:PlaceHolder>
</div>
			<div class="modal" id="myModal-2">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title" id="modalTitle"></h4>
        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
      </div>

      <!-- Modal body -->
      <div class="modal-body m-auto">
        <picture>
          <source id="modalImageWebp" srcset="" type="image/webp">
          <source id="modalImagePng" srcset="" type="image/png">
          <img id="modalImage" class="img-fluid circle-img object-fit-cover" src="" alt="open model">
        </picture>
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
        <button type="button" class="btn-theme btn-blue" data-bs-dismiss="modal">Close</button>
      </div>

    </div>
  </div>
</div>

		</div>
	</section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
	<script>
        document.addEventListener("DOMContentLoaded", function () {
            document.querySelectorAll(".viewImage").forEach(function (el) {
                el.addEventListener("click", function () {
                    let imageUrl = this.getAttribute("data-image");
                    let title = this.getAttribute("data-title");

                    document.getElementById("modalTitle").innerText = title;
                    document.getElementById("modalImageWebp").srcset = imageUrl;
                    document.getElementById("modalImagePng").srcset = imageUrl;
                    document.getElementById("modalImage").src = imageUrl;
                    document.getElementById("modalImage").alt = title;
                });
            });
        });
    </script>

</asp:Content>
