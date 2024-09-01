using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Yesbd;
using Yesbd.Input_Portion;
using System.Data.SqlClient;
using System.Web.Services;
using System.Text;
using System.Collections.Specialized;
using Yesbd.LogData;

namespace Yesbd.Input_Portion
{
    public partial class Accounts_Entry : System.Web.UI.Page
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        Yesbd.Input_Portion.DataModel iob = new Input_Portion.DataModel();
        Yesbd.Input_Portion.DataAccess dob = new Input_Portion.DataAccess();
        SqlConnection conn = new SqlConnection(DatabaseFunctions.connection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                string formLink = "/Input_Portion/Accounts_Entry.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!Page.IsPostBack)
                    {
                        Sysdate();
                        //DatabaseFunctions.dropDownAddWithSelect(ddlClientNM, "SELECT DISTINCT CLIENTNM FROM CLIENT");
                        //TransactionNo();
                    }
                }
                else
                {
                    Response.Redirect("../../home_default.aspx");
                }
            }
        }

        public void Sysdate()
        {
            DateTime dt = DatabaseFunctions.Timezone(DateTime.Now);
            string date = dt.ToString("dd/MM/yyyy");
            txtDate.Text = date;
        }

        public void TransactionNo()
        {
            //DateTime today = DateTime.Today.Date;
            //string td = DatabaseFunctions.Dayformat(today);
            //txtDate.Text = td;
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            string mon = transdate.ToString("MMM").ToUpper();
            string year = transdate.ToString("yy");
            lblMY.Text = mon + "-" + year;
            DatabaseFunctions.lblAdd(@"Select max(TRANSNO) FROM TRANSMST where TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", lblSMxNo);
            if (lblSMxNo.Text == "")
            {
                txtTransactionNo.Text = "1";
            }
            else
            {
                int iNo = int.Parse(lblSMxNo.Text);
                int totIno = iNo + 1;
                txtTransactionNo.Text = totIno.ToString();
            }

            txtInvoiceNo.Focus();
        }


        protected void GridShow()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDt = transdate.ToString("yyyy/MM/dd");

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TRANS WHERE TRANSDT = '" + TrDt + "' and TRANSMY = '" + lblMY.Text + "' and TRANSNO = '" + txtTransactionNo.Text + "' AND CLIENTID ='" + lblClientID.Text + "' order by TRANSSL", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds;
                gvDetail.DataBind();

                if (gvDetail.EditIndex == -1)
                {
                    decimal net = 0;
                    decimal netAmt = 0;
                    foreach (GridViewRow grid in gvDetail.Rows)
                    {
                        Label lblAmt = (Label)grid.Cells[3].FindControl("lblAmt");

                        lblAmt.Text = lblAmt.Text == "" ? "0.00" : lblAmt.Text;

                        net = Convert.ToDecimal(lblAmt.Text);
                        netAmt += net;
                        string nAmount = SpellAmount.comma(netAmt);
                        txtTotal.Text = nAmount;
                    }
                }
                else
                {

                }

                TextBox txtParticulars = (TextBox)gvDetail.FooterRow.FindControl("txtParticulars");
                txtParticulars.Focus();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvDetail.DataSource = ds;
                gvDetail.DataBind();
                int columncount = gvDetail.Rows[0].Cells.Count;
                gvDetail.Rows[0].Cells.Clear();
                gvDetail.Rows[0].Cells.Add(new TableCell());
                gvDetail.Rows[0].Cells[0].ColumnSpan = columncount;
                gvDetail.Rows[0].Cells[0].Text = "No Records Found";
                gvDetail.Rows[0].Visible = false;
            }
        }

        protected void GridShow_Complete()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDt = transdate.ToString("yyyy/MM/dd");

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TRANS WHERE TRANSDT = '" + TrDt + "' and TRANSMY = '" + lblMY.Text + "' and TRANSNO = '" + txtTransactionNo.Text + "' AND CLIENTID ='" + lblClientID.Text + "' order by TRANSSL", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds;
                gvDetail.DataBind();
                gvDetail.FooterRow.Visible = false;
            }
            else
            {

            }
        }

        protected void GridShow_CompleteEdit()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDt = transdate.ToString("yyyy/MM/dd");

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TRANS WHERE TRANSDT = '" + TrDt + "' and TRANSMY = '" + lblMY.Text + "' and TRANSNO = '" + ddlTransactionNoEdit.Text + "' AND CLIENTID ='" + lblClientID.Text + "' order by TRANSSL", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds;
                gvDetail.DataBind();
                gvDetail.FooterRow.Visible = false;
            }
            else
            {

            }
        }

        protected void gvDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (btnEdit.Text == "EDIT")
            {
                gvDetail.EditIndex = -1;
                GridShow();
            }
            else
            {
                gvDetail.EditIndex = -1;
                GridShow_Edit();
            }
        }

        private void check_transno()
        {
            Label CheckCount = new Label();
            DatabaseFunctions.lblAdd("SELECT COUNT(*) AS TRANSNO FROM TRANSMST WHERE  TRANSMY ='" + lblMY.Text + "' AND TRANSNO = " + txtTransactionNo.Text + " AND CLIENTID ='" + lblClientID.Text + "'", CheckCount);

            if (CheckCount.Text == "0")
            {
            }
            else
            {
                string userName = HttpContext.Current.Session["UserName"].ToString();
                Label UserCheck = new Label();
                DatabaseFunctions.lblAdd("SELECT USERID FROM TRANSMST WHERE TRANSMY ='" + lblMY.Text + "' AND TRANSNO =" + txtTransactionNo.Text + " AND CLIENTID ='" + lblClientID.Text + "'", UserCheck);
                if (userName == UserCheck.Text)
                {

                }
                else
                {
                    Label MxTrNoCheck = new Label();
                    DatabaseFunctions.lblAdd(" SELECT MAX(TRANSNO) AS TRANSNO FROM TRANSMST WHERE TRANSMY ='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", MxTrNoCheck);
                    txtTransactionNo.Text = (Convert.ToInt64(MxTrNoCheck.Text) + 1).ToString();
                }
            }
        }

        private string Acc_Transsl()
        {
            DatabaseFunctions.lblAdd(@"SELECT MAX(TRANSSL) FROM TRANS WHERE TRANSMY = '" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", lblTransSL);
            string ItemCD;
            string mxCD = "";
            string mid = "";
            string subItemCD = "";
            int subCD, incrItCD;
            if (lblTransSL.Text == "")
            {
                ItemCD = "00000001";
            }
            else
            {
                mxCD = lblTransSL.Text;
                //OItemCD = mxCD.Substring(4,4);
                subCD = int.Parse(mxCD);
                incrItCD = subCD + 1;
                if (incrItCD < 10)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "0000000" + mid;
                }
                else if (incrItCD < 100)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "000000" + mid;
                }
                else if (incrItCD < 1000)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "00000" + mid;
                }
                else if (incrItCD < 10000)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "0000" + mid;
                }
                else if (incrItCD < 100000)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "000" + mid;
                }
                else if (incrItCD < 1000000)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "00" + mid;
                }
                else if (incrItCD < 10000000)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "0" + mid;
                }

                ItemCD = subItemCD;
            }
            return ItemCD;
        }

        public void Datafield()
        {
            iob.UserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.ITime = DatabaseFunctions.Timezone(DateTime.Now);

            iob.UpdUserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UPDUserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.UPDIpaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UpdTime = DatabaseFunctions.Timezone(DateTime.Now);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");
            //string mon = DateTime.Today.Date.ToString("MMM").ToUpper();
            string mon = transdate.ToString("MMM").ToUpper();
            string year = transdate.ToString("yy");
            lblMY.Text = mon + "-" + year;

            iob.Date = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            iob.TransNo = Convert.ToInt64(btnEdit.Text == "EDIT" ? txtTransactionNo.Text : ddlTransactionNoEdit.Text);
            iob.TransMy = lblMY.Text;
            iob.invoiceno = txtInvoiceNo.Text;
            iob.ClientID = lblClientID.Text;
            iob.Remarks = txtRemarks.Text;
            iob.NetAmount = Convert.ToDecimal(txtTotal.Text);

        }

        protected void Refresh()
        {
            ddlTransactionNoEdit.SelectedIndex = -1;
            txtTransactionNo.Text = "";
            txtInvoiceNo.Text = "";
            txtClientNM.Text = "";
            txtRemarks.Text = "";
            lblClientID.Text = "";
            lblJoinDT.Text = "";
            lblNominee.Text = "";
            lblMobileNo.Text = "";
            lblContactAdd.Text = "";
            txtTotal.Text = ".00";
        }

        protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            DateTime TransDT = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDt = TransDT.ToString("yyyy/MM/dd");

            Datafield();

            if (e.CommandName.Equals("SaveCon"))
            {
                TextBox txtParticulars = (TextBox)gvDetail.FooterRow.FindControl("txtParticulars");
                TextBox txtGrdRemarks = (TextBox)gvDetail.FooterRow.FindControl("txtGrdRemarks");
                TextBox txtAmt = (TextBox)gvDetail.FooterRow.FindControl("txtAmt");

                iob.Particulars = txtParticulars.Text;
                iob.GrdRemarks = txtGrdRemarks.Text;
                decimal Amt = 0;
                txtAmt.Text = txtAmt.Text == "" ? "0" : txtAmt.Text;
                Amt = Convert.ToDecimal(txtAmt.Text);
                iob.Amount = Amt;

                if (txtClientNM.Text == "" || lblClientID.Text == "")
                {
                    lblGridMsg.Visible = true;
                    lblGridMsg.Text = "Select Customer Name.";
                    txtClientNM.Focus();
                }
                else if (txtParticulars.Text == "")
                {
                    lblGridMsg.Visible = true;
                    lblGridMsg.Text = "Select Particulars.";
                    txtParticulars.Focus();
                }
                else if (txtAmt.Text == "0" || txtAmt.Text == "")
                {
                    lblGridMsg.Visible = true;
                    lblGridMsg.Text = "Please Select Particulars Amount.";
                    txtAmt.Focus();
                }
                else
                {
                    lblGridMsg.Visible = false;

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (btnEdit.Text == "EDIT")
                    {
                        check_transno();
                        cmd = new SqlCommand("Select TRANSNO from TRANSMST where TRANSNO='" + txtTransactionNo.Text + "' AND TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("Select TRANSNO from TRANSMST where TRANSNO='" + ddlTransactionNoEdit.Text + "' AND TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        iob.TransSL = Acc_Transsl();

                        if (btnEdit.Text == "EDIT")
                        {
                            iob.TransNo = Convert.ToInt64(txtTransactionNo.Text);

                            dob.InsertTransInfo(iob);

                            GridShow();
                        }
                        else
                        {
                            iob.TransNo = Convert.ToInt64(ddlTransactionNoEdit.Text);
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("select * from TRANSMST where TRANSMY='" + lblMY.Text + "' and TRANSNO =" + iob.TransNo + " AND CLIENTID ='" + lblClientID.Text + "'", conn);
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                            DataSet ds1 = new DataSet();
                            da.Fill(ds1);
                            conn.Close();

                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                dob.InsertTransInfo(iob);

                                GridShow_Edit();
                            }
                            else
                            {
                                lblGridMsg.Visible = true;
                                lblGridMsg.Text = "Must be in New Mode.";
                            }

                        }
                    }
                    else
                    {
                        iob.TransNo = Convert.ToInt64(txtTransactionNo.Text);
                        iob.TransSL = Acc_Transsl();

                        dob.InsertTransMstInfo(iob);

                        dob.InsertTransInfo(iob);

                        GridShow();
                    }
                }
            }

           ////////////.................................... For Complete ................................................/////////////////////

            else if (e.CommandName.Equals("Complete"))
            {
                TextBox txtParticulars = (TextBox)gvDetail.FooterRow.FindControl("txtParticulars");
                TextBox txtGrdRemarks = (TextBox)gvDetail.FooterRow.FindControl("txtGrdRemarks");
                TextBox txtAmt = (TextBox)gvDetail.FooterRow.FindControl("txtAmt");

                iob.Particulars = txtParticulars.Text;
                iob.GrdRemarks = txtGrdRemarks.Text;
                decimal Amt = 0;
                txtAmt.Text = txtAmt.Text == "" ? "0" : txtAmt.Text;
                Amt = Convert.ToDecimal(txtAmt.Text);
                iob.Amount = Amt;

                if (txtClientNM.Text == "" || lblClientID.Text == "")
                {
                    lblGridMsg.Visible = true;
                    lblGridMsg.Text = "Select Customer Name.";
                    txtClientNM.Focus();
                }
                else if (txtParticulars.Text == "")
                {
                    lblGridMsg.Visible = true;
                    lblGridMsg.Text = "Select Particulars.";
                    txtParticulars.Focus();
                }
                else if (txtAmt.Text == "0" || txtAmt.Text == "")
                {
                    lblGridMsg.Visible = true;
                    lblGridMsg.Text = "Please Select Particulars Amount.";
                    txtAmt.Focus();
                }
                else
                {
                    lblGridMsg.Visible = false;

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    if (btnEdit.Text == "EDIT")
                    {
                        check_transno();
                        cmd = new SqlCommand("Select TRANSNO from TRANSMST where TRANSNO='" + txtTransactionNo.Text + "' AND TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("Select TRANSNO from TRANSMST where TRANSNO='" + ddlTransactionNoEdit.Text + "' AND TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        iob.TransSL = Acc_Transsl();

                        if (btnEdit.Text == "EDIT")
                        {
                            iob.TransNo = Convert.ToInt64(txtTransactionNo.Text);

                            dob.InsertTransInfo(iob);

                            //Refresh();
                            //txtParticulars.Text = "";
                            //txtParticulars.Text = "";
                            //txtAmount.Text = ".00";
                            GridShow_Complete();

                        }
                        else
                        {
                            iob.TransNo = Convert.ToInt64(ddlTransactionNoEdit.Text);
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("select * from TRANSMST where TRANSMY='" + lblMY.Text + "' and TRANSNO =" + iob.TransNo + " AND CLIENTID ='" + lblClientID.Text + "'", conn);
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);
                            conn.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                dob.InsertTransInfo(iob);

                                //Refresh();
                                //txtParticulars.Text = "";
                                //txtParticulars.Text = "";
                                //txtAmount.Text = ".00";
                                //ddlTransactionNoEdit.Focus();
                                //GridShow_Edit();

                                GridShow_CompleteEdit();
                            }
                            else
                            {
                                lblGridMsg.Visible = true;
                                lblGridMsg.Text = "Must be in New Mode.";
                            }

                        }
                    }
                    else
                    {
                        iob.TransNo = Convert.ToInt64(txtTransactionNo.Text);
                        iob.TransSL = Acc_Transsl();

                        dob.InsertTransMstInfo(iob);

                        dob.InsertTransInfo(iob);

                        //Refresh();
                        //txtParticulars.Text = "";
                        //txtParticulars.Text = "";
                        //txtAmount.Text = ".00";

                        GridShow_Complete();
                    }
                }

                if (btnEdit.Text == "EDIT") ////new mode
                {
                    Decimal totAmt = 0;
                    Decimal a = 0;
                    decimal tAmt = 0;
                    //decimal dis = 0;
                    //decimal disAmt = 0;
                    decimal amt = 0;
                    decimal Amount = 0;
                    if (gvDetail.EditIndex == -1)
                    {
                        foreach (GridViewRow grid in gvDetail.Rows)
                        {
                            Label lblAmt = (Label)grid.Cells[3].FindControl("lblAmt");

                            lblAmt.Text = lblAmt.Text == "" ? "0" : lblAmt.Text;
                            String TotalAmount = lblAmt.Text;
                            totAmt = Convert.ToDecimal(TotalAmount);
                            a += totAmt;
                            string tAmount = SpellAmount.comma(a);
                            txtAmt.Text = tAmount;
                            txtTotal.Text = a.ToString();
                        }
                    }
                    else
                    {

                    }
                }
                else ////// edit mode
                {
                    Decimal totAmt = 0;
                    Decimal a = 0;
                    if (gvDetail.EditIndex == -1)
                    {
                        foreach (GridViewRow grid in gvDetail.Rows)
                        {
                            Label lblAmt = (Label)grid.Cells[3].FindControl("lblAmt");

                            lblAmt.Text = lblAmt.Text == "" ? "0" : lblAmt.Text;
                            string TotalAmount = lblAmt.Text;
                            totAmt = Convert.ToDecimal(TotalAmount);
                            a += totAmt;
                            string tAmount = SpellAmount.comma(a);
                            txtAmt.Text = tAmount;
                            txtTotal.Text = a.ToString();
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            Session["Date"] = "";
            Session["TransactionNo"] = "";
            Session["TransactionNoEdit"] = "";
            Session["InvoiceNo"] = "";
            Session["ClientNM"] = "";
            Session["ClientID"] = "";
            Session["LoanDuration"] = "";
            Session["LoanAmount"] = "";
            Session["ContactAdd"] = "";
            Session["Remarks"] = "";

            if (txtDate.Text == "")
            {
                lblGridMsg.Visible = true;
                lblGridMsg.Text = "Select Date.";
                txtDate.Focus();
            }
            else if (txtClientNM.Text == "" || lblClientID.Text == "")
            {
                lblGridMsg.Visible = true;
                lblGridMsg.Text = "Select Customer Name.";
                txtClientNM.Focus();
            }
            else
            {

                lblGridMsg.Visible = false;

                Session["Date"] = txtDate.Text;
                Session["InvoiceNo"] = txtInvoiceNo.Text;
                Session["ClientNM"] = txtClientNM.Text;
                Session["ClientID"] = lblClientID.Text;
                Session["LoanDuration"] = lblLoan.Text;
                Session["LoanAmount"] = lblLoanAmt.Text;
                Session["ContactAdd"] = lblContactAdd.Text;
                Session["Remarks"] = txtRemarks.Text;

                Datafield();

                if (btnEdit.Text == "NEW")
                {
                    if (ddlTransactionNoEdit.Text == "Select" || ddlTransactionNoEdit.Text == "")
                    {
                        lblGridMsg.Visible = true;
                        lblGridMsg.Text = "Select Transaction No.";
                        ddlTransactionNoEdit.Focus();
                    }
                    else
                    {
                        Session["TransactionNo"] = ddlTransactionNoEdit.Text;

                        iob.TransNo = Convert.ToInt64(ddlTransactionNoEdit.Text);

                        TransMst_Log_Data_Update();

                        dob.UpdateTransMstInfo(iob);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('../Report/print/Rpt_Transaction_Memo.aspx','_newtab');", true);
                    }
                }
                else
                {
                    Session["TransactionNo"] = txtTransactionNo.Text;

                    if (btnEdit.Text == "EDIT")
                    {
                        iob.TransNo = Convert.ToInt64(txtTransactionNo.Text);

                        TransMst_Log_Data_Update();

                        dob.UpdateTransMstInfo(iob);
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('../Report/print/Rpt_Transaction_Memo.aspx','_newtab');", true);
                }
            }
        }

        protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            Datafield();

            if (btnEdit.Text == "EDIT")
            {
                Label lblTransSL = (Label)gvDetail.Rows[e.RowIndex].FindControl("lblTransSL");
                lblTransSL_log.Text = lblTransSL.Text;

                SqlCommand cmd1 = new SqlCommand("select * from TRANS where TRANSMY='" + lblMY.Text + "' and TRANSNO ='" + txtTransactionNo.Text + "' and TRANSDT = '" + TrDate + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                conn.Close();

                Trans_Log_Delete();

                if (ds1.Tables[0].Rows.Count > 1)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from TRANS where TRANSNO ='" + txtTransactionNo.Text + "' and  TRANSDT = '" + TrDate + "' and TRANSSL = '" + lblTransSL.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from TRANS where TRANSNO ='" + txtTransactionNo.Text + "' and  TRANSDT = '" + TrDate + "' and TRANSSL = '" + lblTransSL.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    cmd.ExecuteNonQuery();

                    TransMst_Log_Data_Delete();

                    SqlCommand cmd2 = new SqlCommand("delete from TRANSMST where TRANSNO ='" + txtTransactionNo.Text + "' and TRANSMY='" + lblMY.Text + "' and  TRANSDT = '" + TrDate + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }


                gvDetail.EditIndex = -1;
                GridShow();

                lblErrorMSG.Visible = true;
                lblErrorMSG.Text = "Complete Transaction By Changing Discount.";

            }
            else
            {
                Label lblTransSL = (Label)gvDetail.Rows[e.RowIndex].FindControl("lblTransSL");
                lblTransSL_log.Text = lblTransSL.Text;

                SqlCommand cmd1 = new SqlCommand("select * from TRANS where TRANSMY='" + lblMY.Text + "' and TRANSNO ='" + ddlTransactionNoEdit.Text + "' and TRANSDT = '" + TrDate + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                conn.Close();

                Trans_Log_Delete();

                if (ds1.Tables[0].Rows.Count > 1)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from TRANS where TRANSNO ='" + ddlTransactionNoEdit.Text + "' and  TRANSDT = '" + TrDate + "' and TRANSSL = '" + lblTransSL.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from TRANS where TRANSNO ='" + ddlTransactionNoEdit.Text + "' and  TRANSDT = '" + TrDate + "' and TRANSSL = '" + lblTransSL.Text + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    cmd.ExecuteNonQuery();

                    TransMst_Log_Data_Delete();

                    SqlCommand cmd2 = new SqlCommand("delete from TRANSMST where TRANSNO ='" + ddlTransactionNoEdit.Text + "' and TRANSMY='" + lblMY.Text + "' and  TRANSDT = '" + TrDate + "' AND CLIENTID ='" + lblClientID.Text + "'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }

                gvDetail.EditIndex = -1;
                GridShow_Edit();

                lblErrorMSG.Visible = true;
                lblErrorMSG.Text = "Complete Transaction By Changing Discount.";
            }
        }

        protected void gvDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (btnEdit.Text == "EDIT")
            {
                gvDetail.EditIndex = e.NewEditIndex;
                GridShow();
            }
            else
            {
                gvDetail.EditIndex = e.NewEditIndex;
                GridShow_Edit();
            }

            TextBox txtParticularsEdit = (TextBox)gvDetail.Rows[e.NewEditIndex].FindControl("txtParticularsEdit");
            txtParticularsEdit.Focus();
        }

        protected void gvDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            string userName = HttpContext.Current.Session["UserName"].ToString();
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            TextBox txtParticularsEdit = (TextBox)gvDetail.Rows[e.RowIndex].FindControl("txtParticularsEdit");
            TextBox txtGrdRemarksEdit = (TextBox)gvDetail.Rows[e.RowIndex].FindControl("txtGrdRemarksEdit");
            Label lblTransSLEdit = (Label)gvDetail.Rows[e.RowIndex].FindControl("lblTransSLEdit");
            TextBox txtAmtEdit = (TextBox)gvDetail.Rows[e.RowIndex].FindControl("txtAmtEdit");

            iob.Particulars = txtParticularsEdit.Text;
            iob.GrdRemarks = txtGrdRemarksEdit.Text;
            iob.TransSL = lblTransSLEdit.Text;

            Datafield();

            if (txtClientNM.Text == "" || lblClientID.Text == "")
            {
                lblGridMsg.Visible = true;
                lblGridMsg.Text = "Select Customer Name.";
                txtClientNM.Focus();
            }
            else if (txtParticularsEdit.Text == "")
            {
                lblGridMsg.Visible = true;
                lblGridMsg.Text = "Select Particulars.";
                txtParticularsEdit.Focus();
            }
            else
            {
                txtAmtEdit.Text = txtAmtEdit.Text == "" ? "0" : txtAmtEdit.Text;
                decimal Amt = 0;
                Amt = Convert.ToDecimal(txtAmtEdit.Text);
                iob.Amount = Amt;

                if (btnEdit.Text == "EDIT")
                {
                    iob.TransNo = Convert.ToInt64(txtTransactionNo.Text);
                    lblTransSL_log.Text = lblTransSLEdit.Text;
                    Trans_Log_Update();

                    dob.UpdateTransInfo(iob);

                    TransMst_Log_Data_Update();

                    dob.UpdateTransMstInfo(iob);

                    gvDetail.EditIndex = -1;
                    GridShow();

                    lblErrorMSG.Visible = true;
                    lblErrorMSG.Text = "Complete Transaction By Changing Discount.";
                }
                else
                {
                    iob.TransNo = Convert.ToInt64(ddlTransactionNoEdit.Text);
                    lblTransSL_log.Text = lblTransSLEdit.Text;
                    Trans_Log_Update();

                    dob.UpdateTransInfo(iob);

                    TransMst_Log_Data_Update();

                    dob.UpdateTransMstInfo(iob);

                    gvDetail.EditIndex = -1;
                    GridShow_Edit();

                    lblErrorMSG.Visible = true;
                    lblErrorMSG.Text = "Complete Transaction By Changing Discount.";
                }

            }
        }

        protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionListClientNM(string prefixText, int count, string contextKey)
        {
            string connection = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand("Select CLIENTNM from CLIENT where CLIENTNM LIKE '" + prefixText + "%'", conn);

            SqlDataReader oReader;
            conn.Open();
            List<String> CompletionSet = new List<string>();
            oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oReader.Read())
                CompletionSet.Add(oReader["CLIENTNM"].ToString());
            return CompletionSet.ToArray();
        }

        protected void txtClientNM_TextChanged(object sender, EventArgs e)
        {
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");
            //string mon = DateTime.Today.Date.ToString("MMM").ToUpper();
            string mon = transdate.ToString("MMM").ToUpper();
            string year = transdate.ToString("yy");
            lblMY.Text = mon + "-" + year;

            DatabaseFunctions.lblAdd(@"SELECT CLIENTID FROM CLIENT WHERE CLIENTNM ='" + txtClientNM.Text + "'", lblClientID);

            DatabaseFunctions.lblAdd(@"SELECT CONVERT(NVARCHAR(10), TRANSDT, 103) AS TRANSDT  FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblJoinDT);
            DatabaseFunctions.lblAdd(@"SELECT LOANDURATION FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblLoan);
            DatabaseFunctions.lblAdd(@"SELECT LOANAMOUNT FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblLoanAmt);
            DatabaseFunctions.lblAdd(@"SELECT NOMINEENM FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblNominee);
            DatabaseFunctions.lblAdd(@"SELECT MOBNO FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblMobileNo);
            DatabaseFunctions.lblAdd(@"SELECT CONTACTADD FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblContactAdd);

            if (btnEdit.Text == "EDIT")
            {
                TransactionNo();
                txtInvoiceNo.Focus();
                GridShow();
            }
            else
            {
                DatabaseFunctions.dropDownAddWithSelect(ddlTransactionNoEdit, "SELECT DISTINCT TRANSNO FROM TRANS WHERE TRANSDT ='" + TrDate + "' AND TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'");
                ddlTransactionNoEdit.Focus();
                GridShow_Edit();
            }
        }

        //protected void ddlClientNM_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    string TrDate = transdate.ToString("yyyy/MM/dd");
        //    //string mon = DateTime.Today.Date.ToString("MMM").ToUpper();
        //    string mon = transdate.ToString("MMM").ToUpper();
        //    string year = transdate.ToString("yy");
        //    lblMY.Text = mon + "-" + year;

        //    if (ddlClientNM.Text == "" || ddlClientNM.Text == "Select")
        //    {
        //        lblGridMsg.Visible = true;
        //        lblGridMsg.Text = "Select Customer Name.";
        //        ddlClientNM.Focus();
        //    }
        //    else
        //    {
        //        lblGridMsg.Visible = false;
        //        DatabaseFunctions.lblAdd(@"SELECT CLIENTID FROM CLIENT WHERE CLIENTNM ='" + ddlClientNM.Text + "'", lblClientID);

        //        DatabaseFunctions.lblAdd(@"SELECT CONVERT(NVARCHAR(10), TRANSDT, 103) AS TRANSDT  FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblJoinDT);
        //        DatabaseFunctions.lblAdd(@"SELECT LOANDURATION FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblLoan);
        //        DatabaseFunctions.lblAdd(@"SELECT LOANAMOUNT FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblLoanAmt);
        //        DatabaseFunctions.lblAdd(@"SELECT NOMINEENM FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblNominee);
        //        DatabaseFunctions.lblAdd(@"SELECT MOBNO FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblMobileNo);
        //        DatabaseFunctions.lblAdd(@"SELECT CONTACTADD FROM CLIENT WHERE CLIENTID ='" + lblClientID.Text + "'", lblContactAdd);

        //        if (btnEdit.Text == "EDIT")
        //        {
        //            TransactionNo();
        //            txtInvoiceNo.Focus();
        //            GridShow();
        //        }
        //        else
        //        {
        //            DatabaseFunctions.dropDownAddWithSelect(ddlTransactionNoEdit, "SELECT DISTINCT TRANSNO FROM TRANS WHERE TRANSDT ='" + TrDate + "' AND TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'");
        //            ddlTransactionNoEdit.Focus();
        //            GridShow_Edit();
        //        }

        //    }
        //}

        protected void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            TextBox txtParticulars = (TextBox)gvDetail.FooterRow.FindControl("txtParticulars");
            txtParticulars.Focus();
        }

        protected void txtParticulars_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            TextBox txtGrdRemarks = (TextBox)row.FindControl("txtGrdRemarks");
            txtGrdRemarks.Focus();
        }

        protected void txtParticularsEdit_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);

            TextBox txtGrdRemarksEdit = (TextBox)row.FindControl("txtGrdRemarksEdit");
            txtGrdRemarksEdit.Focus();
        }

        protected void txtGrdRemarks_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);

            TextBox txtAmt = (TextBox)row.FindControl("txtAmt");
            txtAmt.Focus();
        }

        protected void txtGrdRemarksEdit_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);

            TextBox txtAmtEdit = (TextBox)row.FindControl("txtAmtEdit");
            txtAmtEdit.Focus();
        }

        protected void txtAmt_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);

            ImageButton imgbtnAdd = (ImageButton)row.FindControl("imgbtnAdd");
            imgbtnAdd.Focus();
        }

        protected void txtAmtEdit_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);

            ImageButton imgbtnUpdate = (ImageButton)row.FindControl("imgbtnUpdate");
            imgbtnUpdate.Focus();
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (btnEdit.Text == "EDIT")
            {
                //DatabaseFunctions.dropDownAddWithSelect(ddlClientNM, "SELECT DISTINCT CLIENTNM FROM CLIENT");
                //ddlClientNM.Focus();
                txtClientNM.Focus();
                //TransactionNo();
                GridShow();
            }

            else
            {
                DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                string TrDate = transdate.ToString("yyyy/MM/dd");

                string month = transdate.ToString("MMM").ToUpper();
                string years = transdate.ToString("yy");
                lblMY.Text = month + "-" + years;

                DatabaseFunctions.dropDownAddWithSelect(ddlTransactionNoEdit, "SELECT DISTINCT TRANSNO FROM TRANS WHERE TRANSDT ='" + TrDate + "' AND TRANSMY='" + lblMY.Text + "' AND CLIENTID ='" + lblClientID.Text + "'");
                ddlTransactionNoEdit.Focus();
                GridShow_Edit();
            }
        }


        /////////////........................Editing Portion......................./////////////////

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "EDIT")
            {
                DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                string TrDate = transdate.ToString("yyyy/MM/dd");

                txtTransactionNo.Visible = false;
                btnEdit.Text = "NEW";
                //btnPrint.Visible = true;
                ddlTransactionNoEdit.Visible = true;
                lblErrorMSG.Visible = false;
                //DatabaseFunctions.dropDownAddWithSelect(ddlClientNM, "SELECT DISTINCT CLIENTNM FROM CLIENT");
                //ddlClientNM.Focus();
                Refresh();
                //lblMY.Text = "";
                txtClientNM.Focus();
                GridShow();
                Sysdate();
            }
            else
            {
                txtTransactionNo.Visible = true;
                btnEdit.Text = "EDIT";
                ddlTransactionNoEdit.Visible = false;
                lblErrorMSG.Visible = false;
                //DatabaseFunctions.dropDownAddWithSelect(ddlClientNM, "SELECT DISTINCT CLIENTNM FROM CLIENT");
                //ddlClientNM.Focus();
                Refresh();
                //TransactionNo();
                txtClientNM.Focus();
                GridShow_Edit();
                Sysdate();
            }
        }

        protected void ddlTransactionNoEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDt = transdate.ToString("yyyy/MM/dd");

            if (txtClientNM.Text == "" || lblClientID.Text == "")
            {
                gvDetail.Visible = false;
                lblGridMsg.Visible = true;
                lblGridMsg.Text = "Select Customer Name.";
                txtClientNM.Focus();
                txtTotal.Text = "";
            }
            else if (ddlTransactionNoEdit.Text == "Select" || ddlTransactionNoEdit.Text == "")
            {
                gvDetail.Visible = false;
                lblGridMsg.Visible = true;
                lblGridMsg.Text = "Please Select Transaction No.";
                ddlTransactionNoEdit.Focus();
                txtTotal.Text = "";
            }
            else
            {
                gvDetail.Visible = true;
                lblGridMsg.Visible = false;
                iob.TransNo = Convert.ToInt64(ddlTransactionNoEdit.Text);

                DatabaseFunctions.txtAdd(@"select INVOICENO from TRANSMST where CLIENTID ='" + lblClientID.Text + "' and TRANSDT = '" + TrDt + "' and TRANSMY = '" + lblMY.Text + "' and TRANSNO =" + iob.TransNo + "", txtInvoiceNo);
                DatabaseFunctions.txtAdd(@"select REMARKS from TRANSMST where CLIENTID ='" + lblClientID.Text + "' and TRANSDT = '" + TrDt + "' and TRANSMY = '" + lblMY.Text + "' and TRANSNO =" + iob.TransNo + "", txtRemarks);
                GridShow_Edit();
            }
        }

        protected void GridShow_Edit()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDt = transdate.ToString("yyyy/MM/dd");

            Int64 TransactionNoEdit = 0;
            if (ddlTransactionNoEdit.Text == "Select" || ddlTransactionNoEdit.Text == "")
            {
                TransactionNoEdit = 0;
            }
            else
            {
                TransactionNoEdit = Convert.ToInt64(ddlTransactionNoEdit.Text);
            }
            //TransactionNoEdit = ddlTransactionNoEdit.Text == "Select"? 0 : Convert.ToInt64(ddlTransactionNoEdit.Text);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TRANS where CLIENTID ='" + lblClientID.Text + "' and TRANSDT = '" + TrDt + "' and TRANSMY = '" + lblMY.Text + "' and TRANSNO = " + TransactionNoEdit + " order by TRANSSL", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds;
                gvDetail.DataBind();

                if (gvDetail.EditIndex == -1)
                {
                    Decimal totAmt = 0;
                    Decimal a = 0;
                    decimal net = 0;
                    decimal netAmt = 0;
                    foreach (GridViewRow grid in gvDetail.Rows)
                    {
                        Label lblAmt = (Label)grid.Cells[3].FindControl("lblAmt");

                        lblAmt.Text = lblAmt.Text == "" ? "0.00" : lblAmt.Text;

                        net = Convert.ToDecimal(lblAmt.Text);
                        netAmt += net;
                        string nAmount = SpellAmount.comma(netAmt);
                        txtTotal.Text = nAmount;
                    }
                }
                else
                {

                }

                TextBox txtParticulars = (TextBox)gvDetail.FooterRow.FindControl("txtParticulars");
                txtParticulars.Focus();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvDetail.DataSource = ds;
                gvDetail.DataBind();
                int columncount = gvDetail.Rows[0].Cells.Count;
                gvDetail.Rows[0].Cells.Clear();
                gvDetail.Rows[0].Cells.Add(new TableCell());
                gvDetail.Rows[0].Cells[0].ColumnSpan = columncount;
                gvDetail.Rows[0].Cells[0].Text = "No Records Found";
                gvDetail.Rows[0].Visible = false;

                //Refresh();
                txtClientNM.Focus();
            }
        }

        public void Trans_Log_Delete()
        {
            Yesbd.LogData.Interface.LogDataInterface iob = new LogData.Interface.LogDataInterface();

            iob.IpAddressInsert = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UserIdInsert = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPcInsert = DatabaseFunctions.UserPc();
            iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            Int64 TransNo;
            TransNo = Convert.ToInt64(btnEdit.Text == "NEW" ? ddlTransactionNoEdit.Text : txtTransactionNo.Text);

            // logdata add start //
            Label lblLogData = new Label();

            DatabaseFunctions.lblAdd(@"SELECT ISNULL(CONVERT(NVARCHAR(20),TRANSDT),'NULL')+' '+TRANSMY+' '+ISNULL(CONVERT(NVARCHAR(20),TRANSNO),'NULL')+' '+ISNULL(INVOICENO,'NULL')+' '+ISNULL(CLIENTID,'NULL')+' '+ISNULL(PARTICULARS,'NULL')
                                        +' '+ISNULL(REMARKS,'NULL')+' '+TRANSSL+' '+ISNULL(CONVERT(NVARCHAR(20),AMOUNT),'NULL')+' '+ISNULL(USERPC,'NULL')+' '+ USERID+' '+ISNULL(CONVERT(NVARCHAR(20),INTIME),'NULL')+' '+ISNULL(IPADDRESS,'NULL')
                                        +' '+ISNULL(UPDUSERPC,'NULL')+' '+ISNULL(UPDUSERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),UPDTIME),'NULL')+' '+ISNULL(UPDIPADDRESS,'NULL') FROM TRANS
                                        WHERE TRANSNO ='" + TransNo + "' and  TRANSDT = '" + TrDate + "' and TRANSSL = '" + lblTransSL_log.Text + "'", lblLogData);
            string logid = "DELETE";
            string tableid = "TRANS";
            LogDataFunction.InsertLogData(logid, tableid, lblLogData.Text, iob.IpAddressInsert);
            // logdata add start //
        }

        public void Trans_Log_Update()
        {
            Yesbd.LogData.Interface.LogDataInterface iob = new LogData.Interface.LogDataInterface();

            iob.IpAddressInsert = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UserIdInsert = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPcInsert = DatabaseFunctions.UserPc();
            iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            Int64 TransNo;
            TransNo = Convert.ToInt64(btnEdit.Text == "NEW" ? ddlTransactionNoEdit.Text : txtTransactionNo.Text);

            // logdata add start //
            Label lblLogData = new Label();

            DatabaseFunctions.lblAdd(@"SELECT ISNULL(CONVERT(NVARCHAR(20),TRANSDT),'NULL')+' '+TRANSMY+' '+ISNULL(CONVERT(NVARCHAR(20),TRANSNO),'NULL')+' '+ISNULL(INVOICENO,'NULL')+' '+ISNULL(CLIENTID,'NULL')+' '+ISNULL(PARTICULARS,'NULL')
                                        +' '+ISNULL(REMARKS,'NULL')+' '+TRANSSL+' '+ISNULL(CONVERT(NVARCHAR(20),AMOUNT),'NULL')+' '+ISNULL(USERPC,'NULL')+' '+ USERID+' '+ISNULL(CONVERT(NVARCHAR(20),INTIME),'NULL')+' '+ISNULL(IPADDRESS,'NULL')
                                        +' '+ISNULL(UPDUSERPC,'NULL')+' '+ISNULL(UPDUSERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),UPDTIME),'NULL')+' '+ISNULL(UPDIPADDRESS,'NULL') FROM TRANS
                                        WHERE TRANSNO ='" + TransNo + "' and  TRANSDT = '" + TrDate + "' and TRANSSL = '" + lblTransSL_log.Text + "'", lblLogData);
            string logid = "UPDATE";
            string tableid = "TRANS";
            LogDataFunction.InsertLogData(logid, tableid, lblLogData.Text, iob.IpAddressInsert);
            // logdata add start //
        }

        public void Trans_Log_Update_without_transsl()
        {
            Yesbd.LogData.Interface.LogDataInterface iob = new LogData.Interface.LogDataInterface();

            iob.IpAddressInsert = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UserIdInsert = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPcInsert = DatabaseFunctions.UserPc();
            iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            Int64 TransNo;
            TransNo = Convert.ToInt64(btnEdit.Text == "NEW" ? ddlTransactionNoEdit.Text : txtTransactionNo.Text);

            // logdata add start //
            Label lblLogData = new Label();

            DatabaseFunctions.lblAdd(@"SELECT ISNULL(CONVERT(NVARCHAR(20),TRANSDT),'NULL')+' '+TRANSMY+' '+ISNULL(CONVERT(NVARCHAR(20),TRANSNO),'NULL')+' '+ISNULL(INVOICENO,'NULL')+' '+ISNULL(CLIENTID,'NULL')+' '+ISNULL(PARTICULARS,'NULL')
                                        +' '+ISNULL(REMARKS,'NULL')+' '+TRANSSL+' '+ISNULL(CONVERT(NVARCHAR(20),AMOUNT),'NULL')+' '+ISNULL(USERPC,'NULL')+' '+ USERID+' '+ISNULL(CONVERT(NVARCHAR(20),INTIME),'NULL')+' '+ISNULL(IPADDRESS,'NULL')
                                        +' '+ISNULL(UPDUSERPC,'NULL')+' '+ISNULL(UPDUSERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),UPDTIME),'NULL')+' '+ISNULL(UPDIPADDRESS,'NULL') FROM TRANS
                                        WHERE TRANSNO ='" + TransNo + "' and  TRANSDT = '" + TrDate + "' and TRANSMY='" + lblMY.Text + "'", lblLogData);
            string logid = "UPDATE";
            string tableid = "TRANS";
            LogDataFunction.InsertLogData(logid, tableid, lblLogData.Text, iob.IpAddressInsert);
            // logdata add start //
        }

        public void TransMst_Log_Data_Delete()
        {
            Yesbd.LogData.Interface.LogDataInterface iob = new LogData.Interface.LogDataInterface();

            iob.IpAddressInsert = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UserIdInsert = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPcInsert = DatabaseFunctions.UserPc();
            iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");
            Int64 TransNo;

            TransNo = Convert.ToInt64(btnEdit.Text == "NEW" ? ddlTransactionNoEdit.Text : txtTransactionNo.Text);

            // logdata add start //
            Label lblLogDataMST = new Label();
            DatabaseFunctions.lblAdd(@"SELECT ISNULL(CONVERT(NVARCHAR(20),TRANSDT),'NULL')+' '+TRANSMY+' '+ISNULL(CONVERT(NVARCHAR(20),TRANSNO),'NULL')+' '+ISNULL(INVOICENO,'NULL')+' '+ISNULL(CLIENTID,'NULL')
                                        +' '+ISNULL(CONVERT(NVARCHAR(20),TOTAMT),'NULL')+' '+ISNULL(REMARKS,'NULL')+' '+ISNULL(USERPC,'NULL')+' '+ USERID+' '+ISNULL(CONVERT(NVARCHAR(20),INTIME),'NULL')
                                        +' '+ISNULL(IPADDRESS,'NULL')+' '+ISNULL(UPDUSERPC,'NULL')+' '+ISNULL(UPDUSERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),UPDTIME),'NULL')+' '+ISNULL(UPDIPADDRESS,'NULL') FROM TRANSMST
                                        WHERE TRANSMY='" + lblMY.Text + "' and TRANSDT='" + TrDate + "' and TRANSNO = " + TransNo + "", lblLogDataMST);
            string logid1 = "DELETE";
            string tableid1 = "TRANSMST";
            LogDataFunction.InsertLogData(logid1, tableid1, lblLogDataMST.Text, iob.IpAddressInsert);
            // logdata add start //
        }

        public void TransMst_Log_Data_Update()
        {
            Yesbd.LogData.Interface.LogDataInterface iob = new LogData.Interface.LogDataInterface();

            iob.IpAddressInsert = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UserIdInsert = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPcInsert = DatabaseFunctions.UserPc();
            iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");
            Int64 TransNo;

            TransNo = Convert.ToInt64(btnEdit.Text == "NEW" ? ddlTransactionNoEdit.Text : txtTransactionNo.Text);

            // logdata add start //
            Label lblLogDataMST = new Label();
            DatabaseFunctions.lblAdd(@"SELECT ISNULL(CONVERT(NVARCHAR(20),TRANSDT),'NULL')+' '+TRANSMY+' '+ISNULL(CONVERT(NVARCHAR(20),TRANSNO),'NULL')+' '+ISNULL(INVOICENO,'NULL')+' '+ISNULL(CLIENTID,'NULL')
                                        +' '+ISNULL(CONVERT(NVARCHAR(20),TOTAMT),'NULL')+' '+ISNULL(REMARKS,'NULL')+' '+ISNULL(USERPC,'NULL')+' '+ USERID+' '+ISNULL(CONVERT(NVARCHAR(20),INTIME),'NULL')
                                        +' '+ISNULL(IPADDRESS,'NULL')+' '+ISNULL(UPDUSERPC,'NULL')+' '+ISNULL(UPDUSERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),UPDTIME),'NULL')+' '+ISNULL(UPDIPADDRESS,'NULL') FROM TRANSMST
                                        WHERE TRANSMY='" + lblMY.Text + "' and TRANSDT='" + TrDate + "' and TRANSNO = " + TransNo + "", lblLogDataMST);
            string logid1 = "UPDATE";
            string tableid1 = "TRANSMST";
            LogDataFunction.InsertLogData(logid1, tableid1, lblLogDataMST.Text, iob.IpAddressInsert);
            // logdata add start //
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            Datafield();

            if (btnEdit.Text == "EDIT")
            {
                iob.TransNo = Convert.ToInt64(txtTransactionNo.Text);

                TransMst_Log_Data_Update();

                dob.UpdateTransMstInfo(iob);

                Refresh();

                DatabaseFunctions.lblAdd(@"Select max(TRANSNO) FROM STK_TRANS where TRANSMY='" + lblMY.Text + "' and CLIENTID ='" + lblClientID.Text + "'", lblSMxNo);
                if (lblSMxNo.Text == "")
                {
                    txtTransactionNo.Text = "1";
                }
                else
                {
                    int iNo = int.Parse(lblSMxNo.Text);
                    int totIno = iNo + 1;
                    txtTransactionNo.Text = totIno.ToString();
                }

                GridShow();
                txtInvoiceNo.Focus();
            }
            else
            {
                iob.TransNo = Convert.ToInt64(ddlTransactionNoEdit.Text);
                if (ddlTransactionNoEdit.Text == "Select")
                {
                    lblGridMsg.Visible = true;
                    lblGridMsg.Text = "Select Transaction No.";
                }
                else
                {
                    lblGridMsg.Visible = false;

                    TransMst_Log_Data_Update();

                    dob.UpdateTransMstInfo(iob);

                    Refresh();

                    GridShow_Edit();
                    ddlTransactionNoEdit.Focus();
                }
            }

        }
    }
}