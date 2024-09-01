using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Yesbd;
using Yesbd.Input_Portion;
using System.Data;

namespace Yesbd.Input_Portion
{
    public class DataAccess
    {
        SqlConnection con;
        SqlCommand cmd;

        public DataAccess()
        {
            con = new SqlConnection(DatabaseFunctions.connection);
            cmd = new SqlCommand("", con);
        }

        public string InsertEmpInfoEmp(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"insert into EMPLOYEE (EMPID, EMPNM, EMPSNM, FATHERNM, MOTHERNM, ADDRPRE, ADDRPER, TELNO, MOBNO,
                                EMAIL, VOTERID, BLOODGR, MSTATUS, LOGINTP, LOGINBY, LOGINID, LOGINPW, REMARKS, STATUS, USERPC, USERID, INTIME, IPADDRESS) 
                  values(@EMPID, @EMPNM, @EMPSNM, @FATHERNM, @MOTHERNM, @ADDRPRE, @ADDRPER, @TELNO, @MOBNO, @EMAIL, @VOTERID, @BLOODGR, @MSTATUS, 
                            @LOGINTP, @LOGINBY, @LOGINID, @LOGINPW, @REMARKS, @STATUS, @USERPC, @USERID, @INTIME, @IPADDRESS)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@EMPID", SqlDbType.NVarChar).Value = ob.EmpID;
                cmd.Parameters.Add("@EMPNM", SqlDbType.NVarChar).Value = ob.EmpNM;
                cmd.Parameters.Add("@EMPSNM", SqlDbType.NVarChar).Value = ob.SpNM;
                cmd.Parameters.Add("@FATHERNM", SqlDbType.NVarChar).Value = ob.FthrNM;
                cmd.Parameters.Add("@MOTHERNM", SqlDbType.NVarChar).Value = ob.MthrNM;
                cmd.Parameters.Add("@ADDRPRE", SqlDbType.NVarChar).Value = ob.PreAdd;
                cmd.Parameters.Add("@ADDRPER", SqlDbType.NVarChar).Value = ob.PerAdd;
                cmd.Parameters.Add("@TELNO", SqlDbType.NVarChar).Value = ob.TelNo;
                cmd.Parameters.Add("@MOBNO", SqlDbType.NVarChar).Value = ob.MobileNO;
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = ob.Email;
                cmd.Parameters.Add("@VOTERID", SqlDbType.NVarChar).Value = ob.VoterID;
                cmd.Parameters.Add("@BLOODGR", SqlDbType.NVarChar).Value = ob.BloodGRP;
                cmd.Parameters.Add("@MSTATUS", SqlDbType.NVarChar).Value = ob.MStatus;
                cmd.Parameters.Add("@LOGINTP", SqlDbType.NVarChar).Value = ob.LoginTP;
                cmd.Parameters.Add("@LOGINBY", SqlDbType.NVarChar).Value = ob.LoginBY;
                cmd.Parameters.Add("@LOGINID", SqlDbType.NVarChar).Value = ob.LoginID;
                cmd.Parameters.Add("@LOGINPW", SqlDbType.NVarChar).Value = ob.LoginPss;
                cmd.Parameters.Add("@REMARKS", SqlDbType.NVarChar).Value = ob.Remarks;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
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

        public string UpdateEmpInfoEmp(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"update EMPLOYEE set EMPNM=@EMPNM, EMPSNM=@EMPSNM, FATHERNM=@FATHERNM, MOTHERNM=@MOTHERNM, ADDRPRE=@ADDRPRE, ADDRPER=@ADDRPER, 
                                            TELNO=@TELNO, MOBNO=@MOBNO, EMAIL=@EMAIL, VOTERID=@VOTERID, BLOODGR=@BLOODGR, MSTATUS=@MSTATUS,
                                            LOGINTP=@LOGINTP, LOGINBY=@LOGINBY, LOGINID=@LOGINID, REMARKS=@REMARKS, 
                                            STATUS=@STATUS, UPDUSERPC=@UPDUSERPC, UPDATEUSERID=@UPDATEUSERID, UPDTIME=@UPDTIME, UPDIPADDRESS=@UPDIPADDRESS Where EMPID=@EMPID ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@EMPNM", SqlDbType.NVarChar).Value = ob.EmpNM;
                cmd.Parameters.Add("@EMPSNM", SqlDbType.NVarChar).Value = ob.SpNM;
                cmd.Parameters.Add("@FATHERNM", SqlDbType.NVarChar).Value = ob.FthrNM;
                cmd.Parameters.Add("@MOTHERNM", SqlDbType.NVarChar).Value = ob.MthrNM;
                cmd.Parameters.Add("@ADDRPRE", SqlDbType.NVarChar).Value = ob.PreAdd;
                cmd.Parameters.Add("@ADDRPER", SqlDbType.NVarChar).Value = ob.PerAdd;
                cmd.Parameters.Add("@TELNO", SqlDbType.NVarChar).Value = ob.TelNo;
                cmd.Parameters.Add("@MOBNO", SqlDbType.NVarChar).Value = ob.MobileNO;
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = ob.Email;
                cmd.Parameters.Add("@VOTERID", SqlDbType.NVarChar).Value = ob.VoterID;
                cmd.Parameters.Add("@BLOODGR", SqlDbType.NVarChar).Value = ob.BloodGRP;
                cmd.Parameters.Add("@MSTATUS", SqlDbType.NVarChar).Value = ob.MStatus;
                cmd.Parameters.Add("@LOGINTP", SqlDbType.NVarChar).Value = ob.LoginTP;
                cmd.Parameters.Add("@LOGINBY", SqlDbType.NVarChar).Value = ob.LoginBY;
                cmd.Parameters.Add("@LOGINID", SqlDbType.NVarChar).Value = ob.LoginID;
                //cmd.Parameters.Add("@LOGINPW", SqlDbType.NVarChar).Value = ob.LoginPss;
                cmd.Parameters.Add("@REMARKS", SqlDbType.NVarChar).Value = ob.Remarks;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@UPDUSERPC", SqlDbType.NVarChar).Value = ob.UPDUserPC;
                cmd.Parameters.Add("@UPDATEUSERID", SqlDbType.NVarChar).Value = ob.UpdUserID;
                cmd.Parameters.Add("@UPDTIME", SqlDbType.SmallDateTime).Value = ob.UpdTime;
                cmd.Parameters.Add("@UPDIPADDRESS", SqlDbType.NVarChar).Value = ob.UPDIpaddress;
                cmd.Parameters.Add("@EMPID", SqlDbType.NVarChar).Value = ob.EmpID;

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

        public string INSERT_ROLE(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO ROLE(COMPID,USERID,MODULEID,MENUTP,MENUID,STATUS,INSERTR,UPDATER,DELETER,USERPC,INSUSERID,INSTIME,INSIPNO)
 				                Values (@COMPID,@USERID,@MODULEID,@MENUTP,@MENUID,@STATUS,@INSERTR,@UPDATER,@DELETER,@USERPC,@INSUSERID,@INSTIME,@INSIPNO)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@COMPID", SqlDbType.BigInt).Value = "101";
                cmd.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = ob.EmpID;
                cmd.Parameters.Add("@MODULEID", SqlDbType.NVarChar).Value = ob.ModuleId;
                cmd.Parameters.Add("@MENUTP", SqlDbType.NVarChar).Value = ob.MenuType;
                cmd.Parameters.Add("@MENUID", SqlDbType.NVarChar).Value = ob.MenuId;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@INSERTR", SqlDbType.NVarChar).Value = ob.InsertRole;
                cmd.Parameters.Add("@UPDATER", SqlDbType.NVarChar).Value = ob.UpdateRole;
                cmd.Parameters.Add("@DELETER", SqlDbType.NVarChar).Value = ob.DeleteRole;

                cmd.Parameters.Add("@USERPC", SqlDbType.NVarChar).Value = ob.UserPC;
                cmd.Parameters.Add("@INSIPNO", SqlDbType.NVarChar).Value = ob.Ipaddress;
                cmd.Parameters.Add("@INSTIME", SqlDbType.DateTime).Value = ob.ITime;
                cmd.Parameters.Add("@INSUSERID", SqlDbType.NVarChar).Value = ob.UserID;

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


        /////....................................Client Information.............................///////

        public string InsertClientInfo(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"insert into CLIENT (TRANSDT, LOANDURATION, LOANAMOUNT, MONTHLYRENT, DUEAMOUNT, CLIENTID, INVREFNO, CLIENTNM, CLIENTAGE, FATHERNM, MOTHERNM, 
                                    SPOUSENM, GIRL, BOY, NOMINEENM, RELATION, HOUSE, WARD, VILLAGE, TOWNSHIP, POSTOFFICE, POLICESTAT, DISTRICT, TELNO, MOBNO, MOBNO_HOME, 
                                    CONTACTADD, IMGCLIENT, IMGNOMINEE, CLIENTPAYABLE, CLIENTTYPE, PREACCNO, VEHICLENO, VEHICLETYPE, STATUS, LOANSTATUS, DUEDATE, COMPANYPAYABLE, COMPANYPAYABLE_INWARDS,
                                    MONTHLYINSTALLMENT, CLIENTACCNO, LOANAMOUNT_INWARDS, MONTHLYRENT_INWARDS, DUEAMOUNT_INWARDS, MONTHLYINSTALLMENT_INWARDS, CLIENTPAYABLE_INWARDS, USERPC, USERID, INTIME, IPADDRESS) 
                                values(@TRANSDT, @LOANDURATION, @LOANAMOUNT, @MONTHLYRENT, @DUEAMOUNT, @CLIENTID, @INVREFNO, @CLIENTNM, @CLIENTAGE, @FATHERNM, @MOTHERNM, 
                                    @SPOUSENM, @GIRL, @BOY, @NOMINEENM, @RELATION, @HOUSE, @WARD, @VILLAGE, @TOWNSHIP, @POSTOFFICE, @POLICESTAT, @DISTRICT, @TELNO, @MOBNO, @MOBNO_HOME, 
                                    @CONTACTADD, @IMGCLIENT, @IMGNOMINEE, @CLIENTPAYABLE, @CLIENTTYPE, @PREACCNO, @VEHICLENO, @VEHICLETYPE, @STATUS, @LOANSTATUS, @DUEDATE, @COMPANYPAYABLE, @COMPANYPAYABLE_INWARDS,
                                    @MONTHLYINSTALLMENT, @CLIENTACCNO, @LOANAMOUNT_INWARDS, @MONTHLYRENT_INWARDS, @DUEAMOUNT_INWARDS, @MONTHLYINSTALLMENT_INWARDS, @CLIENTPAYABLE_INWARDS, @USERPC, @USERID, @INTIME, @IPADDRESS)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@TRANSDT", SqlDbType.SmallDateTime).Value = ob.Date;
                cmd.Parameters.Add("@LOANDURATION", SqlDbType.NVarChar).Value = ob.Loanduration;
                cmd.Parameters.Add("@LOANAMOUNT", SqlDbType.Decimal).Value = ob.LoandAmount;
                cmd.Parameters.Add("@MONTHLYRENT", SqlDbType.Decimal).Value = ob.MonthlyRent;
                cmd.Parameters.Add("@DUEAMOUNT", SqlDbType.Decimal).Value = ob.DueAmt;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.NVarChar).Value = ob.ClientID;
                cmd.Parameters.Add("@INVREFNO", SqlDbType.NVarChar).Value = ob.invoiceno;
                cmd.Parameters.Add("@CLIENTNM", SqlDbType.NVarChar).Value = ob.ClntNM;
                cmd.Parameters.Add("@CLIENTAGE", SqlDbType.NVarChar).Value = ob.Clientage;
                cmd.Parameters.Add("@FATHERNM", SqlDbType.NVarChar).Value = ob.FthrNM;
                cmd.Parameters.Add("@MOTHERNM", SqlDbType.NVarChar).Value = ob.MthrNM;
                cmd.Parameters.Add("@SPOUSENM", SqlDbType.NVarChar).Value = ob.SpNM;
                cmd.Parameters.Add("@GIRL", SqlDbType.NVarChar).Value = ob.Girl;
                cmd.Parameters.Add("@BOY", SqlDbType.NVarChar).Value = ob.Boy;
                cmd.Parameters.Add("@NOMINEENM", SqlDbType.NVarChar).Value = ob.Nominee;
                cmd.Parameters.Add("@RELATION", SqlDbType.NVarChar).Value = ob.Relation;
                cmd.Parameters.Add("@HOUSE", SqlDbType.NVarChar).Value = ob.House;
                cmd.Parameters.Add("@WARD", SqlDbType.NVarChar).Value = ob.Ward;
                cmd.Parameters.Add("@VILLAGE", SqlDbType.NVarChar).Value = ob.Village;
                cmd.Parameters.Add("@TOWNSHIP", SqlDbType.NVarChar).Value = ob.Township;
                cmd.Parameters.Add("@POSTOFFICE", SqlDbType.NVarChar).Value = ob.PostOffice;
                cmd.Parameters.Add("@POLICESTAT", SqlDbType.NVarChar).Value = ob.PoliceS;
                cmd.Parameters.Add("@DISTRICT", SqlDbType.NVarChar).Value = ob.District;
                cmd.Parameters.Add("@TELNO", SqlDbType.NVarChar).Value = ob.TelNo;
                cmd.Parameters.Add("@MOBNO", SqlDbType.NVarChar).Value = ob.MobileNO;
                cmd.Parameters.Add("@MOBNO_HOME", SqlDbType.NVarChar).Value = ob.MobNoHome;
                cmd.Parameters.Add("@CONTACTADD", SqlDbType.NVarChar).Value = ob.ContactAdd;
                cmd.Parameters.Add("@IMGCLIENT", SqlDbType.NVarChar).Value = ob.filenameclient;
                cmd.Parameters.Add("@IMGNOMINEE", SqlDbType.NVarChar).Value = ob.filenameominee;
                cmd.Parameters.Add("@CLIENTPAYABLE", SqlDbType.Decimal).Value = ob.ClientPayable;
                cmd.Parameters.Add("@CLIENTTYPE", SqlDbType.NVarChar).Value = ob.ClientType;
                cmd.Parameters.Add("@PREACCNO", SqlDbType.NVarChar).Value = ob.PreAccNo;
                cmd.Parameters.Add("@VEHICLENO", SqlDbType.NVarChar).Value = ob.VehicleNo;
                cmd.Parameters.Add("@VEHICLETYPE", SqlDbType.NVarChar).Value = ob.VehicleType;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@LOANSTATUS", SqlDbType.NVarChar).Value = ob.LoanStatus;

                cmd.Parameters.Add("@DUEDATE", SqlDbType.SmallDateTime).Value = ob.DueDate;
                cmd.Parameters.Add("@COMPANYPAYABLE", SqlDbType.Decimal).Value = ob.CompnayPayable;
                cmd.Parameters.Add("@COMPANYPAYABLE_INWARDS", SqlDbType.NVarChar).Value = ob.CompnayPayable_Inwards;
                cmd.Parameters.Add("@MONTHLYINSTALLMENT", SqlDbType.NVarChar).Value = ob.MonthlyInstallment_str;
                cmd.Parameters.Add("@CLIENTACCNO", SqlDbType.NVarChar).Value = ob.ClientAccNo;

                cmd.Parameters.Add("@LOANAMOUNT_INWARDS", SqlDbType.NVarChar).Value = ob.LoanAmount_Inwards;
                cmd.Parameters.Add("@MONTHLYRENT_INWARDS", SqlDbType.NVarChar).Value = ob.MonthlyRent_Inwards;
                cmd.Parameters.Add("@DUEAMOUNT_INWARDS", SqlDbType.NVarChar).Value = ob.DueAmt_Inwards;
                cmd.Parameters.Add("@MONTHLYINSTALLMENT_INWARDS", SqlDbType.NVarChar).Value = ob.MonthlyInstallment_Inwards;
                cmd.Parameters.Add("@CLIENTPAYABLE_INWARDS", SqlDbType.NVarChar).Value = ob.ClientPayable_Inwards;
                

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

        public string UpdateClientInfo(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"update CLIENT set TRANSDT=@TRANSDT, LOANDURATION=@LOANDURATION, LOANAMOUNT=@LOANAMOUNT, CLIENTID=@CLIENTID, INVREFNO=@INVREFNO, CLIENTNM=@CLIENTNM, CLIENTAGE=@CLIENTAGE, FATHERNM=@FATHERNM, 
                                    MOTHERNM=@MOTHERNM, SPOUSENM=@SPOUSENM, GIRL=@GIRL, BOY=@BOY, NOMINEENM=@NOMINEENM, RELATION=@RELATION, HOUSE=@HOUSE, WARD=@WARD, VILLAGE=@VILLAGE, TOWNSHIP=@TOWNSHIP, POLICESTAT=@POLICESTAT, 
                                    DISTRICT=@DISTRICT, TELNO=@TELNO, MOBNO=@MOBNO, CONTACTADD=@CONTACTADD, IMGCLIENT=@IMGCLIENT, IMGNOMINEE=@IMGNOMINEE, MONTHLYRENT=@MONTHLYRENT, DUEAMOUNT=@DUEAMOUNT, POSTOFFICE=@POSTOFFICE, 
                                    MOBNO_HOME=@MOBNO_HOME, CLIENTPAYABLE=@CLIENTPAYABLE, CLIENTTYPE=@CLIENTTYPE, PREACCNO=@PREACCNO, VEHICLENO=@VEHICLENO, VEHICLETYPE=@VEHICLETYPE, STATUS=@STATUS, LOANSTATUS=@LOANSTATUS, 
                                    DUEDATE=@DUEDATE, MONTHLYINSTALLMENT=@MONTHLYINSTALLMENT, CLIENTACCNO=@CLIENTACCNO, LOANAMOUNT_INWARDS=@LOANAMOUNT_INWARDS, MONTHLYRENT_INWARDS=@MONTHLYRENT_INWARDS, 
                                    DUEAMOUNT_INWARDS=@DUEAMOUNT_INWARDS, MONTHLYINSTALLMENT_INWARDS=@MONTHLYINSTALLMENT_INWARDS, CLIENTPAYABLE_INWARDS=@CLIENTPAYABLE_INWARDS, COMPANYPAYABLE=@COMPANYPAYABLE, COMPANYPAYABLE_INWARDS=@COMPANYPAYABLE_INWARDS,
                                    UPDUSERPC=@UPDUSERPC, UPDATEUSERID=@UPDATEUSERID, UPDTIME=@UPDTIME, UPDIPADDRESS=@UPDIPADDRESS Where CLIENTID=@CLIENTID ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@TRANSDT", SqlDbType.SmallDateTime).Value = ob.Date;
                cmd.Parameters.Add("@LOANDURATION", SqlDbType.NVarChar).Value = ob.Loanduration;
                cmd.Parameters.Add("@LOANAMOUNT", SqlDbType.Decimal).Value = ob.LoandAmount;
                cmd.Parameters.Add("@INVREFNO", SqlDbType.NVarChar).Value = ob.invoiceno;
                cmd.Parameters.Add("@CLIENTNM", SqlDbType.NVarChar).Value = ob.ClntNM;
                cmd.Parameters.Add("@CLIENTAGE", SqlDbType.NVarChar).Value = ob.Clientage;
                cmd.Parameters.Add("@FATHERNM", SqlDbType.NVarChar).Value = ob.FthrNM;
                cmd.Parameters.Add("@MOTHERNM", SqlDbType.NVarChar).Value = ob.MthrNM;
                cmd.Parameters.Add("@SPOUSENM", SqlDbType.NVarChar).Value = ob.SpNM;
                cmd.Parameters.Add("@GIRL", SqlDbType.NVarChar).Value = ob.Girl;
                cmd.Parameters.Add("@BOY", SqlDbType.NVarChar).Value = ob.Boy;
                cmd.Parameters.Add("@NOMINEENM", SqlDbType.NVarChar).Value = ob.Nominee;
                cmd.Parameters.Add("@RELATION", SqlDbType.NVarChar).Value = ob.Relation;
                cmd.Parameters.Add("@HOUSE", SqlDbType.NVarChar).Value = ob.House;
                cmd.Parameters.Add("@WARD", SqlDbType.NVarChar).Value = ob.Ward;
                cmd.Parameters.Add("@VILLAGE", SqlDbType.NVarChar).Value = ob.Village;
                cmd.Parameters.Add("@TOWNSHIP", SqlDbType.NVarChar).Value = ob.Township;
                cmd.Parameters.Add("@POLICESTAT", SqlDbType.NVarChar).Value = ob.PoliceS;
                cmd.Parameters.Add("@DISTRICT", SqlDbType.NVarChar).Value = ob.District;
                cmd.Parameters.Add("@TELNO", SqlDbType.NVarChar).Value = ob.TelNo;
                cmd.Parameters.Add("@MOBNO", SqlDbType.NVarChar).Value = ob.MobileNO;
                cmd.Parameters.Add("@CONTACTADD", SqlDbType.NVarChar).Value = ob.ContactAdd;
                cmd.Parameters.Add("@IMGCLIENT", SqlDbType.NVarChar).Value = ob.filenameclient;
                cmd.Parameters.Add("@IMGNOMINEE", SqlDbType.NVarChar).Value = ob.filenameominee;
                cmd.Parameters.Add("@MONTHLYRENT", SqlDbType.Decimal).Value = ob.MonthlyRent;
                cmd.Parameters.Add("@DUEAMOUNT", SqlDbType.Decimal).Value = ob.DueAmt;
                cmd.Parameters.Add("@POSTOFFICE", SqlDbType.NVarChar).Value = ob.PostOffice;
                cmd.Parameters.Add("@MOBNO_HOME", SqlDbType.NVarChar).Value = ob.MobNoHome;
                cmd.Parameters.Add("@CLIENTPAYABLE", SqlDbType.Decimal).Value = ob.ClientPayable;
                cmd.Parameters.Add("@CLIENTTYPE", SqlDbType.NVarChar).Value = ob.ClientType;
                cmd.Parameters.Add("@PREACCNO", SqlDbType.NVarChar).Value = ob.PreAccNo;
                cmd.Parameters.Add("@VEHICLENO", SqlDbType.NVarChar).Value = ob.VehicleNo;
                cmd.Parameters.Add("@VEHICLETYPE", SqlDbType.NVarChar).Value = ob.VehicleType;
                cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = ob.Status;
                cmd.Parameters.Add("@LOANSTATUS", SqlDbType.NVarChar).Value = ob.LoanStatus;

                cmd.Parameters.Add("@DUEDATE", SqlDbType.SmallDateTime).Value = ob.DueDate;
                cmd.Parameters.Add("@MONTHLYINSTALLMENT", SqlDbType.NVarChar).Value = ob.MonthlyInstallment_str;
                cmd.Parameters.Add("@CLIENTACCNO", SqlDbType.NVarChar).Value = ob.ClientAccNo;

                cmd.Parameters.Add("@LOANAMOUNT_INWARDS", SqlDbType.NVarChar).Value = ob.LoanAmount_Inwards;
                cmd.Parameters.Add("@MONTHLYRENT_INWARDS", SqlDbType.NVarChar).Value = ob.MonthlyRent_Inwards;
                cmd.Parameters.Add("@DUEAMOUNT_INWARDS", SqlDbType.NVarChar).Value = ob.DueAmt_Inwards;
                cmd.Parameters.Add("@MONTHLYINSTALLMENT_INWARDS", SqlDbType.NVarChar).Value = ob.MonthlyInstallment_Inwards;
                cmd.Parameters.Add("@CLIENTPAYABLE_INWARDS", SqlDbType.NVarChar).Value = ob.ClientPayable_Inwards;
                cmd.Parameters.Add("@COMPANYPAYABLE", SqlDbType.Decimal).Value = ob.CompnayPayable;
                cmd.Parameters.Add("@COMPANYPAYABLE_INWARDS", SqlDbType.NVarChar).Value = ob.CompnayPayable_Inwards;
                cmd.Parameters.Add("@UPDUSERPC", SqlDbType.NVarChar).Value = ob.UPDUserPC;
                cmd.Parameters.Add("@UPDATEUSERID", SqlDbType.NVarChar).Value = ob.UpdUserID;
                cmd.Parameters.Add("@UPDTIME", SqlDbType.SmallDateTime).Value = ob.UpdTime;
                cmd.Parameters.Add("@UPDIPADDRESS", SqlDbType.NVarChar).Value = ob.UPDIpaddress;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.NVarChar).Value = ob.ClientID;

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


        /////....................................Accounts Entry Portion.............................///////


        public string InsertTransInfo(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"INSERT INTO TRANS (TRANSDT, TRANSMY, TRANSNO, INVOICENO, CLIENTID, PARTICULARS, REMARKS, TRANSSL, AMOUNT, USERPC, USERID, INTIME, IPADDRESS) 
                  VALUES(@TRANSDT, @TRANSMY, @TRANSNO, @INVOICENO, @CLIENTID, @PARTICULARS, @REMARKS, @TRANSSL, @AMOUNT, @USERPC, @USERID, @INTIME, @IPADDRESS)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@TRANSDT", SqlDbType.SmallDateTime).Value = ob.Date;
                cmd.Parameters.Add("@TRANSMY", SqlDbType.NVarChar).Value = ob.TransMy;
                cmd.Parameters.Add("@TRANSNO", SqlDbType.BigInt).Value = ob.TransNo;
                cmd.Parameters.Add("@INVOICENO", SqlDbType.NVarChar).Value = ob.invoiceno;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.NVarChar).Value = ob.ClientID;
                cmd.Parameters.Add("@PARTICULARS", SqlDbType.NVarChar).Value = ob.Particulars;
                cmd.Parameters.Add("@REMARKS", SqlDbType.NVarChar).Value = ob.GrdRemarks;
                cmd.Parameters.Add("@TRANSSL", SqlDbType.NVarChar).Value = ob.TransSL;
                cmd.Parameters.Add("@AMOUNT", SqlDbType.Decimal).Value = ob.Amount;
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


        public string InsertTransMstInfo(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"INSERT INTO TRANSMST (TRANSDT, TRANSMY, TRANSNO, INVOICENO, CLIENTID, TOTAMT, REMARKS, USERPC, USERID, INTIME, IPADDRESS) 
                                        VALUES(@TRANSDT, @TRANSMY, @TRANSNO, @INVOICENO, @CLIENTID, @TOTAMT, @REMARKS, @USERPC, @USERID, @INTIME, @IPADDRESS)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@TRANSDT", SqlDbType.SmallDateTime).Value = ob.Date;
                cmd.Parameters.Add("@TRANSMY", SqlDbType.NVarChar).Value = ob.TransMy;
                cmd.Parameters.Add("@TRANSNO", SqlDbType.BigInt).Value = ob.TransNo;
                cmd.Parameters.Add("@INVOICENO", SqlDbType.NVarChar).Value = ob.invoiceno;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.NVarChar).Value = ob.ClientID;
                cmd.Parameters.Add("@TOTAMT", SqlDbType.Decimal).Value = ob.NetAmount;
                cmd.Parameters.Add("@REMARKS", SqlDbType.NVarChar).Value = ob.Remarks;
                
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

        public string UpdateTransInfo(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"UPDATE TRANS SET INVOICENO=@INVOICENO, PARTICULARS=@PARTICULARS, REMARKS=@REMARKS, AMOUNT=@AMOUNT, UPDUSERPC=@UPDUSERPC, UPDUSERID=@UPDUSERID,
                          UPDTIME=@UPDTIME, UPDIPADDRESS=@UPDIPADDRESS WHERE TRANSDT=@TRANSDT AND TRANSMY=@TRANSMY AND TRANSNO=@TRANSNO AND TRANSSL=@TRANSSL AND CLIENTID=@CLIENTID";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@INVOICENO", SqlDbType.NVarChar).Value = ob.invoiceno;
                cmd.Parameters.Add("@PARTICULARS", SqlDbType.NVarChar).Value = ob.Particulars;
                cmd.Parameters.Add("@REMARKS", SqlDbType.NVarChar).Value = ob.GrdRemarks;
                cmd.Parameters.Add("@AMOUNT", SqlDbType.Decimal).Value = ob.Amount;

                cmd.Parameters.Add("@UPDUSERPC", SqlDbType.NVarChar).Value = ob.UPDUserPC;
                cmd.Parameters.Add("@UPDUSERID", SqlDbType.NVarChar).Value = ob.UpdUserID;
                cmd.Parameters.Add("@UPDTIME", SqlDbType.SmallDateTime).Value = ob.UpdTime;
                cmd.Parameters.Add("@UPDIPADDRESS", SqlDbType.NVarChar).Value = ob.UPDIpaddress;

                cmd.Parameters.Add("@TRANSDT", SqlDbType.SmallDateTime).Value = ob.Date;
                cmd.Parameters.Add("@TRANSMY", SqlDbType.NVarChar).Value = ob.TransMy;
                cmd.Parameters.Add("@TRANSNO", SqlDbType.BigInt).Value = ob.TransNo;
                cmd.Parameters.Add("@TRANSSL", SqlDbType.NVarChar).Value = ob.TransSL;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.NVarChar).Value = ob.ClientID;

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


        public string UpdateTransMstInfo(DataModel ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"UPDATE TRANSMST SET INVOICENO=@INVOICENO, TOTAMT=@TOTAMT, REMARKS=@REMARKS, UPDUSERPC=@UPDUSERPC, UPDUSERID=@UPDUSERID,
                                    UPDTIME=@UPDTIME, UPDIPADDRESS=@UPDIPADDRESS WHERE TRANSDT=@TRANSDT AND TRANSMY=@TRANSMY AND TRANSNO=@TRANSNO AND CLIENTID=@CLIENTID";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@INVOICENO", SqlDbType.NVarChar).Value = ob.invoiceno;
                cmd.Parameters.Add("@REMARKS", SqlDbType.NVarChar).Value = ob.Remarks;
                cmd.Parameters.Add("@TOTAMT", SqlDbType.Decimal).Value = ob.NetAmount;

                cmd.Parameters.Add("@UPDUSERPC", SqlDbType.NVarChar).Value = ob.UPDUserPC;
                cmd.Parameters.Add("@UPDUSERID", SqlDbType.NVarChar).Value = ob.UpdUserID;
                cmd.Parameters.Add("@UPDTIME", SqlDbType.SmallDateTime).Value = ob.UpdTime;
                cmd.Parameters.Add("@UPDIPADDRESS", SqlDbType.NVarChar).Value = ob.UPDIpaddress;

                cmd.Parameters.Add("@TRANSDT", SqlDbType.SmallDateTime).Value = ob.Date;
                cmd.Parameters.Add("@TRANSMY", SqlDbType.NVarChar).Value = ob.TransMy;
                cmd.Parameters.Add("@TRANSNO", SqlDbType.BigInt).Value = ob.TransNo;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.NVarChar).Value = ob.ClientID;

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