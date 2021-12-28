using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.Entities.Payroll;
using HRMS.Core.ReqRespVm.Response.Leads;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.ViewComponents
{
    public class TeamLeadViewComponent : ViewComponent
    {
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeDetailRepository;
        private readonly IGenericRepository<CustomerLeadDetail, int> _ICustomerLeadRepository;
        public TeamLeadViewComponent(IGenericRepository<EmployeeDetail, int> employeeDetailRepo, IGenericRepository<CustomerLeadDetail, int> customerLeadRepo)
        {
            _IEmployeeDetailRepository = employeeDetailRepo;
            _ICustomerLeadRepository = customerLeadRepo;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var empCode = HttpContext.Session.GetString("empCode");
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var EmployeeDetailList = await _IEmployeeDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.SuperVisorCode == empCode);
            var CustomerComplete = new List<LeadsBySupervisorVM>();
            EmployeeDetailList.Entities.ToList().ForEach(x =>
            {
                CustomerComplete.Add(new LeadsBySupervisorVM
                {
                    employeeId = x.Id,
                    employeeName = x.EmployeeName,
                    Level = x.Level,
                    Leads = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id).Count(),
                    Called = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id && y.LeadType != 0).Count(),
                    Pending = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id && y.LeadType == 0).Count(),
                    Hot = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id && y.LeadType == 1).Count(),
                    Warm = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id && y.LeadType == 2).Count(),
                    Cold = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id && y.LeadType == 3).Count(),
                    NotInterested = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id && y.LeadType == 4).Count(),
                    LeadConvertedToClient = CustomerLeadLIst.Entities.Where(y => y.EmpId == x.Id && y.LeadType == 5).Count(),
                });
            });
            return await Task.FromResult((IViewComponentResult)View("_TeamLeadDetail", CustomerComplete));
        }
    }
}
