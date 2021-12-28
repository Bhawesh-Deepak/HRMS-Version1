using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.Payroll
{
    [Table("EmployeeDetail", Schema ="Payroll")]
    public class EmployeeDetail:BaseModel<int>
    {
        public string Salutation { get; set; }
        public string EmployeeName { get; set; }
        public string EmpCode { get; set; }
        public DateTime JoiningDate { get; set; }
        public string EmployementStatus { get; set; }
        public string OfficeEmailId { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string Location { get; set; }
        public string LegalEntity { get; set; }
        public string PAndLHeadName { get; set; }
        public string SuperVisorCode { get; set; }
        public string Level { get; set; }
        public string PanCardNumber { get; set; }
        public string PassportNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string PreviousOrganisation { get; set; }
        public string WorkExprience { get; set; }
        public string EducationalQualification { get; set; }
        public string InstituteName { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string RecruitmentSource { get; set; }
        public string RecruitmentName { get; set; }
        public string FatherName { get; set; }
        public string PersonalEmailId { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string BiometricCode { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Region { get; set; }
        public string PIPStartDate { get; set; }
        public string PIPEndDate { get; set; }
        public string PIP { get; set; }
        public string WhatsAppNumber { get; set; }
        public string NoticePeriod { get; set; }
        public string SpouceName { get; set; }
        public DateTime DateOfMairrage { get; set; }
        public string EmergencyNumber { get; set; }
        public string EmergencyRelationWithEmployee { get; set; }
        public string UANNumber { get; set; }
        public string ESICNew { get; set; }
        public string LeaveSupervisor { get; set; }
        public string IJPLocation { get; set; }
        public string ShiftTiming { get; set; }
        public string ConfirmationStatus { get; set; }
        public string Nationality { get; set; }
        public string PAndFBankAccountNumberx { get; set; }
        public string ESICPreviousNumber { get; set; }
        public string Induction { get; set; }
        public string VISANumber { get; set; }
        public DateTime? VISADate { get; set; }
        public string TaxFileNumber { get; set; }
        public string SupernationAccountNumber { get; set; }
        public string SwiftCode { get; set; }
        public string RoutingCode { get; set; }
        public string AlternateMobileNumber { get; set; }
        public string BranchOfficeId { get; set; }
        public DateTime? ExitDate { get; set; }
        public string HolidayGroupId { get; set; }
        public string IsESICEligible { get; set; }
        public string LandLineNumber { get; set; }
        public string LeaveApprover1 { get; set; }
        public string LeaveApprover2 { get; set; }
    }
}
