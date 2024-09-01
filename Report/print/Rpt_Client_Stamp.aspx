<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rpt_Client_Stamp.aspx.cs" Inherits="Yesbd.Report.print.Rpt_Client_Stamp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clinet Information</title>
    <link href="../../favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/sweet-alert.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />

    <script type="text/javascript">
        function ClosePrint() {
            var print = document.getElementById("print");
            print.style.visibility = "hidden";
            //            print.display = false;

            window.print();
        }
    </script>
    <style type="text/css">
        #btnPrint {
            font-weight: 700;
        }

        .auto-style1 {
            width: 100%;
            height: 8%;
        }

        .page {
            width: 21cm;
            padding: .0cm;
            margin: 1cm auto;
        }

        .subpage {
            padding: 1cm;
            border: 5px red solid;
            height: 237mm;
            outline: 2cm #FFEAEA solid;
        }

        @page {
            size: A4;
            margin: 0;
            margin-bottom: 1.7cm;
            margin-top: 1.7cm;
        }

        @media print {
            .page {
                margin: 0;
                border: initial;
                border-radius: initial;
                width: initial;
                min-height: initial;
                box-shadow: initial;
                background: initial;
                page-break-after: always; /* here always for subpage */
            }
        }

        .txtColor:focus {
            border: solid 4px green !important;
        }

        .txtColor {
            margin-left: 0px;
        }

        .style25 {
            width: 223px;
            font-family: Arial, Helvetica, sans-serif;
        }

        .img {
            /*float: right;
            position: absolute;
            right: 153px;
            top: 200px;
            z-index: 1000;*/
            width: 150px;
            height: 120px;
        }

        .auto-style2 {
            width: 289px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
        }

        .auto-style3 {
            width: 289px;
        }

        .tblAmount th, .tblAmount td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 5px;
            text-align: left;
        }
        .clsdynamicvalue {
            font-weight: bold;
        }
        /*.spaceUnder{
            border-collapse: separate;
            border-spacing: 0 5px;
        }*/
    </style>
</head>
<body style="background-color: #fafafa;">
    <form id="form1" runat="server">
        <div class="page">
            <div style="float: left; width: 100%; background: none repeat scroll 0 0 white; border-radius: 5px;">
                <%--<div style="margin: 0 auto; padding: 10px 10px 30px; width: 1200px; height: auto; border: 1px solid #d3d3d3; border-radius: 5px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); background: none repeat scroll 0 0 white;">--%>
                <div>
                    <div>
                        <table class="auto-style1">
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; font-family: Arial;" colspan="3">&nbsp;</td>
                                <td style="text-align: center; font-family: Arial;">&nbsp;</td>
                                <td style="text-align: center; font-family: Arial;" colspan="3">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center;" rowspan="5" colspan="3">&nbsp;
                                <asp:Image ID="ImgNominee" runat="server" ImageUrl="" CssClass="img" />&nbsp;
                                <%--<img id="Image1" src="" alt="logo" style="float: left; width: 187px; height: 53px; margin-top: -18px;" />--%>
                                </td>
                                <%--<td style="text-align: center; font-size: medium; color: black; height: 20px; width: 50%; font-family: Arial;"><img src="/Images/bismillah.jpg" alt="bismillah" style="width: 300px; height: 20px;" /></td>--%>
                                <td style="text-align: center; font-size: small; color: black; height: 20px; width: 50%; font-family: Arial;"><span lang="BN-BD">বিসমিল্লাহির রাহমানির রাহিম</span></td>
                                <td style="text-align: center;" rowspan="5" colspan="3">&nbsp;
                                <asp:Image ID="ImgClient" runat="server" ImageUrl="" CssClass="img" />&nbsp;
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; font-size: small; color: black; height: 20px; width: 50%; font-family: Arial;">&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblMotto" runat="server"></asp:Label></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; font-size: small; color: black; height: 20px; width: 65%; font-family: Arial;">&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblCompanyMotto" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; font-size: large; color: black; height: 25px; width: 50%; font-family: Dodger;">
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label><br />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; font-size: small; color: black; height: 20px; width: 50%; font-family: Arial;">&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblCompanyAddress" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; font-size: large; font-weight: 700; font-family: Arial; width: 25%;" colspan="3">&nbsp;</td>
                                <td style="text-align: center; font-size: large; font-weight: 700; font-family: Arial; width: 50%;">&nbsp;</td>
                                <%--<td style="width: 3%;">
                                <asp:ImageButton ID="print" CommandName="Print" runat="server" ImageUrl="~/Images/print.png" ToolTip="Print" TabIndex="1" OnClientClick="ClosePrint()" />
                            </td>--%>
                                <td style="text-align: left; font-size: small; font-family: Arial;" colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: right; font-size: small; font-family: Arial; width: 10%;"><span lang="BN-BD">তারিখ</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 1%;"><span>:</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial;">
                                    <asp:Label runat="server" ID="lblDate"></asp:Label></td>
                                <td style="text-align: center; font-size: small; font-family: Arial; width: 35%;"></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 20%;">একাউন্ট নং</td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 1%;"><span>:</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial;"><span lang="BN-BD">
                                    <asp:Label ID="lblClientAccNo" runat="server"></asp:Label></span></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: right; font-size: small; font-family: Arial; width: 10%;"><span lang="BN-BD">প্রদেয়</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 1%;"><span>:</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial;"><span lang="BN-BD">
                                    <asp:Label runat="server" ID="lblCompanyPayable" CssClass="clsdynamicvalue"></asp:Label></span></td>
                                <td style="text-align: center; font-size: medium; font-weight: bold; font-family: Arial; width: 40%;">&nbsp;&nbsp;&nbsp; <span lang="BN-BD">(গ্রাহকের আবেদন ফরম)</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 15%;"><span lang="BN-BD">কিস্তি</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 1%;"><span>:</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial;">
                                    <asp:Label runat="server" ID="lblLoanDuration"></asp:Label></td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: right; font-size: small; font-family: Arial; width: 10%;"><span lang="BN-BD">ফরম নং</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 1%;"><span>:</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial;">
                                    <asp:Label runat="server" ID="lblInvoiceno"></asp:Label></td>
                                <td style="text-align: center; font-size: small; font-family: Arial; width: 40%;"></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 15%;"><span lang="BN-BD">মুল্য</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial; width: 1%;"><span>:</span></td>
                                <td style="text-align: left; font-size: small; font-family: Arial;">
                                    <asp:Label runat="server" ID="lblLoanAmount" CssClass="clsdynamicvalue"></asp:Label></td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; font-family: Arial;" colspan="3">&nbsp;</td>
                                <td style="text-align: center; font-family: Arial;">&nbsp;</td>
                                <td style="text-align: center; font-family: Arial;" colspan="3">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                    </div>

                    <table style="width: 100%; padding: 10px">
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">মাসিক ভাড়া</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblMonthlyRent" CssClass="clsdynamicvalue"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">অবশিষ্ট টাকা</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;">
                                <asp:Label runat="server" ID="lblDueAmount" CssClass="clsdynamicvalue"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">গ্রাহকের নাম</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 45%; text-align: left;" colspan="4">
                                <asp:Label runat="server" ID="lblClientNM"></asp:Label></td>
                            <td style="width: 12%; text-align: left" colspan="2"><span lang="BN-BD">বয়স</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 25%; text-align: left;">
                                <asp:Label runat="server" ID="lblClientAge"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">পিতার নাম</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblFatherNM"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">মাতার নাম</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblMotherNM"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">স্বামী/স্ত্রীর নাম</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblSpouse"></asp:Label></td>
                            <td style="width: 6%; text-align: right"><span lang="BN-BD">ছেলে</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 14%; text-align: left;" colspan="2">
                                <asp:Label runat="server" ID="lblBoy"></asp:Label></td>
                            <td style="width: 5%; text-align: right"><span lang="BN-BD">মেয়ে</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 16%; text-align: left;">
                                <asp:Label runat="server" ID="lblGirl"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">মনোনীত ব্যক্তির নাম</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblNominee"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">সম্পর্ক</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblRelation"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>

                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 17%; text-align: right;"><span lang="BN-BD" style="text-align: left">স্থায়ী ঠিকানাঃ&nbsp;বাড়ি</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblHouse"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">ওয়ার্ড</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblWard"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">ইউনিয়ন/পৌরসভা</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblTownship"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">গ্রাম</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblVillage"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">ডাকঘর</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblPostOffice"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">থানা</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblPoliceS"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">জেলা</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblDistrict"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">টেলিফোন নং</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblTelNo"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">মোবাইল নং(গ্রাহক)</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblMobile"></asp:Label></td>
                            <td style="width: 15%; text-align: left"><span lang="BN-BD">মোবাইল নং(বাসা)</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 27%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblMobileHome"></asp:Label></td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">গাড়ির নং</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblVehicleNo" CssClass="clsdynamicvalue"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">পূর্বের হিসাব নং</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblPreAccNo"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">গাড়ির ধরণ</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblVehicleType"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">গ্রাহকের ধরণ</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblClientType"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="width: 12%; text-align: right;"><span lang="BN-BD">যোগাযোগের টিকানা</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 40%; text-align: left;">
                                <asp:Label runat="server" ID="lblContactAdd"></asp:Label></td>
                            <td style="width: 12%; text-align: right"><span lang="BN-BD">গ্রাহকের প্রদেয়</span></td>
                            <td style="width: 1%; text-align: center"><strong>:</strong></td>
                            <td style="width: 30%; text-align: left;" colspan="5">
                                <asp:Label runat="server" ID="lblClientPayable" CssClass="clsdynamicvalue"></asp:Label></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <%--<tr>
                            <td style="width: 2%">&nbsp;</td>
                            <td style="width: 12%; text-align: right;">&nbsp;</td>
                            <td style="width: 1%; text-align: center">&nbsp;</td>
                            <td style="text-align: left;" colspan="8">&nbsp;</td>
                            <td style="width: 1%">&nbsp;</td>
                        </tr>--%>
                    </table>
                    <br />
                    <br />
                    <table class="spaceUnder" style="width: 100%; padding: 10px">
                        <%--<tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: center; font-size: medium; font-weight: bold"><span lang="BN-BD">..............ক্রয় প্রসঙ্গে ।</span></td>
                            <td style="width: 2%"></td>
                        </tr>--%>
                        <tr>
                            <td style="width: 2%"></td>
                            <%--<td style="text-align: left; font-size: small;"><span lang="BN-BD">আমার পরিবারের ব্যয় মেটানোর উদ্দেশ্যে এবং সমাজে আর্থিকভাবে স্বাবলম্বী হওয়ার লক্ষ্যে আপনার সুন্দর ও সুশৃঙ্খল ব্যবস্থাপনায় পরিচালিত প্রতিষ্ঠান হতে নির্ধারিত মাসিক ভাড়া সহ &nbsp;&nbsp;&nbsp; ০,০০,০০০(০ &nbsp;&nbsp;&nbsp; লক্ষ &nbsp;&nbsp;&nbsp;&nbsp; ০ &nbsp;&nbsp;&nbsp;&nbsp; হাজার &nbsp;&nbsp;&nbsp;&nbsp; ০ &nbsp;&nbsp;&nbsp;&nbsp; শত) টাকা ১২(&nbsp;&nbsp;&nbsp;,০০০*১২/&nbsp;&nbsp;&nbsp;,০০০*৬ +&nbsp;&nbsp;&nbsp;,০০০*৬) কিস্তিতে পরবর্তী বছর&nbsp;&nbsp;০০/০০/২০ তারিখের মধ্যে পরিশোধের অঙ্গীকারে একটি সিএনজি ক্রয় করতে আগ্রহী। আমি এ মর্মে ঘোষণা করেছি
উপরোক্ত পরিচিতি ও অন্যান্য বিবরণ সম্পূর্ণরূপে সঠিক। নিম্নে বর্ণিত গ্রাহকদের পালনীয় নিয়ম-নীতি ও ভবিষ্যতে প্রয়োজনে প্রবর্তিত সকল নিয়ম-নীতি মেনে চলতে বাধ্য থাকব।
                            </span></td>--%>
                            <%
                                if (string.IsNullOrEmpty(lblClientDueDate.Text))
                                { %>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">আমার পরিবারের ব্যয় মেটানোর উদ্দেশ্যে এবং সমাজে আর্থিকভাবে স্বাবলম্বী হওয়ার লক্ষ্যে আপনার সুন্দর ও সুশৃঙ্খল ব্যবস্থাপনায় পরিচালিত 
                                প্রতিষ্ঠান হতে নির্ধারিত মাসিক ভাড়া সহ
                                <asp:Label ID="lblLoanAmountwithInwards" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                টাকা
                                <asp:Label ID="lblLoanDuration_with_Installments" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                কিস্তিতে পরবর্তী বছর
                                <asp:Label ID="lblPaymentDueDate" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                তারিখের মধ্যে পরিশোধের অঙ্গীকারে একটি সিএনজি ক্রয় করতে আগ্রহী। আমি এ মর্মে ঘোষণা করেছি 
                                উপরোক্ত পরিচিতি ও অন্যান্য বিবরণ সম্পূর্ণরূপে সঠিক। নিম্নে বর্ণিত গ্রাহকদের পালনীয় নিয়ম-নীতি ও ভবিষ্যতে প্রয়োজনে প্রবর্তিত সকল নিয়ম-নীতি মেনে চলতে বাধ্য থাকব।
                            </span></td>
                            <% }
                                else
                                { %>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">আমার পরিবারের ব্যয় মেটানোর উদ্দেশ্যে এবং সমাজে আর্থিকভাবে স্বাবলম্বী হওয়ার লক্ষ্যে আপনার সুন্দর ও সুশৃঙ্খল ব্যবস্থাপনায় পরিচালিত প্রতিষ্ঠান হতে নির্ধারিত 
                                মাসিক ভাড়া সহ
                                <asp:Label ID="lblLoanAmountwithInwards2" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                টাকার মধ্যে
                                <asp:Label ID="lblLoanDuration_with_InstallmentsAmt" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                টাকা
                                <asp:Label ID="lblLoanDuration_with_Installments2" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                কিস্তিতে এবং বাকি
                                <asp:Label ID="lblDueAmount_with_Wards" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                টাকা পরবর্তী বছর
                                <asp:Label ID="lblPaymentDueDate2" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                তারিখে একত্রে অবশিষ্ট টাকা অথবা পরবর্তী বছরে
                                <asp:Label ID="lblDueAmount_with_Wards2" runat="server" CssClass="clsdynamicvalue"></asp:Label>
                                টাকার নির্ধারিত মাসিক ভাড়া সহ কিস্তিতে পরিশোধের অঙ্গীকারে একটি সিএনজি ক্রয় করতে আগ্রহী। 
                                আমি এ মর্মে ঘোষণা করেছি উপরোক্ত পরিচিতি ও অন্যান্য বিবরণ সম্পূর্ণরূপে সঠিক। নিম্নে বর্ণিত গ্রাহকদের পালনীয় নিয়ম-নীতি ও ভবিষ্যতে প্রয়োজনে প্রবর্তিত সকল নিয়ম-নীতি মেনে চলতে বাধ্য থাকব।</span></td>
                            <% } %>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;">&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;">&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;">&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: right; font-size: small;">______________________<br />
                                গ্রাহকের স্বাক্ষর&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: medium; font-weight: bold;"><span lang="BN-BD">গ্রাহকদের অবশ্যই পালনীয় নিয়ম-নীতিঃ</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১) সিএনজি ক্রয়ের যাবতীয় কাগজপত্রের খরচ গ্রাহকের বহন করতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">২) <b><span style="font-family: Dodger;">মেসার্স ইউনুছ এন্টারপ্রাইজ</span></b>-এর দুই জন প্রাক্তন গ্রাহকের স্বাক্ষর যুক্ত সুপারিশ অত্যাবশ্যক।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৩) গ্রাহক অবশ্যই নিজে যাচাই-বাছাই করে সিএনজি ক্রয় করবে কারণ পরবর্তিতে কোন সমস্যার জন্য কর্তৃপক্ষ দায়ী থাকবে না।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৪) সিএনজির ক্রয়মূল্য পরিশোধের আগে পণ্যটি অন্য কাউকে হস্তান্তর বা বিক্রি করতে চাইলে অবশ্যই কর্তৃপক্ষকে জানাতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৫) কিস্তি ও সিএনজি ক্রয়-বিক্রয়ের যাবতীয় লেনদেন চেকের মাধ্যমে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৬) প্রতি মাসের নির্দিষ্ট তারিখের মধ্যে নির্দিষ্ট কিস্তি পরিশোধ করতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৭) কিস্তি পরিশোধ করতে এক মাস বিলম্ব হলে সিএনজি গাড়িটি বর্তমান বাজার মূল্যে বিক্রি করে গ্রাহকের পাওনা গ্রাহক এবং প্রতিষ্ঠানের<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;পাওনা প্রতিষ্ঠানকে বুঝিয়ে দিতে বাধ্য থাকবে। এক্ষেত্রে লাভ-ক্ষতির পরিমাণ গ্রাহকের বহন করতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৮) গ্রাহক যদি কোন কারণে চুক্তির সময়ের পূর্বে সিএনজি-টি বিক্রি বা সম্পূর্ণ টাকা পরিশোধ করতে চাই তাহলে সিএনজির ক্রয়মূল্য ও<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;নির্ধারিত মাসিক ভাড়া প্রদান করতে হবে। এক্ষেত্রে মাসের সংখ্যা চুক্তির তারিখ থেকে হিসাব করা হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৯) চুক্তি শেষ না হওয়া পর্যন্ত কর্তৃপক্ষ সিএনজি-টি দেখতে চাইলে অবশ্যই সিএনজি-টি নিয়ে অফিসে উপস্থিত হতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১০) সিএনজির নাম্বার, ডকুমেন্ট হালনাগাদ সংক্রান্ত কার্যক্রমে যদি পণ্যটি <b><span style="font-family: Dodger;">BRTA</span></b> পরিদর্শন করতে চাই তাহলে সময়মত পণ্যটি নিয়ে নিজ<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;দায়িত্বে <b><span style="font-family: Dodger;">BRTA</span></b> অফিসে যেতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১১) সিএনজির যাবতীয় ডকুমেন্ট হালনাগাদ প্রতিষ্ঠানের মাধ্যমে করতে হবে। এক্ষেত্রে ডকুমেন্ট হালনাগাদের যাবতীয় খরচ গ্রাহক বহন করবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১২) এই প্রতিষ্ঠানের সিএনজি দিয়ে অবৈধ, অনৈতিক কাজে লিপ্ত হওয়ার প্রমাণ পাওয়া গেলে কর্তৃপক্ষকে সিএনজি বুঝিয়ে দিতে গ্রাহক বাধ্য<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;থাকবে এবং অবৈধ, অনৈতিক কাজে লিপ্ত হওয়ার কারণে সরকারি আইনানুযায়ী শাস্তি, অর্থদন্ড গ্রাহক বহন করবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <%--<tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">৭) কিস্তি ও ক্রয়-বিক্রয়ের যাবতীয় লেনদেন চেকের মাধ্যমে হবে এবং প্রতি মাসের নির্দিষ্ট তারিখের ভেতর নির্দিষ্ট কিস্তি পরিশোধ করতে হবে,<br />
                                &nbsp;&nbsp;&nbsp; কিস্তি যদি ১ মাস বিলম্ব হয় তাহলে পণ্য বিক্রির মাধ্যমে গ্রাহকের পাওনা গ্রাহক আর প্রকল্পের পাওনা প্রকল্প বুঝে নিবে ।</span></td>
                            <td style="width: 2%"></td>
                        </tr>--%>
                    </table>

                    <table style="width: 98%; margin: 5% 1% 0% 1%; font-family: Calibri;">
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small; font-weight: bold;" class="auto-style3"><span lang="BN-BD">সুপারিশ করা গেল (প্রাক্তন গ্রাহক)</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <%--<tr>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="style25" style="text-align: center; font-size: small;"><span lang="BN-BD">সুপারিশ করা গেল ।</span></td>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="style25" style="text-align: center; font-size: small;"><span lang="BN-BD">বিবেচনা করা যেতে পারে ।</span></td>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="style25" style="text-align: center; font-size: small;"><span lang="BN-BD">অনুমোধন করা গেল/গেল না ।</span></td>
                            <td style="text-align: center">&nbsp;</td>
                        </tr>--%>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">&nbsp;</td>
                            <%--<td class="style25" style="text-align: center; font-size: small;">______________________________<br />
                                <span lang="BN-BD">প্রাক্তন গ্রাহক</span></td>--%>
                            <td class="auto-style2" style="font-size: small;"><span>১) স্বাক্ষরঃ
                                <br />
                                <br />
                                মোবাইল নংঃ </span></td>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="style25" style="text-align: center; font-size: small;">____________________________<br />
                                <span lang="BN-BD">চেয়ারম্যান/এমডি</span></td>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="style25" style="text-align: center; font-size: small;">____________________________<br />
                                <span lang="BN-BD">পরিচালক</span></td>
                            <td style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="auto-style2" style="font-size: small;"><span>২) স্বাক্ষরঃ
                                <br />
                                <br />
                                মোবাইল নংঃ </span></td>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="style25" style="text-align: center; font-size: small;">&nbsp;<br />
                                <span lang="BN-BD">&nbsp;</span></td>
                            <td style="text-align: right">&nbsp;</td>
                            <td class="style25" style="text-align: center; font-size: small;">&nbsp;<br />
                                <span lang="BN-BD">&nbsp;</span></td>
                            <td style="text-align: center">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <table class="spaceUnder" style="width: 100%; padding: 10px">
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১৩) সিএনজি ক্রয় করার পর চুক্তি অনুযায়ী ১ম বছরের কিস্তি পরিশোধ করে পরবর্তী বছরের জন্য নতুন চুক্তি করতে হবে। নতুন চুক্তি করার<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;সময় অফিসের খরচ প্রদান করতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১৪) কোন কারণে গ্রাহক নির্ধারিত তারিখে কিস্তি পরিশোধ করতে না পারলে অফিসে যোগাযোগ করে সর্বোচ্চ ৭ দিন পর্যন্ত সময় নিতে পারবে।<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;এক্ষেত্রে বর্ধিত সময়ের মধ্যে কিস্তি পরিশোধ করতে না পারলে সিএনজি গাড়িটি সহ স্বশরীরে অফিসে উপস্থিত হয়ে ম্যানেজিং<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ডিরেক্টর/পরিচালক বরাবর কিস্তি পরিশোধ করতে না পারার কারণ উল্লেখপূর্বক আবেদন প্রদান করতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>

                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১৫) কিস্তি পরিশোধ করার জন্য বর্ধিত সময় প্রতি মাসে নেওয়া যাবে না।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১৬) সিএনজি সম্পর্কিত কোন ধরণের বড় দূর্ঘটনা হলে তার ব্যয়ভার গ্রাহক বহন করবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১৭) কিস্তি প্রদানের তারিখে প্রতিষ্ঠানের অফিসার কর্তৃক কল করা হলে অযথা বাড়াবাড়ি, ঝগড়া ও অসংগতি মূলক কথা বলা যাবে না। শুধুমাত্র
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ব্যাংকে কিস্তি জমা করা অথবা কোন গুরুতর সমস্যা থাকলে কিস্তি জমা করার জন্য বর্ধিত সময় নেওয়া, ডকুমেন্ট হালনাগাদ,<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ডিজিটাল নাম্বার প্লেট সংযোজন ও চেক বই সম্পর্কিত কথাবার্তা বলা যাবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১৮) অফিসিয়াল কোন জরূরী বিষয়ে গ্রাহক-কে অফিসে উপস্থিত হওয়ার জন্য বলা হলে অবশ্যই সময়মতো অফিস চলাকালীন সময়ে উপস্থিত<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;থাকতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">১৯) কোন বিশেষ কারণে গ্রাহক অফিসের কল রিসিভ করতে না পারলে ফ্রী হওয়ার পর অফিসের নাম্বারে কল করতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">২০) কথোপকথনের সময় অফিসারদের সাথে মার্জনীয়, সুন্দর আচরণ করতে হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">২১) ম্যানেজিং ডিরেক্টর/পরিচালক বরাবর কিস্তি পরিশোধ করতে না পারার কারণ উল্লেখপূর্বক আবেদন করে সময় নেওয়ার পরও যদি কিস্তি<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;পরিশোধ করতে না পারে তাহলে কর্তৃপক্ষ যে সিদ্ধান্ত প্রদান করবে সেটা মানতে গ্রাহকগণ বাধ্য থাকবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">২২) চুক্তি সম্পাদন হওয়ার পর সিএনজি গাড়িটির মূল মালিকানা গ্রাহকের নিকট হস্তান্তর করা হবে এবং উক্ত সময়ে মালিকানা হস্তান্তর করার<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;যাবতীয় খরচ গ্রাহক বহন করবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small;"><span lang="BN-BD">২৩) সিএনজি ক্রয়-বিক্রয়, লেনদেন সম্পর্কিত যেকোন বিষয়ে কর্তৃপক্ষের সিদ্ধান্ত চুড়ান্ত বলে গণ্য হবে।</span></td>
                            <td style="width: 2%"></td>
                        </tr>

                    </table>
                    <br />
                    <table style="width: 100%; padding: 10px">
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small; font-weight: bold;" colspan="7"><span lang="BN-BD">উপরোক্ত সকল নিয়মাবলী বুঝে, শুনে স্ব-ইচ্ছায়, স্বজ্ঞানে, কাহারো বিনা প্ররোচনায় ও বিনা দ্ধিধায় নিজ নামে নিম্নে
                                <br />
                                স্বাক্ষর করিলাম ।</span></td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: right; font-size: small; font-weight: bold">____________________________<br />
                                স্বাক্ষর&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small; font-weight: bold"><span lang="BN-BD">
                                <table class="tblAmount" style="width: 70%">
                                    <tr>
                                        <td style="width: 16%; border: 0">**নতুন নাম্বারের</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 40%; border: 0">টাকা সহ হিসাব করে নতুন হিসাব খোলা হল।</td>
                                    </tr>
                                </table>
                                <br />
                                <table class="tblAmount" style="width: 40%">
                                    <tr>
                                        <td style="width: 3%; border: 0">&nbsp;&nbsp;&nbsp;তারিখঃ</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                    </tr>
                                </table>
                                <br />
                                <table class="tblAmount" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%; border: 0">** ডকুমেন্ট (&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) বাবদ</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 12%; border: 0">টাকা কিস্তি শেষে</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%; border: 0">টাকা </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 0" colspan="13">পরিশোধের অঙ্গীকারে নিজ নামে নিম্নে স্বাক্ষর করিলাম ।</td>
                                    </tr>
                                </table>
                                <br />

                            </span>
                            </td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: right; font-size: small; font-weight: bold">____________________________<br />
                                স্বাক্ষর&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small; font-weight: bold"><span lang="BN-BD">
                                <table class="tblAmount" style="width: 40%">
                                    <tr>
                                        <td style="width: 3%; border: 0">&nbsp;&nbsp;&nbsp;তারিখঃ</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                    </tr>
                                </table>
                                <br />
                                <table class="tblAmount" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%; border: 0">** ডকুমেন্ট (&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) বাবদ</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 12%; border: 0">টাকা কিস্তি শেষে</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%; border: 0">টাকা </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 0" colspan="13">পরিশোধের অঙ্গীকারে নিজ নামে নিম্নে স্বাক্ষর করিলাম ।</td>
                                    </tr>
                                </table>
                                <br />

                            </span>
                            </td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: right; font-size: small; font-weight: bold">____________________________<br />
                                স্বাক্ষর&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: left; font-size: small; font-weight: bold"><span lang="BN-BD">
                                <table class="tblAmount" style="width: 100%">
                                    <tr>
                                        <td style="width: 14%; border: 0">**নতুনভাবে প্রদেয়</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 16%; border: 0">টাকা সহ মোট টাকার</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 3%;">&nbsp;</td>
                                        <td style="width: 22%; border: 0">নতুন হিসাব খোলা হল।</td>
                                    </tr>
                                </table>
                                <br />
                                <table class="tblAmount" style="width: 90%">
                                    <tr>
                                        <td style="width: 34%; border: 0">** অদ্য তারিখ হতে ০২/০৫/১০ দিন পর পর</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 4%;">&nbsp;</td>
                                        <td style="width: 36%; border: 0">টাকা পরিশোধ করার অঙ্গীকার করিলাম।</td>
                                    </tr>
                                </table>
                            </span>
                            </td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="text-align: right; font-size: small; font-weight: bold">____________________________<br />
                                স্বাক্ষর&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td style="width: 2%"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" colspan="7">
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
                <asp:Label runat="server" ID="lblClientID" Visible="False"></asp:Label>
                <asp:Label runat="server" ID="lblimgclient" Visible="False"></asp:Label>
                <asp:Label runat="server" ID="lblimgnominee" Visible="False"></asp:Label>
                <asp:Label runat="server" ID="lblClientDueDate" Visible="False"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
