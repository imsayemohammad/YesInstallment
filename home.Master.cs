using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yesbd
{
    public partial class home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }

            else
            {
                if (!IsPostBack)
                {
                    loggeduser.Text = HttpContext.Current.Session["fullnameUser"].ToString();
                    DateTime DT = DatabaseFunctions.Timezone(DateTime.Now);
                    string date = DT.ToString("ddMMyy");
                    //string img = "";
                }
            }
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["LoginType"] = null;
            Session["usertype"] = null;
            Session["fullnameUser"] = null;
            Session["clientnm"] = null;
            Session["usercd"] = null;

            Response.Redirect("~/user/Login.aspx");

        }

        //public void DynamicPageUserCheck()
        //{
        //    string UserID = HttpContext.Current.Session["EmpID"].ToString();

        //    DatabaseFunctions.lblAdd("SELECT MENUID FROM ROLE WHERE USERID='" + UserID + "'", lblMenuID);
        //    Session["MENUID"] = lblMenuID.Text;

        //    DatabaseFunctions.lblAdd("SELECT STATUS FROM ROLE WHERE USERID='" + UserID + "' AND MENUID='" + lblMenuID.Text + "'", lblDynamicSTATUS);

        //    if (lblDynamicSTATUS.Text == 'A'.ToString())
        //    {
        //        Response.Redirect("~/Home_default.aspx");
        //    }

        //    else
        //    {
        //        Response.Redirect("~/user/Login.aspx");
        //        lblmsg.Text = "You aren't Permit for This Page";
        //    }
        //}
    }
}