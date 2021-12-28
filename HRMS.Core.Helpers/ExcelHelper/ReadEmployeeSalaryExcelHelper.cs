using HRMS.Core.Entities.Payroll;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.ReqRespVm.RequestVm;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Helpers.ExcelHelper
{
    public class ReadEmployeeSalaryExcelHelper
    {
        public EmployeeSalaryVm GetEmployeeSalaryDetails(IFormFile inputFile)
        {
            var dataResult = ReadExcelDataHelper.GetDataTableFromExcelFile(inputFile);

            var model = new EmployeeSalaryVm();
            var employeeModels = new List<EmployeeDetail>();
            var salaryModels = new List<EmployeeSalaryDetail>();


            for (int i = 1; i < dataResult.dtResult.Rows.Count; i++)
            {
                var empModel = new EmployeeDetail();

                empModel.Salutation = dataResult.dtResult.Rows[i][0].ToString().GetDefaultDBNull<string>();
                empModel.EmployeeName = dataResult.dtResult.Rows[i][1].ToString().GetDefaultDBNull<string>();
                empModel.EmpCode = dataResult.dtResult.Rows[i][2].ToString().GetDefaultDBNull<string>();
                empModel.JoiningDate = dataResult.dtResult.Rows[i][3].ToString().GetDefaultDBNull<DateTime>();
                empModel.EmployementStatus = dataResult.dtResult.Rows[i][4].ToString().GetDefaultDBNull<string>();
                empModel.OfficeEmailId = dataResult.dtResult.Rows[i][5].ToString().GetDefaultDBNull<string>();
                empModel.DepartmentName = dataResult.dtResult.Rows[i][6].ToString().GetDefaultDBNull<string>();
                empModel.DesignationName = dataResult.dtResult.Rows[i][7].ToString().GetDefaultDBNull<string>();
                empModel.Location = dataResult.dtResult.Rows[i][8].ToString().GetDefaultDBNull<string>();
                empModel.LegalEntity = dataResult.dtResult.Rows[i][9].ToString().GetDefaultDBNull<string>();
                empModel.PAndLHeadName = dataResult.dtResult.Rows[i][10].ToString().GetDefaultDBNull<string>();
                empModel.SuperVisorCode = dataResult.dtResult.Rows[i][11].ToString().GetDefaultDBNull<string>();
                empModel.Level = dataResult.dtResult.Rows[i][12].ToString().GetDefaultDBNull<string>();
                empModel.PanCardNumber = dataResult.dtResult.Rows[i][13].ToString().GetDefaultDBNull<string>();
                empModel.PassportNumber = dataResult.dtResult.Rows[i][14].ToString().GetDefaultDBNull<string>();
                empModel.AadharCardNumber = dataResult.dtResult.Rows[i][15].ToString().GetDefaultDBNull<string>();
                empModel.BankAccountName = dataResult.dtResult.Rows[i][16].ToString().GetDefaultDBNull<string>();
                empModel.BankAccountNumber= dataResult.dtResult.Rows[i][17].ToString().GetDefaultDBNull<string>();
                empModel.BankName = dataResult.dtResult.Rows[i][18].ToString().GetDefaultDBNull<string>();
                empModel.IFSCCode = dataResult.dtResult.Rows[i][19].ToString().GetDefaultDBNull<string>();
                empModel.PreviousOrganisation= dataResult.dtResult.Rows[i][20].ToString().GetDefaultDBNull<string>();
                empModel.WorkExprience = dataResult.dtResult.Rows[i][21].ToString().GetDefaultDBNull<string>();

                empModel.EducationalQualification = dataResult.dtResult.Rows[i][22].ToString().GetDefaultDBNull<string>();
                empModel.InstituteName = dataResult.dtResult.Rows[i][23].ToString().GetDefaultDBNull<string>();
                empModel.ConfirmationDate = dataResult.dtResult.Rows[i][24].ToString().GetDefaultDBNull<DateTime>();
                empModel.RecruitmentSource = dataResult.dtResult.Rows[i][25].ToString().GetDefaultDBNull<string>();
                empModel.RecruitmentName = dataResult.dtResult.Rows[i][26].ToString().GetDefaultDBNull<string>();
                empModel.FatherName = dataResult.dtResult.Rows[i][27].ToString().GetDefaultDBNull<string>();
                empModel.PersonalEmailId = dataResult.dtResult.Rows[i][28].ToString().GetDefaultDBNull<string>();
                empModel.ContactNumber = dataResult.dtResult.Rows[i][29].ToString().GetDefaultDBNull<string>();
                empModel.DateOfBirth = dataResult.dtResult.Rows[i][30].ToString().GetDefaultDBNull<DateTime>();

                empModel.CurrentAddress = dataResult.dtResult.Rows[i][31].ToString().GetDefaultDBNull<string>();
                empModel.PermanentAddress = dataResult.dtResult.Rows[i][32].ToString().GetDefaultDBNull<string>();
                empModel.BiometricCode = dataResult.dtResult.Rows[i][33].ToString().GetDefaultDBNull<string>();
                empModel.BloodGroup = dataResult.dtResult.Rows[i][34].ToString().GetDefaultDBNull<string>();
                empModel.Gender = dataResult.dtResult.Rows[i][35].ToString().GetDefaultDBNull<string>();
                empModel.MaritalStatus = dataResult.dtResult.Rows[i][36].ToString().GetDefaultDBNull<string>();
                empModel.Region = dataResult.dtResult.Rows[i][37].ToString().GetDefaultDBNull<string>();
                empModel.PIPStartDate = dataResult.dtResult.Rows[i][38].ToString().GetDefaultDBNull<string>();
                empModel.PIPEndDate = dataResult.dtResult.Rows[i][39].ToString().GetDefaultDBNull<string>();

                empModel.PIP = dataResult.dtResult.Rows[i][40].ToString().GetDefaultDBNull<string>();
                empModel.WhatsAppNumber = dataResult.dtResult.Rows[i][41].ToString().GetDefaultDBNull<string>();
                empModel.NoticePeriod = dataResult.dtResult.Rows[i][42].ToString().GetDefaultDBNull<string>();
                empModel.SpouceName = dataResult.dtResult.Rows[i][43].ToString().GetDefaultDBNull<string>();
                empModel.DateOfMairrage = dataResult.dtResult.Rows[i][44].ToString().GetDefaultDBNull<DateTime>();
                empModel.EmergencyNumber = dataResult.dtResult.Rows[i][45].ToString().GetDefaultDBNull<string>();
                empModel.EmergencyRelationWithEmployee = dataResult.dtResult.Rows[i][46].ToString().GetDefaultDBNull<string>();
                empModel.UANNumber = dataResult.dtResult.Rows[i][47].ToString().GetDefaultDBNull<string>();
                empModel.ESICNew = dataResult.dtResult.Rows[i][48].ToString().GetDefaultDBNull<string>();

                empModel.LeaveSupervisor = dataResult.dtResult.Rows[i][49].ToString().GetDefaultDBNull<string>();
                empModel.IJPLocation = dataResult.dtResult.Rows[i][50].ToString().GetDefaultDBNull<string>();
                empModel.ShiftTiming = dataResult.dtResult.Rows[i][51].ToString().GetDefaultDBNull<string>();
                empModel.ConfirmationStatus = dataResult.dtResult.Rows[i][52].ToString().GetDefaultDBNull<string>();
                empModel.Nationality = dataResult.dtResult.Rows[i][53].ToString().GetDefaultDBNull<string>();
                empModel.PAndFBankAccountNumberx = dataResult.dtResult.Rows[i][54].ToString().GetDefaultDBNull<string>();
                empModel.ESICPreviousNumber = dataResult.dtResult.Rows[i][55].ToString().GetDefaultDBNull<string>();
                empModel.Induction = dataResult.dtResult.Rows[i][56].ToString().GetDefaultDBNull<string>();
                empModel.VISANumber = dataResult.dtResult.Rows[i][60].ToString().GetDefaultDBNull<string>();
                empModel.VISADate= dataResult.dtResult.Rows[i][61].ToString().GetDefaultDBNull<DateTime>();
                empModel.TaxFileNumber = dataResult.dtResult.Rows[i][62].ToString().GetDefaultDBNull<string>();
                empModel.SupernationAccountNumber = dataResult.dtResult.Rows[i][63].ToString().GetDefaultDBNull<string>();
                empModel.SwiftCode = dataResult.dtResult.Rows[i][64].ToString().GetDefaultDBNull<string>();
                empModel.RoutingCode = dataResult.dtResult.Rows[i][65].ToString().GetDefaultDBNull<string>();
                empModel.AlternateMobileNumber = dataResult.dtResult.Rows[i][66].ToString().GetDefaultDBNull<string>();
                empModel.BranchOfficeId = dataResult.dtResult.Rows[i][67].ToString().GetDefaultDBNull<string>();
                empModel.ExitDate = dataResult.dtResult.Rows[i][68].ToString().GetDefaultDBNull<DateTime>();
                empModel.HolidayGroupId = dataResult.dtResult.Rows[i][69].ToString().GetDefaultDBNull<string>();
                empModel.IsESICEligible = dataResult.dtResult.Rows[i][70].ToString().GetDefaultDBNull<string>();

                empModel.LandLineNumber = dataResult.dtResult.Rows[i][71].ToString().GetDefaultDBNull<string>();
                empModel.LeaveApprover1 = dataResult.dtResult.Rows[i][72].ToString().GetDefaultDBNull<string>();
                empModel.LeaveApprover2 = dataResult.dtResult.Rows[i][73].ToString().GetDefaultDBNull<string>();

                employeeModels.Add(empModel);

                var empSalaryModel = new EmployeeSalaryDetail();
                empSalaryModel.CTC = dataResult.dtResult.Rows[i][74].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.EmpCode = empModel.EmpCode;
                empSalaryModel.BasicSalary = dataResult.dtResult.Rows[i][75].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.ConvenanceAllowance = dataResult.dtResult.Rows[i][76].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.EducationAllowance = dataResult.dtResult.Rows[i][77].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.FoodCouponAllowance = dataResult.dtResult.Rows[i][78].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.HouseRentAllowance = dataResult.dtResult.Rows[i][79].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.LTARiembursement = dataResult.dtResult.Rows[i][80].ToString().GetDefaultDBNull<decimal>();

                empSalaryModel.MedicalAllowance = dataResult.dtResult.Rows[i][81].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.SpecialAllowance = dataResult.dtResult.Rows[i][82].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.TelephoneAllowance = dataResult.dtResult.Rows[i][83].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.UniformReimburesement = dataResult.dtResult.Rows[i][84].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.BookAndPriodical = dataResult.dtResult.Rows[i][85].ToString().GetDefaultDBNull<decimal>();

                empSalaryModel.CarRunningAndMaintainence = dataResult.dtResult.Rows[i][86].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.PACover = dataResult.dtResult.Rows[i][87].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.MediClaimAmount = dataResult.dtResult.Rows[i][88].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.PFDeduction = dataResult.dtResult.Rows[i][89].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.ESIDeduction = dataResult.dtResult.Rows[i][90].ToString().GetDefaultDBNull<decimal>();

                empSalaryModel.PTStateName = dataResult.dtResult.Rows[i][91].ToString().GetDefaultDBNull<string>();
                empSalaryModel.IsPFEligible = dataResult.dtResult.Rows[i][92].ToString().GetDefaultDBNull<string>();
                empSalaryModel.LWFDeduction = dataResult.dtResult.Rows[i][93].ToString().GetDefaultDBNull<decimal>();
                empSalaryModel.PLP = dataResult.dtResult.Rows[i][94].ToString().GetDefaultDBNull<decimal>();

                salaryModels.Add(empSalaryModel);

            }
            model.EmployeeDetails = employeeModels;
            model.EmployeeSalaryDetails = salaryModels;
            return model;
        }
    }
}
