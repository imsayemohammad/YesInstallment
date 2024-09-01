<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="Accounts_Trans_Summary.aspx.cs" Inherits="Yesbd.Report.UI.Accounts_Trans_Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />
    <link href="/MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="/MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="/MenuCssJs/js/jquery-ui.js"></script>

    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_other .ajax__calendar_day,
        .cal_Theme1 .ajax__calendar_other .ajax__calendar_year {
            color: White; /*Your background color of calender control*/
        }

        .txtColor {
            margin-left: 0px;
        }

        .AutoExtender {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            max-height: 180px;
            list-style: none;
            overflow: scroll;
            /*border: 1px solid #808080;
            border-radius: 10px;*/
        }

        .AutoExtenderList {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: black;
        }

        .AutoExtenderHighlight {
            color: black;
            background-color: #ddd;
            cursor: pointer;
            border: 1px solid #808080;
            border-radius: 4px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="col-md-12" id="mainContentBox">
        <div id="contentBox" style="display: block">
            <div id="contentHeaderBox">
                <h1>Date wise Transaction Summary</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->
            </div>
            <!-- content header end -->

            <!-- Content Start From here -->
            <div class="form-class">
                <div class="row"></div>
                <div class="row form-class">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        From <strong>:</strong>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtFrom" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnTextChanged="txtFrom_TextChanged" TabIndex="2"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFrom" CssClass="well txtColor" runat="server" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblClientID" runat="server" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="row form-class">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        To <strong>:</strong>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtTo" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnTextChanged="txtTo_TextChanged" TabIndex="3"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtTo" CssClass="well txtColor" runat="server" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <div class="row form-class">
                    <div class="col-md-5"></div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Font-Bold="True"
                            CssClass="form-control btn-primary" Style="text-align: center" OnClick="btnSearch_Click" TabIndex="4" />
                    </div>
                    <div class="col-md-5">
                        <asp:Label ID="lblErrorMSG" runat="server" ForeColor="#990000" Visible="False" Font-Bold="True" Font-Italic="True"></asp:Label>
                    </div>
                </div>
            </div>
            <!-- Content End From here -->
        </div>
    </div>
</asp:Content>

