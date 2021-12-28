using HRMS.Core.Entities.Payroll;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.UserManagement
{
    public class EmployeeProfileController : Controller
    {
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeRepository;

        public EmployeeProfileController(IGenericRepository<EmployeeDetail, int> employeeRepository)
        {
            _IEmployeeRepository = employeeRepository;
        }
        public async Task<IActionResult> Index()
        {
            var empId = Convert.ToInt32(HttpContext.Session.GetString("empId"));
            var response = await _IEmployeeRepository.GetAllEntityById(x => x.Id == empId);
            return View(ViewHelper.GetViewPathDetails("EmployeeProfile", "ProfileDetail"),response.Entity);
        }
    }
}
