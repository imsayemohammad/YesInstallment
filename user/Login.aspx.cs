using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yesbd.user;

namespace Yesbd.user
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(DatabaseFunctions.connection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserName"] = null;
                Session["IpAddress"] = null;
                Session["PCName"] = null;
                Session["LoginType"] = null;
                txtUserName.Focus();
                FieldCheck();
                //loginButton.Focus();
            }

            //RegisterHyperLink.NavigateUrl = "Register.aspx";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}

        }

        public string FieldCheck()
        {
            string checkResult = "";
            if (txtUserName.Text == "")
            {
                checkResult = "Username/Email field is Required.";
                txtUserName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                checkResult = "Password field is required.";
                txtPassword.Focus();
            }
            else
            {
                checkResult = "true";
            }

            return checkResult;
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //    try

            //    {
            //    string uname = LoginUser.UserName.Trim(); //Get the username from the control
            //    string password = LoginUser.Password.Trim(); //get the Password from the control
            //    bool flag = AuthenticateUser(uname, password);
            //    if (flag == true)
            //    {
            //        e.Authenticated = true;
            //        Session["UserName"] = LoginUser.UserName;
            //        //LoginUser.DestinationPageUrl = "~/WebForm1.aspx";
            //        LoginUser.DestinationPageUrl = "~/Default.aspx";

            //    }
            //    else
            //        e.Authenticated = false;
            //}
            //catch (Exception)
            //{
            //    e.Authenticated = false;
            //}
            //DataTable table = new DataTable();
            //try
            //{
            //    LoginDataAccess dob = new LoginDataAccess();
            //    table = dob.showEmpLoginInfo();
            //    for (int i = 0; i < table.Rows.Count; i++)
            //    {
            //        if (LoginUser.UserName == table.Rows[i][0].ToString() && LoginUser.Password == "ss")// && table.Rows[i][1].ToString() != "Top")
            //        {
            //            Session["UserName"] = LoginUser.UserName;
            //            //Response.Redirect("~/WebForm1.aspx");
            //            Server.Transfer("~/WebForm1.aspx");
            //        }
            //        //if (Login1.UserName == table.Rows[i][0].ToString() && Login1.Password == "aa" && table.Rows[i][1].ToString() == "Top")
            //        //{
            //        //    Session["UserName"] = Login1.UserName;
            //        //    Response.Redirect("~/Login/UI/TopHome.aspx");
            //        //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.Message);
            //}
        }
        //private bool AuthenticateUser(string uname, string password)
        //{
        //    bool bflag = false;
        //    DataTable table = new DataTable();
        //    try
        //    {
        //        LoginDataAccess dob = new LoginDataAccess();
        //        table = dob.showEmpLoginInfo(uname, password);
        //        DataSet userDS = new DataSet();
        //    }
        //    catch (Exception ex)
        //    {
        //        table = null;
        //        Response.Write(ex.Message);
        //    }
        //    if (table != null)
        //    {
        //        if (table.Rows.Count > 0)
        //            bflag = true;
        //    }
        //    return bflag;
        //}

        private bool AuthenticateMember(string uname, string password)
        {
            bool bflag = false;
            DataTable table = new DataTable();
            try
            {
                LoginDataAccess dob = new LoginDataAccess();
                table = dob.showMemberLoginInfo(uname, password);
                DataSet userDS = new DataSet();
            }
            catch (Exception ex)
            {
                table = null;
                Response.Write(ex.Message);
            }
            if (table != null)
            {
                if (table.Rows.Count > 0)
                    bflag = true;
            }
            return bflag;
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUserName.Text.Trim();
                string pass = txtPassword.Text.Trim();
                bool flag = AuthenticateMember(user, pass);
                if (flag == true)
                {
                    //e.Authenticated = true;
                    Session["LoginType"] = lblLoginAs.Text;
                    Session["UserName"] = txtUserName.Text;
                    
                    string strHostName = System.Net.Dns.GetHostName();
                    IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    Session["PCName"] = strHostName;
                    Session["IpAddress"] = ipAddress;
                    //InsertLogOnHistory();

                    DatabaseFunctions.lblAdd("Select LOGINTP from EMPLOYEE where LOGINID='" + user + "'  and LOGINPW='" + pass + "'", lblTP);
                    Session["usertype"] = lblTP.Text;
                    if (lblTP.Text == "SAM")
                    {
                        Session["SAM"] = lblTP.Text;
                    }

                    DatabaseFunctions.lblAdd("Select EMPNM from EMPLOYEE where LOGINID='" + user + "'  and LOGINPW='" + pass + "'", lblFUllnm);
                    Session["fullnameUser"] = lblFUllnm.Text;

                    DatabaseFunctions.lblAdd("Select EMPSNM from EMPLOYEE where LOGINID='" + user + "'  and LOGINPW='" + pass + "'", lblEmpSurNM);
                    Session["surname"] = lblEmpSurNM.Text;

                    DatabaseFunctions.lblAdd("SELECT EMPID FROM EMPLOYEE WHERE LOGINID='" + user + "' AND LOGINPW ='" + pass + "'", lblempID);
                    Session["EmpID"] = lblempID.Text;

                    //DatabaseFunctions.lblAdd("SELECT MENUID FROM ROLE WHERE USERID='" + lblempID.Text + "'", lblMenuID);
                    //Session["MENUID"] = lblMenuID.Text;

                    ////DatabaseFunctions.lblAdd("SELECT MENUID FROM ROLE WHERE USERID='" + lblempID.Text + "' AND STATUS='A'", lblDynamicSTATUS);
                    ////Session["DYNAMIC_MENUID_CHCK"] = lblDynamicSTATUS.Text;

                    //DatabaseFunctions.lblAdd("SELECT STATUS FROM ROLE WHERE USERID='" + lblempID.Text + "' AND MENUID='" + lblMenuID.Text + "'", lblDynamicSTATUS);
                    //Session["DYNAMIC_STATUS_CHCK"] = lblDynamicSTATUS.Text;

                    DatabaseFunctions.lblAdd("Select STATUS from EMPLOYEE where LOGINID='" + user + "'  and LOGINPW='" + pass + "'", lblstUser);

                    if (lblstUser.Text == 'A'.ToString())
                    {
                        Response.Redirect("~/Home_default.aspx");
                        //string urllink = txtlink.Text;
                        //if (urllink != "")
                        //{
                        //    Response.Redirect(urllink);
                        //}
                        //else
                        //{
                        //    Response.Redirect("~/Home_default.aspx");
                        //}

                    }

                    else
                    {
                        lblmsg.Text = "You Are Not a Valid User";
                    }
                }

                else
                {
                    //bool flag = AuthenticateUser(user, pass);
                    //if (flag == true)
                    //{

                    //    Session["UserName"] = txtUserName.Text;
                    //    //Session["UserPC"] = Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName;
                    //    //string a = Session["UserPC"].ToString();

                    //    string strHostName = Dns.GetHostName();
                    //    IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                    //    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    //    Session["PCName"] = strHostName;
                    //    Session["IpAddress"] = ipAddress;
                    //    //InsertLogOnHistory();

                    //    Response.Redirect("~/Home.aspx");

                    //e.Authenticated = false;
                    lblmsg1.Text = "Wrong Username Password or Type Mismatch";
                }
            }


            catch (Exception)
            {
                //e.Authenticated = false;
            }
        }

        private void InsertLogOnHistory()
        {
            try
            {
                LoginDataAccess dob = new LoginDataAccess();
                string user = txtUserName.ToString();
                DateTime inTime = DateTime.Now;
                DateTime date = DateTime.Today;

                string IP = "";
                String strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] addlist = ipEntry.AddressList;
                try
                {
                    for (int i = 0; i < addlist.Length; i++)
                    {
                        IP = ipEntry.AddressList[i].ToString();// addlist[i].ToString;// ipEntry.AddressList[3].ToString();
                    }
                }
                catch { IP = "127.0.0.1"; }
                string _ip = IP;
                // String str = dob.InsertLogonHistory(user, inTime, strr, date, dom, IP);
                // MessageBox.Show(str);
            }
            catch (Exception er)
            {
                Page.Response.Write(er.Message);
            }
        }

    }
}