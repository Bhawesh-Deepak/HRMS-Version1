using HRMS.Core.Entities.Payroll;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.Helpers.ExcelHelper;
using HRMS.Core.ReqRespVm.RequestVm;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Payroll
{
    public class EmployeeSalaryController : Controller
    {
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeDetailRepository;
        private readonly IGenericRepository<EmployeeSalaryDetail, int> _IEmployeeSalaryDetailRepository;

        public EmployeeSalaryController(IGenericRepository<EmployeeDetail, int> employeeDetailRepo,
            IGenericRepository<EmployeeSalaryDetail, int> employeeSalaryDetailRepo)
        {
            _IEmployeeDetailRepository = employeeDetailRepo;
            _IEmployeeSalaryDetailRepository = employeeSalaryDetailRepo;
        }
        public IActionResult Index()
        {
            return View(ViewHelper.GetViewPathDetails("Employee", "EmployeeSalaryIndex"));
        }
        [HttpPost]
        public async Task<IActionResult> UploadEmployeeSalary(UploadExcelVm model)
        {
            try
            {

                var response = new ReadEmployeeSalaryExcelHelper().GetEmployeeSalaryDetails(model.UploadFile);

                var employeeDetailResponse = await _IEmployeeDetailRepository.CreateEntities(response.EmployeeDetails.ToArray());

                var employeeSalaryReponse = await _IEmployeeSalaryDetailRepository.CreateEntities(response.EmployeeSalaryDetails.ToArray());

                return Json("Employee Basic information and Salary Detail Uploaded successfully !!!");
            }
            catch (Exception ex)
            {
                Serilog.Log.Information(ex.InnerException.ToString(),ex);
                return Json("Unable to upload the Excel File, Something wents wrong please contact admin !");
            }

        }
    }
}
