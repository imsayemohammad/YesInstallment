using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yesbd.Report.print
{
    public partial class Rpt_Accounts_Trans_Summary : System.Web.UI.Page
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        SqlConnection _conn = new SqlConnection(DatabaseFunctions.connection);

        // To keep track of the previous row Group Identifier    
        //string strPreviousRowID = string.Empty;
        // To keep track the Index of Group Total    
        int intSubTotalIndex = 1;

        decimal dblSubTotalAmount = 0;
        string dblSubTotalAmountComma = "";

        decimal tot_Amount = 0;

        string tot_AmountComma = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                if (Session["FROM"] == null || Session["TO"] == null)
                {
                    Response.Redirect("../../Report/UI/Accounts_Trans_Summary.aspx");
                }
                else
                {
                    try
                    {
                        DatabaseFunctions.lblAdd(@"SELECT COMPNM FROM COMPANY", lblCompNM);
                        DatabaseFunctions.lblAdd(@"SELECT ADDRESS FROM COMPANY", lblAddress);

                        DateTime PrintDate = DateTime.Now;
                        string td = PrintDate.ToString("dd-MMM-yyyy hh:mm tt");
                        lblTime.Text = td;

                        string From = Session["FROM"].ToString();
                        string To = Session["TO"].ToString();

                        DateTime FDate = DateTime.Parse(From, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                        lblFDate.Text = FDate.ToString("dd-MMM-yyyy");
                        DateTime TDate = DateTime.Parse(To, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                        lblTDate.Text = TDate.ToString("dd-MMM-yyyy");
                        showGrid();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
        }

        public void showGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            string From = Session["FROM"].ToString();
            string To = Session["TO"].ToString();

            DateTime FDate = DateTime.Parse(From, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string FDT = FDate.ToString("yyyy/MM/dd");

            DateTime TDate = DateTime.Parse(To, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TDT = TDate.ToString("yyyy/MM/dd");

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(@"SELECT TRANS.TRANSDT AS DT, CONVERT(NVARCHAR(20),TRANS.TRANSDT, 103) AS TRANSDT, TRANS.TRANSNO, TRANS.CLIENTID, TRANS.PARTICULARS, 
                        TRANS.AMOUNT FROM TRANS WHERE TRANS.TRANSDT BETWEEN '" + FDT + "' AND '" + TDT + "' ORDER BY DT", conn);

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
        }

        public int i = 0;
        decimal Balance = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string TRANSDT = DataBinder.Eval(e.Row.DataItem, "TRANSDT").ToString();
                e.Row.Cells[0].Text = "&nbsp;" + TRANSDT;

                string TRANSNO = DataBinder.Eval(e.Row.DataItem, "TRANSNO").ToString();
                e.Row.Cells[1].Text = "&nbsp;" + TRANSNO;

                string CLIENTID = DataBinder.Eval(e.Row.DataItem, "CLIENTID").ToString();
                e.Row.Cells[2].Text = "&nbsp;" + GetClientName(CLIENTID);

                string PARTICULARS = DataBinder.Eval(e.Row.DataItem, "PARTICULARS").ToString();
                e.Row.Cells[3].Text = "&nbsp;" + PARTICULARS;

                decimal AMOUNT = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AMOUNT").ToString());
                string amt = SpellAmount.comma(AMOUNT);
                e.Row.Cells[4].Text = amt + "&nbsp;";

                dblSubTotalAmount += AMOUNT;
                dblSubTotalAmountComma = SpellAmount.comma(dblSubTotalAmount);

                tot_Amount += AMOUNT;
                tot_AmountComma = SpellAmount.comma(tot_Amount);

                //if (i == 0)
                //{
                //    Balance += AMOUNT;
                //    string amnt = SpellAmount.comma(Balance);
                //    e.Row.Cells[5].Text = amnt + "&nbsp;";
                //}
                //else
                //{
                //    Balance = AMOUNT;
                //    string amnt = SpellAmount.comma(Balance);
                //    e.Row.Cells[5].Text = amnt + "&nbsp;";
                //}
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan= 3;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Text = "TOTAL :";
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].Text = tot_AmountComma;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }

            ShowHeader(GridView1);
        }
        
        protected string GetClientName(string clientid)
        {
            string m = "";
            _conn.Open();
            var selectString = "SELECT CLIENTNM FROM CLIENT WHERE CLIENTID=@CLIENTID";
            var cmd = new SqlCommand(selectString, _conn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("CLIENTID", SqlDbType.NVarChar).Value = clientid;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var clientname = reader["CLIENTNM"].ToString();
                m = clientname;
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

        //protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    bool IsSubTotalRowNeedToAdd = DataBinder.Eval(e.Row.DataItem, "TRANSNO") != null;
        //    if (DataBinder.Eval(e.Row.DataItem, "TRANSNO") == null)
        //    {
        //        IsSubTotalRowNeedToAdd = true;
        //        //IsGrandTotalRowNeedtoAdd = true;
        //        intSubTotalIndex = 0;
        //    }

        //    if (IsSubTotalRowNeedToAdd)
        //    {
        //        #region Adding Sub Total Row
        //        GridView GridView1 = (GridView)sender;
        //        // Creating a Row          
        //        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
        //        //Adding Total Cell          
        //        TableCell cell = new TableCell();
        //        cell.Text = " TOTAL :";
        //        cell.HorizontalAlign = HorizontalAlign.Left;
        //        cell.ColumnSpan = 3;
        //        cell.CssClass = "SubTotalRowStyle";
        //        row.Cells.Add(cell);

        //        //Adding Amount Column         
        //        cell = new TableCell();
        //        cell.Text = string.Format("{0:0.00}", dblSubTotalAmountComma);
        //        cell.HorizontalAlign = HorizontalAlign.Right;
        //        cell.CssClass = "SubTotalRowStyle";
        //        row.Cells.Add(cell);
        //        //Adding the Row at the RowIndex position in the Grid      
        //        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
        //        intSubTotalIndex++;
        //        #endregion

        //        #region Reseting the Sub Total Variables

        //        dblSubTotalAmount = 0;
        //        #endregion
        //    }
        //}

    }
}