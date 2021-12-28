using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.Payroll
{
    [Table("EmployeeSalaryDetail", Schema = "Payroll")]
    public class EmployeeSalaryDetail: BaseModel<int>
    {
        public string EmpCode { get; set; }
        public decimal CTC { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal ConvenanceAllowance { get; set; }
        public decimal EducationAllowance { get; set; }
        public decimal FoodCouponAllowance { get; set; }
        public decimal HouseRentAllowance { get; set; }
        public decimal LTARiembursement { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal TelephoneAllowance { get; set; }
        public decimal UniformReimburesement { get; set; }
        public decimal BookAndPriodical { get; set; }
        public decimal CarRunningAndMaintainence { get; set; }
        public decimal PACover { get; set; }
        public decimal MediClaimAmount { get; set; }
        public decimal PFDeduction { get; set; }
        public decimal ESIDeduction { get; set; }
        public string PTStateName { get; set; }
        public string IsPFEligible { get; set; }
        public decimal LWFDeduction { get; set; }
        public decimal PLP { get; set; }
    }
}
