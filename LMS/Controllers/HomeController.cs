using ClosedXML.Excel;
using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.Entities.Payroll;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.ReqRespVm.Response.Leads;
using HRMS.Services.Repository.GenericRepository;
using LMS.Helper;
using LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [CustomAuthenticate]
    public class HomeController : Controller
    {
        private readonly IGenericRepository<CustomerDetail, int> _ICustomerDetailRepository;
        private readonly IGenericRepository<LeadType, int> _ILeadTypeRepository;
        private readonly IGenericRepository<CustomerLeadDetail, int> _ICustomerLeadRepository;
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeDetailRepository;
        private readonly ILogger<HomeController> _ILogger;
        public HomeController(IGenericRepository<CustomerDetail, int> iCustomerDetailRepository, IGenericRepository<LeadType, int> iLeadTypeRepository,
            IGenericRepository<EmployeeDetail, int> employeeDetailRepo,
              IGenericRepository<CustomerLeadDetail, int> customerLeadRepo, ILogger<HomeController> logger)
        {
            _ICustomerDetailRepository = iCustomerDetailRepository;
            _ILeadTypeRepository = iLeadTypeRepository;
            _ICustomerLeadRepository = customerLeadRepo;
            _IEmployeeDetailRepository = employeeDetailRepo;
            _ILogger = logger;
        }
        public IActionResult Index()
        {
            Serilog.Log.Information("Home Index action method called !!!");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("Shared", "Error")));
        }
        public async Task<IActionResult> GetLeadsByDate()
        {

            var CustomerDetailList = await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var responseDetails = (from CDList in CustomerDetailList.Entities
                                   join CLList in CustomerLeadLIst.Entities
                                   on CDList.Id equals CLList.CustomerId
                                   where CLList.EmpId == Convert.ToInt32(HttpContext.Session.GetString("empId"))
                                   select new CustomerDetail
                                   {
                                       LeadName = CDList.LeadName,
                                       Location = CDList.Location,
                                       Phone = CDList.Phone,
                                       Email = CDList.Email,
                                       Description_Project = CDList.Description_Project,
                                       AssignDate = CDList.AssignDate.Date,
                                       SpecialRemarks = CDList.SpecialRemarks,
                                       CreatedBy = CDList.CreatedBy,
                                       CreatedDate = CDList.CreatedDate,
                                   }).ToList();

            var Leads = new List<LeadsDetail>();
            foreach (var item in responseDetails.GroupBy(x => x.AssignDate.Date))
            {
                var todayleadsresponse = responseDetails.Where(x => x.AssignDate.Date == item.Key.Date).Count();
                var TotalLeadsResponse = CustomerDetailList.Entities.Where(x => x.CreatedDate.Value.Date == item.Key.Date && x.CreatedBy == Convert.ToInt32(HttpContext.Session.GetString("empId"))).Count();
                Leads.Add(new LeadsDetail()
                {
                    Description = "Uploaded " + TotalLeadsResponse + " and Lead " + todayleadsresponse,
                    NoOfLeads = TotalLeadsResponse + " Uploaded, " + todayleadsresponse + "  Leads",
                    AssignDate = item.First().AssignDate,
                });
            }
            return Json(Leads);
        }
        public async Task<IActionResult> ExportCustomerLead(int? LeadTypeId)
        {
            List<CompleteLeadsDetailVM> responseDetails = await GetCustomerDetailLeadTypeWise(LeadTypeId);

            DataTable dt = new DataTable("LeadDetails");
            dt.Columns.AddRange(new DataColumn[8] {
                    new DataColumn("LeadName"),
                    new DataColumn("Location"),
                    new DataColumn("Phone"),
                    new DataColumn("Email"),
                    new DataColumn("Description/Project"),
                    new DataColumn("Special Remarks"),
                    new DataColumn("AssignDate"),
                     new DataColumn("Status"),
            });

            foreach (var data in responseDetails)
            {
                dt.Rows.Add(data.LeadName, data.Location, data.Phone, data.Email, data.Description_Project, data.SpecialRemarks, data.AssignDate.ToString("dd/MM/yyyy"), data.LeadTypeName);
            }

            using XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dt);
            using MemoryStream stream = new MemoryStream();
            wb.SaveAs(stream);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "CustomerLeadDetails.xlsx");
        }
        private async Task<List<CompleteLeadsDetailVM>> GetCustomerDetailLeadTypeWise(int? LeadTypeId)
        {
            var CustomerDetailList = await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var LeadTypeLIst = await _ILeadTypeRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            if (LeadTypeId == null)
            {
                var responseDetails = (from CDList in CustomerDetailList.Entities
                                       join CLList in CustomerLeadLIst.Entities
                                       on CDList.Id equals CLList.CustomerId
                                       join ltype in LeadTypeLIst.Entities on CLList.LeadType equals ltype.Id into leadtype
                                       from subpet in leadtype.DefaultIfEmpty()
                                       where CLList.EmpId == Convert.ToInt32(HttpContext.Session.GetString("empId"))
                                       select new CompleteLeadsDetailVM
                                       {
                                           CustomerId = CDList.Id,
                                           LeadName = CDList.LeadName,
                                           Location = CDList.Location,
                                           Phone = CDList.Phone,
                                           Email = CDList.Email,
                                           Description_Project = CDList.Description_Project,
                                           AssignDate = CDList.AssignDate,
                                           SpecialRemarks = CDList.SpecialRemarks,
                                           LeadTypeName = subpet?.Name ?? String.Empty
                                       }).ToList();
                return responseDetails;
            }
            else
            {
                var responseDetails = (from CDList in CustomerDetailList.Entities
                                       join CLList in CustomerLeadLIst.Entities
                                       on CDList.Id equals CLList.CustomerId
                                       join ltype in LeadTypeLIst.Entities on CLList.LeadType equals ltype.Id into leadtype
                                       from subpet in leadtype.DefaultIfEmpty()
                                       where CLList.EmpId == Convert.ToInt32(HttpContext.Session.GetString("empId")) && CLList.LeadType == LeadTypeId
                                       select new CompleteLeadsDetailVM
                                       {
                                           CustomerId = CDList.Id,
                                           LeadName = CDList.LeadName,
                                           Location = CDList.Location,
                                           Phone = CDList.Phone,
                                           Email = CDList.Email,
                                           Description_Project = CDList.Description_Project,
                                           AssignDate = CDList.AssignDate,
                                           SpecialRemarks = CDList.SpecialRemarks,
                                           LeadTypeName = subpet?.Name ?? String.Empty
                                       }).ToList();
                return responseDetails;
            }

        }

        public async Task<IActionResult> ExportTeamLaed()
        {
            List<LeadsBySupervisorVM> responseDetails = await GetEmployeeLeads();
            DataTable dt = new DataTable("LeadDetails");
            dt.Columns.AddRange(new DataColumn[10] {
                    new DataColumn("Employee Name"),
                    new DataColumn("Level"),
                    new DataColumn("Lead"),
                    new DataColumn("Called"),
                    new DataColumn("Pending"),
                    new DataColumn("Hot"),
                    new DataColumn("Warm"),
                    new DataColumn("Cold"),
                    new DataColumn("Not Interested"),
                    new DataColumn("Lead Convert To Client"),
            });

            foreach (var data in responseDetails)
            {
                dt.Rows.Add(
                    data.employeeName,
                    data.Level,
                    data.Leads,
                    data.Called,
                    data.Pending,
                    data.Hot,
                    data.Warm,
                    data.Cold, data.NotInterested, data.LeadConvertedToClient);
            }

            using XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dt);
            using MemoryStream stream = new MemoryStream();
            wb.SaveAs(stream);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "CustomerLeadDetails.xlsx");

        }

        private async Task<List<LeadsBySupervisorVM>> GetEmployeeLeads()
        {
            var empCode = HttpContext.Session.GetString("empCode");
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var EmployeeDetailList = await _IEmployeeDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.SuperVisorCode == empCode);
            var CustomerComplete = new List<LeadsBySupervisorVM>();
            EmployeeDetailList.Entities.ToList().ForEach(x =>
            {
                CustomerComplete.Add(new LeadsBySupervisorVM
                {
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
            return CustomerComplete;
        }
        public async Task<IActionResult> GetEmployeeLeadsDetails(int employeeId)
        {
            List<LeadsBySupervisorVM> responseDetails = await GetCustomerDetailEmployeeWise(employeeId);
            return PartialView(ViewHelper.GetViewPathDetails("Home", "GetLeadsByEmployee"), responseDetails);
        }
        public async Task<IActionResult> ExportTeamLaedByEmployee(int employeeId)
        {
            List<LeadsBySupervisorVM> responseDetails = await GetCustomerDetailEmployeeWise(employeeId);
            DataTable dt = new DataTable("LeadDetails");
            dt.Columns.AddRange(new DataColumn[10] {
                    new DataColumn("Employee Name"),
                    new DataColumn("Assign Date"),
                    new DataColumn("Lead"),
                    new DataColumn("Called"),
                    new DataColumn("Pending"),
                    new DataColumn("Hot"),
                    new DataColumn("Warm"),
                    new DataColumn("Cold"),
                    new DataColumn("Not Interested"),
                    new DataColumn("Lead Convert To Client"),
            });

            foreach (var data in responseDetails)
            {
                dt.Rows.Add(
                    data.employeeName,
                    data.AssignDate.Date.ToString("dd/MM/yyyy"),
                    data.Leads,
                    data.Called,
                    data.Pending,
                    data.Hot,
                    data.Warm,
                    data.Cold, data.NotInterested, data.LeadConvertedToClient);
            }

            using XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dt);
            using MemoryStream stream = new MemoryStream();
            wb.SaveAs(stream);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "CustomerLeadDetails.xlsx");

        }
        private async Task<List<LeadsBySupervisorVM>> GetCustomerDetailEmployeeWise(int employeeId)
        {
            var CustomerDetailList = await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var EmployeeDetailLIst = await _IEmployeeDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var responseDetails = (from CDList in CustomerDetailList.Entities
                                   join CLList in CustomerLeadLIst.Entities
                                   on CDList.Id equals CLList.CustomerId
                                   join emp in EmployeeDetailLIst.Entities on CLList.EmpId equals emp.Id
                                   where CLList.EmpId == employeeId
                                   select new CustomerDetail
                                   {
                                       LeadName = CDList.LeadName,
                                       Location = CDList.Location,
                                       Phone = CDList.Phone,
                                       Email = CDList.Email,
                                       Description_Project = CDList.Description_Project,
                                       AssignDate = CDList.AssignDate.Date,
                                       SpecialRemarks = CDList.SpecialRemarks,
                                       CreatedBy = CDList.CreatedBy,
                                       CreatedDate = CDList.CreatedDate,
                                       EmpId = CLList.EmpId,
                                       LeadType = CLList.LeadType,
                                       EmpCode = emp.EmployeeName
                                   }).ToList();
            var CompleteLeadsByEmployee = new List<LeadsBySupervisorVM>();
            foreach (var item in responseDetails.GroupBy(x => x.AssignDate.Date))
            {
                CompleteLeadsByEmployee.Add(new LeadsBySupervisorVM
                {
                    AssignDate = item.Key,
                    employeeId = item.FirstOrDefault().EmpId,
                    employeeName = item.FirstOrDefault().EmpCode,
                    Leads = item.Count(),
                    Called = item.Where(y => y.LeadType != 0).Count(),
                    Pending = item.Where(y => y.LeadType == 0).Count(),
                    Hot = item.Where(y => y.LeadType == 1).Count(),
                    Warm = item.Where(y => y.LeadType == 2).Count(),
                    Cold = item.Where(y => y.LeadType == 3).Count(),
                    NotInterested = item.Where(y => y.LeadType == 4).Count(),
                    LeadConvertedToClient = item.Where(y => y.LeadType == 5).Count(),
                });
            }
            return CompleteLeadsByEmployee;
        }
        public async Task<IActionResult> GetCountLead(int? LeadTypeId)
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("empId"));
            int responseValue = 0;
            var CustomerLeadLIst = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            if (LeadTypeId == null)
            {
                responseValue = CustomerLeadLIst.Entities.Where(y => y.EmpId == empId).Count();
            }
            {
                responseValue = CustomerLeadLIst.Entities.Where(y => y.EmpId == empId && y.LeadType == LeadTypeId).Count();
            }

            return Json(responseValue);
        }
    }
}
