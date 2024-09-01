using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yesbd.Report.print
{
    public partial class Rpt_ClientInfo : System.Web.UI.Page
    {
        SqlConnection _conn = new SqlConnection(DatabaseFunctions.connection);
        private IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);

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
                    Response.Redirect("../../Input_Portion/ClientInfo.aspx");
                }
                else
                {
                    lblClientID.Text = Session["CLIENTID"].ToString();

                    LoadCompanyMotto();
                    LoadClientInfo();
                }
            }
        }


        public void LoadCompanyMotto()
        {
            //var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Yes_bd"].ToString());
            _conn.Open();

            var selectString = "SELECT * FROM COMPANY";
            var cmd = new SqlCommand(selectString, _conn);
            cmd.Parameters.Clear();
            //cmd.Parameters.Add("cEmployeeId", SqlDbType.VarChar, 50).Value = empid;

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lblCompanyName.Text = reader["COMPNM"].ToString();
                lblCompanyMotto.Text = reader["COMPMOTTO"].ToString();
                lblMotto.Text = reader["MOTTO"].ToString();
                lblCompanyAddress.Text = reader["ADDRESS"].ToString();
            }
            reader.Close();
            _conn.Close();
        }

        public void LoadClientInfo()
        {
            //var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Yes_bd"].ToString());
            _conn.Open();

            var selectString = "SELECT CLIENTNM, CONVERT(NVARCHAR(10),TRANSDT,103) AS TRANSDT, INVREFNO, LOANDURATION, CLIENTAGE, " +
                               "FATHERNM, MOTHERNM, SPOUSENM, GIRL, BOY, NOMINEENM, RELATION, HOUSE, WARD, VILLAGE, TOWNSHIP, POLICESTAT, " +
                               "DISTRICT, TELNO, MOBNO, CONTACTADD, MONTHLYRENT, DUEAMOUNT, POSTOFFICE, MOBNO_HOME, CLIENTACCNO, CLIENTPAYABLE, CLIENTTYPE, " +
                               "PREACCNO, VEHICLENO, VEHICLETYPE, LOANAMOUNT, LOANAMOUNT_INWARDS, MONTHLYRENT, MONTHLYRENT_INWARDS, DUEAMOUNT, DUEAMOUNT_INWARDS, COMPANYPAYABLE, COMPANYPAYABLE_INWARDS," +
                               "MONTHLYINSTALLMENT, MONTHLYINSTALLMENT_INWARDS, CLIENTPAYABLE, CLIENTPAYABLE_INWARDS, IMGNOMINEE, IMGCLIENT, CONVERT(NVARCHAR(10),DUEDATE,103) AS DUEDATE, " +
                               "CONVERT(NVARCHAR(10),DATEADD(year, 1, TRANSDT),103) AS PAYMENTDUEDATE FROM CLIENT WHERE CLIENTID=@CLIENTID";
            var cmd = new SqlCommand(selectString, _conn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("CLIENTID", SqlDbType.NVarChar, 100).Value = lblClientID.Text;

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                lblClientNM.Text = reader["CLIENTNM"].ToString();
                lblDate.Text = reader["TRANSDT"].ToString();
                lblInvoiceno.Text = reader["INVREFNO"].ToString();
                lblLoanDuration.Text = reader["LOANDURATION"].ToString();
                lblLoanAmount.Text = reader["LOANAMOUNT"].ToString();
                lblClientAge.Text = reader["CLIENTAGE"].ToString();
                lblFatherNM.Text = reader["FATHERNM"].ToString();
                lblMotherNM.Text = reader["MOTHERNM"].ToString();
                lblSpouse.Text = reader["SPOUSENM"].ToString();
                lblGirl.Text = reader["GIRL"].ToString();
                lblBoy.Text = reader["BOY"].ToString();
                lblNominee.Text = reader["NOMINEENM"].ToString();
                lblRelation.Text = reader["RELATION"].ToString();
                lblHouse.Text = reader["HOUSE"].ToString();
                lblWard.Text = reader["WARD"].ToString();
                lblVillage.Text = reader["VILLAGE"].ToString();
                lblTownship.Text = reader["TOWNSHIP"].ToString();
                lblPoliceS.Text = reader["POLICESTAT"].ToString();
                lblDistrict.Text = reader["DISTRICT"].ToString();
                lblTelNo.Text = reader["TELNO"].ToString();
                lblMobile.Text = reader["MOBNO"].ToString();
                lblContactAdd.Text = reader["CONTACTADD"].ToString();
                lblimgnominee.Text = reader["IMGNOMINEE"].ToString();
                lblimgclient.Text = reader["IMGCLIENT"].ToString();

                lblClientType.Text = reader["CLIENTTYPE"].ToString();
                lblMonthlyRent.Text = reader["MONTHLYRENT"].ToString();
                lblDueAmount.Text = reader["DUEAMOUNT"].ToString();
                lblCompanyPayable.Text = reader["COMPANYPAYABLE"].ToString();
                lblClientPayable.Text = reader["CLIENTPAYABLE"].ToString();
                lblClientAccNo.Text = string.IsNullOrEmpty(reader["CLIENTACCNO"].ToString()) ? "........................." : reader["CLIENTACCNO"].ToString();
                lblPostOffice.Text = reader["POSTOFFICE"].ToString();
                lblMobileHome.Text = reader["MOBNO_HOME"].ToString();
                lblVehicleType.Text = reader["VEHICLETYPE"].ToString();
                lblVehicleNo.Text = reader["VEHICLENO"].ToString();
                lblPreAccNo.Text = reader["PREACCNO"].ToString();
                lblClientDueDate.Text = reader["DUEDATE"].ToString() == "01/01/1900" ? "" : reader["DUEDATE"].ToString();


                var loanAmt = SpellAmount.comma(Convert.ToDecimal(reader["LOANAMOUNT"].ToString()));
                var loanAmt_inwards = string.IsNullOrEmpty(reader["LOANAMOUNT_INWARDS"].ToString()) ? "" : '(' + reader["LOANAMOUNT_INWARDS"].ToString() + ')';
                //var loanAmt_inwards = string.IsNullOrEmpty(reader["LOANAMOUNT"].ToString()) ? "" : "( " + SpellAmountBangla.MoneyConvFn(reader["LOANAMOUNT"].ToString()) + ")";

                var loanduration = reader["LOANDURATION"].ToString();
                var loandurationwithinstallment = string.IsNullOrEmpty(reader["MONTHLYINSTALLMENT"].ToString()) ? "" : "( " + reader["MONTHLYINSTALLMENT"].ToString() + ")";

                var dueamt = SpellAmount.comma(Convert.ToDecimal(reader["DUEAMOUNT"].ToString()));
                var dueamt_inwards = string.IsNullOrEmpty(reader["DUEAMOUNT_INWARDS"].ToString()) ? "" : '(' + reader["DUEAMOUNT_INWARDS"].ToString() + ')';
                //var dueamt_inwards = string.IsNullOrEmpty(reader["DUEAMOUNT"].ToString()) ? "" : "( " + SpellAmountBangla.MoneyConvFn(reader["DUEAMOUNT"].ToString()) + ")";
                
                var installment_amt =  reader["MONTHLYINSTALLMENT"].ToString();
                

                //var firstpart = "";
                //var secondpart = "";
                //var strValue = installment_amt;
                //var lastIndex = strValue.IndexOf(" ");
                //if (lastIndex >= 0)
                //{
                //    firstpart = strValue.Substring(0, strValue.IndexOf(" "));
                //    secondpart = strValue.Substring(strValue.IndexOf(" ") + 1);
                //    if (secondpart == "")
                //    {
                //        secondpart = firstpart;
                //    }

                //}
                //else
                //{
                //    firstpart = strValue.Replace(" ", "");
                //    secondpart = strValue.Replace(" ", "");
                //}

                //var replacevalue = installment_amt.Replace(",", " + ").Replace(" ", " + ");
                //var a = decimal.Parse(replacevalue, CultureInfo.InvariantCulture);
                //var a =  Convert.ToDecimal(firstpart);
                //var b =  Convert.ToDecimal(secondpart);
                //var totalV = a + b;
                //var arepvalue = Regex.Replace(installment_amt, "[, ]", " "); 


                var installment_amt_inwards = string.IsNullOrEmpty(reader["MONTHLYINSTALLMENT"].ToString()) ? "" : reader["MONTHLYINSTALLMENT_INWARDS"].ToString();
                //var installment_amt_inwards = string.IsNullOrEmpty(reader["MONTHLYINSTALLMENT"].ToString()) ? "" : '(' + reader["MONTHLYINSTALLMENT_INWARDS"].ToString() + ')';
                //var installment_amt = SpellAmount.comma(System.Math.Round(Convert.ToDecimal(reader["MONTHLYINSTALLMENT"].ToString()), 2));
                //var installment_amt_inwards = string.IsNullOrEmpty(reader["INSTALLMENTAMT"].ToString()) ? "" : "( " + SpellAmountBangla.MoneyConvFn(reader["INSTALLMENTAMT"].ToString()) + ")";

                if (string.IsNullOrEmpty(lblClientDueDate.Text))
                {
                    lblLoanAmountwithInwards.Text = loanAmt + ' ' + loanAmt_inwards;
                    lblLoanDuration_with_Installments.Text = loanduration + ' ' + loandurationwithinstallment;
                    lblPaymentDueDate.Text = reader["PAYMENTDUEDATE"].ToString();
                }
                else
                {
                    lblLoanAmountwithInwards2.Text = loanAmt + ' ' + loanAmt_inwards;
                    lblLoanDuration_with_InstallmentsAmt.Text = installment_amt_inwards;
                    //lblLoanDuration_with_InstallmentsAmt.Text = installment_amt + ' ' + installment_amt_inwards;
                    lblLoanDuration_with_Installments2.Text = loanduration + ' ' + loandurationwithinstallment;
                    lblPaymentDueDate2.Text = reader["PAYMENTDUEDATE"].ToString();
                    lblDueAmount_with_Wards.Text = dueamt + ' ' + dueamt_inwards;
                    lblDueAmount_with_Wards2.Text = dueamt + ' ' + dueamt_inwards;
                }

                string imgN = lblimgnominee.Text;
                ImgNominee.ImageUrl = "~/uploaded_files/" + imgN;

                string imgC = lblimgclient.Text;
                ImgClient.ImageUrl = "~/uploaded_files/" + imgC;


                //string[] files1 = Directory.GetFiles(@"D:\Backup\My Document's\Project\Personal\Yesbd\Yesbd\uploaded_files\", lblClientID.Text + "-Nominee" + ".*");
                //foreach (string imgN in files1)
                //{
                //    ImgNominee.ImageUrl = imgN;
                //}

                //string[] files2 = Directory.GetFiles(@"D:\Backup\My Document's\Project\Personal\Yesbd\Yesbd\uploaded_files\", lblClientID.Text + "-Client" + ".*");
                //foreach (string imgC in files2)
                //{
                //    ImgClient.ImageUrl = imgC;
                //}

                //DatabaseFunctions.lblAdd(@"SELECT CLIENTNM FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblClientNM);
                //DatabaseFunctions.lblAdd(@"SELECT CONVERT(NVARCHAR(10),TRANSDT,103) AS TRANSDT FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblDate);
                //DatabaseFunctions.lblAdd(@"SELECT INVREFNO FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblInvoiceno);
                //DatabaseFunctions.lblAdd(@"SELECT LOANDURATION FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblLoanDuration);
                //DatabaseFunctions.lblAdd(@"SELECT LOANAMOUNT FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblLoanAmount);
                //DatabaseFunctions.lblAdd(@"SELECT CLIENTAGE FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblClientAge);
                //DatabaseFunctions.lblAdd(@"SELECT FATHERNM FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblFatherNM);
                //DatabaseFunctions.lblAdd(@"SELECT MOTHERNM FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblMotherNM);
                //DatabaseFunctions.lblAdd(@"SELECT SPOUSENM FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblSpouse);
                //DatabaseFunctions.lblAdd(@"SELECT GIRL FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblGirl);
                //DatabaseFunctions.lblAdd(@"SELECT BOY FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblBoy);
                //DatabaseFunctions.lblAdd(@"SELECT NOMINEENM FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblNominee);
                //DatabaseFunctions.lblAdd(@"SELECT RELATION FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblRelation);
                //DatabaseFunctions.lblAdd(@"SELECT HOUSE FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblHouse);
                //DatabaseFunctions.lblAdd(@"SELECT WARD FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblWard);
                //DatabaseFunctions.lblAdd(@"SELECT VILLAGE FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblVillage);
                //DatabaseFunctions.lblAdd(@"SELECT TOWNSHIP FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblTownship);
                //DatabaseFunctions.lblAdd(@"SELECT POLICESTAT FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblPoliceS);
                //DatabaseFunctions.lblAdd(@"SELECT DISTRICT FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblDistrict);
                //DatabaseFunctions.lblAdd(@"SELECT TELNO FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblTelNo);
                //DatabaseFunctions.lblAdd(@"SELECT MOBNO FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblMobile);
                //DatabaseFunctions.lblAdd(@"SELECT CONTACTADD FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblContactAdd);

                //DatabaseFunctions.lblAdd(@"SELECT IMGNOMINEE FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblimgnominee);
                //DatabaseFunctions.lblAdd(@"SELECT IMGCLIENT FROM CLIENT WHERE CLIENTID= '" + lblClientID.Text + "'", lblimgclient);


            }
            reader.Close();
            _conn.Close();
        }
    }
}