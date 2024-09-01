using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Yesbd;
using System.Data.SqlClient;
using System.Web.Services;
using System.Text;
using System.Collections.Specialized;
using System.Threading;

namespace Yesbd.Report.print
{
    public partial class Rpt_Transaction_Memo : System.Web.UI.Page
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);

        decimal tot_Amount = 0;
        string tot_Amount_comma = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseFunctions.lblAdd(@"SELECT COMPNM FROM COMPANY", lblCompNM);
                DatabaseFunctions.lblAdd(@"SELECT ADDRESS FROM COMPANY", lblAddress);
                DatabaseFunctions.lblAdd(@"SELECT CONTACTNO FROM COMPANY", lblContact);
                DatabaseFunctions.lblAdd(@"SELECT EMAILID FROM COMPANY", lblEmail);

                DateTime PrintDate = DateTime.Now;
                string td = PrintDate.ToString("dd-MMM-yyyy hh:mm tt");
                lblTime.Text = td;

                string Date = Session["Date"].ToString();
                string InvoiceNo = Session["InvoiceNo"].ToString();
                string TransactionNo = Session["TransactionNo"].ToString(); 
                string ClientNM = Session["ClientNM"].ToString();
                string ClientID = Session["ClientID"].ToString();
                string LoanDuration = Session["LoanDuration"].ToString();
                string LoanAmount = Session["LoanAmount"].ToString();
                string ContactAdd = Session["ContactAdd"].ToString();
                string Remarks = Session["Remarks"].ToString();
                
                DateTime InDT = DateTime.Parse(Date, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                lblTransactionDT.Text = InDT.ToString("dd-MMM-yyyy");
                lblCustomerNM.Text = ClientNM;
                lblCustomerId.Text = ClientID;
                lblTransactionVNo.Text = TransactionNo;
                lblLoanDuration.Text = LoanDuration;
                lblLoanAmount.Text = LoanAmount;
                lblContactAdd.Text = ContactAdd;
                lblRemarks.Text = Remarks;
                showGrid();

                string inDate = InDT.ToString("yyyy/MM/dd");
                DatabaseFunctions.lblAdd(@"SELECT TOTAMT FROM TRANSMST WHERE TRANSNO='" + TransactionNo + "' AND TRANSDT='" + inDate + "' AND CLIENTID='" + ClientID + "'", lblNetAmount);
                decimal nAmt = Convert.ToDecimal(lblNetAmount.Text);
                string netAmount = SpellAmount.comma(nAmt);
                lblNetAmount.Text = netAmount;
                
                lblInWords.Text = "";
                decimal dec;
                decimal parseAmount = decimal.Parse(lblNetAmount.Text);
                string lblAmount = parseAmount.ToString();
                Boolean ValidInput = Decimal.TryParse(lblNetAmount.Text, out dec);
                if (!ValidInput)
                {
                    lblInWords.ForeColor = System.Drawing.Color.Red;
                    lblInWords.Text = "Enter the Proper Amount...";
                    return;
                }
                if (lblNetAmount.Text.ToString().Trim() == "")
                {
                    lblInWords.ForeColor = System.Drawing.Color.Red;
                    lblInWords.Text = "Amount Cannot Be Empty...";
                    return;
                }
                else
                {
                    if (Convert.ToDecimal(lblNetAmount.Text) == 0)
                    {
                        lblInWords.ForeColor = System.Drawing.Color.Red;
                        lblInWords.Text = "Amount Cannot Be Empty...";
                        return;
                    }
                }

                string x1 = "";
                string x2 = "";

                if (lblAmount.Contains("."))
                {
                    x1 = lblAmount.Trim().Substring(0, lblAmount.Trim().IndexOf("."));
                    x2 = lblAmount.Trim().Substring(lblAmount.Trim().IndexOf(".") + 1);
                }
                else
                {
                    x1 = lblAmount.Trim();
                    x2 = "00";
                }

                if (x1.ToString().Trim() != "")
                {
                    x1 = Convert.ToInt64(x1.Trim()).ToString().Trim();
                }
                else
                {
                    x1 = "0";
                }

                lblAmount = x1 + "." + x2;

                if (x2.Length > 2)
                {
                    lblAmount = Math.Round(Convert.ToDouble(lblAmount), 2).ToString().Trim();
                }

                string AmtConv = SpellAmount.MoneyConvFn(lblAmount.Trim());

                lblInWords.Text = AmtConv.Trim();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void showGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            string Date = Session["Date"].ToString();
            string TransactionNo = Session["TransactionNo"].ToString();
            string ClientID = Session["ClientID"].ToString();

            DateTime InDT = DateTime.Parse(Date, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string inDate = InDT.ToString("yyyy/MM/dd");

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TRANSDT AS DT, CONVERT(NVARCHAR(20),TRANSDT, 103) AS TRANSDT, TRANSNO, CLIENTID, TRANSSL, PARTICULARS, REMARKS, " +
                                            "AMOUNT FROM TRANS WHERE TRANSNO='" + TransactionNo + "' AND TRANSDT='" + inDate + "' AND CLIENTID='" + ClientID + "' ORDER BY DT", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            else
            {

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string TRANSSL = DataBinder.Eval(e.Row.DataItem, "TRANSSL").ToString();
                e.Row.Cells[0].Text = "&nbsp;" + TRANSSL.TrimStart('0');

                string PARTICULARS = DataBinder.Eval(e.Row.DataItem, "PARTICULARS").ToString();
                e.Row.Cells[1].Text = "&nbsp;" + PARTICULARS;

                string REMARKS = DataBinder.Eval(e.Row.DataItem, "REMARKS").ToString();
                e.Row.Cells[2].Text = "&nbsp;" + REMARKS;

                decimal AMOUNT = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AMOUNT").ToString());
                string amt = SpellAmount.comma(AMOUNT);
                e.Row.Cells[3].Text = amt + "&nbsp;";

                tot_Amount += AMOUNT;
                tot_Amount_comma = SpellAmount.comma(tot_Amount);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "TOTAL :";
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].Text = tot_Amount_comma;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                
                e.Row.Font.Bold = true;
            }

            ShowHeader(GridView1);
        }

        private void ShowHeader(GridView grid)
        {
            if (grid.Rows.Count > 0)
            {
                grid.UseAccessibleHeader = true;
                grid.HeaderRow.TableSection = TableRowSection.TableHeader;
                //gridView.HeaderRow.Style["display"] = "table-header-group";
            }
        }

    }
}