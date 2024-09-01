<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rpt_Transaction_Memo.aspx.cs" Inherits="Yesbd.Report.print.Rpt_Transaction_Memo" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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

    <style type="text/css">
        #btnPrint {
            font-weight: 700;
        }

        .style2 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: Calibri;
            font-size: 18pt;
            width: 697px;
        }

        .style3 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: "Helvetica Neue", Arial, Helvetica, sans-serif;
            font-size: small;
            width: 697px;
        }

        .style4 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: Calibri;
            width: 187px;
        }

        .style5 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: "Helvetica Neue", Arial, Helvetica, sans-serif;
            font-size: medium;
            width: 697px;
        }

        .style6 {
            width: 4px;
        }

        .style8 {
            width: 1px;
            font-weight: bold;
        }

        .style10 {
            width: 210px;
            font-family: Calibri;
        }

        .style11 {
        }

        .style13 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: "Helvetica Neue", Arial, Helvetica, sans-serif;
            font-size: 10pt;
            width: 187px;
        }

        .style14 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: "Helvetica Neue", Arial, Helvetica, sans-serif;
            font-size: xx-small;
            width: 140px;
        }

        .style15 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: "Helvetica Neue", Arial, Helvetica, sans-serif;
            font-size: small;
            width: 140px;
        }

        .style19 {
            font-family: Calibri;
        }

        .style20 {
            width: 118px;
            font-family: Calibri;
        }

        .style25 {
            width: 223px;
            font-family: Calibri;
        }

        .style26 {
            width: 95px;
        }

        .style27 {
            width: 135px;
            font-family: Calibri;
        }

        .style28 {
            width: 144px;
            font-family: Calibri;
        }

        .style29 {
            width: 155px;
            font-family: Calibri;
        }

        .style30 {
            width: 420px;
        }

        .style33 {
            text-align: center;
            color: rgb(34, 34, 34);
            font-family: Calibri;
            font-size: small;
            width: 697px;
        }

        .style34 {
            width: 95px;
            font-family: Calibri;
        }

        .footerCqty {
            padding-right: 30px;
            text-align: center;
            font-family: Calibri;
        }

        .style35 {
            width: 100px;
            font-family: Calibri;
        }

        .style36 {
            width: 178px;
        }

        .style37 {
            font-size: 12px;
        }
    </style>

</head>
<body style="font-size: medium">
    <form id="form1" runat="server">
        <div>
            <div>
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: left; font-size: 10pt; font-weight: 700" class="style4" rowspan="4"></td>
                            <td style="text-align: center; font-weight: 700" class="style2">
                                <asp:Label ID="lblCompNM" runat="server"
                                    Style="font-family: Calibri; font-size: 25px; font-weight: 700"></asp:Label>
                            </td>
                            <td style="text-align: center; font-size: x-large; font-weight: 700"
                                class="style14">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: center; font-weight: 700" class="style2">
                                <asp:Label ID="lblAddress" runat="server" Style="font-family: Calibri; font-size: 11px"></asp:Label>
                            </td>
                            <td style="text-align: center; font-size: x-large; font-weight: 700"
                                class="style14">
                                <input id="print" tabindex="1" type="button" value="Print" onclick="ClosePrint()" /></td>
                        </tr>
                        <tr>
                            <td class="style33">PHONE :
                                <asp:Label ID="lblContact" runat="server"
                                    Style="font-family: Calibri; font-size: 11px"></asp:Label>
                            </td>
                            <td style="text-align: center" class="style14">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style33">Email   :
                                <asp:Label ID="lblEmail" runat="server"
                                    Style="font-family: Calibri; font-size: 11px"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: center; font-family: 'Helvetica Neue', Arial, Helvetica, sans-serif">
                                <asp:Label ID="lblTime" runat="server"
                                    Style="text-align: center; font-family: Arial, Helvetica, sans-serif; font-size: small;"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr/>
                </div>
                <table style="width: 100%; margin-top: 5px;">
                    <tr>
                        <td class="style6">&nbsp;</td>
                        <td style="width: 15%; font-family: Calibri;">Date</td>
                        <td style="width: 1%; font-weight: bold;">:</td>
                        <td class="style11">
                            <asp:Label ID="lblTransactionDT" runat="server"
                                Style="font-family: Calibri; font-size: medium"></asp:Label>
                            <strong>&nbsp;</strong></td>
                        <td style="text-align: right; width: 10%; font-family: Calibri;">Transaction No <strong>:&nbsp;</strong></td>
                        <td style="text-align: left; font-family: Calibri;">
                            <asp:Label ID="lblTransactionVNo" runat="server"
                                Style="font-family: Calibri; font-size: 14px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >&nbsp;</td>
                        <td style="font-family: Calibri;">Customer Name</td>
                        <td style="width: 1%;font-weight: bold;">:</td>
                        <td style="font-family: Calibri;">
                            <asp:Label ID="lblCustomerNM" runat="server"
                                Style="font-weight: 700; font-family: Calibri; font-size: medium;"></asp:Label>
                        </td>
                        <td style="font-family: Calibri; text-align: right">Customer Id : </td>
                        <td style="text-align: left; font-family: Calibri;">
                                <asp:Label ID="lblCustomerId" runat="server" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >&nbsp;</td>
                        <td style="font-family: Calibri;">Loan Duration</td>
                        <td style="width: 1%;font-weight: bold;">:</td>
                        <td style="text-align: left; font-family: Calibri;">
                            <asp:Label ID="lblLoanDuration" runat="server" Font-Size="14px"></asp:Label>
                        </td>
                        <td style="font-family: Calibri; text-align: right">Loan Amount : </td>
                        <td style="text-align: left; font-family: Calibri;">
                                <asp:Label ID="lblLoanAmount" runat="server" Font-Size="14px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">&nbsp;</td>
                        <td style="font-family: Calibri;">Address</td>
                        <td style="width: 1%; font-weight: bold;">:</td>
                        <td style="font-family: Calibri;" colspan="3">
                            <asp:Label ID="lblContactAdd" runat="server"
                                Style="font-family: Calibri; font-size: 12px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">&nbsp;</td>
                        <td style="font-family: Calibri;">Remarks</td>
                        <td style="width: 1%; font-weight: bold;">:</td>
                        <td style="font-family: Calibri;" colspan="3">
                            <asp:Label ID="lblRemarks" runat="server"
                                Style="font-family: Calibri; font-size: 12px"></asp:Label></td>
                    </tr>
                </table>
                <div style="width: 98%; margin: 1% 1% 0% 1%;">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        OnRowDataBound="GridView1_RowDataBound" Width="100%" ShowFooter="True"
                        ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField HeaderText="SL">
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField  HeaderText="Particulars (বিবরণ)">
                               <HeaderStyle HorizontalAlign="Center" Width="50%"/>
                                <ItemStyle HorizontalAlign="Left" Width="50%"/>
                            </asp:BoundField>
                            <asp:BoundField  HeaderText="Remarks (মন্তব্য)">
                                <HeaderStyle HorizontalAlign="Center" Width="30%"/>
                                <ItemStyle HorizontalAlign="Left" Width="30%"/>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Amount (জমা)">
                                <HeaderStyle HorizontalAlign="Center" Width="20%"/>
                                <ItemStyle HorizontalAlign="Right" Width="20%"/>
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle Font-Names="Calibri" Font-Size="16px" />
                        <HeaderStyle Font-Names="Calibri" Font-Size="16px" />
                        <RowStyle Font-Names="Calibri" Font-Size="14px" />
                    </asp:GridView>

                    <div style="margin-top: 1%; width: 100%; font-family: Calibri;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 5.9%;">
                                    <div style="width: 100%;">
                                    </div>
                                </td>
                                <td style="width: 38%;">
                                    <div style="width: 100%;">
                                        <p style="text-align: right; font-weight: bold;">&nbsp;</p>
                                    </div>
                                </td>
                                <td style="width: 5%;">
                                    <div style="width: 100%; text-align: center;">
                                    </div>
                                </td>
                                <td style="width: 7%;">
                                    <div style="width: 100%;">
                                        <div style="width: 100%; text-align: center;">
                                        </div>
                                    </div>
                                </td>
                                <td style="width: 7%;">
                                    <div style="width: 100%; text-align: right;">
                                    </div>
                                </td>
                                <td style="width: 23%;">
                                    <div style="width: 100%;">
                                        <div style="width: 100%; text-align: right; font-weight: bold; font-family: Calibri;">
                                            Total Amount : 
                                        </div>
                                    </div>
                                </td>
                                <td style="width: 16%;">
                                    <div style="width: 100%; text-align: right;">
                                        <asp:Label ID="lblNetAmount" runat="server"
                                            Style="font-weight: bold; text-align: right;"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <table style="width: 94%; margin: 1% 3% 0% 3%; font-family: Calibri;">
                    <tr>
                        <td class="style19">In Words :&nbsp;
                            <asp:Label ID="lblInWords" runat="server"></asp:Label>

                        </td>
                        <td></td>
                    </tr>
                </table>
                <table style="width: 98%; margin: 5% 1% 0% 1%; font-family: Calibri;">
                    <tr>
                        <td style="text-align: right">&nbsp;</td>
                        <td class="style25" style="text-align: center; font-size: small;">______________________________<br />
                            <span lang="BN-BD">গ্রাহক</span></td>
                        <td style="text-align: right">&nbsp;</td>
                        <td class="style25" style="text-align: center; font-size: small;">______________________________<br />
                            <span lang="BN-BD">চেয়ারম্যন/ভাইস-চেয়ারম্যন</span></td>
                        <td style="text-align: right">&nbsp;</td>
                        <td class="style25" style="text-align: center; font-size: small;">______________________________<br />
                            <span lang="BN-BD">পরিচালক</span></td>
                        <td style="text-align: center">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
