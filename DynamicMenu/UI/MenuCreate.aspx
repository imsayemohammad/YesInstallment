<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="MenuCreate.aspx.cs" Inherits="Yesbd.DynamicMenu.UI.MenuCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/sweet-alert.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />

    <%--<script type="text/javascript">
        $(document).ready(function () {
            Search_Module();
            Search_MenuName();
            $("#<%=lblMsg.ClientID%>, #<%=lblMsgMenu.ClientID%>").fadeOut(20000);

        });

        function Search_Module() {
            $("#<%=txtModuleName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../../search.asmx/GetCompletionListModuleName",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtModuleName.ClientID %>").val() + "'}",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {

                                return {
                                    label: item,
                                    value: item
                                };

                            }));

                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                },

                minLength: 1,
                select: function () {
                    __doPostBack('#txtMenuName');
                    return true;
                }
            });
        }
        function Search_MenuName() {
            $("#<%=txt.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../../search.asmx/GetCompletionListMenuName",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtMenuName.ClientID %>").val() + "'}",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {

                                return {
                                    label: item,
                                    value: item
                                };

                            }));

                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                },

                minLength: 1,
                select: function () {
                    __doPostBack('#txtMenuLink');
                    return true;
                }
            });
        }


    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">

    <%--<div class="col-md-10 pull-right" id="mainContentBox">
        <div id="contentBox">
            <div id="contentHeaderBox">
                <h1>Menu Information</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->


                <!-- logout option button -->
                <div class="btn-group pull-right" id="editOption">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                        <i class="fa fa-cog"></i>
                    </button>
                    <ul class="dropdown-menu pull-right" style="" role="menu">
                        <li><a href="MenuCreate.aspx"><i class="fa fa-plus"></i>Add Menu</a>
                        </li>
                        <li><a href="MenuUpdate.aspx"><i class="fa fa-edit"></i>Edit Menu</a>
                        </li>
                        <li><a href="MenuDelete.aspx"><i class="fa fa-times"></i>Delete Menu</a>
                        </li>

                    </ul>
                </div>
                <!-- end logout option -->


            </div>
            <!-- content header end -->--%>
    <div class="col-md-12">
        <div id="contentBox">
            <div id="contentHeaderBox">

                <div class="form-class">
                    <div class="panel panel-primary ">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Create Menu</div>
                        <br />
                        <div class="row form-class">
                            <div class="col-md-2"></div>
                            <div class="col-md-2">
                                <strong>Module Name :</strong>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtModuleName" CssClass="form-control input-sm" AutoPostBack="True" OnTextChanged="txtModuleName_TextChanged"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender"
                                    runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionListModuleName" ServicePath="MenuCreate.aspx" TargetControlID="txtModuleName"
                                    UseContextKey="True">
                                </asp:AutoCompleteExtender>

                            </div>
                            <div class="col-md-4"></div>
                        </div>


                        <div class="row form-class">
                            <div class="col-md-12 text-center">
                                <strong>
                                    <asp:Label runat="server" ID="lblMsg" ForeColor="red" Visible="False"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row form-class">
                            <div class="col-md-3"></div>
                            <div class="col-md-2"></div>
                            <div class="col-md-2">
                                <asp:Button runat="server" ID="btnSubmit" Style="text-align: center" Text="Submit" CssClass="form-control input-sm btn-primary" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="col-md-5"></div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="table-responsive">
                                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed"
                                    HeaderStyle-BackColor="#61A6F8" ShowFooter="True" HeaderStyle-Font-Bold="true" HorizontalAlign="Center"
                                    HeaderStyle-ForeColor="White" ForeColor="Black" OnRowCommand="gvDetails_RowCommand" Width="90%"
                                    OnRowEditing="gvDetails_RowEditing" OnRowDataBound="gvDetails_RowDataBound"
                                    OnRowCancelingEdit="gvDetails_RowCancelingEdit" OnRowDeleting="gvDetails_RowDeleting"
                                    OnRowUpdating="gvDetails_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Module ID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblModuleID" runat="server" Text='<%# Eval("MODULEID") %>' Width="50%" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblModuleIDEdit" runat="server" TabIndex="0" Text='<%# Eval("MODULEID") %>' Width="100%" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblModuleID" runat="server" Width="100%" TabIndex="0" />
                                            </FooterTemplate>
                                            <ControlStyle Width="100%" CssClass="text-center" />
                                            <FooterStyle Width="0%" HorizontalAlign="Center" CssClass="text-center" />
                                            <HeaderStyle Width="0%" HorizontalAlign="Center" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" Width="0%" CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Menu Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMenuType" runat="server" CssClass="txtColor" Text='<%#Eval("MENUTP") %>' Width="50%" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlMenuTypeEdit" CssClass="form-control input-sm text-center" Text='<%#Eval("MENUTP") %>' Width="100%" TabIndex="6">
                                                    <asp:ListItem Value="S">--Select Menu Type--</asp:ListItem>
                                                    <asp:ListItem Value="F">Form</asp:ListItem>
                                                    <asp:ListItem Value="R">Report</asp:ListItem>
                                                    <asp:ListItem Value="AR">Admin Report</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList runat="server" ID="ddlMenuType" CssClass="form-control input-sm text-center" Width="100%" TabIndex="1">
                                                    <asp:ListItem Value="S">--Select Menu Type--</asp:ListItem>
                                                    <asp:ListItem Value="F">Form</asp:ListItem>
                                                    <asp:ListItem Value="R">Report</asp:ListItem>
                                                    <asp:ListItem Value="AR">Admin Report</asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <ControlStyle Width="100%" CssClass="text-center" />
                                            <FooterStyle HorizontalAlign="Right" Width="20%" CssClass="text-center" />
                                            <HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Right" Width="20%" CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Menu ID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMenuID" runat="server" Text='<%# Eval("MENUID") %>' Width="50%" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblMenuIDEdit" runat="server" TabIndex="0" Text='<%# Eval("MENUID") %>' Width="100%" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblMenuID" runat="server" Width="100%" TabIndex="0" />
                                            </FooterTemplate>
                                            <ControlStyle Width="100%" CssClass="text-center" />
                                            <FooterStyle Width="0%" HorizontalAlign="Center" CssClass="text-center" />
                                            <HeaderStyle Width="0%" HorizontalAlign="Center" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" Width="0%" CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Menu Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMenuNM" runat="server" CssClass="txtColor" Text='<%# Eval("MENUNM") %>' Width="50%" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtMenuNMdit" runat="server" CssClass="txtColor" Text='<%# Eval("MENUNM") %>' Width="100%" TabIndex="7" OnTextChanged="txtMenuNMdit_TextChanged" />
                                                <%--<asp:AutoCompleteExtender ID="AutoCompleteExtender"
                                                            runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1"
                                                            ServiceMethod="GetCompletionListMenuNM" ServicePath="MenuCreate.aspx" TargetControlID="txtMembrNMEdit"
                                                            UseContextKey="True">
                                                        </asp:AutoCompleteExtender>--%>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtMenuNM" runat="server" CssClass="txtColor" Width="100%" TabIndex="2" OnTextChanged="txtMenuNM_TextChanged" />
                                                <%--<asp:AutoCompleteExtender ID="AutoCompleteExtender"
                                                            runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1"
                                                            ServiceMethod="GetCompletionListMenuNM" ServicePath="MenuCreate.aspx" TargetControlID="txtMembrNM"
                                                            UseContextKey="True" CompletionListCssClass="completionList_grid" CompletionListItemCssClass="listItem_grid"
                                                            CompletionListHighlightedItemCssClass="itemHighlighted_grid">
                                                        </asp:AutoCompleteExtender>--%>
                                            </FooterTemplate>
                                            <ControlStyle Width="100%" CssClass="text-center" />
                                            <FooterStyle Width="30%" HorizontalAlign="Center" CssClass="text-center" />
                                            <HeaderStyle Width="30%" HorizontalAlign="Center" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Menu SL">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMenuSL" runat="server" CssClass="txtColor" Text='<%# Eval("MENUSL") %>' Width="50%" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtMenuSLdit" runat="server" CssClass="txtColor" Text='<%# Eval("MENUSL") %>' Width="100%" TabIndex="8" />
                                                <%--<asp:AutoCompleteExtender ID="AutoCompleteExtender"
                                                            runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1"
                                                            ServiceMethod="GetCompletionListMenuNM" ServicePath="MenuCreate.aspx" TargetControlID="txtMembrNMEdit"
                                                            UseContextKey="True">
                                                        </asp:AutoCompleteExtender>--%>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtMenuSL" runat="server" CssClass="txtColor" Width="100%" TabIndex="3" />
                                                <%--<asp:AutoCompleteExtender ID="AutoCompleteExtender"
                                                            runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1"
                                                            ServiceMethod="GetCompletionListMenuNM" ServicePath="MenuCreate.aspx" TargetControlID="txtMembrNM"
                                                            UseContextKey="True" CompletionListCssClass="completionList_grid" CompletionListItemCssClass="listItem_grid"
                                                            CompletionListHighlightedItemCssClass="itemHighlighted_grid">
                                                        </asp:AutoCompleteExtender>--%>
                                            </FooterTemplate>
                                            <ControlStyle Width="100%" CssClass="text-center" />
                                            <FooterStyle Width="8%" HorizontalAlign="Center" CssClass="text-center" />
                                            <HeaderStyle Width="8%" HorizontalAlign="Center" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Menu Link">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMenuLink" runat="server" CssClass="txtColor" Text='<%# Eval("FLINK") %>' Width="50%"></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtMenuLinkEdit" runat="server" CssClass="txtColor" Text='<%#Eval("FLINK") %>'
                                                    Width="100%" TabIndex="9" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtMenuLink" runat="server" CssClass="txtColor" Width="100%" TabIndex="3" />
                                            </FooterTemplate>
                                            <ControlStyle Width="100%" CssClass="text-center" />
                                            <HeaderStyle HorizontalAlign="Center" Width="32%" CssClass="text-center" />
                                            <FooterStyle HorizontalAlign="Center" Width="32%" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" Width="32%" CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/icon/update.png"
                                                    ToolTip="Update" Height="20px" Width="30px" TabIndex="10" />
                                                <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/icon/cancel.png"
                                                    ToolTip="Cancel" Height="20px" Width="30px" TabIndex="11" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/icon/Edit.png"
                                                    ToolTip="Edit" Height="20px" Width="30px" TabIndex="40" />
                                                <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                                    ImageUrl="~/Images/icon/delete.png" ToolTip="Delete" Height="20px" Width="30px" OnClientClick="return confMSG()"
                                                    TabIndex="41" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Images/icon/add.png"
                                                    CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new Record" ValidationGroup="validaiton"
                                                    TabIndex="4" />

                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#61A6F8" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                </asp:GridView>
                                <br />
                                <strong>
                                    <asp:Label runat="server" ID="lblMsgMenu" ForeColor="red" Visible="False"></asp:Label></strong>
                            </div>
                        </div>


                        <%--<div id="menulist">
                <div class="row form-class">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        <strong>Menu Type :</strong>
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlMenuType" CssClass="form-control input-sm">
                            <asp:ListItem Value="S">--Select Menu Type--</asp:ListItem>
                            <asp:ListItem Value="F">Form</asp:ListItem>
                            <asp:ListItem Value="R">Report</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <div class="row form-class">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        <strong>Menu Name :</strong>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtMenuName" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <div class="row form-class">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        <strong>Menu Link</strong>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtMenuLink" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <div class="row form-class">
                    <div class="col-md-12 text-center">
                        <strong><asp:Label runat="server" ID="lblMsgMenu" ForeColor="red" Visible="False"></asp:Label></strong>
                    </div>
                </div>
                <div class="row form-class">
                    <div class="col-md-5"></div>
                    <div class="col-md-2">
                        <asp:Button runat="server" ID="btnAddMenu" Text="Add" CssClass="form-control input-sm btn-primary" OnClick="btnAddMenu_Click" />
                    </div>
                    <div class="col-md-5"></div>
                </div>
            </div>--%>
                    </div>
                    <asp:Label runat="server" ID="lblModuleID" Visible="False"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="../../Scripts/bootstrap-hover-dropdown.js"></script>
    <script>
        // very simple to use!
        $(document).ready(function () {
            $('.js-activated').dropdownHover().dropdown();
        });
    </script>

</asp:Content>
