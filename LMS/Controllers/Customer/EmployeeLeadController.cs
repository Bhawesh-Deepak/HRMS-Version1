using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.Customer
{
    public class EmployeeLeadController : Controller
    {
        private readonly IGenericRepository<CustomerDetail, int> _ICustomerDetailRepository;
        private readonly IGenericRepository<CustomerLeadDetail, int> _ICustomerLeadRepository;
        public EmployeeLeadController(IGenericRepository<CustomerDetail, int> _customerDetailRepo,
            IGenericRepository<CustomerLeadDetail, int> customerLeadRepo)
        {
            _ICustomerDetailRepository = _customerDetailRepo;
            _ICustomerLeadRepository = customerLeadRepo;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderTitle = "Employee Lead";
            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("EmployeeLead", "EmployeeLeadIndex")));
        }

        public async Task<IActionResult> CreateLead()
        {
            return await Task.Run(() => PartialView(ViewHelper.GetViewPathDetails("EmployeeLead", "EmployeeLeadCreate")));
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateLead(CustomerDetail model)
        {
            model.AssignDate = DateTime.Now;
            model.CreatedDate = DateTime.Now;
            model.CreatedBy= Convert.ToInt32(HttpContext.Session.GetString("empId"));
            var customerCreateResponse = await _ICustomerDetailRepository.CreateEntity(model);
            var customerId = (await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted))
                .Entities.Max(x => x.Id);
            var employeeId = Convert.ToInt32(HttpContext.Session.GetString("empId"));
            var customerLeadDetail = new CustomerLeadDetail() { 
                CustomerId=customerId,
                 LeadType=1,
                 EmpId= employeeId,
                 CreatedBy= employeeId,
                 CreatedDate= DateTime.Now
            };

            var customerLeadResponse = await _ICustomerLeadRepository.CreateEntity(customerLeadDetail);

            return Json(customerLeadResponse.Message);
        }
    }
}
