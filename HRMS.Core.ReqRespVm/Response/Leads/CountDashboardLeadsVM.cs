using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.Response.Leads
{
    public class CountDashboardLeadsVM
    {
        public int TotalLeads { get; set; }
        public int WarmLeads { get; set; }
        public int ColdLeads { get; set; }
        public int HotLeads { get; set; }
        public int IncompleteLeads { get; set; }
        public int NotInterested { get; set; }
    }
}
