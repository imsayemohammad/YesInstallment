using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI.WebControls;
using Yesbd;
using Yesbd.logData.DataAccess;
using Yesbd.LogData.Interface;

namespace Yesbd.LogData
{
    
    public class LogDataFunction
    {
        static LogDataAccess dob = new LogDataAccess();
        static LogDataInterface iob = new LogDataInterface();
        public static void InsertLogData(string logType, string tableId, string logData, string ipAddress)
        {
            try
            {
                iob.IpAddressInsert = ipAddress;
                iob.UserIdInsert = HttpContext.Current.Session["UserName"].ToString();
                iob.UserPcInsert = DatabaseFunctions.UserPc();
                iob.InTimeInsert = DatabaseFunctions.Timezone(DateTime.Now);

                string logSl = DatabaseFunctions.StringData("SELECT ISNULL(MAX(LOGSLNO+1),1) AS MAXLOGSLNO FROM LOG WHERE USERID= '" + iob.UserIdInsert + "'");
                iob.LogSlNo = Convert.ToInt64(logSl);
                iob.LogType = logType;
                //iob.CompanyId = Convert.ToInt64(HttpContext.Current.Session["COMPANYID"].ToString());
                //iob.CompanyUserId = Convert.ToInt64(HttpContext.Current.Session["USERID"].ToString());
                iob.TableId = tableId;
                iob.LogDatA = logData;
                dob.INSERT_LOG(iob);
            }
            catch (Exception)
            {
                
            }

        }
    }
}