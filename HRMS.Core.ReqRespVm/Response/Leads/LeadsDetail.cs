using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.Response.Leads
{
   public class LeadsDetail
    {
        public string NoOfLeads { get; set; }
        public DateTime AssignDate { get; set; }
         
        public string Description{ get; set; }
    }
}
