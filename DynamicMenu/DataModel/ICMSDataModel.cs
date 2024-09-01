using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yesbd.DynamicMenu.DataModel
{
    public class ICMSDataModel
    {

        // Default Model Start //
        public Int64 UserIdInsert { get; set; }
        public string UserPcInsert { get; set; }
        public DateTime InTimeInsert { get; set; }
        public string IpAddressInsert { get; set; }
        public string LotiLengTudeInsert { get; set; }
        public Int64 UserIdUpdate { get; set; }
        public string UserPcUpdate { get; set; }
        public DateTime InTimeUpdate { get; set; }
        public string IpAddressUpdate { get; set; }
        public string LotiLengTudeUpdate { get; set; }

        // Default Model End //

        // Company Model Start //
        public Int64 CompanyId { get; set; }
        public Int64 CompanyUserId { get; set; }
        public string  ComapanyName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string WebId { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
        public string OpType { get; set; }
        public string MobileNo { get; set; }
        public string LogInBy { get; set; }
        public string LogInId { get; set; }
        public string Password { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string MenuId { get; set; }
        public string MenuType { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public string InsertRole { get; set; }
        public string UpdateRole { get; set; }
        public string DeleteRole { get; set; }
        public string LogType { get; set; }
        public Int64 LogSlNo { get; set; }
        public string TableId { get; set; }
        public string LogData { get; set; }
        // Company Model End //


        public string UpdUserID { get; set; }

        public string UPDUserPC { get; set; }

        public string UPDIpaddress { get; set; }

        public DateTime UpdTime { get; set; }

        public string UserID { get; set; }

        public string UserPC { get; set; }

        public string Ipaddress { get; set; }

        public DateTime ITime { get; set; }

        public string UserId { get; set; }

        public string DeptID { get; set; }

        public long MenuSL { get; set; }

        public string SpecialP { get; set; }
    }
}