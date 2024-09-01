using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yesbd.Report.UI
{
    public partial class Accounts_Trans_Summary : System.Web.UI.Page
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
                string formLink = "/Report/UI/Accounts_Trans_Summary.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        txtFrom.Text = DatabaseFunctions.Dayformat1(DateTime.Now).ToString("dd/MM/yyyy");
                        txtTo.Text = DatabaseFunctions.Dayformat1(DateTime.Now).ToString("dd/MM/yyyy");
                    }
                }
                else
                {
                    Response.Redirect("../../home_default.aspx");
                }
            }
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

            if (FrDT > ToDT)
            {
                //Response.Write("<script>alert('From Date is Greater than To Date.');</script>");
                lblErrorMSG.Visible = true;
                lblErrorMSG.Text = "From Date is Greater than To Date.";
            }
            else
            {
                Session["FROM"] = txtFrom.Text;
                Session["TO"] = txtTo.Text;

                ScriptManager.RegisterStartupScript(this,
                              this.GetType(), "OpenWindow", "window.open('../print/Rpt_Accounts_Trans_Summary.aspx','_newtab');", true);

                //Page.ClientScript.RegisterStartupScript(
                //    this.GetType(), "OpenWindow", "window.open('../print/Rpt_Accounts_Transactions.aspx','_newtab');", true);
            }
        }
    }
}