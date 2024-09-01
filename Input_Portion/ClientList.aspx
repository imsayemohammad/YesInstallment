<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ClientList.aspx.cs" Inherits="Yesbd.Input_Portion.ClientList" %>

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



        /* Styles.css */

        .client-table {
            width: 100%;
            border-collapse: collapse;
        }

            .client-table th, .client-table td {
                border: 1px solid #ddd;
                padding: 8px;
                text-align: left;
            }

            .client-table th {
                font-size: small;
                font-weight: bold;
                font-family: Arial;
                background-color: #f2f2f2;
                color: black;
            }

            .client-table td {
                font-size: small;
                font-family: 'Times New Roman';
            }

            .client-table tr:nth-child(even) {
                background-color: #f9f9f9;
            }

            .client-table tr:hover {
                background-color: #ddd;
            }

            .client-table th {
                padding-top: 12px;
                padding-bottom: 12px;
                background-color: #0C4F4F;
                color: white;
            }

        .DataPager {
            margin: 20px 0;
            text-align: center;
        }

            .DataPager button {
                background-color: #4CAF50;
                border: none;
                color: white;
                padding: 10px 20px;
                margin: 2px;
                cursor: pointer;
            }

                .DataPager button:hover {
                    background-color: #45a049;
                }

            .DataPager .aspNetDisabled {
                background-color: #ddd;
                cursor: default;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">

    <div class="col-md-12" id="mainContentBox">
        <div id="contentBox" style="display: block">
            <div id="contentHeaderBox">
                <h1>Customer List</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->

                <!-- logout option button -->
                <div class="btn-group pull-right" id="editOption">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                        <i class="fa fa-cog"></i>
                    </button>
                    <ul class="dropdown-menu pull-right" style="" role="menu">
                        <li><a href="ClientInfo.aspx">
                            <%--<i class="fa fa-edit"></i>--%>
                            <asp:Button ID="btnClientNMEdit" CssClass="fa fa-pencil-square-o" Style="text-align: center" Visible="False" ToolTip="Edit গ্রাহকের নাম" Text="Edit গ্রাহকের নাম" runat="server" />
                        </a>
                        </li>
                        <li><a href="ClientInfo.aspx">
                            <asp:Button ID="btnCancel" CssClass="fa fa-pencil-square-o" Style="text-align: center" Visible="False" ToolTip="বাতিল" Text="Cancel (বাতিল)" runat="server" />
                        </a>
                        </li>
                    </ul>
                </div>
                <!-- end logout option -->

            </div>
            <!-- content header end -->

            <!-- Content Start From here -->
            <div class="row form-class">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row form-class">
                                <div class="col-md-1 col-sm-1 col-12">
                                    <div class="form-group">
                                        <label>&nbsp;</label>
                                        <div class="form-group">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4 col-12">
                                    <div class="form-group">
                                        <label style="float: left">Search by name, mobile or vehicle no</label>
                                        <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-2 col-12">
                                    <div class="form-group">
                                        <label style="float: left">Status</label>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="PAID">PAID</asp:ListItem>
                                                <asp:ListItem Value="UNPAID">UNPAID</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-1 col-sm-1 col-12">
                                    <div class="form-group">
                                        <label>&nbsp;</label>
                                        <div class="form-group">
                                            <asp:Button ID="btnsearch" runat="server" ClientIDMode="Static" CssClass="form-control btn-success" Text="Search" OnClick="btnsearch_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1 col-sm-1 col-12">
                                    <div class="form-group">
                                        <label>&nbsp;</label>
                                        <div class="form-group">
                                            <asp:Button ID="btnRefresh" runat="server" ClientIDMode="Static" CssClass="form-control btn-danger" Text="Refresh" OnClick="btnRefresh_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1 col-sm-1 col-12">
                                    <div class="form-group">
                                        <label>&nbsp;</label>
                                        <div class="form-group">
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12 col-xlg-12 col-md-12 col-12">
                                    <div class="table-responsive">
                                        <asp:ListView ID="lstClientList" runat="server"
                                            ItemPlaceholderID="itemPlaceholder" OnPagePropertiesChanging="lstClientList_PagePropertiesChanging">
                                            <LayoutTemplate>
                                                <table class="client-table">
                                                    <thead>
                                                        <tr>
                                                            <th>Client ID</th>
                                                            <th>Name</th>
                                                            <th>Father</th>
                                                            <th>Mother</th>
                                                            <th>Vehicle No</th>
                                                            <th>Phone</th>
                                                            <th style="width: 5%">Address</th>
                                                            <th>Status</th>
                                                            <th>Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr id="itemPlaceholder" runat="server"></tr>
                                                    </tbody>
                                                </table>
                                                <%--<asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>--%>
                                                <asp:DataPager ID="DataPager1" runat="server" PageSize="15" PagedControlID="lstClientList">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="false"
                                                            ShowPreviousPageButton="true" ShowNextPageButton="false" />
                                                        <%--<asp:NumericPagerField ButtonType="Link" />--%>
                                                        <asp:NumericPagerField ButtonType="Button" />
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true"
                                                            ShowLastPageButton="false" ShowPreviousPageButton="false" />

                                                    </Fields>
                                                </asp:DataPager>
                                            </LayoutTemplate>
                                            <%--<GroupTemplate>
                                                        <tr>
                                                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                                        </tr>
                                                 </GroupTemplate>--%>
                                            <ItemTemplate>
                                                <tr style="">
                                                    <td style="font-size: small">
                                                        <%# Eval("CLIENTID")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CLIENTNM")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("FATHERNM")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("MOTHERNM")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("VEHICLENO")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("MOBNO")%>
                                                    </td>
                                                    <td style="width: 5%">
                                                        <%# Eval("CONTACTADD")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("LOANSTATUS")%>
                                                    </td>

                                                    <td>
                                                        <a href="ClientInfo.aspx?cid=<%# Eval("CLIENTID") %>" target="_blank">
                                                            <img src="../Images/icon/edit1.png" /></a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                <tr>
                                                    <td colspan="8">No Records Found</td>
                                                </tr>
                                            </EmptyDataTemplate>

                                            <%--<EmptyDataTemplate>
                                                        <table id="Table1" runat="server" style="">
                                                            <tr>
                                                                <td colspan="8">No data was found.</td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>--%>
                                        </asp:ListView>

                                        <%--</tbody>

                                        </table>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <%--<div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="main-card mb-3 card">
                            <div class="card-body">
                                <div class="float-left">


                                    <div class="mb-2 mr-sm-5 mb-sm-2 position-relative form-group">
                                        <label for="unitId" class="mr-sm-2">Unit</label>
                                        <%--@Html.DropDownList("unitId", new SelectList(
                                        (System.Collections.IEnumerable)ViewData["SisterConcernList"], "vSisterConcernId", "vSisterConcernName"),
                                        htmlAttributes: new { @class = "form-control" })-%>

                                        <asp:DropDownList ID="ddlClientType" runat="server" TabIndex="6" AutoPostBack="True" CssClass="form-control input-sm">
                                            <asp:ListItem Value="NEW">NEW</asp:ListItem>
                                            <asp:ListItem Value="OLD">OLD</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="mb-2 mr-sm-5 mb-sm-2 position-relative form-group">
                                        <label for="vehicleId" class="mr-sm-2">Vehicle</label>
                                        <select id="ddlVehicleList" name="ddlVehicleList" class="form-control"></select>
                                    </div>
                                    <div class="mb-2 mr-sm-2 mb-sm-2 position-relative form-group">
                                        <label for="vehicleId" class="mr-sm-2">Cost Type</label>
                                        <asp:DropDownList ID="DropDownList1" runat="server" TabIndex="6" AutoPostBack="True" CssClass="form-control input-sm">
                                            <asp:ListItem Value="NEW">NEW</asp:ListItem>
                                            <asp:ListItem Value="OLD">OLD</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="mb-2 mr-sm-4 mb-sm-0 position-relative form-group">
                                        <label for="VehicleCostID" class="mr-sm-2">Sub Cost Type</label>
                                        <select id="ddlSubCostType" name="ddlSubCostType" class="form-control chosen-select cs_1">
                                            <option value="0">All</option>
                                        </select>
                                    </div>

                                    <div class="mb-2 mr-sm-4 mb-sm-0 position-relative form-group">
                                        <label for="daterange" class="mr-sm-1">Date</label>
                                        <input type="date" name="fromDate" id="fromDate" value="" class="form-control mr-sm-4" />
                                        <label for="daterange" class="ml-sm-1 mr-sm-1">To</label>
                                        <input type="date" name="toDate" id="toDate" value="" class="form-control" />
                                    </div>
                                    <button type="button" class="ml-2 btn btn btn-outline-success float-right" onclick="table.ajax.reload(null, false);">Search</button>
                                    <button type="button" onclick="#" class="ml-2 btn btn btn-outline-danger float-right">
                                        Reset
                                    </button>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="main-card mb-3 card">
                            <div class="card-body table-responsive">
                                <div class="float-right" id="button_wrapper"></div>
                                <table style="width: 100%;" id="dataTable" class="table table-hover table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Sl No</th>
                                            <th>Expense Date</th>
                                            <th>Month</th>
                                            <th>Vehicle No</th>
                                            <th>Category</th>
                                            <th>Sub Category</th>
                                            <th>Remarks</th>
                                            <th>Quantity</th>
                                            <th>Price</th>
                                            <th>Amount</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th>Total</th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <!-- ============================================================== -->
            <!-- End Container fluid  -->
        </div>
    </div>






    <%--<script src="../Content/js/jquery.dataTables.min.js"></script>--%>
    <script src="~/js/jquery.dataTables.min.js"></script>
    <script src="~/js/dataTables.bootstrap4.min.js"></script>
    <script src="~/js/dataTables.buttons.min.js"></script>
    <script src="~/js/dataTables.responsive.min.js"></script>
    <script src="~/js/buttons.colVis.min.js"></script>
    <script src="~/js/buttons.print.min.js"></script>
    <script src="~/js/buttons.bootstrap4.min.js"></script>
    <script src="~/js/buttons.html5.min.js"></script>
    <script src="~/js/buttons.colVis.min.js"></script>
    <script src="~/js/jszip.min.js"></script>
    <script src="~/js/pdfmake.min.js"></script>
    <script src="~/js/vfs_fonts.js"></script>
    <script>
        var table;
        $(document).ready(function () {
            var d = new Date();
            var endDate = new Date(d.setDate(d.getDate())).toString();
            var toDate = new Date(endDate).toISOString().split("T")[0];
            var startDate = new Date(d.setDate(d.getDate() - 29)).toString();
            var fromDate = new Date(startDate).toISOString().split("T")[0];
            var unitid = $('#unitId').find(":selected").val() || $('#unitId').val();
            var costType = $('#ddlCostType').find(":selected").val() || $('#ddlCostType').val();
            $('#fromDate').val(fromDate);
            $('#toDate').val(toDate);
            getVehicleList(unitid);
            getSubCostType(costType);

            /* Make datatable view to get old data */
            table = $('#dataTable').DataTable({
                "language":
                {
                    "processing": '<div class="font-icon-wrapper float-left mr-3 mb-3" style="margin-left: 9%;">' +
                        '<div class="loader-wrapper d-flex justify-content-center align-items-center">' +
                        '<div class="loader">' +
                        '<div class="line-scale-pulse-out-rapid">' +
                        '<div></div>' +
                        '<div></div>' +
                        '<div></div>' +
                        '<div></div>' +
                        '<div></div>' +
                        '<div></div>' +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '<p>Loading</p></div>'
                },
                "responsive": true,
                "processing": true,
                "serverSide": true,
                "lengthMenu": [
                    [10, 15, 25, 50, 100, -1],
                    [10, 15, 25, 50, 100, "All"]
                ],
                "order": [1, "desc"],
                "start": 0,
                "length": 10,
                "bFilter": false,
                "dom": 'lTgBfrtip',
                "buttons": [
                    {
                        "extend": 'pdf',
                        "title": 'Expense Report',
                        "filename": 'Expense_Report_From_' + fromDate + '_To_' + toDate,
                        "footer": true,
                        "exportOptions": {
                            "columns": ':visible'
                        }
                    },
                    {
                        "extend": 'excel',
                        "title": 'Expense Report',
                        "autoFilter": true,
                        "filename": 'Expense_Report_From_' + fromDate + '_To_' + toDate,
                        "footer": true,
                        "exportOptions": {
                            "columns": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                        }
                    },
                    {
                        "extend": 'print',
                        "title": 'Expense Report',
                        "filename": 'Expense_Report_From_' + fromDate + '_To_' + toDate,
                        "footer": true,
                        "exportOptions": {
                            "columns": ':visible'
                        },
                        customize: function (win) {
                            $(win.document.body).css('font-size', '10px');
                            $(win.document.body).find('table').addClass('compact').css('font-size', 'inherit');
                        }
                    }
                ],
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;
                    function intVal(i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                            i : 0;
                    };

                    for (var j = 1; j < i; j++) {
                        $(api.column(j).footer()).html('');
                    }

                    for (var i = 7; i < 10; i++) {
                        api.columns(i, { page: 'current' }).every(function () {
                            var total = api.cells(null, this.index(), { page: 'current' }).render('display').reduce(function (a, b) {
                                //b = intVal($(b).children().text());
                                var x = parseFloat(a) || 0;
                                var y = parseFloat(b) || 0;
                                return x + y;
                            }, 0);

                            if (i == 10) {
                                $(this.footer()).html('‎৳ ' + total.toFixed(2));
                            } else {
                                $(this.footer()).html(total.toFixed(2));
                            }

                            if (i == 8) {
                                $(this.footer()).html('');
                            }
                        });
                    }

                },
                "ajax":
                {
                    "url": '@Url.Action("Index", "VExpenditure")',
                    "contentType": "application/x-www-form-urlencoded",
                    "type": "POST",
                    "dataType": "JSON",
                    "data": function (d) {
                        d.unitId = $('#unitId').find(":selected").val() || $('#unitId').val();
                        d.vehicleNo = $('#ddlVehicleList').find(":selected").val();
                        d.costType = $('#ddlCostType').find(":selected").val() || $('#ddlCostType').val();
                        d.subCostType = $('#ddlSubCostType').find(":selected").text() || $('#ddlSubCostType').text();
                        d.fromDate = $('#fromDate').val();
                        d.toDate = $('#toDate').val();
                        return d;
                    },
                    "dataSrc": function (json) {
                        json.draw = json.draw;
                        json.recordsTotal = json.recordsTotal;
                        json.recordsFiltered = json.recordsFiltered;
                        json.data = json.expenditures;
                        var return_data = json;
                        return return_data.data;
                    }
                },
                "columns": [
                    {
                        "data": null,
                        "mRender": function (data, type, full, meta) { return meta.row + meta.settings._iDisplayStart + 1; }
                    },
                    {
                        "data": null,
                        "mRender": function (data, type, full) { return data.expenseDate.split("T")[0]; }
                    },
                    {
                        "data": null,
                        "mRender": function (data, type, full) { return data.expMonthName; }
                    },
                    {
                        "data": null,
                        "mRender": function (data, type, full) { return data.vehicleNo; }
                    },
                    {
                        "data": null,
                        "mRender": function (data, type, full) { return data.vCostType; }
                    },
                    {
                        "data": null,
                        "mRender": function (data, type, full) { return data.vCostTitle; }
                    },
                    {
                        "data": null,
                        "mRender": function (data, type, full) { return data.remarks; }
                    },
                    { "data": "totalQuantity" },
                    { "data": "totalPrice" },
                    { "data": "totalAmount" }
                ]
            });


            table.buttons().container().appendTo('#button_wrapper');
            $('#button_wrapper').find('.buttons-csv').text('Csv');
            $('#button_wrapper').find('.buttons-colvis').removeClass('btn-secondary').addClass('btn-outline-info');
            $('#button_wrapper').find('.buttons-html5').removeClass('btn-secondary').addClass('btn-outline-info');
            $('#button_wrapper').find('.buttons-print').removeClass('btn-secondary').addClass('btn-outline-info');

        });

        $('#unitId').on('change', function () {
            var unitid = $('#unitId').find(":selected").val() || $('#unitId').val();

            getVehicleList(unitid);
        });

        //$('#btnSearch').on('click', function () {
        //    var fromDate = $('#fromDate').val();
        //    var toDate = $('#toDate').val();
        //    table.ajax.reload(null, false);
        //});

        function getVehicleList(unitid) {
            //var unitId = $('#unitId').find(":selected").val() || $('#unitId').val();

            $.ajax({
                type: 'POST',
                url: '@Url.Action("GetVehicleList", "VExpenditure")',
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                data: { "unitId": unitid },
                async: false,
                success: function (data) {
                    var s = '<option value="0">All</option>';
                    var s = '';
                    for (var i = 0; i < data.length; i++) {
                        s += '<option value="' + data[i].vehicleID + '">' + data[i].vehicleNo + '</option>';
                    }
                    $("#ddlVehicleList").html(s);
                    //console.log(data);
                }
            });
        }

        $('#ddlCostType').on('change', function () {
            var costType = $('#ddlCostType').find(":selected").val() || $('#ddlCostType').val();
            getSubCostType(costType);
        });

        function getSubCostType(costType) {
            $.ajax({
                type: 'POST',
                url: '@Url.Action("GetSubCostType", "VExpenditure")',
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                data: { "costType": costType },
                async: false,
                success: function (data) {
                    var s = '<option value="0">All</option>';
                    var s = '';
                    for (var i = 0; i < data.length; i++) {
                        s += '<option value="' + data[i].vehicleCostID + '">' + data[i].vCostTitle + '</option>';
                    }
                    $("#ddlSubCostType").html(s);
                }
            });
        }

    </script>






    <%--<script>
        function ClearID() {
            document.getElementById("hidBannerID").value = "";
            document.getElementById("txtBannerTitle").value = "";
            document.getElementById("txtArBannerTitle").value = "";
            document.getElementById("chkActiveBanner").checked = false;
        }
        function DeleteBannerById(x) {
            var BannerId = x;
            if (confirm("Are You Sure You Want To Delete ?")) {

                $.ajax({
                    type: 'Post',
                    url: 'Banner.aspx/DeleteBannerById',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({
                        BannerId: BannerId
                    }),
                    dataType: "json",
                    success: function() {
                        location.reload();

                    }

                });

            } else {

            }

        }

        function GetBannerById(x) {

            var BannerId = x;

            ClearID();
            $.ajax({
                type: 'Post',
                url: 'Banner.aspx/GetBannerById',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    BannerId: BannerId
                }),
                dataType: "json",
                success: function(result) {
                    $.each(result,
                        function(key, value) {
                            document.getElementById('hidBannerID').value = value.hidBannerID;
                            document.getElementById('txtBannerTitle').value = value.txtBannerTitle;
                            document.getElementById('txtArBannerTitle').value = value.txtArBannerTitle;
                            $("[id$='imgSmallImage']").attr("src", value.Image);
                            if (value.chkActiveBanner !== false) {
                                //document.getElementById('chkbookings').prop('checked', true);
                                document.getElementById("chkActiveBanner").checked = true;
                            } else {
                                document.getElementById("chkActiveBanner").checked = false;
                                //document.getElementById('chkbookings').prop('checked', false);
                            }
                        });
                }

            });
        }

    </script>--%>
</asp:Content>
