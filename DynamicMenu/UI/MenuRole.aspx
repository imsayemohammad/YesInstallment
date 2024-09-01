<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="MenuRole.aspx.cs" Inherits="Yesbd.DynamicMenu.UI.MenuRole" %>

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
            Search_CompanyName();
            $('#paneldown').hide();
            $('#panelbody').show();
            $("#<%=lblMsg.ClientID%>, #<%=lblMsg.ClientID%>").fadeOut(20000);


        });

        function Search_Module() {
            $("#<%=txtUserName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../../search.asmx/GetCompletionListUserNameForMenuRole",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtUserName.ClientID %>").val() + "'}",
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

        function Search_CompanyName() {
            $("#<%=txtComapnyAdminName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../../search.asmx/GetCompletionListCompany",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtComapnyAdminName.ClientID %>").val() + "'}",
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
                    __doPostBack('#txtUnit');
                    return true;
                }
            });
        }

    </script>--%>
    <style>
        span.crosshair {
            cursor: pointer;
        }

        .Gridview {
            border: 1px solid #ddd;
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">

    <asp:UpdatePanel ID="Up_TabContaner" runat="server">
        <ContentTemplate>

            <div class="col-md-12">
                <div id="contentBox">
                    <div id="contentHeaderBox">

                        <!-- Content Start From here -->
                        <div class="form-class">

                            <div class="row form-class">
                                <div class="col-md-2"></div>
                                <div class="col-md-2"><strong>Member Name :</strong></div>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" ID="ddlMemberName" CssClass="form-control input-sm text-capitalize"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlMemberName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <strong>
                                        <asp:Label runat="server" ID="lblMsg" Visible="False" ForeColor="red"></asp:Label></strong>
                                </div>
                            </div>

                            <div class="form-class">
                                <div class="panel-body" id="panelbody">
                                    <div class="table table-responsive" style="border: 1px solid #ddd; border-radius: 5px;">
                                        <asp:GridView ID="gridViewAslRole" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderStyle="None" CellPadding="4" CssClass="Gridview text-center" AllowPaging="True" PageSize="10" OnSorting="gridViewAslRole_Sorting"
                                            OnPageIndexChanging="gridViewAslRole_PageIndexChanging" OnRowCommand="gridViewAslRole_RowCommand"
                                            OnRowUpdating="gridViewAslRole_RowUpdating" Font-Italic="False" ShowFooter="True" Width="100%"
                                            OnRowEditing="gridViewAslRole_RowEditing" OnRowCancelingEdit="gridViewAslRole_RowCancelingEdit" OnRowDeleting="gridViewAslRole_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ModuleId" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblModuleId" runat="server" Text='<%#Eval("MODULEID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblModuleIdEdit" runat="server" Text='<%#Eval("MODULEID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblModuleIdFooter" runat="server" Width="100%" TabIndex="0" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="MenuId" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMenuId" runat="server" Text='<%#Eval("MENUID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblMenuIdEdit" runat="server" Text='<%#Eval("MENUID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblMenuIdFooter" runat="server" Width="100%" TabIndex="0" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Module Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("MODULENM") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <%--<asp:DropDownList runat="server" ID="ddlModuleNameEdit" CssClass="form-control input-sm" TabIndex="6" AutoPostBack="True" OnSelectedIndexChanged="ddlModuleNameEdit_SelectedIndexChanged">
                                                </asp:DropDownList>--%>
                                                        <asp:Label ID="lblModuleNameEdit" runat="server" Text='<%#Eval("MODULENM") %>'></asp:Label>

                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlModuleName" CssClass="form-control input-sm" Width="100%" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlModuleName_SelectedIndexChanged">
                                                            <%--<asp:ListItem Value="S">--Select Menu Type--</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="16%" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Menu Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMenuName" runat="server" Text='<%#Eval("MENUNM") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <%--<asp:DropDownList runat="server" ID="ddlMenuNameEdit" CssClass="form-control input-sm" TabIndex="6" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuNameEdit_SelectedIndexChanged">
                                                </asp:DropDownList>--%>
                                                        <asp:Label ID="lblMenuNameEdit" runat="server" Text='<%#Eval("MENUNM") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlMenuName" CssClass="form-control input-sm" TabIndex="2" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuName_SelectedIndexChanged">
                                                            <%--<asp:ListItem Value="S">--Select Menu Type--</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="18%" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="18%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Menu Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMenuType" runat="server" CssClass="txtColor" Text='<%#Eval("MENUTP") %>' Width="50%" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <%--<asp:DropDownList runat="server" ID="ddlMenuTypeEdit" CssClass="form-control input-sm" Width="100%" TabIndex="6">
                                                    <asp:ListItem Value="S">--Select Menu Type--</asp:ListItem>
                                                    <asp:ListItem Value="F">Form</asp:ListItem>
                                                    <asp:ListItem Value="R">Report</asp:ListItem>
                                                    <asp:ListItem Value="AR">Admin Report</asp:ListItem>
                                                </asp:DropDownList>--%>

                                                        <asp:Label ID="lblMenuTypeEdit" runat="server" CssClass="txtColor" Text='<%#Eval("MENUTP") %>' Width="50%" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlMenuType" CssClass="form-control input-sm" AutoPostBack="True" Width="100%" TabIndex="1">
                                                            <asp:ListItem Value="S">--Select Menu Type--</asp:ListItem>
                                                            <asp:ListItem Value="F">Form</asp:ListItem>
                                                            <asp:ListItem Value="R">Report</asp:ListItem>
                                                            <asp:ListItem Value="AR">Admin Report</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <ControlStyle Width="100%" CssClass="text-center" />
                                                    <FooterStyle HorizontalAlign="Right" Width="12%" CssClass="text-center" />
                                                    <HeaderStyle HorizontalAlign="Right" Width="12%" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Right" Width="12%" CssClass="text-center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("STATUS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlStatusEdit" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Insert">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInsert" runat="server" Text='<%#Eval("INSERTR") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlInsertEdit" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlInsert" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Update">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUpdate" runat="server" Text='<%#Eval("UPDATER") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlUpdateEdit" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlUpdate" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDelete" runat="server" Text='<%#Eval("DELETER") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlDeleteEdit" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlDelete" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                            <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="text-center" />
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField HeaderText="Special">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSpecial" runat="server" Text='<%#Eval("SPECIALP") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlSpecialEdit" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                    <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList runat="server" ID="ddlSpecial" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="A">ACTIVE</asp:ListItem>
                                                    <asp:ListItem Value="I">INACTIVE</asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="8%" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="text-center" />
                                        </asp:TemplateField>--%>

                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/icon/update.png"
                                                            ToolTip="Update" Height="20px" Width="30px" TabIndex="9" />
                                                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/icon/cancel.png"
                                                            ToolTip="Cancel" Height="20px" Width="30px" TabIndex="10" />
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
                                            <FooterStyle />
                                            <HeaderStyle CssClass="text-center" HorizontalAlign="Center" Height="30px" Font-Size="13px" BackColor="#D9EDF7" />

                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Content End From here -->

                </div>
            </div>
            <asp:Label runat="server" ID="lblMemberId" Visible="False"></asp:Label>
            <asp:Label runat="server" ID="lblDeptID" Visible="False"></asp:Label>
            <asp:Label runat="server" ID="lblModuleId" Visible="False"></asp:Label>

        </ContentTemplate>
        <%--<Triggers>
                <asp:PostBackTrigger ControlID="btnEditNew" />
            </Triggers>--%>
    </asp:UpdatePanel>

    <script type="text/javascript">
        $('#paneldown').click(function () {
            $('#panelbody').show(700);
            $('#paneldown').hide();
            $('#panelup').show();
        });
        $('#panelup').click(function () {
            $('#panelbody').hide(700);
            $('#panelup').hide();
            $('#paneldown').show();
        });
    </script>
    </div>
</asp:Content>
