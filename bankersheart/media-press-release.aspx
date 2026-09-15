<%@ Page  Language="C#" MasterPageFile="~/bankers.Master" AutoEventWireup="true" CodeBehind="media-press-release.aspx.cs" Inherits="bankersheart.media_press_release" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta name="keywords" content="Bankers Hospital, media releases, press release, cardiac care, Vadodara hospital news, Gujarat hospitals, renal denervation, Cardiac care centre Vadodara">
<%--<meta name="description" content="Bankers Hospital shares medical press coverage on cardiac care, healthcare innovation in Gujarat, and patient-focused initiatives.">--%>
    <meta id="metaDescription" name="description" runat="server" />

<link id="head_canonicalLink" rel="canonical" runat="server" />
    
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fancyapps/ui/dist/fancybox.css" />

    <style>
         .fancybox__container{
            z-index: 11111 !important;
        }
         .fancybox-image {
  transform: scale(2.4); /* Adjust the scale factor as needed */
  transition: transform 0.3s ease; /* Smooth transition for zoom effect */
}
      /*  .ribbon {
    width: 150px;
    height: 150px;
    overflow: hidden;
    position: absolute;
}

.ribbon-top-left {
    top: -10px;
    left: -10px;
}
.ribbon .avail {
    position: absolute;
    display: block;
    width: 225px;
    padding: 15px 0;
    background-color: #CD0001!important;
    box-shadow: 0 5px 10px rgba(0, 0, 0, .1);
    color: #fff;
    font: 700 18px / 1 'Lato', sans-serif;
    text-shadow: 0 1px 1px rgba(0, 0, 0, .2);
    text-transform: uppercase;
    text-align: center;
}

.ribbon span {
    position: absolute;
    display: block;
    width: 225px;
    padding: 15px 0;
    background-color: #ed2e30;
    box-shadow: 0 5px 10px rgba(0, 0, 0, .1);
    color: #fff;
    font: 700 18px / 1 'Lato', sans-serif;
    text-shadow: 0 1px 1px rgba(0, 0, 0, .2);
    text-transform: uppercase;
    text-align: center;
}
.ribbon-top-left span {
    right: -25px;
    top: 32px;
    transform: rotate(-45deg);
}*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <section id="inner-banner" class="content-down">
        <div class="container">
            <div class="row">
                <div class="banner-heading">
                <asp:Literal ID="litHeading" runat="server"></asp:Literal>
                    <h2 class="text-white text-center mb-0">Press Releases</h2>
                    <h3></h3>
                    <h4></h4>
                    <h5></h5>
                </div>
            </div>
        </div>
    </section>

	<div id="press-release">
		<div class="container py-5">
			<div class="row">
				<asp:Repeater ID="rptAwards" runat="server">
					<ItemTemplate>
						<%--<h3 class="clr-black fw-semibold text-center">Honoured with awards for Excellence and Innovation</h3>--%>
						<div class="col-lg-3 col-sm-6  pt-5">

							<div class="press-box h-100 position-relative text-center">
								<a href='<%# ResolveUrl("~/poweradmin/webfiles/PressReleases/") + Eval("image") %>' data-fancybox="gallery">
									<img class="img-fluid  media-img"
										src='<%# ResolveUrl("~/poweradmin/webfiles/PressReleases/") + Eval("image") %>'
										alt='<%# Eval("title") + " " + String.Format("{0:D2}", Container.ItemIndex + 1) + " - Bankers Heart Institute" %>'>
								</a>
								<div class="ribbon ribbon-top-left">
									<span class="avail"><%# Eval("PressReleases_Date", "{0:dd MMM yyyy}") %></span>

								</div>
								<div class="bg-red py-3 px-2 h-100">
									<p class="text-center text-white mb-0"><%# Eval("title") %></p>
								</div>

							</div>
						</div>
					</ItemTemplate>
				</asp:Repeater>
			</div>
			<div class="row pt-5 mt-3 justify-content-center text-center">
				<asp:PlaceHolder ID="PaginationAwardsPlaceholder" runat="server"></asp:PlaceHolder>
			</div>
		</div>
	</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="extrajs" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui/dist/fancybox.umd.js"></script>

    <script>
		$('[data-fancybox="gallery"]').fancybox({
			buttons: [
				"zoom",        // Zoom in button will appear
				"slideShow",
				"thumbs",
				"close"
			],
			animationEffect: "zoom-in-out", // Smooth zoom animation
			transitionEffect: "fade",      // Fade effect between images
			loop: true                     // Loop through images in the gallery
		});
	</script>
</asp:Content>
