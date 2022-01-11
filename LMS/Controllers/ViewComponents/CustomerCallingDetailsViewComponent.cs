using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.ReqRespVm.Response.Leads;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.ViewComponents
{
    public class CustomerCallingDetailsViewComponent : ViewComponent
    {
        private readonly IGenericRepository<CustomerCallingDetails, int> _ICustomerCallingDetailsRepository;
        private readonly IGenericRepository<CustomerDetail, int> _ICustomerDetailRepository;
        public CustomerCallingDetailsViewComponent(IGenericRepository<CustomerCallingDetails, int> CustomerCallingDetailsRepo
            , IGenericRepository<CustomerDetail, int> iCustomerDetailRepository)
        {
            _ICustomerCallingDetailsRepository = CustomerCallingDetailsRepo;
            _ICustomerDetailRepository = iCustomerDetailRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var customercallingdetail = await _ICustomerCallingDetailsRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var customerdetail = await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var responseDetails = (from calling in customercallingdetail.Entities
                                   join customer in customerdetail.Entities
                                   on calling.CustomerId equals customer.Id

                                   where calling.EmployeeId == Convert.ToInt32(HttpContext.Session.GetString("empId"))
                                   select new CustomerCallingDetailVM
                                   {
                                      Id=calling.Id,
                                      LeadName=customer.LeadName,
                                      Location=customer.Location,
                                      Phone=customer.Phone,
                                      Email =customer.Email,
                                      Description_Project=customer.Description_Project,
                                      AssignDate=customer.AssignDate,
                                      PhoneDateTime=calling.PhoneDateTime
                                   }).ToList();

            return await Task.FromResult((IViewComponentResult)View("_CustomerCallingDetails", responseDetails));
        }
    }
}
