<%@ Page Title="Accounts Entry" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="Accounts_Entry.aspx.cs" Inherits="Yesbd.Input_Portion.Accounts_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Import Namespace="Yesbd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />
    <link href="/MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="/MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="/MenuCssJs/js/jquery-ui.js"></script>

    <%--<script type="text/javascript">
        $(document).ready(function (e) {
            BindControlEvents();

        });
        function BindControlEvents() {
            $("#txtDate").datepicker({ dateFormat: "dd/mm/yy", changeMonth: true, changeYear: true, yearRange: "-100:+0" });

            <%--$("#<%=txtPNM.ClientID %>").keydown(function (e) {
                if (e.which == 9 || e.which == 13)
                    window.__doPostBack();
            });-%>

        };

        function confMSG() {
            if (confirm("Are you Sure to Delete?")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>--%>
    <script type="text/javascript">
        function confMSG() {
            if (confirm("Are you Sure to Delete?")) {
                return true;
            }
            else {
                return false;
            }
        }

        //$(document).ready(function () {
        //    $("#txtDate").datepicker({ dateFormat: "dd/mm/yy", changeMonth: true, changeYear: true, yearRange: "-100:+0" });
        //});
    </script>

    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_other .ajax__calendar_day,
        .cal_Theme1 .ajax__calendar_other .ajax__calendar_year {
            color: White; /*Your background color of calender control*/
        }

        .txtColor {
            margin-left: 0px;
        }

        .ui-autocomplete {
            max-width: 350px;
            max-height: 250px;
            overflow: auto;
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
    <asp:UpdatePanel ID="Up_TabContaner" runat="server">
        <ContentTemplate>
            <div class="col-md-12" id="mainContentBox">
                <div id="contentBox" style="display: block">
                    <div id="contentHeaderBox">
                        <h1>Accounts Entry</h1>
                        <!-- logout option button -->
                        <%--<div class="btn-group pull-right" id="editOption">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                <i class="fa fa-cog"></i>
                            </button>
                            <ul class="dropdown-menu pull-right" style="" role="menu">
                                <li><i class="fa fa-plus"></i>
                                    <%--<asp:LinkButton runat="server" ID="btnInsert" Text="Add"></asp:LinkButton>-%>
                                    <asp:Button ID="btnSaleEdit" runat="server" Font-Bold="True" OnClick="btnSaleEdit_Click" Text="EDIT" />
                                </li>
                            </ul>
                        </div>--%>
                        <!-- end logout option -->
                    </div>
                    <!-- content header end -->

                    <center>
                        <div style="width:100%">
                              <h2  class="form-control" style="width:300px; background:#066f90; color:#ffffff">ACCOUNTS INFORMATION</h2>
                        </div>
                    </center>

                    <div class="form-class">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="row form-class3px">
                                    <div class="col-md-3">
                                        Invoice Date :
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" ClientIDMode="Static"
                                            CssClass="form-control input-sm text-center" OnTextChanged="txtDate_TextChanged" TabIndex="1"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" CssClass="well txtColor" runat="server" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div class="col-md-2"></div>
                                    <div class="col-md-3">
                                        <asp:Button ID="btnEdit" runat="server" CssClass="form-control btn-primary" Style="text-align: center" Font-Bold="True" OnClick="btnEdit_Click"
                                            Text="EDIT" />
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>

                                <div class="row form-class3px">
                                    <div class="col-md-3">
                                        <span>Customer Name :</span>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtClientNM" TabIndex="2" AutoPostBack="True" CssClass="form-control input-sm" runat="server" OnTextChanged="txtClientNM_TextChanged"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="txtClientNM_AutoCompleteExtender" runat="server"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            CompletionInterval="10" CompletionSetCount="3" DelimiterCharacters=";, :" Enabled="True" 
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionListClientNM"
                                            ServicePath="Accounts_Entry.aspx" TargetControlID="txtClientNM" UseContextKey="True">
                                        </asp:AutoCompleteExtender>
                                        <%--<asp:DropDownList ID="ddlClientNM" runat="server" AutoPostBack="True" CssClass="form-control input-sm"
                                            OnSelectedIndexChanged="ddlClientNM_SelectedIndexChanged" TabIndex="2">
                                        </asp:DropDownList>--%>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>

                                <div class="row form-class3px">
                                    <div class="col-md-3">
                                        Transaction No :
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtTransactionNo" runat="server" CssClass="form-control input-sm" ReadOnly="True" TabIndex="2"></asp:TextBox>
                                        <asp:DropDownList ID="ddlTransactionNoEdit" runat="server"
                                            OnSelectedIndexChanged="ddlTransactionNoEdit_SelectedIndexChanged" TabIndex="3" AutoPostBack="True"
                                            CssClass="form-control input-sm" Visible="False">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        Invoice No :
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="form-control input-sm" TabIndex="4"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>

                                <div class="row form-class3px">
                                    <div class="col-md-3">
                                        Remarks : 
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" CssClass="form-control input-sm"
                                            OnTextChanged="txtRemarks_TextChanged" TabIndex="5"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                                <br />

                                <div class="row form-class3px">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblNominee" runat="server" Visible="False" CssClass="text-left"></asp:Label>
                                        <asp:Label ID="lblContactAdd" runat="server" Visible="False" CssClass="text-left"></asp:Label>
                                    </div>
                                    <div class="col-md-8 text-left">
                                        <asp:Label ID="lblErrorMSG" runat="server" ForeColor="#990000" Visible="False" Font-Bold="True" Font-Italic="True"></asp:Label>
                                        <asp:Label ID="lblSuccessMSG" runat="server" ForeColor="#CC3300" Visible="False" Font-Bold="True" Font-Italic="True"></asp:Label>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="panel panel-primary">
                                    <div class="panel-heading text-center"><strong lang="BN-BD">Customer Information(গ্রাহকের তথ্য) </strong></div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-5"><strong>Customer ID : </strong></div>
                                            <div class="col-md-7" style="text-align: left">
                                                <asp:Label ID="lblClientID" runat="server" Visible="True" CssClass="text-left"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5"><strong>Join Date : </strong></div>
                                            <div class="col-md-7" style="text-align: left">
                                                <asp:Label ID="lblJoinDT" runat="server" Visible="True" CssClass="text-left"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <strong>Loan :</strong>
                                            </div>
                                            <div class="col-md-7" style="text-align: left">
                                                <asp:Label ID="lblLoan" runat="server" Visible="True" CssClass="text-left"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <strong>Amount :</strong>
                                            </div>
                                            <div class="col-md-7" style="text-align: left">
                                                <asp:Label ID="lblLoanAmt" runat="server" Visible="True" CssClass="text-left"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <strong>Mobile No : </strong>
                                            </div>
                                            <div class="col-md-7" style="text-align: left">
                                                <asp:Label ID="lblMobileNo" runat="server" Visible="True" CssClass="text-left"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row"></div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="table table-responsive table-hover" style="border: 1px solid #ddd; border-radius: 5px;">
                                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderStyle="None" CellPadding="4" Width="100%" ShowFooter="True" Font-Names="Calibri" Font-Size="14px"
                                        OnRowCancelingEdit="gvDetail_RowCancelingEdit" OnRowCommand="gvDetail_RowCommand" OnRowDataBound="gvDetail_RowDataBound"
                                        OnRowDeleting="gvDetail_RowDeleting" OnRowEditing="gvDetail_RowEditing" OnRowUpdating="gvDetail_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL" Visible="False">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTransSLEdit" runat="server" Text='<%#Eval("TRANSSL") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTransSL" runat="server" Text='<%#Eval("TRANSSL") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Particulars (বিবরণ)">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtParticularsEdit" CssClass="form-control input-sm" runat="server" OnTextChanged="txtParticularsEdit_TextChanged"
                                                        TabIndex="12" Text='<%#Eval("PARTICULARS") %>' AutoPostBack="True" Font-Names="Calibri" Style="text-align: left" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtParticulars" runat="server" AutoPostBack="True" CssClass="form-control input-sm"
                                                        OnTextChanged="txtParticulars_TextChanged" TabIndex="7" Font-Names="Calibri" Style="text-align: left" />
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblParticulars" runat="server" Style="text-align: left" Text='<%# Eval("PARTICULARS") %>' />
                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="43%" />
                                                <ItemStyle HorizontalAlign="Left" Width="43%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remarks (মন্তব্য)">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGrdRemarksEdit" runat="server" CssClass="form-control input-sm" TabIndex="13" Style="text-align: left"
                                                        Text='<%#Eval("REMARKS") %>' Font-Names="Calibri" AutoPostBack="True" OnTextChanged="txtGrdRemarksEdit_TextChanged"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtGrdRemarks" runat="server" CssClass="form-control input-sm" Style="text-align: left"
                                                        TabIndex="8" Font-Names="Calibri" AutoPostBack="True" OnTextChanged="txtGrdRemarks_TextChanged"></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGrdRemarks" runat="server" Style="text-align: left" Text='<%# Eval("REMARKS") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Left" Width="30%" />
                                                <HeaderStyle HorizontalAlign="Center" Width="30%" />
                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Amount (জমা)">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtAmtEdit" CssClass="form-control input-sm" runat="server" TabIndex="14"
                                                        Text='<%#Eval("AMOUNT") %>' AutoPostBack="True" Font-Names="Calibri" OnTextChanged="txtAmtEdit_TextChanged"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtAmt" runat="server" CssClass="form-control input-sm"
                                                        TabIndex="9" AutoPostBack="True" Font-Names="Calibri" OnTextChanged="txtAmt_TextChanged">.00</asp:TextBox>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmt" runat="server" Style="text-align: right" Text='<%#Eval("AMOUNT") %>'
                                                        Width="100%"></asp:Label>
                                                </ItemTemplate>

                                                <FooterStyle HorizontalAlign="Right" Width="20%" />
                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CommandName="Update" Height="20px"
                                                        ImageUrl="~/Images/update.png" TabIndex="15" ToolTip="Update" Width="20px" />
                                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel"
                                                        Height="20px" ImageUrl="~/Images/Cancel.png" TabIndex="16" ToolTip="Cancel" Width="20px" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <% if (Yesbd.UserPermissionChecker.checkParmit("/Input_Portion/Accounts_Entry.aspx", "INSERTR") == true)
                                                       { %>
                                                    <asp:ImageButton ID="imgbtnAdd" runat="server" CommandName="SaveCon" CssClass="txtColor"
                                                        Height="30px" ImageUrl="~/Images/AddNewitem.png" TabIndex="10" ToolTip="Save &amp; Continue"
                                                        ValidationGroup="validaiton" Width="20px" />
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Complete" CssClass="txtColor"
                                                        Height="30px" ImageUrl="~/Images/checkmark.png" TabIndex="11" ToolTip="Complete"
                                                        ValidationGroup="validaiton" Width="20px" />
                                                    <%} %>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <% if (Yesbd.UserPermissionChecker.checkParmit("/Input_Portion/Accounts_Entry.aspx", "UPDATER") == true)
                                                       { %>
                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" Height="20px"
                                                        ImageUrl="~/Images/Edit.png" TabIndex="114" ToolTip="Edit" Width="20px" />
                                                    <%} %>
                                                    <% if (Yesbd.UserPermissionChecker.checkParmit("/Input_Portion/Accounts_Entry.aspx", "DELETER") == true)
                                                       { %>
                                                    <asp:ImageButton
                                                        ID="imgbtnDelete" runat="server" CommandName="Delete" Height="20px" ImageUrl="~/Images/delete.png"
                                                        TabIndex="15" OnClientClick="return confMSG()" ToolTip="Delete" Width="21px" />
                                                    <% }%>
                                                </ItemTemplate>
                                                <HeaderStyle Width="7%" />
                                                <ItemStyle Width="7%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999966" />
                                        <HeaderStyle BackColor="#999999" Font-Bold="True" ForeColor="White" BorderColor="#666666" BorderWidth="3px" />
                                        <RowStyle Font-Names="Calibri" />
                                    </asp:GridView>
                                    <table style="width: 100%; font-style: normal;">
                                        <tr>
                                            <td style="text-align: right; width: 20%">
                                                <asp:Label ID="lblGridMsg" runat="server" Font-Bold="False" ForeColor="#CC3300" Visible="False"></asp:Label>
                                            </td>
                                            <td style="text-align: right; width: 10%"></td>
                                            <td style="text-align: right; width: 10%"></td>
                                            <td style="width: 8%"></td>
                                            <td style="width: 6%"></td>
                                            <td style="text-align: right; width: 14%"><strong>Total :</strong></td>
                                            <td style="width: 3%"></td>
                                            <td style="width: 8%"></td>
                                            <td style="width: 21%">
                                                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" CssClass="form-control input-sm"
                                                    TabIndex="106" Style="text-align: right">.00</asp:TextBox>
                                            </td>
                                            <td style="width: 1%"></td>
                                            <td style="width: 3%">
                                                <asp:Button ID="btnComplete" runat="server" CssClass="form-control btn-primary" Style="text-align: center; font-size: x-small" OnClick="btnComplete_Click"
                                                    TabIndex="139" Text="Complete" ToolTip="Complete Transaction" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; width: 20%">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="#CC3300" Visible="False"></asp:Label>
                                            </td>
                                            <td style="text-align: right; width: 10%"></td>
                                            <td style="text-align: right; width: 10%"></td>
                                            <td style="width: 8%"></td>
                                            <td style="width: 6%"></td>
                                            <td style="text-align: right; width: 14%"></td>
                                            <td style="width: 3%"></td>
                                            <td style="width: 8%"></td>
                                            <td style="width: 21%"></td>
                                            <td style="width: 1%"></td>
                                            <td style="width: 3%">
                                                <asp:Button ID="btnPrint" runat="server" CssClass="form-control btn-primary" Style="text-align: center; font-size: x-small" OnClick="btnPrint_Click"
                                                    TabIndex="140" Text="Print" ToolTip="Print Transaction" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <asp:Label ID="lblMY" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSMxNo" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblTransSL_log" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblTransSL" runat="server" Visible="False"></asp:Label>
        </ContentTemplate>
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnSale" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
