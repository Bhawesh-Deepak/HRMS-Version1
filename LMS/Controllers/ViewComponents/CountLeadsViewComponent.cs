using ClosedXML.Excel;
using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.ReqRespVm.Response.Leads;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.ViewComponents
{
    public class CountLeadsViewComponent : ViewComponent
    {
        private readonly IGenericRepository<CustomerLeadDetail, int> _ICustomerLeadRepository;
        public CountLeadsViewComponent(IGenericRepository<CustomerLeadDetail, int> customerLeadRepo)
        {
            _ICustomerLeadRepository = customerLeadRepo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
             
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.EmpId == Convert.ToInt32(HttpContext.Session.GetString("empId")));
            var CountDashboard = new CountDashboardLeadsVM()
            {
                TotalLeads = CustomerLeadLIst.Entities.Count(),
                HotLeads = CustomerLeadLIst.Entities.Where(x => x.LeadType == 1).Count(),
                WarmLeads = CustomerLeadLIst.Entities.Where(x => x.LeadType == 2).Count(),
                ColdLeads = CustomerLeadLIst.Entities.Where(x => x.LeadType == 3).Count(),
                NotInterested = CustomerLeadLIst.Entities.Where(x => x.LeadType == 4).Count(),
                IncompleteLeads = CustomerLeadLIst.Entities.Where(x => x.LeadType == 0).Count(),
            };
            return await Task.FromResult((IViewComponentResult)View("_CountDashboardLeads", CountDashboard));
        }
      
    }
}
