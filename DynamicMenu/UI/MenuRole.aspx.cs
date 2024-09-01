using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Yesbd;
using Yesbd;
using System.Data.SqlClient;
using System.Web.Services;
using System.Text;
using System.Collections.Specialized;
using Yesbd.DynamicMenu.DataAccess;
using Yesbd.DynamicMenu.DataModel;


namespace Yesbd.DynamicMenu.UI
{
    public partial class MenuRole : System.Web.UI.Page
    {
        IFormatProvider dateormat = new System.Globalization.CultureInfo("fr-FR", true);

        DataAccess.ICMSDataAccess dob = new DataAccess.ICMSDataAccess();
        DataModel.ICMSDataModel iob = new DataModel.ICMSDataModel();
        SqlConnection con = new SqlConnection(DatabaseFunctions.connection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                string formLink = "/DynamicMenu/UI/MenuRole.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        if (Session["UserName"] == null)
                        {
                            Response.Redirect("~/user/Login.aspx");
                        }
                        else
                        {
                            DatabaseFunctions.dropDownAddWithSelect(ddlMemberName, "SELECT EMPNM FROM [dbo].[EMPLOYEE] WHERE STATUS='A' ORDER BY EMPNM");
                            ddlMemberName.Focus();
                        }
                    }
                }
                else
                {
                    Response.Redirect("../../home_default.aspx");
                }
            }
        }

        //        protected void txtUserName_TextChanged(object sender, EventArgs e)
        //        {
        //            if (txtUserName.Text == "")
        //            {
        //                txtUserName.Focus();
        //                lblMsg.Text = "Select User Name.";
        //                lblMsg.Visible = true;
        //                txtUserName.Text = "";
        //            }
        //            else
        //            {
        //                string companyid = HttpContext.Current.Session["COMPANYID"].ToString();
        //                lblCompanyUserId.Text = "";
        //                DatabaseFunctions.lblAdd(@"SELECT USERCO.USERID FROM USERCO 
        //                WHERE USERCO.USERNM='" + txtUserName.Text + "' AND USERCO.COMPID='" + companyid + "'", lblCompanyUserId);
        //                lblMsg.Visible = false;
        //                Session["Companyidgrid"] = null;
        //                Session["Companyidgrid"] = companyid;
        //            }
        //        }

        //        protected void txtComapnyAdminName_TextChanged(object sender, EventArgs e)
        //        {
        //            if (txtComapnyAdminName.Text == "")
        //            {
        //                txtComapnyAdminName.Focus();
        //                lblMsg.Text = "Select Company Name.";
        //                lblMsg.Visible = true;
        //                txtComapnyAdminName.Text = "";
        //            }
        //            else
        //            {
        //                //string companyid = HttpContext.Current.Session["COMPANYID"].ToString();
        //                lblCompanyUserId.Text = "";
        //                DatabaseFunctions.lblAdd(@"SELECT CONVERT(NVARCHAR,COMPID)+'01' AS USERID FROM COMPANY 
        //                    WHERE COMPNM='" + txtComapnyAdminName.Text + "'", lblCompanyUserId);
        //                Session["Companyidgrid"] = null;
        //                Session["Companyidgrid"] = DatabaseFunctions.StringData(@"SELECT COMPID AS USERID FROM COMPANY 
        //                    WHERE COMPNM='" + txtComapnyAdminName.Text + "'");
        //                lblMsg.Visible = false;
        //            }
        //        }

        protected void ddlMemberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMemberName.Text == "Select")
            {
                lblMsg.Text = "Select Module Name.";
                lblMsg.Visible = true;
            }
            else
            {
                lblMemberId.Text = "";
                DatabaseFunctions.lblAdd(@"SELECT EMPID FROM EMPLOYEE WHERE EMPNM='" + ddlMemberName.Text + "'", lblMemberId);
                ShowGridForAslRole();

            }
        }

        protected void ddlModuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlModuleName = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlModuleName");
            Label lblModuleIdFooter = (Label)gridViewAslRole.FooterRow.FindControl("lblModuleIdFooter");
            DropDownList ddlMenuName = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlMenuName");

            if (ddlModuleName.Text == "Select")
            {
                lblMsg.Text = "Select Module Name.";
                lblMsg.Visible = true;
            }
            else
            {
                lblModuleIdFooter.Text = "";
                DatabaseFunctions.lblAdd(@"SELECT MODULEID FROM MENUMST WHERE MODULENM='" + ddlModuleName.Text + "'", lblModuleIdFooter);

                DatabaseFunctions.dropDownAddWithSelect(ddlMenuName, "SELECT MENUNM FROM MENU WHERE MODULEID='" + lblModuleIdFooter.Text + "'");

                ddlMenuName.Focus();
            }
        }


        protected void ddlMenuName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMenuName = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlMenuName");
            Label lblMenuIdFooter = (Label)gridViewAslRole.FooterRow.FindControl("lblMenuIdFooter");
            DropDownList ddlMenuType = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlMenuType");

            if (ddlMenuName.Text == "Select")
            {
                lblMsg.Text = "Select Menu Name.";
                lblMsg.Visible = true;
            }
            else
            {
                lblMenuIdFooter.Text = "";
                DatabaseFunctions.lblAdd(@"SELECT MENUID FROM MENU WHERE MENUNM='" + ddlMenuName.Text + "'", lblMenuIdFooter);

                ddlMenuType.Focus();
            }
        }

        //protected void ddlModuleNameEdit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
        //    //GridViewRow rowlbl = ((GridViewRow)((Label)sender).NamingContainer);

        //    DropDownList ddlModuleNameEdit = (DropDownList)row.FindControl("ddlModuleNameEdit");
        //    Label lblModuleIdEdit = (Label)row.FindControl("lblModuleIdEdit");

        //    if (ddlModuleNameEdit.Text == "Select")
        //    {
        //        lblMsg.Text = "Select Module Name.";
        //        lblMsg.Visible = true;
        //    }
        //    else
        //    {
        //        lblModuleIdEdit.Text = "";
        //        DatabaseFunctions.lblAdd(@"SELECT MODULEID FROM MENUMST WHERE MODULENM='" + ddlModuleNameEdit.Text + "'", lblModuleIdEdit);
        //    }
        //}

        //protected void ddlMenuNameEdit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
        //    //GridViewRow rowlbl = ((GridViewRow)((Label)sender).NamingContainer);

        //    DropDownList ddlMenuNameEdit = (DropDownList)row.FindControl("ddlMenuNameEdit");
        //    Label lblMenuIdEdit = (Label)row.FindControl("lblMenuIdEdit");

        //    if (ddlMenuNameEdit.Text == "Select")
        //    {
        //        lblMsg.Text = "Select Menu Name.";
        //        lblMsg.Visible = true;
        //    }
        //    else
        //    {
        //        lblMenuIdEdit.Text = "";
        //        DatabaseFunctions.lblAdd(@"SELECT MENUID FROM MENU WHERE MENUNM='" + ddlMenuNameEdit.Text + "'", lblMenuIdEdit);
        //    }
        //}

        //public string FieldCheck()
        //{
        //    string checkResult = "";
        //    if (lblCompanyUserId.Text == "")
        //    {
        //        checkResult = "Select user name.";
        //        txtUserName.Text = "";
        //        txtComapnyAdminName.Text = "";
        //        txtUserName.Focus();
        //    }
        //    else if (ddlMemberName.Text == "--SELECT--" || lblMemberId.Text == "")
        //    {
        //        checkResult = "Select module name.";
        //        ddlMemberName.SelectedIndex = -1;
        //        ddlMemberName.Focus();
        //    }
        //    else if (ddlMenuType.SelectedValue == "S")
        //    {
        //        checkResult = "Select form type.";
        //        ddlMenuType.SelectedIndex = -1;
        //        ddlMenuType.Focus();
        //    }
        //    else
        //    {
        //        checkResult = "true";
        //    }
        //    return checkResult;
        //}

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    if (Session["UserName"] == null)
        //    {
        //        Response.Redirect("~/user/Login.aspx");
        //    }
        //    else
        //    {
        //        if (FieldCheck() == "true")
        //        {
        //            ShowGridForAslRole();
        //            lblMsg.Visible = false;
        //        }
        //        else
        //        {
        //            lblMsg.Text = FieldCheck();
        //            lblMsg.Visible = true;
        //        }

        //    }
        //}

        protected void ShowGridForAslRole()
        {
            string userid = lblMemberId.Text;
            //string moduleid = lblModuleId.Text;
            //string menuTp = ddlMenuType.SelectedValue;

            SqlConnection conn = new SqlConnection(DatabaseFunctions.connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT MENU.MENUNM, MENUMST.MODULENM, 
                CASE(ROLE.STATUS) WHEN 'A' THEN 'ACTIVE' ELSE 'INACTIVE' END AS STATUS, 
                CASE(ROLE.INSERTR) WHEN 'A' THEN 'ACTIVE' ELSE 'INACTIVE' END AS INSERTR, 
                CASE(ROLE.UPDATER) WHEN 'A' THEN 'ACTIVE' ELSE 'INACTIVE' END AS UPDATER, 
                CASE(ROLE.DELETER) WHEN 'A' THEN 'ACTIVE' ELSE 'INACTIVE' END AS DELETER,
                CASE WHEN ROLE.MENUTP ='F' THEN 'Form' 
                WHEN ROLE.MENUTP ='R' THEN 'Report' 
                WHEN ROLE.MENUTP = 'AR' THEN 'Admin Report' END AS MENUTP, 
                ROLE.MODULEID, ROLE.MENUID FROM ROLE INNER JOIN
                MENUMST ON ROLE.MODULEID = MENUMST.MODULEID INNER JOIN
                MENU ON ROLE.MODULEID = MENU.MODULEID AND ROLE.MENUID = MENU.MENUID
                WHERE (ROLE.INSUSERID = @USERID)", conn);
            cmd.Parameters.AddWithValue("@USERID", userid);
            //cmd.Parameters.AddWithValue("@MENUTP", menuTp);
            //cmd.Parameters.AddWithValue("@MODULEID", moduleid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridViewAslRole.DataSource = ds;
                gridViewAslRole.DataBind();
                //TextBox txtZONENM = (TextBox)gridViewAslRole.FooterRow.FindControl("txtCountryNM");
                //txtZONENM.Focus();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gridViewAslRole.DataSource = ds;
                gridViewAslRole.DataBind();
                int columncount = gridViewAslRole.Rows[0].Cells.Count;
                gridViewAslRole.Rows[0].Cells.Clear();
                gridViewAslRole.Rows[0].Cells.Add(new TableCell());
                gridViewAslRole.Rows[0].Cells[0].ColumnSpan = columncount;
                gridViewAslRole.Rows[0].Cells[0].Text = "No Records Found";
                gridViewAslRole.Rows[0].Visible = false;

                //TextBox txtZONENM = (TextBox)gridViewAslRole.FooterRow.FindControl("txtCountryNM");
                //txtZONENM.Focus();
            }

            DropDownList ddlModuleName = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlModuleName");
            //DropDownList ddlMenuName = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlMenuName");
            //Label lblModuleIdFooter = (Label)gridViewAslRole.FooterRow.FindControl("lblModuleIdFooter");

            DatabaseFunctions.dropDownAddWithSelect(ddlModuleName, "SELECT MODULENM FROM MENUMST");

            //DatabaseFunctions.dropDownAddWithSelect(ddlMenuName, "SELECT MENUNM FROM MENU WHERE MODULEID='" + lblModuleIdFooter.Text + "'");
            ddlModuleName.Focus();
        }

        protected void gridViewAslRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                string empid = HttpContext.Current.Session["EmpID"].ToString();
                iob.UserID = HttpContext.Current.Session["UserName"].ToString();
                iob.UserPC = HttpContext.Current.Session["PCName"].ToString();
                iob.Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
                iob.ITime = DateTime.Now;

                if (e.CommandName.Equals("AddNew"))
                {
                    Label lblMenuIdFooter = (Label)gridViewAslRole.FooterRow.FindControl("lblMenuIdFooter");
                    Label lblModuleIdFooter = (Label)gridViewAslRole.FooterRow.FindControl("lblModuleIdFooter");

                    DropDownList ddlModuleName = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlModuleName");
                    DropDownList ddlMenuName = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlMenuName");
                    DropDownList ddlMenuType = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlMenuType");
                    DropDownList ddlStatus = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlStatus");
                    DropDownList ddlInsert = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlInsert");
                    DropDownList ddlUpdate = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlUpdate");
                    DropDownList ddlDelete = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlDelete");
                    //DropDownList ddlSpecial = (DropDownList)gridViewAslRole.FooterRow.FindControl("ddlSpecial");

                    iob.DeptID = "101";
                    iob.UserId = lblMemberId.Text;
                    iob.ModuleId = lblModuleIdFooter.Text;
                    iob.MenuId = lblMenuIdFooter.Text;
                    iob.MenuType = ddlMenuType.SelectedValue;

                    iob.Status = ddlStatus.SelectedValue;
                    iob.InsertRole = ddlInsert.SelectedValue;
                    iob.UpdateRole = ddlUpdate.SelectedValue;
                    iob.DeleteRole = ddlDelete.SelectedValue;
                    //iob.SpecialP = ddlSpecial.SelectedValue;

                    dob.INSERT_ROLE(iob);

                    ShowGridForAslRole();
                    ddlMenuType.Focus();

                }
            }
        }

        protected void gridViewAslRole_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                Label lblCompanyIdEdit = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblCompanyIdEdit");
                Label lblUserIdEdit = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblUserIdEdit");
                Label lblModuleIdEdit = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblModuleIdEdit");
                Label lblMenuIdEdit = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblMenuIdEdit");
                Label lblMenuTypeEdit = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblMenuTypeEdit");

                //DropDownList ddlMenuTypeEdit = (DropDownList)gridViewAslRole.Rows[e.RowIndex].FindControl("ddlMenuTypeEdit");
                DropDownList ddlStatusEdit = (DropDownList)gridViewAslRole.Rows[e.RowIndex].FindControl("ddlStatusEdit");
                DropDownList ddlInsertEdit = (DropDownList)gridViewAslRole.Rows[e.RowIndex].FindControl("ddlInsertEdit");
                DropDownList ddlUpdateEdit = (DropDownList)gridViewAslRole.Rows[e.RowIndex].FindControl("ddlUpdateEdit");
                DropDownList ddlDeleteEdit = (DropDownList)gridViewAslRole.Rows[e.RowIndex].FindControl("ddlDeleteEdit");
                //DropDownList ddlSpecialEdit = (DropDownList)gridViewAslRole.Rows[e.RowIndex].FindControl("ddlSpecialEdit");

                //TextBox txtLotiLongTude = (TextBox)Master.FindControl("txtLotiLongTude");
                //iob.LotiLengTudeUpdate = txtLotiLongTude.Text;
                string userName = HttpContext.Current.Session["UserName"].ToString();
                iob.UpdUserID = HttpContext.Current.Session["UserName"].ToString();
                iob.UPDUserPC = HttpContext.Current.Session["PCName"].ToString();
                iob.UPDIpaddress = HttpContext.Current.Session["IpAddress"].ToString();
                iob.UpdTime = DatabaseFunctions.Timezone(DateTime.Now);

                lblMenuTypeEdit.Text = "";
                DatabaseFunctions.lblAdd(@"SELECT MENUTP FROM ROLE WHERE USERID='" + lblMemberId.Text + "' And MODULEID='" + lblModuleIdEdit.Text + "' And MENUID='" + lblMenuIdEdit.Text + "'", lblMenuTypeEdit);

                iob.DeptID = "101";
                iob.UserId = lblMemberId.Text;
                iob.ModuleId = lblModuleIdEdit.Text;
                iob.MenuId = lblMenuIdEdit.Text;
                iob.MenuType = lblMenuTypeEdit.Text;

                iob.Status = ddlStatusEdit.SelectedValue;
                iob.InsertRole = ddlInsertEdit.SelectedValue;
                iob.UpdateRole = ddlUpdateEdit.SelectedValue;
                iob.DeleteRole = ddlDeleteEdit.SelectedValue;
                //iob.SpecialP = ddlSpecialEdit.SelectedValue;

                dob.UPDATE_ROLE(iob);

                gridViewAslRole.EditIndex = -1;
                ShowGridForAslRole();
            }
        }

        protected void gridViewAslRole_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                gridViewAslRole.EditIndex = e.NewEditIndex;
                ShowGridForAslRole();

                Label lblMemberIdEdit = (Label)gridViewAslRole.Rows[e.NewEditIndex].FindControl("lblMemberIdEdit");
                Label lblMenuIdEdit = (Label)gridViewAslRole.Rows[e.NewEditIndex].FindControl("lblMenuIdEdit");

                DropDownList ddlStatusEdit = (DropDownList)gridViewAslRole.Rows[e.NewEditIndex].FindControl("ddlStatusEdit");
                DropDownList ddlInsertEdit = (DropDownList)gridViewAslRole.Rows[e.NewEditIndex].FindControl("ddlInsertEdit");
                DropDownList ddlUpdateEdit = (DropDownList)gridViewAslRole.Rows[e.NewEditIndex].FindControl("ddlUpdateEdit");
                DropDownList ddlDeleteEdit = (DropDownList)gridViewAslRole.Rows[e.NewEditIndex].FindControl("ddlDeleteEdit");
                //DropDownList ddlSpecialEdit = (DropDownList)gridViewAslRole.Rows[e.NewEditIndex].FindControl("ddlSpecialEdit");

                ddlStatusEdit.Focus();

                string status = "";
                string insert = "";
                string update = "";
                string delete = "";
                //string SpecialP = "";
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT ROLE.STATUS, ROLE.INSERTR, ROLE.UPDATER, ROLE.DELETER
                FROM ROLE INNER JOIN MENUMST ON ROLE.MODULEID = MENUMST.MODULEID INNER JOIN
                MENU ON ROLE.MODULEID = MENU.MODULEID AND ROLE.MENUID = MENU.MENUID
                WHERE ROLE.INSUSERID=@USERID ", con);
                cmd.Parameters.AddWithValue("@USERID", lblMemberId.Text);
                //cmd.Parameters.AddWithValue("@MODULEID", lblMemberIdEdit.Text);
                //cmd.Parameters.AddWithValue("@MENUID", lblMenuIdEdit.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["STATUS"].ToString();
                    insert = dr["INSERTR"].ToString();
                    update = dr["UPDATER"].ToString();
                    delete = dr["DELETER"].ToString();
                    //SpecialP = dr["SPECIALP"].ToString();
                }
                dr.Close();
                con.Close();

                ddlStatusEdit.Text = status;
                ddlInsertEdit.Text = insert;
                ddlUpdateEdit.Text = update;
                ddlDeleteEdit.Text = delete;
                //ddlSpecialEdit.Text = SpecialP;
                lblMsg.Visible = false;
            }
        }

        protected void gridViewAslRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                Label lblModuleId = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblModuleId");
                Label lblMenuId = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblMenuId");
                Label lblMenuType = (Label)gridViewAslRole.Rows[e.RowIndex].FindControl("lblMenuType");

                lblMenuType.Text = "";
                DatabaseFunctions.lblAdd(
                    @"SELECT MENUTP FROM ROLE WHERE USERID='" + lblMemberId.Text + "' And MODULEID='" + lblModuleId.Text + "' And MENUID='" + lblMenuId.Text + "'", lblMenuType);

                iob.DeptID = "101";
                iob.UserId = lblMemberId.Text;
                iob.ModuleId = lblModuleId.Text;
                iob.MenuId = lblMenuId.Text;
                iob.MenuType = lblMenuType.Text;

                dob.DELETE_ROLE(iob);

                gridViewAslRole.EditIndex = -1;
                ShowGridForAslRole();
            }
        }

        protected void Refresh()
        {
            //txtModuleName.Text = "";
            //lblModuleID.Text = "";

            ShowGridForAslRole();
        }

        protected void gridViewAslRole_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                gridViewAslRole.EditIndex = -1;
                ShowGridForAslRole();
                lblMsg.Visible = false;
            }
        }

        protected void gridViewAslRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                gridViewAslRole.PageIndex = e.NewPageIndex;
                gridViewAslRole.DataBind();
                ShowGridForAslRole();
                lblMsg.Visible = false;
            }
        }


        protected void gridViewAslRole_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/user/Login.aspx");
            }
            else
            {
                DataTable dataTable = gridViewAslRole.DataSource as DataTable;

                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable);
                    dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                    gridViewAslRole.DataSource = dataView;
                    gridViewAslRole.DataBind();
                    ShowGridForAslRole();
                }
            }
        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }


    }
}