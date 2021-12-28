using HRMS.Core.Entities.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.RequestVm
{
    public class EmployeeSalaryVm
    {
        public List<EmployeeDetail> EmployeeDetails { get; set; }
        public List<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }
    }
}
