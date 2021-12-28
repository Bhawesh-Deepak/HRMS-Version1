using HRMS.Core.Entities.LeadManagement;
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
    public class NextIntractionLeadsViewComponent : ViewComponent
    {
        private readonly IGenericRepository<CustomerLeadDetail, int> _ICustomerLeadRepository;
        private readonly IGenericRepository<CustomerDetail, int> _ICustomerDetailRepository;
        public NextIntractionLeadsViewComponent(IGenericRepository<CustomerLeadDetail, int> customerLeadRepo, IGenericRepository<CustomerDetail, int> iCustomerDetailRepository)
        {
            _ICustomerLeadRepository = customerLeadRepo;
            _ICustomerDetailRepository = iCustomerDetailRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.EmpId == Convert.ToInt32(HttpContext.Session.GetString("empId")));
            var NextIntraction = CustomerLeadLIst.Entities.Where(x => x.NextIntractionDate >= DateTime.Now).ToList();
            var CustomerDetailList = await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var responseDetails = (from CDList in CustomerDetailList.Entities
                                   join next in NextIntraction
                                   on CDList.Id equals next.CustomerId
                                   select new NextIntractionLeadsVM
                                   {
                                       Id=CDList.Id,
                                       LeadName = CDList.LeadName,
                                       NextIntractionDate =   next.NextIntractionDate,
                                       NextIntractionActivity = next.NextIntractionActivity,
                                       NextIntractionTime = next.NextIntractionTime,
                                      


                                   }).ToList();


            return await Task.FromResult((IViewComponentResult)View("_NextIntractionLeads", responseDetails));
        }
    }
}
