using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class ClientInfo : System.Web.UI.Page
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
                string formLink = "/Input_Portion/ClientInfo.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        if (Request.QueryString.Keys.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(Request.QueryString["cid"].ToString()))
                            {
                                btnEditNew_Click(sender, e);
                            }
                        }
                        else
                        {
                            Sysdate();
                            Invoice_id();
                            ClientSerial_id();
                            AdminChck();
                            txtClientNM.Focus();
                            ddlClientNM.Visible = false;
                        }
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

        public void AdminChck()
        {
            string empid = HttpContext.Current.Session["EmpID"].ToString();
            string usertp = HttpContext.Current.Session["usertype"].ToString();
            string check = empid.Substring(0, 5);
            //if (check == "YES-M" && usertp == "ADMIN" || check == "YES-S")
            if (check == "YES-M" || check == "YES-S")
            {
                btnReset.Visible = true;
                btnSubmit.Visible = true;
                btnEditNew.Visible = true;
                btnsave_print.Visible = true;
            }
            //else if (check == "YES-M" && usertp == "USER")
            //{
            //    btnReset.Visible = false;
            //    btnSubmit.Visible = false;
            //    btnsave_print.Visible = false;
            //    btnEditNew.Visible = true;
            //}
            else
            {
                btnReset.Visible = false;
                btnSubmit.Visible = false;
                btnEditNew.Visible = false;
                btnsave_print.Visible = false;
            }
        }

        protected void ClientSerial_id()
        {
            DateTime projectdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = projectdate.ToString("yyyy/MM/dd");

            string year = projectdate.ToString("yy");
            string month = projectdate.ToString("MM");
            string day = projectdate.ToString("dd");

            string subprojctno = "";
            int subintprojctno = 0;
            string subno = "";
            int maxprojctid = 0;

            DatabaseFunctions.lblAdd(@"SELECT max(CLIENTID) FROM CLIENT WHERE TRANSDT='" + TrDate + "'", lblMaxCleintID);

            string projctid = "";

            if (lblMaxCleintID.Text == "")
            {
                projctid = "YES-CL-" + day + month + year + "001";
            }
            else
            {
                subprojctno = lblMaxCleintID.Text.Substring(13, 3);
                subintprojctno = int.Parse(subprojctno);
                maxprojctid = subintprojctno + 1;
                if (maxprojctid < 10)
                {
                    projctid = "YES-CL-" + day + month + year + "00" + maxprojctid;
                }
                else if (maxprojctid < 100)
                {
                    projctid = "YES-CL-" + day + month + year + "0" + maxprojctid;
                }
                else
                {
                    projctid = "YES-CL-" + day + month + year + maxprojctid;
                }
            }

            txtClientID.Text = projctid;
        }


        private void Invoice_id()
        {
            DateTime projectdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string trDate = projectdate.ToString("yyyy/MM/dd");

            string year = projectdate.ToString("yy");
            string month = projectdate.ToString("MM");
            string day = projectdate.ToString("dd");

            string subprojctno = "";
            int subintprojctno = 0;
            string subno = "";
            int maxprojctid = 0;

            //string var = day + month + year;
            string projctid = "";
            lblMaxInvoice.Text = "";

            DatabaseFunctions.lblAdd(@"SELECT max(INVREFNO) FROM CLIENT WHERE TRANSDT='" + trDate + "'", lblMaxInvoice);

            projctid = lblMaxInvoice.Text;

            if (projctid == "")
            {
                projctid = "YES-" + day + month + year + "01";
                txtInvoiceNo.Text = projctid;
            }
            else
            {
                //string Subid = lblMaxInvoice.Text.Substring(4, 2);
                subprojctno = projctid.Substring(10, 2);
                subintprojctno = int.Parse(subprojctno);
                maxprojctid = subintprojctno + 1;
                if (maxprojctid < 10)
                {
                    projctid = "YES-" + day + month + year + "0" + maxprojctid;
                }

                else
                {
                    projctid = "YES-" + day + month + year + maxprojctid;
                }

            }
            txtInvoiceNo.Text = projctid;
        }

        protected void Refresh()
        {
            //txtDate.Text = "";
            //txtClientID.Text = "";
            //txtInvoiceNo.Text = "";
            txtClientNM.Text = "";
            ddlClientNM.SelectedIndex = -1;
            txtLoanDuration.Text = "";
            txtLoanAmount.Text = "";
            txtAge.Text = "";
            txtFNM.Text = "";
            txtMNM.Text = "";
            txtSpouse.Text = "";
            txtBoy.Text = "";
            txtGirl.Text = "";
            txtNominee.Text = "";
            txtRelation.Text = "";
            txtHouse.Text = "";
            txtWard.Text = "";
            txtVillage.Text = "";
            txtTownship.Text = "";
            txtPoliceS.Text = "";
            txtDistrict.Text = "";
            txtTelNo.Text = "";
            txtPMbNo.Text = "";
            txtContactAdd.Text = "";
            ddlStatus.SelectedIndex = -1;

            txtMonthlyInstallment_Inwards.Text = "";
            txtMonthlyRent_Inwards.Text = "";
            txtLoanAmount_Inwards.Text = "";
            txtDueAmt_Inwards.Text = "";
            txtClientPayable_Inwards.Text = "";
            txtCompnayPayable.Text = "";
            txtCompnayPayable_Inwards.Text = "";

            txtClientAccNo.Text = "";
            txtDueDate.Text = "";
            txtMonthlyInstallment.Text = "";
            txtMonthlyRent.Text = "";
            txtDueAmt.Text = "";
            txtClientPayable.Text = "";
            txtPostOffice.Text = "";
            txtMob_Home.Text = "";
            ddlClientType.SelectedIndex = -1;
            ddlVehicleType.SelectedIndex = -1;
            txtVehicleNo.Text = "";
            txtOldPreAccNo.Text = "";
            //DivForOld.Visible = false;
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            DateTime transdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string TrDate = transdate.ToString("yyyy/MM/dd");

            if (btnEditNew.Text == "Edit")
            {
                Invoice_id();
                ClientSerial_id();
            }

            txtLoanDuration.Focus();
        }

        protected void txtDueDate_TextChanged(object sender, EventArgs e)
        {
            //DateTime transdate = DateTime.Parse(txtDueDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            //string TrDueDate = transdate.ToString("yyyy/MM/dd");

            ddlClientType.Focus();
        }

        protected void txtLoanDuration_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLoanDuration.Text, "[^0-9]"))
            {
                lblMSGError2.Visible = true;
                lblMSGError2.Text = ("Insert Numeric Value (0-9).");
                txtLoanDuration.Text = "";
                txtLoanDuration.Focus();
            }
            else
            {
                lblMSGError2.Visible = false;
                txtDueDate.Focus();
            }
        }

        protected void txtMonthlyInstallment_TextChanged(object sender, EventArgs e)
        {
            lblMSGError2.Visible = false;
            txtMonthlyInstallment_Inwards.Focus();

            //if (System.Text.RegularExpressions.Regex.IsMatch(txtMonthlyInstallment.Text, @"((\d+)((\.\d{1,2})?))$"))
            //{
            //    lblMSGError2.Visible = false;
            //    txtMonthlyInstallment_Inwards.Focus();
            //}
            //else
            //{
            //    lblMSGError2.Visible = true;
            //    lblMSGError2.Text = ("Insert Decimal Value (0-9).");
            //    txtMonthlyInstallment.Text = "";
            //    txtMonthlyInstallment.Focus();
            //}
        }

        protected void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLoanAmount.Text, @"((\d+)((\.\d{1,2})?))$"))
            {
                lblMSGError2.Visible = false;
                txtLoanAmount_Inwards.Focus();
            }
            else
            {
                lblMSGError2.Visible = true;
                lblMSGError2.Text = ("Insert Decimal Value (0-9).");
                txtLoanAmount.Text = "";
                txtLoanAmount.Focus();
            }
        }
        protected void txtCompnayPayable_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCompnayPayable.Text, @"((\d+)((\.\d{1,2})?))$"))
            {
                lblMSGError2.Visible = false;
                txtCompnayPayable_Inwards.Focus();
            }
            else
            {
                lblMSGError2.Visible = true;
                lblMSGError2.Text = ("Insert Decimal Value (0-9).");
                txtCompnayPayable.Text = "";
                txtCompnayPayable.Focus();
            }
        }
        protected void txtClientPayable_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtClientPayable.Text, @"((\d+)((\.\d{1,2})?))$"))
            {
                lblMSGError2.Visible = false;
                txtClientPayable_Inwards.Focus();
            }
            else
            {
                lblMSGError2.Visible = true;
                lblMSGError2.Text = ("Insert Decimal Value (0-9).");
                txtClientPayable.Text = "";
                txtClientPayable.Focus();
            }
        }
        protected void txtDueAmt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDueAmt.Text, @"((\d+)((\.\d{1,2})?))$"))
            {
                lblMSGError2.Visible = false;
                txtDueAmt_Inwards.Focus();
            }
            else
            {
                lblMSGError2.Visible = true;
                lblMSGError2.Text = ("Insert Decimal Value (0-9).");
                txtDueAmt.Text = "";
                txtDueAmt.Focus();
            }
        }
        protected void txtMonthlyRent_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMonthlyRent.Text, @"((\d+)((\.\d{1,2})?))$"))
            {
                lblMSGError2.Visible = false;
                txtMonthlyRent_Inwards.Focus();
            }
            else
            {
                lblMSGError2.Visible = true;
                lblMSGError2.Text = ("Insert Decimal Value (0-9).");
                txtMonthlyRent.Text = "";
                txtMonthlyRent.Focus();
            }
        }

        protected void ddlLoanStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (btnEditNew.Text == "Edit")
            //{
            //    txtClientNM.Focus();
            //}
            //else
            //{
            //    ddlClientNM.Focus();
            //}
            txtMonthlyRent.Focus();
        }

        protected void ddlClientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnEditNew.Text == "Edit")
            {
                txtClientNM.Focus();
            }
            else
            {
                ddlClientNM.Focus();
            }

            //DivForOld.Visible = ddlClientType.SelectedValue == "OLD";
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSubmit.Focus();
        }

        protected void Inser_Images()
        {
            string filenameominee = "";
            iob.filenameominee = "";
            if (FileUpload_Nominee.HasFile)
            {
                string filename = FileUpload_Nominee.FileName;
                string exten = Path.GetExtension(filename);
                exten.ToLower();
                string[] acceptedFiletype = new string[3];

                acceptedFiletype[0] = ".jpg";

                acceptedFiletype[1] = ".jpeg";

                acceptedFiletype[2] = ".png";

                bool acceptFile = false;
                for (int i = 0; i <= 2; i++)
                {

                    if (exten == acceptedFiletype[i])
                    {
                        acceptFile = true;
                    }
                }

                if (!acceptFile)
                {
                    lblUpLoadMSG.Visible = true;
                    lblUpLoadMSG.Text = "The file you are trying to upload is not a permitted file type!";
                }

                else
                {
                    iob.filenameominee = iob.ClientID + "-Nominee" + exten;

                    FileUpload_Nominee.SaveAs(HttpContext.Current.Server.MapPath("~/uploaded_files/" + iob.filenameominee));

                    lblUpLoadMSG.Visible = true;
                    lblUpLoadMSG.Text = "Image Successfully Uploaded!";
                }
            }

            string filenameclient = "";
            iob.filenameclient = "";
            if (FileUpload_Client.HasFile)
            {
                string filename = FileUpload_Client.FileName;
                string exten = Path.GetExtension(filename);
                exten.ToLower();
                string[] acceptedFiletype = new string[3];

                acceptedFiletype[0] = ".jpg";

                acceptedFiletype[1] = ".jpeg";

                acceptedFiletype[2] = ".png";

                bool acceptFile = false;
                for (int i = 0; i <= 2; i++)
                {

                    if (exten == acceptedFiletype[i])
                    {
                        acceptFile = true;
                    }
                }

                if (!acceptFile)
                {
                    lblUpLoadMSG.Visible = true;
                    lblUpLoadMSG.Text = "The file you are trying to upload is not a permitted file type!";
                }

                else
                {
                    iob.filenameclient = iob.ClientID + "-Client" + exten;

                    FileUpload_Client.SaveAs(HttpContext.Current.Server.MapPath("~/uploaded_files/" + iob.filenameclient));



                    lblUpLoadMSG.Visible = true;
                    lblUpLoadMSG.Text = "Image Successfully Uploaded!";
                }
            }
        }

        public void Datafield()
        {
            iob.UserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.ITime = DatabaseFunctions.Timezone(DateTime.Now);

            //ClientSerial_id();

            iob.Date = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            iob.Loanduration = txtLoanDuration.Text;
            decimal loanamt = 0;
            loanamt = txtLoanAmount.Text == "" ? 0 : Convert.ToDecimal(txtLoanAmount.Text);
            iob.LoandAmount = loanamt;
            iob.LoanStatus = ddlLoanStatus.Text;
            iob.invoiceno = txtInvoiceNo.Text;
            iob.ClientID = txtClientID.Text;
            //iob.Clientage = Convert.ToInt16(txtAge.Text);
            iob.Clientage = txtAge.Text;
            iob.FthrNM = txtFNM.Text;
            iob.MthrNM = txtMNM.Text;
            iob.SpNM = txtSpouse.Text;
            iob.Boy = txtBoy.Text;
            iob.Girl = txtGirl.Text;
            iob.Nominee = txtNominee.Text;
            iob.Relation = txtRelation.Text;
            iob.House = txtHouse.Text;
            iob.Ward = txtWard.Text;
            iob.Village = txtVillage.Text;
            iob.Township = txtTownship.Text;
            iob.PoliceS = txtPoliceS.Text;
            iob.District = txtDistrict.Text;
            iob.TelNo = txtTelNo.Text;
            iob.MobileNO = txtPMbNo.Text;
            iob.ContactAdd = txtContactAdd.Text;
            iob.Status = ddlStatus.Text;

            decimal monthlyrent = 0;
            decimal dueamt = 0;
            decimal companypayable = 0;
            decimal clientpayable = 0;
            iob.MonthlyInstallment_str = txtMonthlyInstallment.Text;
            monthlyrent = txtMonthlyRent.Text == "" ? 0 : Convert.ToDecimal(txtMonthlyRent.Text);
            iob.MonthlyRent = monthlyrent;
            dueamt = txtDueAmt.Text == "" ? 0 : Convert.ToDecimal(txtDueAmt.Text);
            iob.DueAmt = dueamt;
            companypayable = txtCompnayPayable.Text == "" ? 0 : Convert.ToDecimal(txtCompnayPayable.Text);
            iob.CompnayPayable = companypayable;
            clientpayable = txtClientPayable.Text == "" ? 0 : Convert.ToDecimal(txtClientPayable.Text);
            iob.ClientPayable = clientpayable;
            iob.ClientAccNo = txtClientAccNo.Text;
            iob.DueDate = txtDueDate.Text == "" ? DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null) : DateTime.Parse(txtDueDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            iob.PostOffice = txtPostOffice.Text;
            iob.MobNoHome = txtMob_Home.Text;
            iob.ClientType = ddlClientType.SelectedValue.Trim();
            iob.VehicleType = ddlVehicleType.SelectedValue.Trim();
            iob.VehicleNo = txtVehicleNo.Text;
            iob.PreAccNo = txtOldPreAccNo.Text;

            iob.MonthlyInstallment_Inwards = txtMonthlyInstallment_Inwards.Text;
            iob.MonthlyRent_Inwards = txtMonthlyRent_Inwards.Text;
            iob.LoanAmount_Inwards = txtLoanAmount_Inwards.Text;
            iob.DueAmt_Inwards = txtDueAmt_Inwards.Text;
            iob.ClientPayable_Inwards = txtClientPayable_Inwards.Text;
            iob.CompnayPayable_Inwards = txtCompnayPayable_Inwards.Text;

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
                lblCheckSrl.Text = "";
                DatabaseFunctions.lblAdd(@"Select COUNT(CLIENTID) CLIENTID from CLIENT where CLIENTID= '" + txtClientID.Text + "'", lblCheckSrl);
                if (lblCheckSrl.Text == "0")
                {
                    if (txtClientNM.Text == "")
                    {
                        lblMSGError1.Visible = true;
                        lblMSGError1.Text = "Please Select গ্রাহকের নাম.";
                        txtClientNM.Focus();
                    }
                    else
                    {
                        lblMSGError1.Visible = false;
                        iob.ClntNM = txtClientNM.Text;
                        Inser_Images();
                        dob.InsertClientInfo(iob);
                        Refresh();
                        Invoice_id();
                        ClientSerial_id();
                    }
                }
                else
                {
                    Refresh();
                    Invoice_id();
                    ClientSerial_id();
                }
            }
            else if (btnEditNew.Text == "New")
            {
                lblCheckClientImg.Text = "";
                lblCheckNomineeImg.Text = "";
                DatabaseFunctions.lblAdd(@"Select IMGCLIENT from CLIENT where CLIENTID= '" + txtClientID.Text + "'", lblCheckClientImg);
                DatabaseFunctions.lblAdd(@"Select IMGNOMINEE from CLIENT where CLIENTID= '" + txtClientID.Text + "'", lblCheckNomineeImg);
                if (lblCheckClientImg.Text == "" && lblCheckNomineeImg.Text == "")
                {
                    Inser_Images();
                }
                else
                {
                    iob.filenameclient = lblCheckClientImg.Text;
                    iob.filenameominee = lblCheckNomineeImg.Text;
                }

                //iob.UpdDate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal).ToString("dd/MM/yyyy HH:mm:ss");

                iob.ClntNM = ddlClientNM.SelectedItem.Text;
                dob.UpdateClientInfo(iob);
                DataReturn();
            }
            else
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = "Please Check Somthing Wrong.";
            }
        }

        protected void btnsave_print_Click(object sender, EventArgs e)
        {
            Datafield();
            iob.UpdUserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UPDUserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.UPDIpaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UpdTime = DatabaseFunctions.Timezone(DateTime.Now);

            if (btnEditNew.Text == "Edit")
            {
                lblCheckSrl.Text = "";
                DatabaseFunctions.lblAdd(@"Select COUNT(CLIENTID) CLIENTID from CLIENT where CLIENTID= '" + txtClientID.Text + "'", lblCheckSrl);
                if (lblCheckSrl.Text == "0")
                {
                    if (txtClientNM.Text == "")
                    {
                        lblMSGError1.Visible = true;
                        lblMSGError1.Text = "Please Select গ্রাহকের নাম.";
                        txtClientNM.Focus();
                    }
                    else
                    {
                        lblMSGError1.Visible = false;
                        iob.ClntNM = txtClientNM.Text;
                        Inser_Images();
                        dob.InsertClientInfo(iob);

                        Session["CLIENTID"] = txtClientID.Text;
                        //Session["CLIENTNM"] = txtClientNM.Text;
                        //Session["FATHERNM"] = txtFNM.Text;
                        //Session["MOTHERNM"] = txtMNM.Text;
                        //Session["CONTACTADD"] = txtContactAdd.Text;
                        //Session["HOUSE"] = txtHouse.Text;
                        //Session["WARD"] = txtWard.Text;
                        //Session["VILLAGE"] = txtVillage.Text;
                        //Session["TOWNSHIP"] = txtTownship.Text;
                        //Session["POLICESTAT"] = txtPoliceS.Text;
                        //Session["DISTRICT"] = txtDistrict.Text;
                        //Session["TELNO"] = txtTelNo.Text;
                        //Session["MOBNO"] = txtPMbNo.Text;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('/Report/print/Rpt_ClientInfo.aspx','_newtab');", true);

                        Refresh();
                        Invoice_id();
                        ClientSerial_id();
                    }
                }
                else
                {
                    Refresh();
                    Invoice_id();
                    ClientSerial_id();
                }
            }
            else
            {
                Session["CLIENTID"] = txtClientID.Text;
                //Session["CLIENTNM"] = ddlClientNM.SelectedItem.Text;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('/Report/print/Rpt_ClientInfo.aspx','_newtab');", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtClientNM.ReadOnly = false;
            Refresh();
        }

        protected void btnEditNew_Click(object sender, EventArgs e)
        {
            //AdminChck();
            String empid = HttpContext.Current.Session["EmpID"].ToString();
            string usertp = HttpContext.Current.Session["usertype"].ToString();
            string check = empid.Substring(0, 5);
            if (check == "YES-M" || check == "YES-S")
            {
                if (btnEditNew.Text == "Edit")
                {

                    DatabaseFunctions.dropDownAddSelectTextWithValue(ddlClientNM, "SELECT CLIENTNM, CLIENTID FROM CLIENT WHERE 1=1 AND CLIENTNM IS NOT NULL AND CLIENTNM <> '' ORDER BY CLIENTNM ASC ");

                    btnEditNew.Text = "New";
                    btnSubmit.Text = "Update";
                    btnsave_print.Text = "Print";
                    btnClientNMEdit.Text = "Edit গ্রাহকের নাম";
                    //btnSubmit.Visible = true;
                    //btnReset.Visible = true;
                    ddlClientNM.Visible = true;
                    txtClientNM.Visible = false;
                    //if (check == "YES-M" && usertp == "USER")
                    //{
                    //    btnReset.Visible = false;
                    //    btnSubmit.Visible = false;
                    //    btnsave_print.Visible = true;
                    //    btnEditNew.Visible = true;
                    //}
                    txtClientID.Text = "";
                    txtClientNM.Text = "";
                    txtDate.Text = "";
                    txtInvoiceNo.Text = "";
                    ddlClientNM.Focus();
                    btnClientNMEdit.Visible = true;
                    Refresh();

                    if (Request.QueryString.Keys.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["cid"].ToString()))
                        {
                            ddlClientNM_SelectedIndexChanged(sender, e);
                            //ddlClientNM.DataBind();
                        }
                    }
                    else
                    {
                        ddlClientNM.SelectedIndex = -1;
                    }
                }
                else
                {
                    btnEditNew.Text = "Edit";
                    btnSubmit.Text = "Submit";
                    btnsave_print.Text = "Save & Print";
                    //btnSubmit.Visible = false;
                    //btnReset.Visible = false;
                    ddlClientNM.Visible = false;
                    txtClientNM.Visible = true;
                    txtClientID.Text = "";
                    txtClientNM.Text = "";
                    //if (check == "YES-M" && usertp == "USER")
                    //{
                    //    btnReset.Visible = false;
                    //    btnSubmit.Visible = false;
                    //    btnsave_print.Visible = false;
                    //    btnEditNew.Visible = true;
                    //}
                    txtClientNM.Focus();
                    btnClientNMEdit.Visible = false;
                    btnCancel.Visible = false;
                    Refresh();
                    Sysdate();
                    Invoice_id();
                    ClientSerial_id();
                }
            }
            else
            {
                btnEditNew.Visible = false;
            }
        }

        protected void btnClientNMEdit_Click(object sender, EventArgs e)
        {
            //AdminChck();
            String empid = HttpContext.Current.Session["EmpID"].ToString();
            string usertp = HttpContext.Current.Session["usertype"].ToString();
            string check = empid.Substring(0, 5);
            if (check == "YES-M" || check == "YES-S")
            {
                if (ddlClientNM.SelectedItem.Text == "--SELECT--")
                {
                    lblMSGError1.Visible = true;
                    lblMSGError1.Text = "Please Select গ্রাহকের নাম.";
                    ddlClientNM.Focus();
                }
                else
                {
                    lblMSGError1.Visible = false;
                    if (btnClientNMEdit.Text == "Edit গ্রাহকের নাম")
                    {
                        btnClientNMEdit.Text = "Update গ্রাহকের নাম";
                        btnCancel.Visible = true;
                        txtClientNM.Text = ddlClientNM.SelectedItem.Text;
                        ddlClientNM.Visible = false;
                        txtClientNM.Visible = true;
                        txtClientNM.Focus();
                    }
                    else if (btnClientNMEdit.Text == "Update গ্রাহকের নাম")
                    {
                        btnClientNMEdit.Text = "Edit গ্রাহকের নাম";
                        string clientnm = txtClientNM.Text;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("update CLIENT set CLIENTNM=N'" + clientnm + "' where CLIENTID='" + txtClientID.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        //DatabaseFunctions.dropDownAddWithSelect(ddlClientNM, "SELECT CLIENTNM FROM CLIENT");
                        DatabaseFunctions.dropDownAddSelectTextWithValue(ddlClientNM, "SELECT CLIENTNM, CLIENTID FROM CLIENT WHERE 1=1 AND CLIENTNM IS NOT NULL AND CLIENTNM <> '' ORDER BY CLIENTNM ASC ");
                        btnCancel.Visible = false;
                        ddlClientNM.Visible = true;
                        txtClientNM.Visible = false;
                        txtClientID.Text = "";
                        txtClientNM.Text = "";
                        txtDate.Text = "";
                        ddlClientNM.Focus();
                        Refresh();
                    }
                    else
                    {
                        btnClientNMEdit.Text = "Edit গ্রাহকের নাম";
                        btnCancel.Visible = false;
                        ddlClientNM.Visible = true;
                        txtClientNM.Visible = false;
                        ddlClientNM.Focus();
                    }
                }
            }
            else
            {
                btnClientNMEdit.Visible = false;
                btnCancel.Visible = false;
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //DatabaseFunctions.dropDownAddWithSelect(ddlClientNM, "SELECT CLIENTNM FROM CLIENT");
            DatabaseFunctions.dropDownAddSelectTextWithValue(ddlClientNM, "SELECT CLIENTNM, CLIENTID FROM CLIENT WHERE 1=1 AND CLIENTNM IS NOT NULL AND CLIENTNM <> '' ORDER BY CLIENTNM ASC ");
            btnClientNMEdit.Text = "Edit গ্রাহকের নাম";
            btnEditNew.Text = "New";
            btnSubmit.Text = "Update";
            btnsave_print.Text = "Print";
            ddlClientNM.Visible = true;
            txtClientNM.Visible = false;
            btnCancel.Visible = false;
            txtClientID.Text = "";
            txtClientNM.Text = "";
            txtDate.Text = "";
            txtInvoiceNo.Text = "";
            ddlClientNM.Focus();
            btnClientNMEdit.Visible = true;
            Refresh();
        }

        private void DataReturn()
        {
            SqlCommand cmd = new SqlCommand("Select * from CLIENT Where CLIENTID='" + txtClientID.Text + "'", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //txtDate.Text = reader["TRANSDT"].ToString();
                DatabaseFunctions.txtAdd(@"SELECT CONVERT(NVARCHAR(10),TRANSDT,103) AS TRANSDT FROM CLIENT WHERE CLIENTID='" + txtClientID.Text + "'", txtDate);
                txtInvoiceNo.Text = reader["INVREFNO"].ToString();
                //txtClientID.Text = reader["CLIENTID"].ToString();
                //txtClientNM.Text = reader["CLIENTNM"].ToString();
                txtLoanDuration.Text = reader["LOANDURATION"].ToString();
                txtLoanAmount.Text = reader["LOANAMOUNT"].ToString();
                txtAge.Text = reader["CLIENTAGE"].ToString();
                txtFNM.Text = reader["FATHERNM"].ToString();
                txtMNM.Text = reader["MOTHERNM"].ToString();
                txtSpouse.Text = reader["SPOUSENM"].ToString();
                txtGirl.Text = reader["GIRL"].ToString();
                txtBoy.Text = reader["BOY"].ToString();
                txtNominee.Text = reader["NOMINEENM"].ToString();
                txtRelation.Text = reader["RELATION"].ToString();
                txtHouse.Text = reader["HOUSE"].ToString();
                txtWard.Text = reader["WARD"].ToString();
                txtVillage.Text = reader["VILLAGE"].ToString();
                txtTownship.Text = reader["TOWNSHIP"].ToString();
                txtPoliceS.Text = reader["POLICESTAT"].ToString();
                txtDistrict.Text = reader["DISTRICT"].ToString();
                txtTelNo.Text = reader["TELNO"].ToString();
                txtPMbNo.Text = reader["MOBNO"].ToString();
                txtContactAdd.Text = reader["CONTACTADD"].ToString();
                var clienttp = reader["CLIENTTYPE"].ToString();
                if (clienttp == "")
                {
                    ddlClientType.SelectedIndex = -1;
                    //DivForOld.Visible = clienttp == "OLD";
                }
                else
                {
                    ddlClientType.Text = clienttp;
                    //DivForOld.Visible = clienttp == "OLD";
                }
                txtMonthlyRent.Text = reader["MONTHLYRENT"].ToString();
                txtDueAmt.Text = reader["DUEAMOUNT"].ToString();
                txtClientPayable.Text = reader["CLIENTPAYABLE"].ToString();
                txtPostOffice.Text = reader["POSTOFFICE"].ToString();
                txtMob_Home.Text = reader["MOBNO_HOME"].ToString();
                var vehicletp = reader["VEHICLETYPE"].ToString();
                if (vehicletp == "")
                {
                    ddlVehicleType.SelectedIndex = -1;
                }
                else
                {
                    ddlVehicleType.Text = vehicletp;
                }

                var duedate = DatabaseFunctions.StringData(@"SELECT CONVERT(NVARCHAR(10),DUEDATE,103) AS DUEDATE FROM CLIENT WHERE CLIENTID='" + txtClientID.Text + "'");
                txtDueDate.Text = duedate == "01/01/1900" ? "" : duedate;
                txtMonthlyInstallment.Text = reader["MONTHLYINSTALLMENT"].ToString();
                txtClientAccNo.Text = reader["CLIENTACCNO"].ToString();

                txtVehicleNo.Text = reader["VEHICLENO"].ToString();
                txtOldPreAccNo.Text = reader["PREACCNO"].ToString();

                txtCompnayPayable.Text = reader["COMPANYPAYABLE"].ToString();
                txtCompnayPayable_Inwards.Text = reader["COMPANYPAYABLE_INWARDS"].ToString();

                txtLoanAmount_Inwards.Text = reader["LOANAMOUNT_INWARDS"].ToString();
                txtMonthlyRent_Inwards.Text = reader["MONTHLYRENT_INWARDS"].ToString();
                txtDueAmt_Inwards.Text = reader["DUEAMOUNT_INWARDS"].ToString();
                txtMonthlyInstallment_Inwards.Text = reader["MONTHLYINSTALLMENT_INWARDS"].ToString();
                txtClientPayable_Inwards.Text = reader["CLIENTPAYABLE_INWARDS"].ToString();

                var loanstatus = reader["LOANSTATUS"].ToString();
                if (loanstatus == "")
                {
                    ddlLoanStatus.SelectedIndex = -1;
                }
                else
                {
                    ddlLoanStatus.Text = loanstatus;
                }
                ddlStatus.Text = reader["STATUS"].ToString();
            }
            reader.Close();
            conn.Close();
        }

        protected void txtClientNM_TextChanged(object sender, EventArgs e)
        {
            //if (btnEditNew.Text == "New")
            //{
            //    if (txtClientNM.Text == "")
            //    {
            //        lblMSGError1.Visible = true;
            //        lblMSGError1.Text = "Please Select গ্রাহকের নাম.";
            //        txtClientNM.Focus();
            //    }
            //    else
            //    {
            //        lblMSGError1.Visible = false;
            //        DatabaseFunctions.txtAdd(@"Select CLIENTID from CLIENT where CLIENTNM= N'" + txtClientNM.Text + "'", txtClientID);
            //        //DatabaseFunctions.lblAdd(@"Select CLIENTNM from CLIENT where CLIENTID= '" + txtClientID.Text + "'", lblClientNM);
            //        //if (txtClientNM.Text == lblClientNM.Text)
            //        //{
            //        //    DataReturn();
            //        //}
            //        //else
            //        //{
            //        //    txtAge.Focus();
            //        //}

            //    }
            //}
            //else
            //{
            //    txtAge.Focus();
            //}

            txtAge.Focus();
        }


        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        //public static string[] GetCompletionListClientNM(string prefixText, int count, string contextKey)
        //{
        //    string connection = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connection);

        //    SqlCommand cmd = new SqlCommand("Select CLIENTNM from CLIENT where CLIENTNM LIKE N'" + prefixText + "%'", conn);

        //    SqlDataReader oReader;
        //    conn.Open();
        //    List<String> CompletionSet = new List<string>();
        //    oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    while (oReader.Read())
        //        CompletionSet.Add(oReader["CLIENTNM"].ToString());
        //    return CompletionSet.ToArray();
        //}

        protected void ddlClientNM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClientNM.SelectedItem.Text == "--SELECT--" || ddlClientNM.SelectedItem.Text == "")
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = "Please Select গ্রাহকের নাম.";
                txtClientNM.Focus();
            }
            else
            {
                lblMSGError1.Visible = false;

                if (Request.QueryString.Keys.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["cid"].ToString()))
                    {
                        txtClientID.Text = Request.QueryString["cid"].ToString();
                        ddlClientNM.SelectedValue = Request.QueryString["cid"].ToString();
                    }
                }
                else
                {
                    DatabaseFunctions.txtAdd(@"Select CLIENTID from CLIENT where CLIENTNM= N'" + ddlClientNM.SelectedItem.Text.Trim() + "'", txtClientID);
                }
                
                DataReturn();
            }
        }

        protected void txtMob_Home_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMob_Home.Text, "[^0-9]"))
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = ("Insert a valid phone number like 017xxxxxxxx.");
                //txtMob_Home.Text.Remove(txtMob_Home.Text.Length - 1);
                txtMob_Home.Text = "";
                txtMob_Home.Focus();
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
                lblMSGError1.Text = ("Insert a valid phone number like 017xxxxxxxx.");
                //txtPMbNo.Text.Remove(txtPMbNo.Text.Length - 1);
                txtPMbNo.Text = "";
                txtPMbNo.Focus();
            }
            else
            {
                lblMSGError1.Visible = false;
                txtContactAdd.Focus();
            }
        }

        protected void txtTelNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTelNo.Text, "[^0-9]"))
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = ("Insert a valid phone number.");
                //txtPMbNo.Text.Remove(txtPMbNo.Text.Length - 1);
                txtTelNo.Text = "";
                txtTelNo.Focus();
            }
            else
            {
                lblMSGError1.Visible = false;
                txtPMbNo.Focus();
            }
        }

        protected void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAge.Text, "[^0-9]"))
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = ("Insert Numeric Value.");
                //txtPMbNo.Text.Remove(txtPMbNo.Text.Length - 1);
                txtAge.Text = "";
                txtAge.Focus();
            }
            else
            {
                lblMSGError1.Visible = false;
                txtFNM.Focus();
            }
        }

        protected void txtBoy_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoy.Text, "[^0-9]"))
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = ("Insert Numeric Value.");
                //txtPMbNo.Text.Remove(txtPMbNo.Text.Length - 1);
                txtBoy.Text = "";
                txtBoy.Focus();
            }
            else
            {
                lblMSGError1.Visible = false;
                txtGirl.Focus();
            }
        }

        protected void txtGirl_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtGirl.Text, "[^0-9]"))
            {
                lblMSGError1.Visible = true;
                lblMSGError1.Text = ("Insert Numeric Value.");
                //txtPMbNo.Text.Remove(txtPMbNo.Text.Length - 1);
                txtGirl.Text = "";
                txtGirl.Focus();
            }
            else
            {
                lblMSGError1.Visible = false;
                txtNominee.Focus();
            }
        }
    }
}