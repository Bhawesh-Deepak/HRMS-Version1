using HRMS.Core.Entities.Payroll;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.ViewComponents
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeDetailRepository;

        public HeaderMenuViewComponent(IGenericRepository<EmployeeDetail, int> employeeDetailRepo)
        {
            _IEmployeeDetailRepository = employeeDetailRepo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var empCode = HttpContext.Session.GetString("empCode");
            var Employees = await _IEmployeeDetailRepository.GetAllEntities(x => x.EmpCode.Trim().ToUpper() == empCode.Trim().ToUpper());
            return await Task.FromResult((IViewComponentResult)View("_HeaderMenu", Employees.Entities.First()));
        }
    }
}
