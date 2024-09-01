using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Yesbd;
using Yesbd.DynamicMenu.DataModel;

namespace Yesbd.DynamicMenu.DataAccess
{
    public class ICMSDataAccess 
    {
         SqlConnection con;
        SqlCommand cmd;

        public ICMSDataAccess()
        {
            con = new SqlConnection(DatabaseFunctions.connection);
            cmd = new SqlCommand("", con);
        }


        public string INSERT_COMPANY(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO COMPANY(ADDRESS,COMPID,COMPNM,CONTACTNO,EMAILID,INSIPNO,INSLTUDE,INSTIME,INSUSERID,STATUS,WEBID)
 				Values 
				(@ADDRESS,@COMPID,@COMPNM,@CONTACTNO,@EMAILID,@INSIPNO,@INSLTUDE,@INSTIME,@INSUSERID,@STATUS,@WEBID)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = ob.Address;
                cmd.Parameters.Add("@COMPID", SqlDbType.BigInt).Value = ob.CompanyId;
                cmd.Parameters.Add("@COMPNM", SqlDbType.NVarChar).Value = ob.ComapanyName;
                cmd.Parameters.Add("@CONTACTNO", SqlDbType.NVarChar).Value = ob.ContactNo;
                cmd.Parameters.Add("@EMAILID", SqlDbType.NVarChar).Value = ob.EmailId;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@WEBID", SqlDbType.NVarChar).Value = ob.WebId;

                cmd.Parameters.Add("@INSIPNO", SqlDbType.NVarChar).Value = ob.IpAddressInsert;
                cmd.Parameters.Add("@INSLTUDE", SqlDbType.NVarChar).Value = ob.LotiLengTudeInsert;
                cmd.Parameters.Add("@INSTIME", SqlDbType.DateTime).Value = ob.InTimeInsert;
                cmd.Parameters.Add("@INSUSERID", SqlDbType.BigInt).Value = ob.UserIdInsert;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }


        public string INSERT_USERCO(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO USERCO(COMPID,USERID,USERNM,DEPTNM,OPTP,ADDRESS,MOBNO,EMAILID,LOGINBY,LOGINID,LOGINPW,TIMEFR,TIMETO,STATUS,USERPC,INSUSERID,INSTIME,INSIPNO,INSLTUDE)
 				Values 
				(@COMPID,@USERID,@USERNM,@DEPTNM,@OPTP,@ADDRESS,@MOBNO,@EMAILID,@LOGINBY,@LOGINID,@LOGINPW,@TIMEFR,@TIMETO,@STATUS,@USERPC,@INSUSERID,@INSTIME,@INSIPNO,@INSLTUDE)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@COMPID", SqlDbType.BigInt).Value = ob.CompanyId;
                cmd.Parameters.Add("@USERID", SqlDbType.BigInt).Value = ob.CompanyUserId;
                cmd.Parameters.Add("@USERNM", SqlDbType.NVarChar).Value = ob.UserName;
                cmd.Parameters.Add("@DEPTNM", SqlDbType.NVarChar).Value = ob.DepartmentName;
                cmd.Parameters.Add("@OPTP", SqlDbType.NVarChar).Value = ob.OpType;
                cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = ob.Address;
                cmd.Parameters.Add("@MOBNO", SqlDbType.NVarChar).Value = ob.MobileNo;
                cmd.Parameters.Add("@EMAILID", SqlDbType.NVarChar).Value = ob.EmailId;
                cmd.Parameters.Add("@LOGINBY", SqlDbType.NVarChar).Value = ob.LogInBy;
                cmd.Parameters.Add("@LOGINID", SqlDbType.NVarChar).Value = ob.LogInId;
                cmd.Parameters.Add("@LOGINPW", SqlDbType.NVarChar).Value = ob.Password;
                cmd.Parameters.Add("@TIMEFR", SqlDbType.NVarChar).Value = ob.TimeFrom;
                cmd.Parameters.Add("@TIMETO", SqlDbType.NVarChar).Value = ob.TimeTo;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;

                cmd.Parameters.Add("@USERPC", SqlDbType.NVarChar).Value = ob.UserPcInsert;
                cmd.Parameters.Add("@INSIPNO", SqlDbType.NVarChar).Value = ob.IpAddressInsert;
                cmd.Parameters.Add("@INSLTUDE", SqlDbType.NVarChar).Value = ob.LotiLengTudeInsert;
                cmd.Parameters.Add("@INSTIME", SqlDbType.DateTime).Value = ob.InTimeInsert;
                cmd.Parameters.Add("@INSUSERID", SqlDbType.BigInt).Value = ob.UserIdInsert;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }



        public string INSERT_MENUMST(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO MENUMST(MODULEID, MODULENM, USERPC, INSUSERID, INSTIME, INSIPNO)
 				                    Values (@MODULEID, @MODULENM, @USERPC, @USERID, @INTIME, @IPADDRESS)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;
                cmd.Parameters.Add("@MODULENM", SqlDbType.NVarChar).Value = ob.ModuleName;
                cmd.Parameters.Add("@USERPC", SqlDbType.NVarChar).Value = ob.UserPC;
                cmd.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = ob.UserID;
                cmd.Parameters.Add("@INTIME", SqlDbType.SmallDateTime).Value = ob.ITime;
                cmd.Parameters.Add("@IPADDRESS", SqlDbType.NVarChar).Value = ob.Ipaddress;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }

        public string INSERT_MENU(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO MENU(MODULEID,MENUTP,MENUID,MENUNM, MENUSL, FLINK, USERPC, INSUSERID, INSTIME, INSIPNO)
 				                    Values (@MODULEID,@MENUTP,@MENUID,@MENUNM,@MENUSL,@FLINK,@USERPC,@USERID,@INTIME,@IPADDRESS)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;
                cmd.Parameters.Add("@MENUTP", SqlDbType.NVarChar).Value = ob.MenuType;
                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@MENUNM", SqlDbType.NVarChar).Value = ob.MenuName;
                cmd.Parameters.Add("@MENUSL", SqlDbType.Int).Value = ob.MenuSL;
                cmd.Parameters.Add("@FLINK", SqlDbType.NVarChar).Value = ob.MenuLink;
                cmd.Parameters.Add("@USERPC", SqlDbType.NVarChar).Value = ob.UserPC;
                cmd.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = ob.UserID;
                cmd.Parameters.Add("@INTIME", SqlDbType.SmallDateTime).Value = ob.ITime;
                cmd.Parameters.Add("@IPADDRESS", SqlDbType.NVarChar).Value = ob.Ipaddress;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }

        public string DELETE_MENUMST(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"DELETE FROM MENUMST WHERE MODULEID=@MODULEID ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }
        public string DELETE_MENU(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"DELETE FROM MENU WHERE MENUID=@MENUID AND MODULEID=@MODULEID ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }


        public string UPDATE_MENU(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE MENU SET MENUNM=@MENUNM, MENUSL=@MENUSL, FLINK=@FLINK, UPDUSERID=@UPDATEUSERID, 
                            UPDTIME=@UPDTIME, UPDIPNO=@UPDIPADDRESS WHERE MENUID=@MENUID AND MODULEID=@MODULEID ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MENUNM", SqlDbType.NVarChar).Value = ob.MenuName;
                cmd.Parameters.Add("@MENUSL", SqlDbType.Int).Value = ob.MenuSL;
                cmd.Parameters.Add("@FLINK", SqlDbType.NVarChar).Value = ob.MenuLink;
                //cmd.Parameters.Add("@UPDUSERPC", SqlDbType.NVarChar).Value = ob.UPDUserPC;
                cmd.Parameters.Add("@UPDATEUSERID", SqlDbType.NVarChar).Value = ob.UpdUserID;
                cmd.Parameters.Add("@UPDTIME", SqlDbType.SmallDateTime).Value = ob.UpdTime;
                cmd.Parameters.Add("@UPDIPADDRESS", SqlDbType.NVarChar).Value = ob.UPDIpaddress;

                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }


        public string INSERT_ROLE(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO ROLE(COMPID,USERID,MODULEID,MENUTP,MENUID,STATUS,INSERTR,UPDATER,DELETER, USERPC, INSUSERID, INSTIME, INSIPNO)
 				Values 
				(@COMPID,@USERID,@MODULEID,@MENUTP,@MENUID,@STATUS,@INSERTR,@UPDATER,@DELETER, @USERPC, @INSUSERID, @INTIME, @IPADDRESS)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@COMPID", SqlDbType.NVarChar).Value = ob.DeptID;
                cmd.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = ob.UserId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;
                cmd.Parameters.Add("@MENUTP", SqlDbType.NVarChar).Value = ob.MenuType;
                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@INSERTR", SqlDbType.NVarChar).Value = ob.InsertRole;
                cmd.Parameters.Add("@UPDATER", SqlDbType.NVarChar).Value = ob.UpdateRole;
                cmd.Parameters.Add("@DELETER", SqlDbType.NVarChar).Value = ob.DeleteRole;
                //cmd.Parameters.Add("@SPECIALP", SqlDbType.NVarChar).Value = ob.SpecialP;

                //cmd.Parameters.Add("@INSLTUDE", SqlDbType.NVarChar).Value = ob.LotiLengTudeInsert;
                cmd.Parameters.Add("@USERPC", SqlDbType.NVarChar).Value = ob.UserPC;
                cmd.Parameters.Add("@INSUSERID", SqlDbType.NVarChar).Value = ob.UserID;
                cmd.Parameters.Add("@INTIME", SqlDbType.SmallDateTime).Value = ob.ITime;
                cmd.Parameters.Add("@IPADDRESS", SqlDbType.NVarChar).Value = ob.Ipaddress;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }

        public string UPDATE_ROLE(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE ROLE SET STATUS=@STATUS, INSERTR=@INSERTR, UPDATER=@UPDATER, 
                DELETER=@DELETER, UPDUSERID=@UPDATEUSERID, UPDTIME=@UPDTIME, UPDIPNO=@UPDIPADDRESS 
                WHERE COMPID=@COMPID AND USERID=@USERID AND MODULEID=@MODULEID AND MENUID=@MENUID AND MENUTP=@MENUTP";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@INSERTR", SqlDbType.NVarChar).Value = ob.InsertRole;
                cmd.Parameters.Add("@UPDATER", SqlDbType.NVarChar).Value = ob.UpdateRole;
                cmd.Parameters.Add("@DELETER", SqlDbType.NVarChar).Value = ob.DeleteRole;
                //cmd.Parameters.Add("@SPECIALP", SqlDbType.NVarChar).Value = ob.SpecialP;

                //cmd.Parameters.Add("@UPDUSERPC", SqlDbType.NVarChar).Value = ob.UPDUserPC;
                cmd.Parameters.Add("@UPDATEUSERID", SqlDbType.NVarChar).Value = ob.UpdUserID;
                cmd.Parameters.Add("@UPDTIME", SqlDbType.SmallDateTime).Value = ob.UpdTime;
                cmd.Parameters.Add("@UPDIPADDRESS", SqlDbType.NVarChar).Value = ob.UPDIpaddress;
                //cmd.Parameters.Add("@UPDLTUDE", SqlDbType.NVarChar).Value = ob.LotiLengTudeUpdate;

                cmd.Parameters.Add("@COMPID", SqlDbType.NVarChar).Value = ob.DeptID;
                cmd.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = ob.UserId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;
                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@MENUTP", SqlDbType.NVarChar).Value = ob.MenuType;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }

        public string DELETE_ROLE(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"DELETE FROM ROLE WHERE COMPID=@COMPID AND MODULEID=@MODULEID  
                        AND MENUTP=@MENUTP AND MENUID=@MENUID AND USERID=@USERID";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@COMPID", SqlDbType.NVarChar).Value = ob.DeptID;
                cmd.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = ob.UserId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;
                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@MENUTP", SqlDbType.NVarChar).Value = ob.MenuType;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }

        public string UPDATE_ROLE_HLOE_COMPANY(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE ROLE SET STATUS=@STATUS,INSERTR=@INSERTR,UPDATER=@UPDATER, 
                DELETER=@DELETER, UPDUSERID=@UPDUSERID,UPDTIME=@UPDTIME,UPDIPNO=@UPDIPNO 
                WHERE COMPID=@COMPID AND MODULEID=@MODULEID AND MENUID=@MENUID AND MENUTP=@MENUTP";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@INSERTR", SqlDbType.NVarChar).Value = ob.InsertRole;
                cmd.Parameters.Add("@UPDATER", SqlDbType.NVarChar).Value = ob.UpdateRole;
                cmd.Parameters.Add("@DELETER", SqlDbType.NVarChar).Value = ob.DeleteRole;

                cmd.Parameters.Add("@COMPID", SqlDbType.Int).Value = ob.CompanyId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;
                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@MENUTP", SqlDbType.NVarChar).Value = ob.MenuType;

                cmd.Parameters.Add("@UPDUSERID", SqlDbType.BigInt).Value = ob.UserIdUpdate;
                cmd.Parameters.Add("@UPDTIME", SqlDbType.DateTime).Value = ob.InTimeUpdate;
                cmd.Parameters.Add("@UPDIPNO", SqlDbType.NVarChar).Value = ob.IpAddressUpdate;
                //cmd.Parameters.Add("@UPDLTUDE", SqlDbType.NVarChar).Value = ob.LotiLengTudeUpdate;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }

        public string INSERT_LOG(ICMSDataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO LOG(COMPID,USERID,LOGTYPE,LOGSLNO,LOGDT,LOGTIME,LOGIPNO,LOGLTUDE,TABLEID,LOGDATA,USERPC)
 				Values 
				(@COMPID,@USERID,@LOGTYPE,@LOGSLNO,@LOGDT,@LOGTIME,@LOGIPNO,@LOGLTUDE,@TABLEID,@LOGDATA,@USERPC)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@COMPID", SqlDbType.BigInt).Value = ob.CompanyId;
                cmd.Parameters.Add("@USERID", SqlDbType.BigInt).Value = ob.CompanyUserId;
                cmd.Parameters.Add("@LOGTYPE", SqlDbType.NVarChar).Value = ob.LogType;
                cmd.Parameters.Add("@LOGSLNO", SqlDbType.BigInt).Value = ob.LogSlNo;
                cmd.Parameters.Add("@TABLEID", SqlDbType.NVarChar).Value = ob.TableId;
                cmd.Parameters.Add("@LOGDATA", SqlDbType.NVarChar).Value = ob.LogData;

                cmd.Parameters.Add("@LOGDT", SqlDbType.DateTime).Value = ob.InTimeInsert;
                cmd.Parameters.Add("@LOGTIME", SqlDbType.DateTime).Value = ob.InTimeInsert;
                cmd.Parameters.Add("@LOGIPNO", SqlDbType.NVarChar).Value = ob.IpAddressInsert;
                cmd.Parameters.Add("@LOGLTUDE", SqlDbType.NVarChar).Value = ob.LotiLengTudeInsert;
                cmd.Parameters.Add("@USERPC", SqlDbType.NVarChar).Value = ob.UserPcInsert;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }
    }
}