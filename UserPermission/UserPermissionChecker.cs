using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using Yesbd;
using Yesbd;

namespace Yesbd
{
    public class UserPermissionChecker
    {
        public static bool checkParmit(string formLink, string permissionType)
        {
            string moduleId = "";
            string menuId = "";
            moduleId = DatabaseFunctions.StringData("SELECT MODULEID FROM MENU WHERE FLINK='" + formLink + "'");
            menuId = DatabaseFunctions.StringData("SELECT MENUID FROM MENU WHERE FLINK='" + formLink + "'");

            string userId = HttpContext.Current.Session["EmpID"].ToString();

            string permission = DatabaseFunctions.StringData(@"SELECT CASE(" + permissionType + ") WHEN 'A' THEN 'true' else 'false' end As Status " +
            "FROM ROLE WHERE USERID='" + userId + "' AND MODULEID='" + moduleId + "' AND MENUID='" + menuId + "';");
            if (permission == "")
                permission = "false";

            return Convert.ToBoolean(permission);
        }
    }
}