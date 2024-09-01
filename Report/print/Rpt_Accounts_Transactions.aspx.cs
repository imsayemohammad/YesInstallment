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
    public partial class Rpt_Accounts_Transactions : System.Web.UI.Page
    {
        SqlConnection _conn = new SqlConnection(DatabaseFunctions.connection);
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                if (Session["CLIENTID"] == null)
                {
                    Response.Redirect("../../Report/UI/Accounts_Transactions.aspx");
                }
                else
                {
                    //try
                    //{
                        DatabaseFunctions.lblAdd(@"SELECT COMPNM FROM COMPANY", lblCompNM);
                        DatabaseFunctions.lblAdd(@"SELECT ADDRESS FROM COMPANY", lblAddress);

                        DateTime PrintDate = DateTime.Now;
                        string td = PrintDate.ToString("dd-MMM-yyyy hh:mm tt");
                        lblTime.Text = td;

                        string Customernm = Session["CLIENTNM"].ToString();
                        string Customerid = Session["CLIENTID"].ToString();
                        string From = Session["FROM"].ToString();
                        string To = Session["TO"].ToString();

                        DateTime FDate = DateTime.Parse(From, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                        lblFDate.Text = FDate.ToString("dd-MMM-yyyy");
                        DateTime TDate = DateTime.Parse(To, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                        lblTDate.Text = TDate.ToString("dd-MMM-yyyy");

                        lblCustomerNM.Text = Customernm;
                        LoadClientInfo(Customerid);

                        showGrid();
                    //}
                    //catch (Exception ex)
                    //{
                    //    Response.Write(ex.Message);
                    //}
                }
            }
        }


        public void LoadClientInfo(string customerid)
        {
            _conn.Open();
            var selectString = "SELECT FATHERNM, MOTHERNM, NOMINEENM, MOBNO, LOANDURATION, LOANAMOUNT, LOANSTATUS, " +
                               "CONTACTADD, MONTHLYRENT, CLIENTPAYABLE, COMPANYPAYABLE FROM CLIENT WHERE CLIENTID=@CLIENTID";
            var cmd = new SqlCommand(selectString, _conn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("CLIENTID", SqlDbType.NVarChar, 100).Value = customerid;

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                lblFatherNM.Text = reader["FATHERNM"].ToString();
                lblMotherNM.Text = reader["MOTHERNM"].ToString();
                lblNominee.Text = reader["NOMINEENM"].ToString();
                lblMobile.Text = reader["MOBNO"].ToString();
                lblLoanDuration.Text = reader["LOANDURATION"].ToString();
                lblLoanAmount.Text = reader["LOANAMOUNT"].ToString();


                lblMonthlyRent.Text = reader["MONTHLYRENT"].ToString();
                lblCompanyPayable.Text = reader["COMPANYPAYABLE"].ToString();

                lblLoanStatus.Text = reader["LOANSTATUS"].ToString();
                lblCutomerAddress.Text = reader["CONTACTADD"].ToString();
            }
            reader.Close();
            _conn.Close();

            //DatabaseFunctions.lblAdd(@"SELECT FATHERNM  FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblFatherNM);
            //DatabaseFunctions.lblAdd(@"SELECT MOTHERNM FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblMotherNM);
            //DatabaseFunctions.lblAdd(@"SELECT NOMINEENM FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblNominee);
            //DatabaseFunctions.lblAdd(@"SELECT MOBNO FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblMobile);
            //DatabaseFunctions.lblAdd(@"SELECT LOANDURATION FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblLoanDuration);
            //DatabaseFunctions.lblAdd(@"SELECT LOANAMOUNT FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblLoanAmount);
            //DatabaseFunctions.lblAdd(@"SELECT LOANSTATUS FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblLoanStatus);
            //DatabaseFunctions.lblAdd(@"SELECT CONTACTADD FROM CLIENT WHERE CLIENTID ='" + Customerid + "'", lblCutomerAddress);
        }


        public void showGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            string CLIENTID = Session["CLIENTID"].ToString();
            string From = Session["FROM"].ToString();
            string To = Session["TO"].ToString();

            DateTime FDate = DateTime.Parse(From, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string FDT = FDate.ToString("yyyy/MM/dd");

            DateTime TDate = DateTime.Parse(To, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TDT = TDate.ToString("yyyy/MM/dd");

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(@"SELECT TRANS.TRANSDT AS DT, CONVERT(NVARCHAR(20),TRANS.TRANSDT, 103) AS TRANSDT, TRANS.TRANSNO, TRANS.CLIENTID, TRANS.PARTICULARS, 
                        TRANS.AMOUNT FROM TRANS WHERE TRANS.CLIENTID='" + CLIENTID + "' AND TRANS.TRANSDT BETWEEN '" + FDT + "' AND '" + TDT + "' ORDER BY DT", conn);

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
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.Visible = true;
            }

            //SetInitialRow();
        }

        public int i = 0;
        public int j = 0;
        decimal Balance = 0;
        decimal LoanBalance = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var loanAmt = lblCompanyPayable.Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(lblCompanyPayable.Text); //Loan Amount(GIVEN) as ClientPayable/Loan Amount (প্রদেয়)
            var priceAmt = lblLoanAmount.Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(lblLoanAmount.Text); //Price amount as Loanamount
            var monthlyRent = lblMonthlyRent.Text == "" ? Convert.ToDecimal("0.00") : Convert.ToDecimal(lblMonthlyRent.Text);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string TRANSDT = DataBinder.Eval(e.Row.DataItem, "TRANSDT").ToString();
                e.Row.Cells[0].Text = "&nbsp;" + TRANSDT;

                string TRANSNO = DataBinder.Eval(e.Row.DataItem, "TRANSNO").ToString();
                e.Row.Cells[1].Text = "&nbsp;" + TRANSNO;

                string PARTICULARS = DataBinder.Eval(e.Row.DataItem, "PARTICULARS").ToString();
                e.Row.Cells[2].Text = "&nbsp;" + PARTICULARS;

                decimal AMOUNT = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AMOUNT").ToString());
                string amt = SpellAmount.comma(AMOUNT); //Credit amount
                e.Row.Cells[3].Text = amt + "&nbsp;";

                //decimal LOANAMOUNT = loanAmt - (AMOUNT - monthlyRent);
                //string lamt = SpellAmount.comma(LOANAMOUNT); //For Loan amount (প্রদেয়)
                //e.Row.Cells[4].Text = "&nbsp;" + lamt;


                if (i == 0)
                {
                    LoanBalance = loanAmt - (AMOUNT - monthlyRent);
                    string loanamnt = SpellAmount.comma(LoanBalance);
                    e.Row.Cells[4].Text = loanamnt + "&nbsp;";
                }
                else
                {
                    LoanBalance = LoanBalance - (AMOUNT - monthlyRent);
                    string loanamnt = SpellAmount.comma(LoanBalance);
                    e.Row.Cells[4].Text = loanamnt + "&nbsp;";
                }


                if (j == 0)
                {
                    Balance = priceAmt - AMOUNT;
                    string amnt = SpellAmount.comma(Balance);
                    e.Row.Cells[5].Text = amnt + "&nbsp;";
                }
                else
                {
                    Balance = Balance - AMOUNT;
                    string amnt = SpellAmount.comma(Balance);
                    e.Row.Cells[5].Text = amnt + "&nbsp;";
                }

                i++;
                j++;
            }

            ShowHeader(GridView1);
        }

        protected decimal GetLoanAmount(string clientid)
        {
            decimal m = 0;
            _conn.Open();
            var selectString = "SELECT COMPANYPAYABLE FROM CLIENT WHERE CLIENTID=@CLIENTID";
            var cmd = new SqlCommand(selectString, _conn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("CLIENTID", SqlDbType.NVarChar).Value = clientid;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var companypayable = Convert.ToDecimal(reader["COMPANYPAYABLE"].ToString());
                m = companypayable;
            }

            reader.Close();
            _conn.Close();
            return m;
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

        //private void SetInitialRow()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;
        //    dt.Columns.Add(new DataColumn("date", typeof(DateTime)));
        //    dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column3", typeof(decimal)));
        //    dt.Columns.Add(new DataColumn("Column4", typeof(decimal)));
        //    dt.Columns.Add(new DataColumn("Column5", typeof(decimal)));
        //    dr = dt.NewRow();
        //    dr["date"] = "";
        //    dr["Column1"] = string.Empty;
        //    dr["Column2"] = string.Empty;
        //    dr["Column3"] = string.Empty;
        //    dr["Column4"] = "Loan Amount-(Credit - Monthly Rent)";
        //    dr["Column4"] = "(Price Amount - Credit)";
        //    dt.Rows.Add(dr);
        //    //Store the DataTable in ViewState
        //    ViewState["CurrentTable"] = dt;
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //}

    }
}