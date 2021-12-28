using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.Response.Leads
{
   public class LeadsBySupervisorVM
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string Level { get; set; }
        public int Leads { get; set; }
        public int Called { get; set; }
        public int Pending { get; set; }
        public int Hot { get; set; }
        public int Warm { get; set; }
        public int Cold { get; set; }
        public int NotInterested { get; set; }
        public int LeadConvertedToClient { get; set; }
        public DateTime  AssignDate { get; set; }
    }
}
