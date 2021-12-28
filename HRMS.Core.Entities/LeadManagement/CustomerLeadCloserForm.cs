using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.LeadManagement
{
    [Table("CustomerLeadCloserForm", Schema = "LeadManagement")]
    public class CustomerLeadCloserForm : BaseModel<int>
    {

        public int CustomerId { get; set; }
        public string TCFID { get; set; }
        public string TCFRefrenceId { get; set; }
        public string status { get; set; }
        public string SubmittedOn { get; set; }
        public string Month { get; set; }
        public string OpsAppvdDate { get; set; }
        public string Branch { get; set; }
        public string NetRevenueINR { get; set; }
        public string UnitNumber { get; set; }
        public string ShareHolder { get; set; }
        public string SharePercentage { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Builder { get; set; }
        public string ProductName { get; set; }
        public string ProjectCity { get; set; }
        public string EmployeeName { get; set; }
        public string DeletedRemarks { get; set; }
        public string MobileNo { get; set; }
        public string LeadSource { get; set; }
        public string rstatus { get; set; }
        public string RFDate { get; set; }
        public string RFComment { get; set; }
        public string CancelledOn { get; set; }
        public string CRMExecutive { get; set; }
        public string CRMRemarks { get; set; }
        public string PaymentPlan { get; set; }
        public string T2 { get; set; }
        public string PnlHead { get; set; }
        public string Region { get; set; }
        public string Fin_Segment { get; set; }
        public string Whitelisted { get; set; }
        public string CountedMonth { get; set; }
        public string WriteOff { get; set; }
        public string CPName { get; set; }
        public string CPCode { get; set; }
        public string SubBrokerDetails { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }
        public string AgentDetails { get; set; }
        public string Gross { get; set; }
        public string NewGr { get; set; }
        public string NewGrRemarks { get; set; }
        public string ProductType { get; set; }
        public string PartiallyInvoiced { get; set; }
        public string FullyInvoiced { get; set; }
        public string SelfFunding { get; set; }
        public string TPLSanctioned { get; set; }
        public string TPLDisbursed { get; set; }
        public string DefferedLoan { get; set; }
    }
}
