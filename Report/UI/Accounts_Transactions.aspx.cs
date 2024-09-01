using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yesbd.Report.UI
{
    public partial class Accounts_Transactions : System.Web.UI.Page
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }

            else
            {
                string formLink = "/Report/UI/Accounts_Transactions.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        //DatabaseFunctions.dropDownAddWithSelect(ddlClientNM, "SELECT DISTINCT CLIENTNM FROM CLIENT");
                        txtFrom.Text = DatabaseFunctions.Dayformat1(DateTime.Now).ToString("dd/MM/yyyy");
                        txtTo.Text = DatabaseFunctions.Dayformat1(DateTime.Now).ToString("dd/MM/yyyy");
                        txtClientNM.Focus();
                    }
                }
                else
                {
                    Response.Redirect("../../home_default.aspx");
                }
            }
        }

        //protected void ddlClientNM_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlClientNM.Text == "" || ddlClientNM.Text == "Select")
        //    {
        //        lblErrorMSG.Visible = true;
        //        lblErrorMSG.Text = "Select Customer Name.";
        //        ddlClientNM.Focus();
        //    }
        //    else
        //    {
        //        lblErrorMSG.Visible = false;
        //        DatabaseFunctions.lblAdd(@"SELECT CLIENTID FROM CLIENT WHERE CLIENTNM ='" + ddlClientNM.Text + "'", lblClientID);
        //    }

        //    btnSearch.Focus();
        //}

        protected void txtClientNM_TextChanged(object sender, EventArgs e)
        {
            DatabaseFunctions.lblAdd(@"SELECT CLIENTID FROM CLIENT WHERE CLIENTNM ='" + txtClientNM.Text + "'", lblClientID);
            btnSearch.Focus();
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

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Focus();
        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime FrDT = DateTime.Parse(txtFrom.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            DateTime ToDT = DateTime.Parse(txtTo.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);

            if (txtClientNM.Text == "" || lblClientID.Text == "")
            {
                lblErrorMSG.Visible = true;
                lblErrorMSG.Text = "Select Customer Name.";
                txtClientNM.Focus();
            }
            else if (FrDT > ToDT)
            {
                //Response.Write("<script>alert('From Date is Greater than To Date.');</script>");
                lblErrorMSG.Visible = true;
                lblErrorMSG.Text = "From Date is Greater than To Date.";
            }
            else
            {
                Session["CLIENTNM"] = txtClientNM.Text;
                Session["CLIENTID"] = lblClientID.Text;
                Session["FROM"] = txtFrom.Text;
                Session["TO"] = txtTo.Text;

                ScriptManager.RegisterStartupScript(this,
                              this.GetType(), "OpenWindow", "window.open('../print/Rpt_Accounts_Transactions.aspx','_newtab');", true);

                //Page.ClientScript.RegisterStartupScript(
                //    this.GetType(), "OpenWindow", "window.open('../print/Rpt_Accounts_Transactions.aspx','_newtab');", true);
            }
        }
    }
}