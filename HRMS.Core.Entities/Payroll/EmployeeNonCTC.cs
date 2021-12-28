using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.Payroll
{
    [Table("EmployeeNonCTCComponent",Schema="Payroll")]
    public class EmployeeNonCTC: BaseModel<int>
    {
        public int DateMonth { get; set; }
        public int DateYear { get; set; }
        public string EmpCode { get; set; }
        public decimal StatuaryBonus { get; set; }
        public decimal PerformanceIncentive { get; set; }
        public decimal JoiningBonus { get; set; }
        public decimal NoticePay { get; set; }
        public decimal OverTimePay { get; set; }
        public decimal NPSEarning { get; set; }
        public decimal OtherAllowance { get; set; }
        public decimal PerformaceLinkedPay { get; set; }
        public decimal PerformanceLinkedPayB { get; set; }
        public decimal BooksAndPeriodicalTaxable { get; set; }
        public decimal CarMaintainenceTaxable { get; set; }
        public decimal GratuityPay { get; set; }
        public decimal LeaveEncashment { get; set; }
        public decimal HoldSalary { get; set; }
        public decimal ParentalMediclaim { get; set; }
        public decimal OtherRecovery { get; set; }
        public decimal MiscleneousDeduction { get; set; }
        public decimal LabourWelfare { get; set; }
        public decimal LoanOther { get; set; }
        public decimal MobileDeduction { get; set; }
        public decimal NoticeRecovery { get; set; }
        public decimal OtherDeduction { get; set; }
        public decimal SalaryAdvanceDeduction { get; set; }
        public decimal FoodCouponDeduction { get; set; }
        public decimal AssetsRecovery { get; set; }
        public decimal TravelDeduction { get; set; }
        public decimal EPFRecovery { get; set; }
        public decimal NPS { get; set; }
        public decimal ARRVPF_Deduction { get; set; }
    }
}
