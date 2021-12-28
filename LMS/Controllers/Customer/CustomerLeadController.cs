using HRMS.Core.Entities.LeadManagement;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LMS.Controllers.Customer
{
    public class CustomerLeadController : Controller
    {
        private readonly IGenericRepository<CustomerLead, int> _ICustomerLeadRepository;
        
        public CustomerLeadController(IGenericRepository<CustomerLead, int> customerLeadRepository)
        {
          
            _ICustomerLeadRepository = customerLeadRepository;
        }
        public async Task<IActionResult> Index(int customerId)
        {
            var leadCode = "KUDO00" + customerId.ToString();
            var dbModel = new CustomerLead()
            {
                CustomerId = customerId,
                LeadCode = leadCode,
                IsActive = true,
                IsDeleted = false,
                CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("empId")),
                CreatedDate = DateTime.Now
            };

            var response = await _ICustomerLeadRepository.CreateEntity(dbModel);
            return RedirectToAction("Index", "LeadCloser",new { customerId= customerId });
        }
    }
}
