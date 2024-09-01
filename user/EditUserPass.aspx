<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="EditUserPass.aspx.cs" Inherits="Yesbd.user.EditUserPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User </title>
    <%--<link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="/Scripts/jquery-1.9.1.js"> </script>
    <script type="text/javascript" src="/Scripts/bootstrap.js"> </script>--%>

    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/sweet-alert.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:UpdatePanel ID="Up_TabContaner" runat="server">
        <ContentTemplate>
            <div class="col-md-12">
                <div id="contentBox">
                    <div id="contentHeaderBox">
                        <h1>Change Password</h1>
                        <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->

                    </div>
                    <!-- content header end -->

                    <!-- Content Start From here -->
                    <div class="form-class">
                        <div class="row"></div>
                        <div class="row form-class">
                            <div class="col-md-3"></div>
                            <div class="col-md-2">
                                <b>User ID :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtuserID" CssClass="form-control input-sm" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-3"></div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-3"></div>
                            <div class="col-md-2">
                                <b>Old Password :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtOldpass" CssClass="form-control input-sm" runat="server" TabIndex="1" OnTextChanged="txtOldpass_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label runat="server" ID="lblmsg" CssClass="label label-danger "></asp:Label>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" CssClass="label label-danger " ControlToValidate="txtOldpass" Text="Old Password Required"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-3"></div>
                            <div class="col-md-2">
                                <b>New Password :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtnewpass" CssClass="form-control input-sm" runat="server" TabIndex="2"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:RequiredFieldValidator runat="server" ID="rqpass" CssClass="label label-danger " ControlToValidate="txtnewpass" Text="Plz Insert New Password"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <div class="row form-class">
                            <div class="col-md-3"></div>
                            <div class="col-md-2">
                                <b>Confirm Password :</b>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtnewpassconfirm" CssClass="form-control input-sm" TabIndex="3" runat="server" OnTextChanged="txtnewpassconfirm_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label runat="server" ID="lblmsgpass" CssClass="label label-danger "></asp:Label>
                            <asp:RequiredFieldValidator runat="server" CssClass="label label-danger " ID="RequiredFieldValidator1" Text="Plz Confirm New Password" ControlToValidate="txtnewpassconfirm"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row form-class">
                            <div class="col-md-5">
                                <asp:Label ID="lblChkUserCD" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblOldpass" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnEditpass" class="btn btn-success" runat="server" Text="Change Password" OnClick="btnEditpass_Click" TabIndex="4" />
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-1">
                                <asp:Label runat="server" ID="lblCheck" Visible="False"></asp:Label>
                            </div>

                        </div>
                    </div>
                    <!-- Content End From here -->
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
