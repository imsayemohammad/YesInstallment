using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yesbd;

namespace Yesbd.DynamicMenu.UI
{
    public partial class MenuCreate : System.Web.UI.Page
    {
        IFormatProvider dateormat = new System.Globalization.CultureInfo("fr-FR", true);

        DataAccess.ICMSDataAccess dob = new DataAccess.ICMSDataAccess();
        DataModel.ICMSDataModel iob = new DataModel.ICMSDataModel();
        SqlConnection conn = new SqlConnection(DatabaseFunctions.connection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                string formLink = "/DynamicMenu/UI/MenuCreate.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        txtModuleName.Focus();
                        lblMsg.Visible = false;
                        lblMsgMenu.Visible = false;

                    }
                }
                else
                {
                    Response.Redirect("../../home_default.aspx");
                }
            }
        }

        public string ModuleNameAdd()
        {
            string checkResult = "";
            if (txtModuleName.Text == "")
            {
                checkResult = "false";
                lblMsg.Text = "Select Module Name.";
                lblMsg.Visible = true;
            }
            else
            {
                string datacheck = DatabaseFunctions.StringData("SELECT MODULENM FROM MENUMST WHERE MODULENM='" + txtModuleName.Text + "'");
                if (datacheck == "")
                {
                    string empid = HttpContext.Current.Session["EmpID"].ToString();
                    iob.UserID = HttpContext.Current.Session["UserName"].ToString();
                    iob.UserPC = HttpContext.Current.Session["PCName"].ToString();
                    iob.Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
                    iob.ITime = DateTime.Now;

                    iob.ModuleId = ModuleId();
                    lblModuleID.Text = iob.ModuleId;
                    iob.ModuleName = txtModuleName.Text.Trim();

                    dob.INSERT_MENUMST(iob);
                }
            }
            return checkResult;
        }

        public string ModuleId()
        {
            string moduleId = "";
            string maxDbModuleId = DatabaseFunctions.StringData("SELECT MAX(MODULEID) AS MODULEID FROM MENUMST");
            if (maxDbModuleId == "")
                moduleId = "01";
            else
            {
                int maxid = Convert.ToInt16(maxDbModuleId);
                maxid++;
                if (maxid < 10)
                    moduleId = "0" + maxid;
                else
                    moduleId = maxid.ToString();
            }
            return moduleId;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtModuleName.Text != "")
            {
                string checkModuleNmFromDb =
                    DatabaseFunctions.StringData("SELECT MODULENM FROM MENUMST WHERE MODULENM='" + txtModuleName.Text + "'");
                if (checkModuleNmFromDb == "")
                {
                    ModuleNameAdd();
                    lblMsg.Text = "Module Create Succesfully.";
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = Color.Green;
                }
                else
                {
                    DatabaseFunctions.lblAdd("SELECT MODULEID FROM MENUMST WHERE MODULENM='" + txtModuleName.Text + "'", lblModuleID);
                    lblMsg.Text = "Module Already Created. Add menu Name.";
                    lblMsg.Visible = true;
                    lblMsg.ForeColor = Color.Green;

                    //txtMenuName.Focus();
                }
                Session["ModuleId"] =
                   DatabaseFunctions.StringData("SELECT MODULEID FROM MENUMST WHERE MODULENM='" + txtModuleName.Text + "'");
            }
            else
            {
                lblMsg.Text = "Write a Module Name.";
                lblMsg.Visible = true;
                lblMsg.ForeColor = Color.Red;
                txtModuleName.Focus();
            }

            BindMenuDetails();

        }

        //public string FieldCheck()
        //{
        //    string checkResult = "";
        //    if (txtModuleName.Text == "")
        //    {
        //        checkResult = "Select module Name.";
        //        txtModuleName.Focus();
        //    }
        //    else if (ddlMenuType.SelectedValue == "S")
        //    {
        //        checkResult = "Select menu type.";
        //        ddlMenuType.Focus();
        //    }
        //    else if (txtMenuName.Text == "")
        //    {
        //        checkResult = "Write menu name.";
        //        txtMenuName.Focus();
        //    }
        //    else if (txtMenuLink.Text == "")
        //    {
        //        checkResult = "Write menu link.";
        //        txtMenuLink.Focus();
        //    }
        //    else
        //    {
        //        checkResult = "true";
        //    }
        //    return checkResult;
        //}

        //protected void btnAddMenu_Click(object sender, EventArgs e)
        //{
        //    if (FieldCheck() == "true")
        //    {
        //        string moduleid = "";
        //        if (Session["ModuleId"] != "")
        //        {
        //            moduleid = Session["ModuleId"].ToString();
        //            string menuName =
        //                DatabaseFunctions.StringData("SELECT MENUNM FROM MENU WHERE MENUNM='" + txtMenuName.Text.Trim() + "' AND MODULEID='" + moduleid + "'");
        //            if (menuName != "")
        //            {
        //                lblMsgMenu.Text = "Menu already exists. Try another one.";
        //                lblMsgMenu.Visible = true;
        //                txtMenuName.Focus();
        //            }
        //            else
        //            {
        //                MenuNameAdd(moduleid);
        //                lblMsgMenu.Text = "Menu Created Succressfully.";
        //                lblMsgMenu.Visible = true;
        //                txtMenuName.Text = "";
        //                txtMenuLink.Text = "";
        //                txtMenuName.Focus();
        //            }
        //        }
        //        else
        //        {
        //            lblMsgMenu.Text = "Select Module Name.";
        //            lblMsgMenu.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        lblMsgMenu.Text = FieldCheck();
        //        lblMsgMenu.Visible = true;
        //    }
        //}

        public string MenuId(string moduleid)
        {
            string menuid = "";
            string maxMunuIdFromDb = DatabaseFunctions.StringData("SELECT MAX(MENUID) FROM MENU WHERE MODULEID='" + moduleid + "'");
            if (maxMunuIdFromDb == "")
                menuid = moduleid + "01";
            else
            {
                string menuidwithoutmodule = maxMunuIdFromDb.Substring(2, 2);
                int menuidconvert = Convert.ToInt16(menuidwithoutmodule);
                menuidconvert++;
                if (menuidconvert < 10)
                    menuid = moduleid + "0" + menuidconvert;
                else
                    menuid = moduleid + menuidconvert;
            }
            return menuid;
        }
        //public void MenuNameAdd(string moduleid)
        //{
        //    iob.IpAddressInsert = DatabaseFunctions.IpAddress();
        //    iob.UserIdInsert = Convert.ToInt64(Session["USERID"].ToString());
        //    iob.UserPcInsert = DatabaseFunctions.UserPc();
        //    iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);

        //    iob.ModuleId = moduleid;
        //    iob.MenuId = MenuId(moduleid);
        //    iob.MenuName = txtMenuName.Text.Trim();
        //    iob.MenuType = ddlMenuType.SelectedValue;
        //    iob.MenuLink = txtMenuLink.Text;

        //    string s = dob.INSERT_MENU(iob);
        //    if (s == "")
        //    {
        //       // MenuAddInAslRoleForAllUser(iob.ModuleId, iob.MenuId, iob.MenuType);
        //       // MenuActiveForAllCompanyAdmin(iob.ModuleId, iob.MenuId, iob.MenuType);
        //    }
        //}

        //        public void MenuAddInAslRoleForAllUser(string moduleId, string menuId, string menutp)
        //        {
        //            TextBox txtLotiLongTude = (TextBox)Master.FindControl("txtLotiLongTude");
        //            iob.LotiLengTudeInsert = txtLotiLongTude.Text;
        //            iob.IpAddressInsert = DatabaseFunctions.IpAddress();
        //            iob.UserIdInsert = Convert.ToInt64(Session["USERID"].ToString());
        //            iob.UserPcInsert = DatabaseFunctions.UserPc();
        //            iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);
        //            iob.ModuleId = moduleId;
        //            iob.MenuId = menuId;
        //            iob.MenuType = menutp;
        //            iob.Status = "I";
        //            iob.InsertRole = "I";
        //            iob.UpdateRole = "I";
        //            iob.DeleteRole = "I";
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand(@"SELECT SUBSTRING(CONVERT(NVARCHAR,USERID),1,3) AS CMPID, USERID 
        //                             FROM USERCO WHERE SUBSTRING(CONVERT(NVARCHAR,USERID),1,3) !='100' AND SUBSTRING(CONVERT(NVARCHAR,USERID),4,2)='01'", con);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                iob.CompanyId = Convert.ToInt16(dr["CMPID"].ToString());
        //                iob.CompanyUserId = Convert.ToInt16(dr["USERID"].ToString());
        //                dob.INSERT_ROLE(iob);
        //            }
        //            dr.Close();
        //            con.Close();
        //        }

        public void MenuActiveForAllCompanyAdmin(string moduleId, string menuId, string menutp)
        {
            TextBox txtLotiLongTude = (TextBox)Master.FindControl("txtLotiLongTude");
            iob.LotiLengTudeUpdate = txtLotiLongTude.Text;
            //iob.IpAddressUpdate = DatabaseFunctions.IpAddress();
            //iob.UserIdUpdate = Convert.ToInt64(Session["USERID"].ToString());
            //iob.InTimeUpdate = DatabaseFunctions.Timezone(DateTime.Now);
            string empid = HttpContext.Current.Session["EmpID"].ToString();
            iob.UserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.ITime = DateTime.Now;

            iob.ModuleId = moduleId;
            iob.MenuId = menuId;
            iob.MenuType = menutp;
            iob.Status = "A";
            iob.InsertRole = "A";
            iob.UpdateRole = "A";
            iob.DeleteRole = "A";

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT COMPID, CONVERT(NVARCHAR,COMPID)+'01' AS USERID 
                FROM COMPANY WHERE COMPID!='100'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                iob.CompanyId = Convert.ToInt16(dr["COMPID"].ToString());
                iob.CompanyUserId = Convert.ToInt16(dr["USERID"].ToString());
                dob.UPDATE_ROLE(iob);
            }
            dr.Close();
            conn.Close();
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionListModuleName(string prefixText, int count, string contextKey)
        {
            string connection = ConfigurationManager.ConnectionStrings["Yes_bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Select MODULENM from MENUMST where MODULENM LIKE '" + prefixText + "%'", conn);
            SqlDataReader oReader;
            conn.Open();
            List<String> CompletionSet = new List<string>();
            oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oReader.Read())
                CompletionSet.Add(oReader["MODULENM"].ToString());
            return CompletionSet.ToArray();
        }

        protected void txtModuleName_TextChanged(object sender, EventArgs e)
        {
            
            string checkModuleNmFromDb =
                   DatabaseFunctions.StringData("SELECT MODULENM FROM MENUMST WHERE MODULENM='" + txtModuleName.Text + "'");
            if (checkModuleNmFromDb == "")
            {
                lblMsg.Text = "Module name not present.";
                lblMsg.Visible = true;
            }
            else
            {
                Session["ModuleId"] =
                   DatabaseFunctions.StringData("SELECT MODULEID FROM MENUMST WHERE MODULENM='" + txtModuleName.Text + "'");
                lblModuleID.Text = Session["ModuleId"].ToString();
                lblMsg.Visible = false;

                //GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
                //DropDownList ddlMenuType = (DropDownList)row.FindControl("ddlMenuType");
                //if (ddlMenuType.SelectedValue == "")
                //{

                //}

                BindMenuDetails();
            }

        }

        protected void BindMenuDetails()
        {
            string moduleId = Session["ModuleId"].ToString();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MENU.MODULEID, MENU.MENUTP, MENU.MENUID, MENU.MENUNM, MENU.MENUSL, MENU.FLINK " +
                                            "FROM MENU INNER JOIN MENUMST ON MENU.MODULEID = MENUMST.MODULEID " +
                                            "where MENU.MODULEID='" + moduleId + "' ORDER BY MENU.MENUID", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                //TextBox txtExmNM = (TextBox)gvDetails.FooterRow.FindControl("txtExmNM");
                //txtExmNM.Focus();

            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                int columncount = gvDetails.Rows[0].Cells.Count;
                gvDetails.Rows[0].Cells.Clear();
                gvDetails.Rows[0].Cells.Add(new TableCell());
                gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                gvDetails.Rows[0].Cells[0].Text = "No Records Found";
                gvDetails.Rows[0].Visible = false;

                //TextBox txtExmNM = (TextBox)gvDetails.FooterRow.FindControl("txtExmNM");
                //txtExmNM.Focus();
            }
        }

        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindMenuDetails();
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string empid = HttpContext.Current.Session["EmpID"].ToString();
            iob.UserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.ITime = DateTime.Now;

            if (e.CommandName.Equals("AddNew"))
            {
                // Label lblModuleID = (Label)gvDetails.FooterRow.FindControl("lblModuleID");
                DropDownList ddlMenuType = (DropDownList)gvDetails.FooterRow.FindControl("ddlMenuType");
                Label lblMenuID = (Label)gvDetails.FooterRow.FindControl("lblMenuID");
                TextBox txtMenuNM = (TextBox)gvDetails.FooterRow.FindControl("txtMenuNM");
                TextBox txtMenuSL = (TextBox)gvDetails.FooterRow.FindControl("txtMenuSL");
                TextBox txtMenuLink = (TextBox)gvDetails.FooterRow.FindControl("txtMenuLink");


                iob.ModuleId = lblModuleID.Text;
                iob.MenuId = MenuId(iob.ModuleId);
                iob.MenuName = txtMenuNM.Text.Trim();
                iob.MenuSL = Convert.ToInt64(txtMenuSL.Text);
                iob.MenuType = ddlMenuType.SelectedValue;
                iob.MenuLink = txtMenuLink.Text;

                string s = dob.INSERT_MENU(iob);
                if (s == "")
                {
                    // MenuAddInAslRoleForAllUser(iob.ModuleId, iob.MenuId, iob.MenuType);
                    // MenuActiveForAllCompanyAdmin(iob.ModuleId, iob.MenuId, iob.MenuType);
                }

                BindMenuDetails();
                ddlMenuType.Focus();

            }
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblModuleID = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblModuleID");
            Label lblMenuID = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblMenuID");

            SqlCommand cmd1 = new SqlCommand("select * from MENU where MODULEID = '" + lblModuleID.Text + "'", conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            conn.Close();
            if (ds1.Tables[0].Rows.Count > 1)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from MENU where MODULEID = '" + lblModuleID.Text + "' And MENUID = '" + lblMenuID.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from MENU where MODULEID = '" + lblModuleID.Text + "' And MENUID = '" + lblMenuID.Text + "'", conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("delete from MENUMST where MODULEID = '" + lblModuleID.Text + "'", conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
                Refresh();
            }

            gvDetails.EditIndex = -1;
            BindMenuDetails();

        }

        protected void Refresh()
        {
            txtModuleName.Text = "";
            lblModuleID.Text = "";

            BindMenuDetails();
        }

        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            BindMenuDetails();
        }

        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string userName = HttpContext.Current.Session["UserName"].ToString();
            iob.UpdUserID = HttpContext.Current.Session["UserName"].ToString();
            iob.UPDUserPC = HttpContext.Current.Session["PCName"].ToString();
            iob.UPDIpaddress = HttpContext.Current.Session["IpAddress"].ToString();
            iob.UpdTime = DateTime.Now;

            Label lblModuleIDEdit = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblModuleIDEdit");
            DropDownList ddlMenuTypeEdit = (DropDownList)gvDetails.Rows[e.RowIndex].FindControl("ddlMenuTypeEdit");
            Label lblMenuIDEdit = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblMenuIDEdit");
            TextBox txtMenuNMdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMenuNMdit");
            TextBox txtMenuSLdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMenuSLdit");
            TextBox txtMenuLinkEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMenuLinkEdit");

            iob.ModuleId = lblModuleIDEdit.Text;
            iob.MenuId = lblMenuIDEdit.Text;        // MenuId(iob.ModuleId);
            iob.MenuName = txtMenuNMdit.Text.Trim();
            iob.MenuType = ddlMenuTypeEdit.SelectedValue;
            iob.MenuSL = Convert.ToInt64(txtMenuSLdit.Text);
            iob.MenuLink = txtMenuLinkEdit.Text;

            dob.UPDATE_MENU(iob);

            gvDetails.EditIndex = -1;
            BindMenuDetails();
        }



        protected void txtMenuNM_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtMenuNMdit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
