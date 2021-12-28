using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.RequestVm
{
    public class EmployeeAttendanceVm
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string EmpCode { get; set; }
        public int LopDays { get; set; }
    }
}
