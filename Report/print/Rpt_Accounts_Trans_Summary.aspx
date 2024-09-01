<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rpt_Accounts_Trans_Summary.aspx.cs" Inherits="Yesbd.Report.print.Rpt_Accounts_Trans_Summary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report-Customer Wise Transaction</title>
    <link href="/Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="/MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="/MenuCssJs/js/jquery-2.1.3.js" type="text/javascript"></script>
    <script src="/MenuCssJs/js/jquery-ui.js" type="text/javascript"></script>
    <script src="/MenuCssJs/js/function.js" type="text/javascript"></script>

    <script type="text/javascript">
        function ClosePrint() {
            var print = document.getElementById("print");
            print.style.visibility = "hidden";
            //            print.display = false;

            window.print();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#gridhead').hide();
            $(window).scroll(function (event) {
                var scroll = $(window).scrollTop();
                if (scroll > 50) {
                    $('#gridhead').show();
                }
                else
                    $('#gridhead').hide();
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id*=GridView1] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>

    <style media="print" type="text/css">
        .showHeader thead {
            display: table-header-group;
            border: 1px solid #000;
        }
    </style>

    <style type="text/css">
        #btnPrint {
            font-weight: 700;
        }

        .style1 {
            font-size: small;
            text-align: center;
            width: 821px;
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
        }

        @media print {
            .page {
                margin: 0;
                margin-top: 1.9cm;
                border: initial;
                border-radius: initial;
                width: initial;
                min-height: initial;
                box-shadow: initial;
                background: initial;
                page-break-after: always; /* here always for subpage */
            }
        }

        .style2 {
            font-size: 16px;
            font-family: Calibri;
        }

        .SubTotalRowStyle {
            border: solid 1px Black;
            font-weight: bold;
            text-align: right;
        }

        .GrandTotalRowStyle {
            border: solid 1px Gray;
            color: #000000;
            font-weight: bold;
            font-size: 16px;
            text-align: right;
            height: 25px;
            font-family: Calibri;
        }

        .GroupHeaderStyle {
            border: solid 1px Black;
            text-align: left;
            color: #000000;
            font-weight: bold;
            height: 30px;
        }

        .GridRowStyle {
            padding-left: 6%;
        }

        .style3 {
            font-family: Calibri;
        }

        .style9 {
            text-align: center;
            font-family: Calibri;
            font-size: 16px;
            width: 821px;
        }

        .style8 {
            text-align: center;
            width: 821px;
        }

        .style10 {
            width: 227px;
        }

        .style11 {
            width: 6px;
        }

        .style12 {
            width: 262px;
        }

        th {
            text-align: center;
        }

        .hover_row {
            background-color: #A1DCF2;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="page">
            <div style="float: left; width: 100%; background: none repeat scroll 0 0 white; border-radius: 5px;">
                <%--<div style="margin: 0 auto; padding: 10px 10px 30px; width: 1100px; height: auto; border: 1px solid #d3d3d3; border-radius: 5px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); background: none repeat scroll 0 0 white;">--%>
                <table style="width: 100%;">
                    <tr>
                        <td class="style10">&nbsp;</td>
                        <td class="style1">
                            <asp:Label ID="lblCompNM" runat="server"
                                Style="font-family: Calibri; font-size: 20px; font-weight: 700"></asp:Label>
                        </td>
                        <td class="style11" style="text-align: right">&nbsp;</td>
                        <td style="text-align: right" class="style12">
                            <input id="print" tabindex="1" type="button" value="Print" onclick="ClosePrint()" /></td>
                        <td style="text-align: right">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style10">&nbsp;</td>
                        <td class="style9">
                            <asp:Label ID="lblAddress" runat="server"
                                Style="font-family: Calibri; font-size: 11px"></asp:Label>
                        </td>
                        <td class="style11">&nbsp;</td>
                        <td style="text-align: right" class="style12">&nbsp;</td>
                        <td style="text-align: right">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style10">&nbsp;</td>
                        <td class="style9">
                            <strong>DATE WISE TRANSACTION SUMMARY</strong></td>
                        <td class="style11">&nbsp;</td>
                        <td style="text-align: right" class="style12">&nbsp;</td>
                        <td style="text-align: right">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style10">&nbsp;</td>
                        <td class="style8">
                            <span class="style2">FROM </span><strong><span class="style2">:&nbsp; 
                            </span></strong>
                            <asp:Label ID="lblFDate" runat="server" CssClass="style2"></asp:Label>
                            <span class="style3">&nbsp;&nbsp;&nbsp; TO <strong>:&nbsp; </strong>
                            </span>
                            <asp:Label ID="lblTDate" runat="server" CssClass="style2"></asp:Label>
                        </td>
                        <td class="style11">&nbsp;</td>
                        <td style="text-align: right" class="style12">
                            <asp:Label ID="lblTime" runat="server"
                                Style="text-align: right; font-family: Calibri; font-size: 15px;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <div style="width: 96%; margin: 0% 2% 0% 2%; height: 1px; background: #000000;">
                </div>

                <div class="showHeader" style="width: 96%; margin: 1% 2% 0% 2%;">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        OnRowDataBound="GridView1_RowDataBound" Width="100%" ShowFooter="True"
                        ShowHeaderWhenEmpty="True" >
                        <Columns>
                            <asp:BoundField HeaderText="Date">
                                <HeaderStyle HorizontalAlign="Center" CssClass="text-center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Trans. No">
                                <HeaderStyle HorizontalAlign="Center" CssClass="text-center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Customer">
                                <HeaderStyle HorizontalAlign="Center" CssClass="text-center" Width="20%" />
                                <ItemStyle HorizontalAlign="Left" CssClass="text-left" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Particulars (বিবরণ)">
                                <HeaderStyle HorizontalAlign="Center" CssClass="text-center" Width="25%" />
                                <ItemStyle HorizontalAlign="Left" CssClass="text-left" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Credit (জমা)">
                                <HeaderStyle Width="15%" HorizontalAlign="Center" CssClass="text-center" />
                                <ItemStyle HorizontalAlign="Right" Width="15%" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle Font-Names="Calibri" Font-Size="16px" />
                        <HeaderStyle Font-Bold="True" Font-Names="Calibri" Font-Size="18px" />
                        <RowStyle Font-Bold="True" Font-Size="15px" Font-Names="Calibri" />
                    </asp:GridView>
                    
                </div>
            </div>
        </div>
        <br/>
    </form>
</body>
</html>
