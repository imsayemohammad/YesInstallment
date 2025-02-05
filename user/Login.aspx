﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Yesbd.user.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta charset="utf-8" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
    <meta name="description" content="" />
    <meta name="author" content="Sergey Pozhilov (GetTemplate.com)" />
    <script src="assets/js/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"> </script>
    <script type="text/javascript" src="../Scripts/bootstrap-hover-dropdown.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/headroom.min.js"></script>
    <script src="assets/js/jQuery.headroom.min.js"></script>
    <script src="assets/js/template.js"></script>
    <title>Sign in</title>
    <%--<script>
        $(document).ready(function () {
            $('#<%=txtlink.ClientID%>').val($.session.get('URLLINK'));
            $.getJSON("http://jsonip.appspot.com?callback=?",
               function (data) {
                   $("#<%=txtIp.ClientID %>").val(data.ip);
               });
        });
    </script>--%>

    <link rel="shortcut icon" href="assets/images/favicon.ico" />

    <link rel="stylesheet" media="screen" href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,700" />
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />

    <!-- Custom styles for our template -->
    <link rel="stylesheet" href="assets/css/bootstrap-theme.css" media="screen" />
    <link rel="stylesheet" href="assets/css/main.css" />


    <style type="text/css">
        .myscroller {
            height: 355px;
            overflow-y: scroll;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="script1"></asp:ScriptManager>
        <!-- Fixed navbar -->

        <div class="navbar navbar-inverse navbar-fixed-top headroom">
            <div class="container">
                <div class="navbar-header">
                    <!-- Button for smallest screens -->
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                    <a class="navbar-brand" style="font-family: fantasy;" href="javascript:;">
                        <%--<img src="/user/assets/images/Yes-bd8.png" style="width: 25%; height: 10%; font-family: fantasy;" alt="মেসার্স ইউনুছ এন্টারপ্রাইজ" />--%>
                        মেসার্স &nbsp;ইউনুছ এন্টারপ্রাইজ&nbsp;</a>
                </div>
                <%--<div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav pull-right">
                        <li><a href="#">Home</a></li>
                        <li><a href="../About.aspx">About</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">More Pages <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Menu 1</a></li>
                                <li><a href="#">Menu 2</a></li>
                            </ul>
                        </li>
                        <li><a href="../Contact.aspx">Contact</a></li>
                        <li class="active"><a class="btn" href="Login.aspx">SIGN IN / SIGN UP</a></li>
                    </ul>
                </div>--%>
                <!--/.nav-collapse -->
            </div>
        </div>
        <!-- /.navbar -->

        <header id="head" class="secondary"></header>

        <!-- container -->
        <div class="container">

            <div class="row">

                <!-- Article main content -->
                <div class="col-md-12 maincontent">
                    <%--<header class="page-header">
					<h1 class="page-title">Sign in</h1>
				</header>--%>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <asp:TextBox runat="server" Style="display: none" ID="txtIp" ClientIDMode="Static"></asp:TextBox>
                            <div class="col-md-4 col-md-offset-4 col-sm-8 col-sm-offset-2" style="padding-top: 10px">
                                <div class="panel panel-default">
                                    <div class="panel-body">

                                        <h3 class="thin text-center">Sign in to your Account</h3>

                                        <hr />
                                        <asp:TextBox runat="server" Style="display: none" ID="txtLotiLongTude"></asp:TextBox>

                                        <div class="top-margin">
                                            <label>Username/Email <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName"
                                                CssClass="field-validation-error" ForeColor="red" ErrorMessage="The user name field is required." />
                                        </div>
                                        <div class="top-margin">
                                            <label>Password <span class="text-danger">*</span></label>
                                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="red"
                                                ControlToValidate="txtPassword" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                                        </div>
                                        <div class="text-center; top-margin">
                                            <asp:Label runat="server" ID="lblmsg" ForeColor="red"></asp:Label>
                                            <asp:Label runat="server" ID="lblmsg1" ForeColor="red"></asp:Label>
                                            <asp:Label runat="server" ID="lblLoginAs" ForeColor="red"></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txtlink" ClientIDMode="Static" Style="display: none" class="form-control" runat="server"></asp:TextBox>
                                        <hr />
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <%--<b><a href="#">Forgot password?</a></b>--%>
                                            </div>
                                            <div class="col-lg-6 text-right">
                                                <asp:Button runat="server" CommandName="Login" Text="Log in" ID="loginButton" CssClass="btn btn-action" OnClick="loginButton_Click" />
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <asp:Label ID="lblTP" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblNM" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lbluserCD" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblst" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblstUser" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblDynamicSTATUS" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblMenuID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblDept" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblFUllnm" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblempID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblEmpSurNM" runat="server" Visible="False"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- /Article -->

            </div>
        </div>
        <!-- /container -->


        <footer id="footer" class="top-space">

            <div class="footer1">
                <div class="container">
                    <div class="row">

                        <div class="col-md-3 widget">
                            <h3 class="widget-title">Contact</h3>
                            <div class="widget-body">
                                <p>
                                    <%--Tel: <br/>--%>
                                    +880-1866850985<br />
                                    <a href="mailto:#">tipuraz@gmail.com</a><br />
                                    ইউনুচ মঞ্জিল, স্বপনের দোকান,
                                    <br />
                                    সুলতানপুর, রাউজান, চট্টগ্রাম.
                                </p>
                            </div>
                        </div>

                        <div class="col-md-6 widget">
                        </div>

                        <div class="col-md-3 widget">
                            <h3 class="widget-title">Follow Us</h3>
                            <div class="widget-body">
                                <p class="follow-me-icons clearfix">
                                    <a href="#" target="_blank"><i class="fa fa-facebook"></i></a>
                                    <a href="#" target="_blank"><i class="fa fa-google-plus"></i></a>
                                    <a href="#" target="_blank"><i class="fa fa-twitter"></i></a>
                                    <a href="#" target="_blank"><i class="fa fa-youtube"></i></a>
                                </p>

                                <p>
                                    Copyright &copy; <%=DateTime.Now.Year %>, <a href="https://www.linkedin.com/in/imsayemohammad-32a39444/" target="_blank" rel="designer">Sayem Mohammad</a> All Rights Reserved.<br />
                                    <%--Developed by <a href="#" rel="designer">Yes-bd</a>--%>
                                </p>
                            </div>
                        </div>

                    </div>
                    <!-- /row of widgets -->
                </div>
            </div>
        </footer>

        <!-- JavaScript libs are placed at the end of the document so the pages load faster -->


        <script>
            $(document).ready(function () {
                navigator.geolocation.getCurrentPosition(showPosition);
                function showPosition(position) {
                    var coordinates = position.coords;
                    var long = coordinates.longitude;
                    var loti = coordinates.latitude;
                    $("#<%=txtLotiLongTude.ClientID %>").val(loti + ", " + long);

                }
            });
        </script>
    </form>
</body>
</html>
