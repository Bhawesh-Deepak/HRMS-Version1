using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.Response.Leads
{
    public class CustomerCallingDetailVM
    {
        public int Id { get; set; }
        public string LeadName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description_Project { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime PhoneDateTime { get; set; }
    }
}
