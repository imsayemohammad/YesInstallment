using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Yesbd;
using Yesbd.Input_Portion;
using System.Data;

namespace Yesbd.Input_Portion
{
    public partial class EmpInfo : System.Web.UI.Page
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
                string formLink = "/Input_Portion/EmpInfo.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        itemID();
                        AdminChck();
                        txtEmpNM.Focus();

                        Sysdate();
                        lblPasswordNM.Visible = true;
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
            DateTime dt = DateTime.Now;
            string date = dt.ToString("dd/MM/yyyy");
            //txtJoinDT.Text = date;
            //string time = TraceModeValue.ToString("hh:mm:ss");
            //txtInTime.Text = String.Format("{0:t}", Now);
        }

        public void AdminChck()
        {
            string empid = HttpContext.Current.Session["EmpID"].ToString();
            string usertp = HttpContext.Current.Session["usertype"].ToString();
            lblMemberid.Text = empid;
            string check = empid.Substring(0, 5);
            if (check == "YES-M" && usertp == "ADMIN" || check == "YES-S")
            {
                btnReset.Visible = true;
                btnSubmit.Visible = true;
                btnEditNew.Visible = true;
                ddlLoginTP.Enabled = true;
                ddlStatus.Enabled = true;
                itemID();
            }
            else if (check == "YES-M" && usertp == "USER")
            {
                btnReset.Visible = true;
                btnSubmit.Visible = true;
                btnEditNew.Visible = true;
                ddlLoginTP.Enabled = false;
                ddlStatus.Enabled = false;
                //ddlLoginTP.Text = "USER";
                //ddlStatus.Text = "A";
            }
            else
            {
                btnReset.Visible = false;
                btnSubmit.Visible = false;
                btnEditNew.Visible = false;
            }
        }

        private void itemID()
        {
            DatabaseFunctions.lblAdd(@"SELECT MAX(EMPID) FROM EMPLOYEE WHERE EMPID LIKE 'YES-M%'", lblIMaxItemID);
            string ItemID;
            string mxCD, OItemID, mid, subItemCD;
            int subCD, incrItCD;

            if (lblIMaxItemID.Text == "")
            {
                ItemID = "YES-M001";
            }
            else
            {
                mxCD = lblIMaxItemID.Text;
                OItemID = mxCD.Substring(5, 3);
                subCD = int.Parse(OItemID);
                incrItCD = subCD + 1;
                if (incrItCD < 10)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "00" + mid;
                }
                else if (incrItCD < 100)
                {
                    mid = incrItCD.ToString();
                    subItemCD = "0" + mid;
                }

                else
                    subItemCD = incrItCD.ToString();
                ItemID = "YES-M" + subItemCD;
            }

            txtEmpID.Text = ItemID;
        }

        public void Datafield()
        {
            iob.UserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.ITime = DateTime.Now;

            //DateTime joindate = DateTime.Parse(txtJoinDT.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            //string JnDate = joindate.ToString("yyyy/MM/dd");
            //itemID();

            iob.EmpID = txtEmpID.Text;
            iob.SpNM = txtSpNM.Text;
            iob.FthrNM = txtFNM.Text;
            iob.MthrNM = txtMNM.Text;
            iob.PreAdd = txtPreAdd.Text;
            iob.PerAdd = txtPerAdd.Text;
            iob.TelNo = txtTelNo.Text;
            iob.MobileNO = txtPMbNo.Text;
            iob.Email = txtEmail.Text;
            iob.VoterID = txtVotrID.Text;
            iob.BloodGRP = txtBlGrp.Text;
            iob.MStatus = ddlMStatus.Text;
            iob.LoginTP = ddlLoginTP.Text;
            iob.LoginBY = ddlLoginBy.Text;
            iob.LoginID = txtLoginID.Text;
            iob.LoginPss = txtPasswrd.Text;
            iob.Remarks = txtRemrks.Text;
            iob.Status = ddlStatus.Text;
        }

        protected void Refresh()
        {
            //txtEmpID.Text = "";
            txtEmpNM.Text = "";
            txtSpNM.Text = "";
            txtFNM.Text = "";
            txtMNM.Text = "";
            txtPreAdd.Text = "";
            txtPerAdd.Text = "";
            txtTelNo.Text = "";
            txtPMbNo.Text = "";
            txtEmail.Text = "";
            txtVotrID.Text = "";
            txtBlGrp.Text = "";
            ddlMStatus.SelectedIndex = -1;
            ddlLoginTP.SelectedIndex = -1;
            ddlLoginBy.SelectedIndex = -1;
            txtLoginID.Text = "";
            txtPasswrd.Text = "";
            txtRemrks.Text = "";
            ddlStatus.SelectedIndex = -1;
        }

        protected void ddlMStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlMStatus.SelectedItem.Text == "SELECT")
            //{

            //    lblMSGERROR.Visible = true;
            //    lblMSGERROR.Text = "Please Select Marital Status";
            //    ddlMStatus.Focus();

            //}
            //else
            //{
            lblMSGERROR.Visible = false;
            //}
        }

        protected void ddlLoginTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoginBy.Focus();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSubmit.Focus();
        }

        protected void ddlLoginBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLoginBy.Text == "SELECT")
            {
                lblLoginByMSG.Visible = true;
                lblLoginByMSG.Text = "Please Select Login By";
                ddlLoginBy.Focus();
            }
            else if (ddlLoginBy.Text == "MOBILE")
            {
                lblLoginByMSG.Visible = false;
                txtLoginID.Text = txtPMbNo.Text;
                txtPasswrd.Focus();

            }
            else
            {
                lblLoginByMSG.Visible = false;
                txtLoginID.Text = txtEmail.Text;
                txtPasswrd.Focus();
            }
        }

        protected void txtTelNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTelNo.Text, "[^0-9]"))
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = "Insert a valid Phone number.";
                txtTelNo.Focus();
            }
            else
            {
                lblMSGError1.Visible = false;
                txtPMbNo.Focus();
            }
        }

        protected void txtPMbNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPMbNo.Text, "[^0-9]"))
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = "Insert a valid Mobile number like 017xxxxxxxx.";
                txtPMbNo.Focus();
            }
            else
            {
                lblCheck.Text = "";
                DatabaseFunctions.lblAdd("Select COUNT(MOBNO) AS MOBNO from EMPLOYEE WHERE MOBNO='" + txtPMbNo.Text + "'", lblCheck);
                if (lblCheck.Text == "0")
                {
                    lblMSGError1.Visible = false;
                    if (ddlLoginBy.Text == "MOBILE")
                    {
                        txtLoginID.Text = txtPMbNo.Text;
                    }
                    txtEmail.Focus();
                }
                else
                {
                    lblMSGError1.Visible = true;
                    lblMSGError1.Text = "This Mobile number Already Inserted.";
                    txtPMbNo.Focus();
                }
            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                lblCheck.Text = "";
                DatabaseFunctions.lblAdd("Select COUNT(EMAIL) AS EMAIL from EMPLOYEE WHERE EMAIL='" + txtEmail.Text + "'", lblCheck);
                if (lblCheck.Text == "0")
                {
                    lblMSGError1.Visible = false;
                    if (ddlLoginBy.Text == "EMAIL")
                    {
                        txtLoginID.Text = txtEmail.Text;
                    }
                    txtVotrID.Focus();
                }
                else
                {
                    lblMSGError1.Visible = true;
                    lblMSGError1.Text = "This Email ID Already Inserted.";
                    txtEmail.Focus();
                }
            }
            else
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = "Please Enter Valid Email ID.";
                txtEmail.Focus();
            }
        }

        public void menurule_insert()
        {
            conn.Open();
            string query = "";
            if (Session["USERTYPE"].ToString() == "SUPERADMIN")
                query = "SELECT MODULEID, MENUTP, MENUID FROM MENU WHERE MODULEID > '02'";
            else
                query = @"SELECT DISTINCT MENU.MODULEID, MENU.MENUTP, MENU.MENUID, ROLE.STATUS FROM  ROLE INNER JOIN
                        MENU ON ROLE.MODULEID = MENU.MODULEID AND ROLE.MENUID = MENU.MENUID AND ROLE.MENUTP = MENU.MENUTP INNER JOIN
                        MENUMST ON ROLE.MODULEID = MENUMST.MODULEID AND MENU.MODULEID = MENUMST.MODULEID INNER JOIN
                        EMPLOYEE ON ROLE.USERID = EMPLOYEE.EMPID WHERE ROLE.STATUS='A'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            foreach (var item in dr)
            {
                iob.ModuleId = dr["MODULEID"].ToString();
                iob.MenuType = dr["MENUTP"].ToString();
                iob.MenuId = dr["MENUID"].ToString();
                if (iob.OpType == "ADMIN")
                {
                    iob.Status = "A";
                    iob.InsertRole = "A";
                    iob.UpdateRole = "A";
                    iob.DeleteRole = "A";
                }
                else
                {
                    iob.Status = "A";
                    iob.InsertRole = "A";
                    iob.UpdateRole = "A";
                    iob.DeleteRole = "A";
                }

                dob.INSERT_ROLE(iob);

                lblMSGError1.Text = "User create Succefully.";
                lblMSGError1.Visible = true;
                lblMSGError1.ForeColor = Color.Green;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Datafield();
            iob.UpdUserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UPDUserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.UPDIpaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UpdTime = DatabaseFunctions.Timezone(DateTime.Now);

            if (btnEditNew.Text == "Edit")
            {
                lblCheckEmpNM.Text = "";
                DatabaseFunctions.lblAdd("Select COUNT(EMPNM) AS EMPNM from EMPLOYEE WHERE EMPNM='" + txtEmpNM.Text + "'", lblCheckEmpNM);
                if (lblCheckEmpNM.Text == "0")
                {
                    lblCheckMobile.Text = "";
                    DatabaseFunctions.lblAdd("Select COUNT(MOBNO) AS MOBNO from EMPLOYEE WHERE MOBNO='" + txtPMbNo.Text + "'", lblCheckMobile);
                    if (lblCheckMobile.Text == "0")
                    {
                        lblCheckEmail.Text = "";
                        DatabaseFunctions.lblAdd("Select COUNT(EMAIL) AS EMAIL from EMPLOYEE WHERE EMAIL='" + txtEmail.Text + "'", lblCheckEmail);
                        if (lblCheckEmail.Text == "0")
                        {
                            if (txtPasswrd.Text == "")
                            {
                                lblMSGError1.Visible = true;
                                lblMSGError1.Text = "Password should not be empty.";
                                lblMSGError1.ForeColor = Color.Red;
                                txtPasswrd.Focus();
                            }
                            else
                            {
                                iob.EmpNM = txtEmpNM.Text;
                                lblMSGError1.Visible = false;

                                dob.InsertEmpInfoEmp(iob);
                                menurule_insert();
                                Refresh();
                                itemID();
                            }
                        }
                        else
                        {
                            lblMSGError1.Visible = true;
                            lblMSGError1.Text = "This Email ID Already Inserted.";
                            lblMSGError1.ForeColor = Color.Red;
                            txtEmail.Focus();
                        }
                    }
                    else
                    {
                        lblMSGError1.Visible = true;
                        lblMSGError1.Text = "This Mobile number Already Inserted.";
                        lblMSGError1.ForeColor = Color.Red;
                        txtPMbNo.Focus();
                    }
                }
                else
                {
                    lblMSGError1.Visible = true;
                    lblMSGError1.Text = "This Member Name Already Inserted.";
                    lblMSGError1.ForeColor = Color.Red;
                    txtEmpNM.Focus();
                }
            }
            else if (btnEditNew.Text == "New")
            {
                iob.EmpNM = ddlEmpNM.Text;
                dob.UpdateEmpInfoEmp(iob);

                DataReturn();

                lblMSGError1.Text = "Succefully Updated.";
                lblMSGError1.Visible = true;
                lblMSGError1.ForeColor = Color.Green;
            }
            else
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = "Something went wrong.";
                lblMSGError1.ForeColor = Color.Red;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmpNM.ReadOnly = false;
            Refresh();
        }

        protected void btnEditNew_Click(object sender, EventArgs e)
        {
            //AdminChck();
            string usertp = HttpContext.Current.Session["usertype"].ToString();
            String empid = HttpContext.Current.Session["EmpID"].ToString();
            string check = empid.Substring(0, 5);
            if (check == "YES-M" || check == "YES-S")
            {
                if (btnEditNew.Text == "Edit")
                {
                    btnEditNew.Text = "New";
                    btnSubmit.Text = "Update";
                    //btnSubmit.Visible = true;
                    //btnReset.Visible = true;
                    txtEmpID.Text = "";
                    txtEmpNM.Text = "";
                    ddlEmpNM.Visible = true;
                    txtEmpNM.Visible = false;
                    ddlEmpNM.SelectedIndex = -1;
                    if (usertp == "ADMIN")
                    {
                        DatabaseFunctions.dropDownAddWithSelect(ddlEmpNM, "SELECT EMPNM FROM EMPLOYEE WHERE EMPID LIKE 'YES-M%'");
                        ddlLoginTP.Enabled = true;
                        ddlStatus.Enabled = true;
                    }
                    else
                    {
                        DatabaseFunctions.dropDownAddWithSelect(ddlEmpNM, "SELECT EMPNM FROM EMPLOYEE WHERE EMPID LIKE 'YES-M%' AND LOGINTP='USER'");
                        ddlLoginTP.Enabled = false;
                        ddlStatus.Enabled = false;
                    }
                    ddlEmpNM.Focus();
                    txtPasswrd.Visible = false;
                    lblPasswordNM.Visible = false;
                    lblMSGError1.Visible = false;
                    txtPMbNo.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    Refresh();
                }
                else
                {
                    btnEditNew.Text = "Edit";
                    btnSubmit.Text = "Submit";
                    //btnSubmit.Visible = false;
                    //btnReset.Visible = false;
                    ddlEmpNM.Visible = false;
                    txtEmpNM.Visible = true;
                    txtEmpNM.Focus();
                    txtPMbNo.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    txtPasswrd.Visible = true;
                    lblPasswordNM.Visible = true;
                    lblMSGError1.Visible = false;
                    if (usertp == "ADMIN")
                    {
                        ddlLoginTP.Enabled = true;
                        ddlStatus.Enabled = true;
                    }
                    else
                    {
                        ddlLoginTP.Enabled = false;
                        ddlStatus.Enabled = false;
                    }
                    Refresh();
                    itemID();
                }
            }
            else
            {
                btnEditNew.Visible = false;
            }
        }

        private void DataReturn()
        {
            SqlCommand cmd = new SqlCommand("Select * from EMPLOYEE Where EMPID='" + txtEmpID.Text + "'", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtEmpID.Text = reader["EMPID"].ToString();
                //txtEmpNM.Text = reader["EMPNM"].ToString();
                txtSpNM.Text = reader["EMPSNM"].ToString();
                txtFNM.Text = reader["FATHERNM"].ToString();
                txtMNM.Text = reader["MOTHERNM"].ToString();
                txtPreAdd.Text = reader["ADDRPRE"].ToString();
                txtPerAdd.Text = reader["ADDRPER"].ToString();
                txtTelNo.Text = reader["TELNO"].ToString();
                txtPMbNo.Text = reader["MOBNO"].ToString();
                txtEmail.Text = reader["EMAIL"].ToString();
                txtVotrID.Text = reader["VOTERID"].ToString();
                txtBlGrp.Text = reader["BLOODGR"].ToString();

                string mstatus = reader["MSTATUS"].ToString();
                ddlMStatus.Text = mstatus == "" ? "Single" : mstatus;

                DatabaseFunctions.lblAdd("Select LOGINTP from EMPLOYEE where EMPNM='" + ddlEmpNM.Text + "'", lbllogintp);
                if (lbllogintp.Text == "")
                {
                    ddlLoginTP.SelectedIndex = -1;
                }
                else
                {
                    ddlLoginTP.Text = lbllogintp.Text;
                }

                DatabaseFunctions.lblAdd("Select LOGINBY from EMPLOYEE where EMPNM='" + ddlEmpNM.Text + "'", lblloginby);
                //string loginby = reader["LOGINBY"].ToString();
                if (lblloginby.Text == "")
                {
                    ddlLoginBy.SelectedIndex = -1;
                }
                else
                {
                    ddlLoginBy.Text = lblloginby.Text;
                    if (ddlLoginBy.Text == "MOBILE")
                    {
                        txtPMbNo.ReadOnly = true;
                        txtEmail.ReadOnly = false;
                    }
                    else if (ddlLoginBy.Text == "EMAIL")
                    {
                        txtPMbNo.ReadOnly = false;
                        txtEmail.ReadOnly = true;
                    }
                    else
                    {
                        txtPMbNo.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                    }
                }
                txtLoginID.Text = reader["LOGINID"].ToString();
                txtPasswrd.Text = reader["LOGINPW"].ToString();
                txtRemrks.Text = reader["REMARKS"].ToString();
                ddlStatus.Text = reader["STATUS"].ToString();
            }
            reader.Close();
            conn.Close();
        }

        protected void txtEmpNM_TextChanged(object sender, EventArgs e)
        {
            if (btnEditNew.Text == "New")
            {
                if (txtEmpNM.Text == "")
                {
                    lblMSGError1.Enabled = true;
                    lblMSGError1.Text = "Please Select Member Name.";
                    txtEmpNM.Focus();
                }
                else
                {
                    lblMSGError1.Enabled = false;
                    DatabaseFunctions.txtAdd(@"Select EMPID from EMPLOYEE where EMPNM= '" + txtEmpNM.Text + "'", txtEmpID);
                    //Session["empID"] = null;
                    //Session["empID"] = txtEmpID.Text;
                    DatabaseFunctions.lblAdd(@"Select EMPNM from EMPLOYEE where EMPID= '" + txtEmpID.Text + "'", lblempNM);
                    if (txtEmpNM.Text == lblempNM.Text)
                    {
                        DataReturn();
                    }
                    else
                    {
                        txtSpNM.Focus();
                    }
                }
            }
            else
            {
                lblCheck.Text = "";
                DatabaseFunctions.lblAdd("Select COUNT(EMPNM) AS EMPNM from EMPLOYEE WHERE EMPNM='" + txtEmpNM.Text + "'", lblCheck);
                if (lblCheck.Text == "0")
                {
                    lblMSGError1.Visible = false;
                    txtSpNM.Focus();
                }
                else
                {
                    lblMSGError1.Visible = true;
                    lblMSGError1.Text = "This Member Name Already Inserted.";
                    txtEmpNM.Focus();
                }
            }
        }

        protected void ddlEmpNM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmpNM.Text == "Select" || ddlEmpNM.Text == "")
            {
                lblMSGError1.Enabled = true;
                lblMSGError1.Text = "Please Select Member Name.";
                ddlEmpNM.Focus();
            }
            else
            {
                lblMSGError1.Enabled = false;
                DatabaseFunctions.txtAdd(@"Select EMPID from EMPLOYEE where EMPNM= '" + ddlEmpNM.Text + "'", txtEmpID);

                DataReturn();
            }
        }

        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        //public static string[] GetCompletionListEmpNM(string prefixText, int count, string contextKey)
        //{
        //    string connection = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connection);

        //    SqlCommand cmd = new SqlCommand("Select EMPNM from EMPLOYEE where EMPNM LIKE '" + prefixText + "%'", conn);

        //    SqlDataReader oReader;
        //    conn.Open();
        //    List<String> CompletionSet = new List<string>();
        //    oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (oReader.Read())
        //        CompletionSet.Add(oReader["EMPNM"].ToString());
        //    return CompletionSet.ToArray();
        //}
    }
}