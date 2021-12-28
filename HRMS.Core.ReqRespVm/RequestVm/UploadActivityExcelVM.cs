using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.RequestVm
{
    public class UploadActivityExcelVM: BaseModel<int>
    {
        public int EmpId { get; set; }
        public string LeadName { get; set; }
        public string LeadType { get; set; }
        public string Description { get; set; }
        public DateTime? IntractionDate { get; set; } = DateTime.Now.Date;
        public TimeSpan? IntractionTime { get; set; } = DateTime.Now.TimeOfDay;
        public string Activity { get; set; } = string.Empty;
        public DateTime? NextIntractionDate { get; set; }
        public TimeSpan? NextIntractionTime { get; set; }
        public string NextIntractionActivity { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
