using HRMS.Core.Entities.Payroll;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.Helpers.ExcelHelper;
using HRMS.Core.ReqRespVm.RequestVm;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Payroll
{
    public class EmployeeNonCTCController : Controller
    {
        private readonly IGenericRepository<EmployeeNonCTC, int> _IEmployeeNonCTCRepository;

        public EmployeeNonCTCController(IGenericRepository<EmployeeNonCTC, int> employeeNonCTCRepo)
        {
            _IEmployeeNonCTCRepository = employeeNonCTCRepo;
        }
        public IActionResult Index()
        {
            return View(ViewHelper.GetViewPathDetails("NonCTC", "NonCTCCreate"));
        }

        [HttpPost]
        public async Task<IActionResult> UploadNonCTCComponent(UploadExcelVm model)
        {
            try
            {
                var response = new ReadNonCTCComponentExcelHelper().GetEmployeeNonCTCComponent(model.UploadFile);
                var dbResponse = await _IEmployeeNonCTCRepository.CreateEntities(response.ToArray());
                return Json("");
            }
            catch (Exception ex) {
                string message = ex.Message;
            }
            return Json("");
        }
    }
}
