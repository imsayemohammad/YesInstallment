<%@ Page Title="Customer Information" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="ClientInfo.aspx.cs" Inherits="Yesbd.Input_Portion.ClientInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customer Information</title>

    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/sweet-alert.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtDate").datepicker({ dateFormat: "dd/mm/yy", changeMonth: true, changeYear: true, yearRange: "-100:+0" });
        });
    </script>

    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_other .ajax__calendar_day,
        .cal_Theme1 .ajax__calendar_other .ajax__calendar_year {
            color: White; /*Your background color of calender control*/
        }

        /*.auto-style1 {
            text-align: center;
        }*/
        .auto-style1 {
            text-align: center;
        }

        .txtColor:focus {
            border: solid 4px grey !important;
        }

        .txtColor {
            margin-left: 0px;
            text-align: left;
        }

        .completionList {
            width: 220px !important;
            margin: 0px;
            padding: 2px;
            overflow: auto;
            border-radius: 5px;
            background-color: #CCCCCC;
            list-style-type: none;
        }

        .listItem {
            color: #1C1C1C;
        }

        .itemHighlighted {
            background-color: orange;
        }

        .BoxModel {
            border: 1px solid #cfcfcf;
            width: 100%;
            padding: 7px;
            border-radius: 4px;
        }

        .txthightlight {
            border: 3px solid #cfcfcf;
            width: 100%;
            padding: 3px;
            border-radius: 4px;
            display: block;
            text-align: center;
        }

        .decimalValue {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:UpdatePanel ID="Up_TabContaner" runat="server">
        <ContentTemplate>
            <div class="col-md-12">
                <div id="contentBox">
                    <div id="contentHeaderBox">
                        <h1>Customer Information(আবেদন ফরম)</h1>
                        <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->

                        <!-- logout option button -->
                        <div class="btn-group pull-right" id="editOption">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                <i class="fa fa-cog"></i>
                            </button>
                            <ul class="dropdown-menu pull-right" style="" role="menu">
                                <li><a href="ClientInfo.aspx">
                                    <%--<i class="fa fa-edit"></i>--%>
                                    <asp:Button ID="btnClientNMEdit" CssClass="fa fa-pencil-square-o" Style="text-align: center" Visible="False" ToolTip="Edit গ্রাহকের নাম" Text="Edit গ্রাহকের নাম" runat="server" OnClick="btnClientNMEdit_Click" />
                                </a>
                                </li>
                                <li><a href="ClientInfo.aspx">
                                    <asp:Button ID="btnCancel" CssClass="fa fa-pencil-square-o" Style="text-align: center" Visible="False" ToolTip="বাতিল" Text="Cancel (বাতিল)" runat="server" OnClick="btnCancel_Click" />
                                </a>
                                </li>
                            </ul>
                        </div>
                        <!-- end logout option -->

                    </div>
                    <!-- content header end -->

                    <!-- Content Start From here -->
                    <div class="form-class">
                        <div class="row"></div>
                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">তারিখ :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtDate" TabIndex="1" AutoPostBack="True" CssClass="form-control input-sm txtColor" runat="server" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" CssClass="well txtColor" runat="server" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">ফরম নং :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtInvoiceNo" ReadOnly="True" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">গ্রাহক নং :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtClientID" ReadOnly="True" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">হিসাব নং :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtClientAccNo" TabIndex="2" CssClass="form-control input-sm text-right txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">পূর্বের হিসাব নং :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtOldPreAccNo" TabIndex="3" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">কিস্তি :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtLoanDuration" TabIndex="4" AutoPostBack="True" CssClass="form-control input-sm txtColor" runat="server" OnTextChanged="txtLoanDuration_TextChanged"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">অবশিষ্ট তারিখ :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtDueDate" TabIndex="5" AutoPostBack="True" CssClass="form-control input-sm txtColor" runat="server" OnTextChanged="txtDueDate_TextChanged"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDueDate" CssClass="well txtColor" runat="server" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">গ্রাহকের ধরণ :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlClientType" runat="server" TabIndex="6" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlClientType_SelectedIndexChanged">
                                    <asp:ListItem Value="NEW">NEW</asp:ListItem>
                                    <asp:ListItem Value="OLD">OLD</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <b lang="BN-BD">কিস্তি স্ট্যাটাস :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlLoanStatus" runat="server" TabIndex="7" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlLoanStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="UNPAID">UNPAID</asp:ListItem>
                                    <asp:ListItem Value="PAID">PAID</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">গ্রাহকের নাম :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtClientNM" TabIndex="9" CssClass="form-control input-sm txtColor" runat="server" OnTextChanged="txtClientNM_TextChanged"></asp:TextBox>

                                <asp:DropDownList ID="ddlClientNM" runat="server" AutoPostBack="True" Visible="False" TabIndex="9" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlClientNM_SelectedIndexChanged">
                                    <%--<asp:ListItem>SELECT</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2"><b lang="BN-BD">বয়স :</b></div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtAge" TabIndex="10" CssClass="form-control input-sm txtColor" AutoPostBack="True" runat="server" OnTextChanged="txtAge_TextChanged"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">পিতার নাম :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtFNM" TabIndex="11" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">মাতার নাম :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMNM" TabIndex="12" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">স্বামী/স্ত্রীর নাম :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtSpouse" TabIndex="13" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <b lang="BN-BD">ছেলে :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtBoy" TabIndex="14" CssClass="form-control input-sm txtColor" AutoPostBack="True" runat="server" OnTextChanged="txtBoy_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <b lang="BN-BD">মেয়ে :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtGirl" TabIndex="15" CssClass="form-control input-sm txtColor" AutoPostBack="True" runat="server" OnTextChanged="txtGirl_TextChanged"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">মনোনীত ব্যক্তির নাম :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtNominee" TabIndex="16" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">সম্পর্ক :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRelation" TabIndex="17" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">গাড়ির ধরণ :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlVehicleType" runat="server" TabIndex="18" AutoPostBack="True" CssClass="form-control input-sm">
                                    <asp:ListItem Value="NEW">NEW</asp:ListItem>
                                    <asp:ListItem Value="OLD">OLD</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">গাড়ির নং :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtVehicleNo" TabIndex="19" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <%--<div class="BoxModel" runat="server" id="DivForOld" Visible="False">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Label runat="server" ID="lblOldClientPortion" Text="পুরাতন গ্রাহকঃ " CssClass="txthightlight" Visible="True"></asp:Label>
                                        </div>
                                        <div class="col-md-8 text-right">
                                            <asp:Label ID="lblOldMsg" runat="server" Font-Bold="True" Font-Italic="True" Visible="False" ForeColor="#CC3300"></asp:Label>
                                            <asp:Label ID="lblMSGError2" runat="server" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>


                        <div class="BoxModel" runat="server" id="DivForCalculation">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Label runat="server" ID="lblAccClientPortion" Text="হিসাবের আংশঃ " CssClass="txthightlight" Visible="True"></asp:Label>
                                            <br/>
                                        </div>
                                        <div class="col-md-8 text-right">
                                            <asp:Label ID="lblOldMsg" runat="server" Font-Bold="True" Font-Italic="True" Visible="False" ForeColor="#CC3300"></asp:Label>
                                            <asp:Label ID="lblMSGError2" runat="server" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">প্রদেয় :</b>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtCompnayPayable" TabIndex="20" AutoPostBack="True" CssClass="form-control input-sm txtColor decimalValue" runat="server" OnTextChanged="txtCompnayPayable_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">কথায় :</b>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtCompnayPayable_Inwards" TabIndex="21" placeholder="প্রদেয় কথায়" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">গ্রাহকের প্রদেয় :</b>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtClientPayable" TabIndex="22" AutoPostBack="True" CssClass="form-control input-sm txtColor decimalValue" runat="server" OnTextChanged="txtClientPayable_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">কথায় :</b>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtClientPayable_Inwards" TabIndex="23" placeholder="গ্রাহকের প্রদেয় কথায়" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">মুল্য :</b>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtLoanAmount" TabIndex="24" AutoPostBack="True" CssClass="form-control input-sm text-right txtColor decimalValue" runat="server" OnTextChanged="txtLoanAmount_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">কথায় :</b>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtLoanAmount_Inwards" TabIndex="25" placeholder="ঋণ মুল্য কথায়" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">অবশিষ্ট টাকা :</b>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtDueAmt" TabIndex="26" AutoPostBack="True" CssClass="form-control input-sm text-right txtColor decimalValue" runat="server" OnTextChanged="txtDueAmt_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">কথায় :</b>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtDueAmt_Inwards" TabIndex="27" placeholder="অবশিষ্ট টাকা কথায়" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">মাসিক কিস্তি :</b>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtMonthlyInstallment" TabIndex="28" AutoPostBack="True" CssClass="form-control input-sm text-right txtColor" runat="server" OnTextChanged="txtMonthlyInstallment_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">কথায় :</b>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtMonthlyInstallment_Inwards" TabIndex="29" placeholder="মাসিক কিস্তি সংখ্যায় (মাসিক কিস্তি কথায়)" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">মাসিক ভাড়া :</b>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtMonthlyRent" TabIndex="30" AutoPostBack="True" CssClass="form-control input-sm txtColor decimalValue" runat="server" OnTextChanged="txtMonthlyRent_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">কথায় :</b>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtMonthlyRent_Inwards" TabIndex="31" placeholder="মাসিক ভাড়া কথায়" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />
                        <%--<asp:Panel ID="PanelAddres" runat="server" GroupingText="স্থায়ী ঠিকানা">--%>
                        <div class="BoxModel">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Label runat="server" ID="lblAddres" Text="স্থায়ী ঠিকানাঃ" CssClass="txthightlight" Visible="True"></asp:Label>
                                        </div>
                                        <div class="col-md-8 text-right">
                                            <asp:Label ID="lblUpLoadMSG" runat="server" Font-Bold="True" Font-Italic="True" Visible="False" ForeColor="#CC3300"></asp:Label>
                                            <asp:Label runat="server" ID="lblLoginByMSG" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                            <asp:Label ID="lblMSGError1" runat="server" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                            <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                            <asp:Label runat="server" ID="lblMSGERROR" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">বাড়ি :</b>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtHouse" TabIndex="33" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <b lang="BN-BD">ওয়ার্ড :</b>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtWard" TabIndex="34" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">গ্রাম :</b>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtVillage" TabIndex="35" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <b lang="BN-BD">ইউনিয়ন/পৌরসভা :</b>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtTownship" TabIndex="36" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row form-class">
                                <div class="col-md-2">
                                    <b lang="BN-BD">ডাকঘর :</b>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtPostOffice" TabIndex="37" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">থানা :</b>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtPoliceS" TabIndex="38" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <b lang="BN-BD">জেলা :</b>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtDistrict" TabIndex="39" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--</asp:Panel>--%>
                        <br />
                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">যোগাযোগের টিকানা :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtContactAdd" TabIndex="40" CssClass="form-control input-sm txtColor" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">স্ট্যাটাস :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <%--<asp:ListItem>SELECT</asp:ListItem>--%>
                                    <asp:ListItem Value="A">এক্টিভ</asp:ListItem>
                                    <asp:ListItem Value="I">ইন-এক্টিভ</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">মোবাইল নং (বাসা):</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtMob_Home" TabIndex="41" MaxLength="11" CssClass="form-control input-sm txtColor" placeholder="মোবাইল নং (বাসা)" AutoPostBack="True" runat="server" OnTextChanged="txtMob_Home_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">মোবাইল নং (গ্রাহক):</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPMbNo" TabIndex="42" MaxLength="11" CssClass="form-control input-sm txtColor" placeholder="মোবাইল নং (গ্রাহক)" AutoPostBack="True" runat="server" OnTextChanged="txtPMbNo_TextChanged"></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="MobileNo1Validator"
                                    runat="server"
                                    ErrorMessage="Insert a valid phone number like 01711001100"
                                    ControlToValidate="txtPMbNo"
                                    ValidationExpression="^([0-9]{11})"
                                    SetFocusOnError="true"
                                    CssClass="alert-danger">
                                </asp:RegularExpressionValidator>--%>
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">টেলিফোন নং :</b>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtTelNo" TabIndex="43" CssClass="form-control input-sm txtColor" AutoPostBack="True" runat="server" OnTextChanged="txtTelNo_TextChanged"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b lang="BN-BD">মনোনীত ব্যক্তির ছবি :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:FileUpload ID="FileUpload_Nominee" runat="server" />
                            </div>
                            <div class="col-md-2">
                                <b lang="BN-BD">গ্রাহকের ছবি :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:FileUpload ID="FileUpload_Client" runat="server" />
                            </div>
                        </div>
                        <br />
                        <div class="row form-class">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="btnSubmit" CssClass="form-control btn-primary" Style="text-align: center" TabIndex="50" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="btnReset" CssClass="form-control btn-primary" Style="text-align: center" runat="server" TabIndex="51" Text="Reset" OnClick="btnReset_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnsave_print" CssClass="form-control btn-primary" Style="text-align: center" Text="Save & Print" TabIndex="52" runat="server" OnClick="btnsave_print_Click" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="btnEditNew" CssClass="form-control btn-primary" Style="text-align: center" Text="Edit" TabIndex="53" runat="server" OnClick="btnEditNew_Click" />
                            </div>
                            <div class="col-md-3">
                                <asp:Label runat="server" ID="lblClientid" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblMaxCleintID" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblSrl" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblCheckSrl" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblMaxInvoice" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblClientNM" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lbldate" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblCheckClientImg" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblCheckNomineeImg" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- Content End From here -->
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:PostBackTrigger ControlID="btnsave_print" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
