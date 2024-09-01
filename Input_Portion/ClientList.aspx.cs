using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Yesbd.Input_Portion
{
    public partial class ClientList : System.Web.UI.Page
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
                string formLink = "/Input_Portion/ClientList.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        ShowClientData();
                    }
                }
                else
                {
                    Response.Redirect("../../home_default.aspx");
                }
            }
            

            //if (!IsPostBack)
            //{
            //    ShowClientData();
            //}
        }


        private void ShowClientData()
        {
            try
            {
                //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(DatabaseFunctions.connection))
                {
                    // Assign the query string before creating the SqlCommand object
                    string query = "";
                    query = $@"SET DATEFORMAT dmy; SELECT * FROM [dbo].[CLIENT] WHERE 1=1";

                    if (txtsearch.Text.Trim() != "" && !string.IsNullOrEmpty(txtsearch.Text.Trim()))
                    {
                        query += $@" AND (CLIENTNM LIKE N'%{txtsearch.Text.Trim()}%' 
                                     OR MOBNO LIKE N'%{txtsearch.Text.Trim()}%'
                                     OR TELNO LIKE N'%{txtsearch.Text.Trim()}%'
                                     OR VEHICLENO LIKE N'%{txtsearch.Text.Trim()}%')";
                    }

                    if (!string.IsNullOrEmpty(ddlStatus.SelectedValue) && ddlStatus.SelectedValue != "0")
                    {
                        query += $@" AND LOANSTATUS= '{ddlStatus.SelectedValue}' ";
                    }

                    query += " ORDER BY  TRANSDT DESC, CLIENTNM ASC  ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                lstClientList.DataSource = dt;
                                lstClientList.DataBind();
                            }
                            else
                            {
                                lstClientList.DataSource = null;
                                lstClientList.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                var msg = exp.Message;
            }

        }


        protected void lstClientList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstClientList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ShowClientData();
        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            ShowClientData();
        }


        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ddlStatus.SelectedIndex = -1;
            ShowClientData();
        }


        //protected void ShowData()
        //{
        //    //if (CookiesData == null)
        //    //{
        //    //    Response.Redirect("~/login.aspx");
        //    //}
        //    //else
        //    //{
        //    //userID = CookiesData["USERID"].ToString();
        //    //fingerId = DbFunction.StringData($@"SELECT FINGERID FROM EMPLOYEEOFFICIAL WHERE EMPID={userID}");

        //    //var fromDate = DateTime.Parse(txtFromDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    //var toDate = DateTime.Parse(txtToDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);

        //    conn.Open();
        //    string Query = "";
        //    Query = $@"Set Dateformat dmy SELECT * FROM [dbo].[CLIENT] WHERE 1=1 ";

        //    //if (!string.IsNullOrEmpty(ddlApprovalStatus.SelectedValue))
        //    //{
        //    //    Query += $@" AND (LEAVEINFO.FINALAPPROVALSTATUS = '{ddlApprovalStatus.SelectedValue}') ";
        //    //}

        //    //if (!string.IsNullOrEmpty(fingerId))
        //    //{
        //    //    Query += $@" AND FINALAPPROVALID={fingerId} ";
        //    //}

        //    //if (txtSearchEmpId.Text != "")
        //    //{
        //    //    Query += $@" AND FINGERID={txtSearchEmpId.Text} ";
        //    //}

        //    //if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        //    //{
        //    //    Query += $@" AND (LEAVEFROM BETWEEN '{txtFromDate.Text.Trim()}' AND '{txtToDate.Text.Trim()}' 
        //    //                 OR LEAVETO BETWEEN '{txtFromDate.Text.Trim()}' AND '{txtToDate.Text.Trim()}')";
        //    //}

        //    //Query += " ORDER BY  LEAVEINFO.LEAVEFROM DESC  ";


        //    SqlCommand cmd = new SqlCommand();
        //    cmd = new SqlCommand(Query, conn);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();

        //    da = new SqlDataAdapter(cmd);
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        lstClientList.Visible = true;
        //        lstClientList.DataSource = ds;
        //        lstClientList.DataBind();

        //        //TextBox txtItemNM = (TextBox)gvLeaveApproval.data.FindControl("txtItemNM");
        //    }
        //    else
        //    {
        //        //lstClientList.Visible = true;
        //        //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //        //lstClientList.DataSource = ds;
        //        //lstClientList.DataBind();
        //        //int columncount = lstClientList.Rows[0].Cells.Count;
        //        //lstClientList.Rows[0].Cells.Clear();
        //        //lstClientList.Rows[0].Cells.Add(new TableCell());
        //        //lstClientList.Rows[0].Cells[0].ColumnSpan = columncount;
        //        //lstClientList.Rows[0].Cells[0].Text = "No Records Found";
        //    }
        //    //}
        //}



        //[System.Web.Services.WebMethod()]
        //public static string GetBannerById(int start, int length, string unitId, int vehicleNo, string costType, string subCostType, string fromDate, string toDate)
        //{
        //    var s = "";
        //    //var banner = new Banner();
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //    //conn.Open();
        //    //var selectString = "SELECT  top 1 * FROM Banners Where  BannerId=@s";
        //    //SqlCommand cmd = new SqlCommand(selectString, conn);
        //    //cmd.Parameters.Add("@s", SqlDbType.Int).Value = BannerId;
        //    //SqlDataReader reader = cmd.ExecuteReader();
        //    //while (reader.Read())
        //    //{
        //    //    banner.hidBannerID = reader["BannerId"].ToString();
        //    //    banner.txtBannerTitle = reader["BannerTitle"].ToString();
        //    //    banner.txtArBannerTitle = reader["ArBannerTitle"].ToString();
        //    //    banner.chkActiveBanner = reader["Status"].ToString();
        //    //    banner.Image = reader["Image"].ToString();
        //    //}

        //    //reader.Close();
        //    //conn.Close();

        //    //int column = Convert.ToInt32(HttpContext.Request.Form["order[0][column]"]);
        //    //string direction = HttpContext.Request.Form["order[0][dir]"].ToString();
        //    //try
        //    //{

        //    //    Datable datable = new Datable();
        //    //    List<Expenditure> expenditures = VExpenditureGateway.GetExpenditure(1, unitId, vehicleNo, costType, subCostType, fromDate, toDate, direction, column, start, length);
        //    //    datable.recordsTotal = expenditures.Count() > 0 ? expenditures[0].Total : 0;
        //    //    datable.recordsFiltered = expenditures.Count() > 0 ? expenditures[0].Total : 0;
        //    //    datable.expenditures = expenditures;
        //    //    return datable;
        //    //}
        //    //catch
        //    //{
        //    //    return RedirectToAction("Index", "VExpenditure");
        //    //}



        //    return s;
        //}


        ///////Recept Start
        ////[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        ////public static string[] GetCompletionListMrecD(string prefixText, int count, string contextKey)
        ////{
        ////    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
        ////    SqlConnection conn = new SqlConnection(connectionString);
        ////    // Try to use parameterized inline query/sp to protect sql injection
        ////    SqlCommand cmd = new SqlCommand("SELECT ACCOUNTNM FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE '" + prefixText + "%'", conn);
        ////    SqlDataReader oReader;
        ////    conn.Open();
        ////    List<String> CompletionSet = new List<string>();
        ////    oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        ////    while (oReader.Read())
        ////        CompletionSet.Add(oReader["ACCOUNTNM"].ToString());
        ////    return CompletionSet.ToArray();
        ////}


    }
}