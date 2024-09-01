using System;using Yesbd;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yesbd.LogData.Interface
{
    public class LogDataInterface
    {  
        // Default Model Start //
        public string UserIdInsert { get; set; }
        public string UserPcInsert { get; set; }
        public DateTime InTimeInsert { get; set; }
        public string IpAddressInsert { get; set; }
        public string LotiLengTudeInsert { get; set; }
        public string UserIdUpdate { get; set; }
        public string UserPcUpdate { get; set; }
        public DateTime InTimeUpdate { get; set; }
        public string IpAddressUpdate { get; set; }
        public string LotiLengTudeUpdate { get; set; }

        // Default Model End //
        public Int64 CompanyId { get; set; }
        public Int64 CompanyUserId { get; set; }
        public string LogType { get; set; }
        public Int64 LogSlNo { get; set; }
        public string TableId { get; set; }
        public string LogDatA { get; set; }
    }
}