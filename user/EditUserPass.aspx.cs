using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yesbd;

namespace Yesbd.user
{
    public partial class EditUserPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                string formLink = "/user/EditUserPass.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        string id = HttpContext.Current.Session["UserName"].ToString();
                        txtuserID.Text = id;

                        string EmpID = HttpContext.Current.Session["EmpID"].ToString();

                        lblChkUserCD.Text = EmpID;
                        
                        //DatabaseFunctions.lblAdd("SELECT EMPID FROM EMPLOYEE where LOGINID='" + id + "' ", lblChkUserCD);
                        DatabaseFunctions.lblAdd("SELECT LOGINPW FROM EMPLOYEE WHERE LOGINID= '" + id + "' AND EMPID='" + lblChkUserCD.Text + "' ", lblOldpass);
                        txtOldpass.Focus();
                    }
                }
                else
                {
                    Response.Redirect("../../home_default.aspx");
                }
            }
        }

        protected void btnEditpass_Click(object sender, EventArgs e)
        {
            if (txtOldpass.Text == lblOldpass.Text)
            {
                if (txtnewpass.Text == txtnewpassconfirm.Text)
                {
                    Update();
                }
                else if (txtnewpass.Text != txtnewpassconfirm.Text)
                {
                    lblmsgpass.Text = "Password Mismatch";
                    txtnewpassconfirm.Focus();
                }
            }
            else if (txtOldpass.Text != lblOldpass.Text)
            {
                lblmsg.Text = "Wrong Password";
                txtOldpass.Focus();
            }
        }


        public void Update()
        {
            //if(txtnewpass.Text ==" ".ToString())
            //{
            //    txtnewpass.Text = txtOldpass.Text;
            //}
            //else if (txtnewpassconfirm.Text = " ".ToString())
            //{
            //    txtnewpass.Text = txtOldpass.Text;
            //}

            string s = "";
            SqlTransaction tran = null;
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
                SqlConnection con = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();

                tran = con.BeginTransaction();

                cmd.CommandType = System.Data.CommandType.Text;

                //cmd.CommandText = "UPDATE AS_USER SET USERPW=@USERPW WHERE  USERID= '" + txtuserID.Text + "' AND USERCD='" + lblChkUserCD.Text + "' AND USERPW='" + lblOldpass.Text + "'  ";

                cmd.CommandText = "UPDATE EMPLOYEE SET LOGINPW=@LOGINPW WHERE EMPID='" + lblChkUserCD.Text + "' AND LOGINID='" + txtuserID.Text + "' AND LOGINPW='" + lblOldpass.Text + "'";
                cmd.Parameters.Clear();

                cmd.Parameters.Add("@LOGINPW", SqlDbType.NVarChar).Value = txtnewpass.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();
                tran.Commit();
                con.Close();
            }

            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            Refresh();
        }

        public void Refresh()
        {
            txtOldpass.Text = "";
            txtnewpass.Text = "";
            txtnewpassconfirm.Text = "";
        }

        protected void txtnewpassconfirm_TextChanged(object sender, EventArgs e)
        {
            if (txtnewpassconfirm.Text != txtnewpass.Text)
            {
                lblmsgpass.Text = "PassWord Mismatch, Please Confirm Password";
            }
            else if (txtnewpassconfirm.Text == txtnewpass.Text)
            {
                lblmsgpass.Text = "";

            }
        }

        protected void txtOldpass_TextChanged(object sender, EventArgs e)
        {
            if (txtOldpass.Text != lblOldpass.Text)
            {
                lblmsg.Text = "Wrong Password";
                txtOldpass.Focus();
            }
            else if (txtOldpass.Text == lblOldpass.Text)
            {
                //lblerrmsg.Text = "";
                lblmsg.Text = "";
                txtnewpass.Focus();
            }
        }
    }
}