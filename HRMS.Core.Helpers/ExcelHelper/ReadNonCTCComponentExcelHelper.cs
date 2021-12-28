using HRMS.Core.Entities.Payroll;
using HRMS.Core.Helpers.CommonHelper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace HRMS.Core.Helpers.ExcelHelper
{
    public class ReadNonCTCComponentExcelHelper
    {
        public IEnumerable<EmployeeNonCTC> GetEmployeeNonCTCComponent(IFormFile inputFile) {

            var dataResult = ReadExcelDataHelper.GetDataTableFromExcelFile(inputFile);
            var models = new List<EmployeeNonCTC>();

            for (int i = 1; i < dataResult.dtResult.Rows.Count; i++)
            {
                var model = new EmployeeNonCTC();
                model.DateMonth = dataResult.dtResult.Rows[i][0].ToString().GetDefaultDBNull<int>();
                model.DateYear = dataResult.dtResult.Rows[i][1].ToString().GetDefaultDBNull<int>();
                model.EmpCode = dataResult.dtResult.Rows[i][2].ToString().GetDefaultDBNull<string>();
                model.StatuaryBonus = dataResult.dtResult.Rows[i][3].ToString().GetDefaultDBNull<decimal>();
                model.PerformanceIncentive = dataResult.dtResult.Rows[i][4].ToString().GetDefaultDBNull<decimal>();

                model.JoiningBonus = dataResult.dtResult.Rows[i][5].ToString().GetDefaultDBNull<decimal>();
                model.NoticePay = dataResult.dtResult.Rows[i][6].ToString().GetDefaultDBNull<decimal>();
                model.OverTimePay = dataResult.dtResult.Rows[i][7].ToString().GetDefaultDBNull<decimal>();
                model.NPSEarning = dataResult.dtResult.Rows[i][8].ToString().GetDefaultDBNull<decimal>();
                model.OtherAllowance = dataResult.dtResult.Rows[i][9].ToString().GetDefaultDBNull<decimal>();

                model.PerformaceLinkedPay = dataResult.dtResult.Rows[i][10].ToString().GetDefaultDBNull<decimal>();
                model.PerformanceLinkedPayB = dataResult.dtResult.Rows[i][11].ToString().GetDefaultDBNull<decimal>();
                model.BooksAndPeriodicalTaxable = dataResult.dtResult.Rows[i][12].ToString().GetDefaultDBNull<decimal>();
                model.CarMaintainenceTaxable = dataResult.dtResult.Rows[i][13].ToString().GetDefaultDBNull<decimal>();
                model.GratuityPay = dataResult.dtResult.Rows[i][14].ToString().GetDefaultDBNull<decimal>();

                model.LeaveEncashment = dataResult.dtResult.Rows[i][15].ToString().GetDefaultDBNull<decimal>();
                model.HoldSalary = dataResult.dtResult.Rows[i][16].ToString().GetDefaultDBNull<decimal>();
                model.ParentalMediclaim = dataResult.dtResult.Rows[i][17].ToString().GetDefaultDBNull<decimal>();
                model.OtherRecovery = dataResult.dtResult.Rows[i][18].ToString().GetDefaultDBNull<decimal>();
                model.MiscleneousDeduction = dataResult.dtResult.Rows[i][19].ToString().GetDefaultDBNull<decimal>();

                model.LabourWelfare = dataResult.dtResult.Rows[i][20].ToString().GetDefaultDBNull<decimal>();
                model.LoanOther = dataResult.dtResult.Rows[i][21].ToString().GetDefaultDBNull<decimal>();
                model.MobileDeduction = dataResult.dtResult.Rows[i][22].ToString().GetDefaultDBNull<decimal>();
                model.NoticeRecovery = dataResult.dtResult.Rows[i][23].ToString().GetDefaultDBNull<decimal>();
                model.OtherDeduction = dataResult.dtResult.Rows[i][24].ToString().GetDefaultDBNull<decimal>();

                model.SalaryAdvanceDeduction = dataResult.dtResult.Rows[i][25].ToString().GetDefaultDBNull<decimal>();
                model.FoodCouponDeduction = dataResult.dtResult.Rows[i][26].ToString().GetDefaultDBNull<decimal>();
                model.AssetsRecovery = dataResult.dtResult.Rows[i][27].ToString().GetDefaultDBNull<decimal>();
                model.TravelDeduction = dataResult.dtResult.Rows[i][28].ToString().GetDefaultDBNull<decimal>();
                model.EPFRecovery = dataResult.dtResult.Rows[i][29].ToString().GetDefaultDBNull<decimal>();


                model.NPS = dataResult.dtResult.Rows[i][30].ToString().GetDefaultDBNull<decimal>();
                model.ARRVPF_Deduction = dataResult.dtResult.Rows[i][31].ToString().GetDefaultDBNull<decimal>();
                


                models.Add(model);
            }

            return models;
        }
    }
}
