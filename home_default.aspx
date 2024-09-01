<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="home_default.aspx.cs" Inherits="Yesbd.home_default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Import Namespace="Yesbd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link type="text/css" href="/MenuCssJs/css/style.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/sweet-alert.css" rel="stylesheet" />
    <link type="text/css" href="/MenuCssJs/css/Theme/responsive.css" rel="stylesheet" />

    <%--<script type="text/javascript">
        $(function () {
            $("#accordion").accordion();
        });
    </script>--%>
    <style type="text/css">
        .right_Side {
            border-radius: 10px;
        }

        .left_Side {
            border-radius: 10px;
        }

        .panel-title {
            cursor: pointer;
        }


        .img1 {
            /*float: right;
            position: absolute;
            right: 153px;
            top: 200px;
            z-index: 1000;*/
            width: 50px;
            height: 41px;
        }
        /*hover image*/


        .image {
            width: 100%;
            height: 100%;
        }

            .image img {
                -webkit-transition: all 1s ease; /* Safari and Chrome */
                -moz-transition: all 1s ease; /* Firefox */
                -ms-transition: all 1s ease; /* IE 9 */
                -o-transition: all 1s ease; /* Opera */
                transition: all 1s ease;
            }

            .image:hover img {
                -webkit-transform: scale(2.1); /* Safari and Chrome */
                -moz-transform: scale(2.1); /* Firefox */
                -ms-transform: scale(2.1); /* IE 9 */
                -o-transform: scale(2.1); /* Opera */
                transform: scale(2.1);
                cursor: pointer;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="col-md-12">
        <%--<div id="contentBox">
            <div id="contentHeaderBox">
            </div>
            <!-- ============================================================== -->
            <!-- Container fluid  -->
            <!-- ============================================================== -->
            <div class="container-fluid">
                <!-- ============================================================== -->
                <!-- Bread crumb and right sidebar toggle -->
                <!-- ============================================================== -->
                <%--<div class="row page-titles">
                        <div class="col-md-5 align-self-center">
                            <h3 class="text-themecolor">Home</h3>
                        </div>
                        <div class="col-md-7 align-self-center">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item active"><a href="/home">Home</a></li>
                            </ol>
                        </div>

                    </div>-%>
                <!-- ============================================================== -->
                <!-- End Bread crumb and right sidebar toggle -->
                <!-- ============================================================== -->
                <!-- ============================================================== -->
                <!-- Sales overview chart -->
                <!-- ============================================================== -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th colspan="3"><span style="font-size: medium">Total sales</span></th>
                                                </tr>
                                                <tr>
                                                    <th>ITEM TYPE</th>
                                                    <th>SALES QTY</th>
                                                    <%--<th>REFUND QTY</th>-%>
                                                    <th>GROSS TOTAL</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <%--<asp:ListView ID="ListView1" runat="server" DataSourceID="sdsdailysales">-%>
                                                <asp:ListView ID="ListView1" runat="server">
                                                    <EmptyDataTemplate>
                                                        <table id="Table1" runat="server" style="">
                                                            <tr>
                                                                <td>No data was returned.
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <%--<td><%# Eval("Item_type")%></td>
                                                    <td><%# Eval("Sale_qty")%></td>
                                                    <td><%=Utility.GetCurrencySymbol()%> <%# Eval("Gross_Total")%></td>-%>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <asp:Literal ID="ltlGetDailySaleTotal" runat="server"></asp:Literal>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th colspan="3"><span style="font-size: medium">Payment history</span></th>
                                                </tr>
                                                <tr>
                                                    <th>PAYMENT TYPE</th>
                                                    <%--<th>PAYMENTS REF</th>
                                                <th>COST</th>-%>
                                                    <th>TOTAL AMOUNT</th>
                                                    <th>PAID AMOUNT</th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <%--<asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource1">-%>
                                                <asp:ListView ID="ListView2" runat="server">
                                                    <EmptyDataTemplate>
                                                        <table id="Table1" runat="server" style="">
                                                            <tr>
                                                                <td>No data was returned.
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <%--<td><%# Eval("PaymentType")%></td>
                                                    <td><%=Utility.GetCurrencySymbol()%> <%# If (Eval("TotalAmount").ToString()<>"", Eval("TotalAmount"), "0.00")%></td>
                                                    <td><%=Utility.GetCurrencySymbol()%> <%# If (Eval("PaidAmount").ToString()<>"", Eval("PaidAmount"), "0.00")%></td>-%>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                <%--<tr>
                                                <td>Cash</td>
                                                <td>AED 0.00</td>
                                                <td>AED 0.00</td>
                                            </tr>-%>
                                            </tbody>
                                            <tfoot>

                                                <asp:Literal ID="ltlgrtotal" runat="server"></asp:Literal>

                                                <%--<tr>
                                                <th>Of which tips</th>
                                                <th>AED 0.00</th>
                                                <th>AED 0.00</th>
                                            </tr>
                                            <tr>
                                                <th>Outstanding</th>
                                                <th>AED 0.00</th>
                                                <th>AED 0.00</th>
                                            </tr>-%>
                                            </tfoot>
                                        </table>



                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th colspan="4"><span style="font-size: medium">Latest sales</span></th>
                                                </tr>
                                                <tr>
                                                    <th>REF#</th>
                                                    <th>Start Date</th>
                                                    <th>Time Range</th>
                                                    <th>Total Amount</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <%--<asp:ListView ID="ListView3" runat="server" DataSourceID="sdsRecentSales">-%>
                                                <asp:ListView ID="ListView3" runat="server">
                                                    <EmptyDataTemplate>
                                                        <table id="Table1" runat="server" style="">
                                                            <tr>
                                                                <td>No data was returned.
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <%--<td><a href="appointmentdetails?id=<%# Eval("ServiceRequestMasterId")%>"><%# Eval("ServiceRequestMasterId")%></a></td>
                                                    <td><%# Eval("StartDate")%></td>
                                                    <td><%# Eval("TimeRange")%></td>
                                                    <td><%# Eval("TotalAmount")%></td>-%>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>


                                                    <%--<th>Total Sales</th>
                                                <th>0</th>
                                                <th>0</th>
                                                <th>AED 0.00</th>-%>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th colspan="4"><span style="font-size: medium">Today's sales</span></th>
                                                </tr>
                                                <tr>
                                                    <th>REF#</th>
                                                    <th>Start Date</th>
                                                    <th>Time Range</th>
                                                    <th>Total Amount</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <%--<asp:ListView ID="ListView4" runat="server" DataSourceID="SdsTodaysSales">-%>
                                                <asp:ListView ID="ListView4" runat="server">
                                                    <EmptyDataTemplate>
                                                        <table id="Table1" runat="server" style="">
                                                            <tr>
                                                                <td>No data was returned.
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <%--<td><a href="appointmentdetails?id=<%# Eval("ServiceRequestMasterId")%>"><%# Eval("ServiceRequestMasterId")%></a></td>
                                                    <td><%# Eval("StartDate")%></td>
                                                    <td><%# Eval("TimeRange")%></td>
                                                    <td><%# Eval("TotalAmount")%></td>-%>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>


                                                    <%--<th>Total Sales</th>
                                                <th>0</th>
                                                <th>0</th>
                                                <th>AED 0.00</th>-%>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>

        </div>--%>
    </div>
</asp:Content>

