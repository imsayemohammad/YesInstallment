<%@ Page Title="Employee Information" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="EmpInfo.aspx.cs" Inherits="Yesbd.Input_Portion.EmpInfo" %>

<%@ Import Namespace="Yesbd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Employee Information</title>
    
    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/sweet-alert.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />
    
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:UpdatePanel ID="Up_TabContaner" runat="server">
        <ContentTemplate>
            <div class="col-md-12">
                <div id="contentBox">
                    <div id="contentHeaderBox">
                        <h1>Employee Information</h1>
                        <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->

                        <!-- logout option button -->
                        <%--<div class="btn-group pull-right" id="editOption">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                <i class="fa fa-cog"></i>
                            </button>
                            <ul class="dropdown-menu pull-right" style="" role="menu">
                                <li><a href="EmpInfo.aspx"><i class="fa fa-edit"></i>Edit</a>
                                </li>
                                <li><a href="EmpInfo.aspx"><i class="fa fa-edit"></i>Delete</a>
                                </li>
                            </ul>
                        </div>--%>
                        <!-- end logout option -->

                    </div>
                    <!-- content header end -->
                    
                    <!-- Content Start From here -->
                    <div class="form-class">
                        <div class="row"></div>
                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Member ID :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEmpID" TabIndex="1" ReadOnly="True" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2"></div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Member Name :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEmpNM" TabIndex="2" AutoPostBack="True" CssClass="form-control input-sm txtColor" runat="server" OnTextChanged="txtEmpNM_TextChanged"></asp:TextBox>
                                <asp:DropDownList ID="ddlEmpNM" runat="server" AutoPostBack="True" Visible="False" TabIndex="2" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlEmpNM_SelectedIndexChanged">
                                </asp:DropDownList>
                                <%--<% if (btnEditNew.Text == "New")
                                   { %>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionListEmpNM" ServicePath="EmpInfo.aspx" TargetControlID="txtEmpNM"
                                    UseContextKey="True" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                    CompletionListHighlightedItemCssClass="itemHighlighted">
                                </asp:AutoCompleteExtender>
                                <% } %>--%>
                            </div>
                            <div class="col-md-2"><b>Surname :</b></div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtSpNM" TabIndex="3" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Father Name :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtFNM" TabIndex="4" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b>Mother Name :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMNM" TabIndex="5" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Present Address :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPreAdd" TabIndex="6" CssClass="form-control input-sm txtColor" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b>Permanent Address :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPerAdd" TabIndex="7" CssClass="form-control input-sm txtColor" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Telephone No :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTelNo" TabIndex="8" CssClass="form-control input-sm txtColor" runat="server" AutoPostBack="True" OnTextChanged="txtTelNo_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b>Mobile No :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPMbNo" TabIndex="9" MaxLength="11" CssClass="form-control input-sm txtColor" AutoPostBack="True" runat="server" OnTextChanged="txtPMbNo_TextChanged"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Email :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEmail" TabIndex="10" CssClass="form-control input-sm txtColor" runat="server" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b>Voter ID :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtVotrID" TabIndex="11" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Blood Group :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBlGrp" TabIndex="12" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b>Marital Status :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlMStatus" runat="server" CssClass="form-control input-sm" TabIndex="13" OnSelectedIndexChanged="ddlMStatus_SelectedIndexChanged">
                                    <%--<asp:ListItem>SELECT</asp:ListItem>--%>
                                    <asp:ListItem Value="Single"></asp:ListItem>
                                    <asp:ListItem Value="Married"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label runat="server" ID="lblMSGERROR" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Login Type :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlLoginTP" runat="server" CssClass="form-control input-sm" TabIndex="14" OnSelectedIndexChanged="ddlLoginTP_SelectedIndexChanged">
                                    <%--<asp:ListItem Value="">SELECT</asp:ListItem>--%>
                                    <asp:ListItem Value="USER"></asp:ListItem>
                                    <asp:ListItem Value="ADMIN"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <b>Login By :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlLoginBy" runat="server" AutoPostBack="True" CssClass="form-control input-sm" TabIndex="15" OnSelectedIndexChanged="ddlLoginBy_SelectedIndexChanged">
                                    <asp:ListItem Value="">SELECT</asp:ListItem>
                                    <asp:ListItem Value="MOBILE"></asp:ListItem>
                                    <asp:ListItem Value="EMAIL"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Login ID :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtLoginID" TabIndex="16" ReadOnly="True" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b>
                                    <asp:Label runat="server" Text="Password" ID="lblPasswordNM" Visible="True"></asp:Label>
                                </b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPasswrd" TabIndex="17" CssClass="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-2">
                                <b>Remarks :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRemrks" TabIndex="18" CssClass="form-control input-sm txtColor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b>Status :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" TabIndex="19" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <%--<asp:ListItem>SELECT</asp:ListItem>--%>
                                    <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                    <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-3">
                                <asp:Label runat="server" ID="lblLoginByMSG" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                <asp:Label ID="lblMSGError1" runat="server" Visible="False" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                                <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#CC3300"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnSubmit" CssClass="form-control btn-primary" TabIndex="21" style="text-align: center;" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnReset" CssClass="form-control btn-primary" runat="server" style="text-align: center;" TabIndex="22" Text="Reset" OnClick="btnReset_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnEditNew" CssClass="form-control btn-primary" Text="Edit" style="text-align: center;" TabIndex="23" runat="server" OnClick="btnEditNew_Click" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label runat="server" ID="lblMemberid" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblEmpID2" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblMstatus" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblloginby" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblIMaxItemID" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblSrl" Visible="False"></asp:Label>
                                <asp:Label ID="lblempNM" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lbllogintp" runat="server" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblCheck" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblCheckEmpNM" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblCheckEmail" Visible="False"></asp:Label>
                                <asp:Label runat="server" ID="lblCheckMobile" Visible="False"></asp:Label>
                            </div>

                        </div>

                        <%--<div class="row form-class">
                    <div class="col-md-5"></div>
                    <div class="col-md-2"></div>
                    <div class="col-md-5"></div>
                </div>--%>
                    </div>
                    <!-- Content End From here -->
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnReset"></asp:PostBackTrigger>
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
