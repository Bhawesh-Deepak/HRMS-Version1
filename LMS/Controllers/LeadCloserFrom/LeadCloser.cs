using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.LeadCloserFrom
{
    public class LeadCloser : Controller
    {
        private readonly IGenericRepository<CustomerLead, int> _ICustomerLeadRepository;
        private readonly IGenericRepository<CustomerDetail, int> _ICustomerDetailRepository;
        private readonly IGenericRepository<CustomerLeadCloserForm, int> _ICustomerLeadCloserFormRepository;
        public LeadCloser(IGenericRepository<CustomerLead, int> customerLeadRepository, IGenericRepository<CustomerDetail, int> iCustomerDetailRepository,
             IGenericRepository<CustomerLeadCloserForm, int> customerLeadCloserForm)
        {
            _ICustomerDetailRepository = iCustomerDetailRepository;
            _ICustomerLeadRepository = customerLeadRepository;
            _ICustomerLeadCloserFormRepository = customerLeadCloserForm;
        }
        public async Task<IActionResult> Index(int customerId)
        {
            var CustomerLead = await _ICustomerLeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var CustomerDetail = await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var CustomerDetails = (from CLead in CustomerLead.Entities
                                   join CDList in CustomerDetail.Entities
                                   on CLead.CustomerId equals CDList.Id
                                   select new CustomerDetail
                                   {
                                       Id = CDList.Id,
                                       LeadName = CDList.LeadName,
                                       Location = CDList.Location,
                                       Email = CDList.Email,
                                       Phone = CDList.Phone,
                                       EmpCode = CLead.LeadCode
                                       ,
                                       SpecialRemarks = CDList.SpecialRemarks,
                                       Description_Project = CDList.Description_Project

                                   }).ToList();

           
            return View(CustomerDetails);
        }

        public async Task<IActionResult> GetCustomerLCF(int custid)
        {
            var CustomerLeadcloForm = await _ICustomerLeadCloserFormRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var CustomerDetail = await _ICustomerDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.Id == custid);

            var response = (from customer in CustomerDetail.Entities
                            join CLCF in CustomerLeadcloForm.Entities
                            on customer.Id equals CLCF.CustomerId
                            into ps
                            from CLCF in ps.DefaultIfEmpty()
                            select new CustomerLeadCloserForm
                            {

                                CustomerId = customer.Id,
                               
                                TCFID = CLCF == null ? null : CLCF.TCFID,
                                TCFRefrenceId = CLCF == null ? null : CLCF.TCFRefrenceId,
                                status = CLCF == null ? null : CLCF.status,
                                SubmittedOn = CLCF == null ? null : CLCF.SubmittedOn,
                                Month = CLCF == null ? null : CLCF.Month,
                                OpsAppvdDate = CLCF == null ? null : CLCF.OpsAppvdDate,
                                Branch = CLCF == null ? null : CLCF.Branch,
                                NetRevenueINR = CLCF == null ? null : CLCF.NetRevenueINR,
                                UnitNumber = CLCF == null ? null : CLCF.UnitNumber,
                                ShareHolder = CLCF == null ? null : CLCF.ShareHolder,
                                SharePercentage = CLCF == null ? null : CLCF.SharePercentage,
                                CustomerName = CLCF == null ? null : CLCF.CustomerName,
                                Email = CLCF == null ? null : CLCF.Email,
                                Builder = CLCF == null ? null : CLCF.Builder,
                                ProductName = CLCF == null ? null : CLCF.ProductName,
                                ProjectCity = CLCF == null ? null : CLCF.ProjectCity,
                                EmployeeName = CLCF == null ? null : CLCF.EmployeeName,
                                DeletedRemarks = CLCF == null ? null : CLCF.DeletedRemarks,
                                MobileNo = CLCF == null ? null : CLCF.MobileNo,
                                LeadSource = CLCF == null ? null : CLCF.LeadSource,
                                rstatus = CLCF == null ? null : CLCF.rstatus,
                                RFDate = CLCF == null ? null : CLCF.RFDate,
                                RFComment = CLCF == null ? null : CLCF.RFComment,
                                CancelledOn = CLCF == null ? null : CLCF.CancelledOn,
                                CRMExecutive = CLCF == null ? null : CLCF.CRMExecutive,
                                CRMRemarks = CLCF == null ? null : CLCF.CRMRemarks,
                                PaymentPlan = CLCF == null ? null : CLCF.PaymentPlan,
                                T2 = CLCF == null ? null : CLCF.T2,
                                PnlHead = CLCF == null ? null : CLCF.PnlHead,
                                Region = CLCF == null ? null : CLCF.Region,
                                Fin_Segment = CLCF == null ? null : CLCF.Fin_Segment,
                                Whitelisted = CLCF == null ? null : CLCF.Whitelisted,
                                CountedMonth = CLCF == null ? null : CLCF.CountedMonth,
                                WriteOff = CLCF == null ? null : CLCF.WriteOff,
                                CPName = CLCF == null ? null : CLCF.CPName,
                                CPCode = CLCF == null ? null : CLCF.CPCode,
                                SubBrokerDetails = CLCF == null ? null : CLCF.SubBrokerDetails,
                                AgentName = CLCF == null ? null : CLCF.AgentName,
                                AgentCode = CLCF == null ? null : CLCF.AgentCode,
                                AgentDetails = CLCF == null ? null : CLCF.AgentDetails,
                                Gross = CLCF == null ? null : CLCF.Gross,
                                NewGr = CLCF == null ? null : CLCF.NewGr,
                                NewGrRemarks = CLCF == null ? null : CLCF.NewGrRemarks,
                                ProductType = CLCF == null ? null : CLCF.ProductType,
                                PartiallyInvoiced = CLCF == null ? null : CLCF.PartiallyInvoiced,
                                FullyInvoiced = CLCF == null ? null : CLCF.FullyInvoiced,
                                SelfFunding = CLCF == null ? null : CLCF.SelfFunding,
                                TPLSanctioned = CLCF == null ? null : CLCF.TPLSanctioned,
                                TPLDisbursed = CLCF == null ? null : CLCF.TPLDisbursed,
                                Id = CLCF == null ? 0 : CLCF.Id,
                                DefferedLoan = CLCF == null ? null : CLCF.DefferedLoan,
                            }); 

            
            return await Task.Run(() => PartialView(ViewHelper.GetViewPathDetails("LeadCloser", "_CustomerLCFPartial"), response.FirstOrDefault()));
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomerLCF(CustomerLeadCloserForm model)
        {
            if (model.Id == 0)
            {
                var response = await _ICustomerLeadCloserFormRepository.CreateEntity(model);
                return RedirectToAction("Index", "LeadCloser");
            }
            else
            {
                var response = await _ICustomerLeadCloserFormRepository.UpdateEntity(model);
                return RedirectToAction("Index", "LeadCloser");
            }


        }
    }
}
