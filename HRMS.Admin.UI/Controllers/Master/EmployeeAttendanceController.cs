using HRMS.Core.Entities.Payroll;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.Helpers.ExcelHelper;
using HRMS.Core.ReqRespVm.RequestVm;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Master
{
    public class EmployeeAttendanceController : Controller
    {

        private readonly IGenericRepository<EmployeeAttendance, int> _IEmployeeAttendanceRepository;

        public EmployeeAttendanceController(IGenericRepository<EmployeeAttendance, int> employeeAttendanceRepo)
        {
            _IEmployeeAttendanceRepository = employeeAttendanceRepo;
        }
        public IActionResult Index()
        {
            return View(ViewHelper.GetViewPathDetails("EmployeeAttendance", "EmployeeAttendanceCreate"));
        }

        [HttpPost]
        public async Task<IActionResult> UploadAttendance(UploadExcelVm model)
        {
            var deleteModel = await _IEmployeeAttendanceRepository
                .GetAllEntities(x => x.DateMonth == model.MonthId && x.DateYear == model.YearId);

            deleteModel.Entities.ToList().ForEach(x => {
                x.IsActive = false;
                x.IsDeleted = true;
                x.UpdatedDate = DateTime.Now;
            });

            var deleteResponse = await _IEmployeeAttendanceRepository.DeleteEntities(deleteModel.Entities.ToArray());

            var response = new ReadAttendanceExcelHelper().GetAttendanceDetails(model.UploadFile);

            var dbResponse = await _IEmployeeAttendanceRepository.CreateEntities(response.ToArray());

            return Json($"Employee Attendance uploaded successfully !!");
        }
    }
}
