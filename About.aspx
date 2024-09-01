<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Yesbd.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    <br />
    <br />
     <hgroup class="title">
        <h1> About Us</h1>
        <h2></h2>
    </hgroup>
    <br />

    <article>
        
        <a href="Contact.aspx"></a>
    </article>

<%--    <aside>
        <h3>Aside Title</h3>
        <p>        
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About">About</a></li>
            <li><a runat="server" href="~/Contact">Contact</a></li>
        </ul>
    </aside>--%>
        <script type="text/javascript" src="Scripts/bootstrap-hover-dropdown.js"></script>

    <script>
        // very simple to use!
        $(document).ready(function () {
            $('.js-activated').dropdownHover().dropdown();
        });
    </script>
</asp:Content>