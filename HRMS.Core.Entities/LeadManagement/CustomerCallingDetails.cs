using HRMS.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.LeadManagement
{
    [Table("CustomerCallingDetails",Schema= "LeadManagement")]
    public  class CustomerCallingDetails: BaseModel<int>
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public string Phone { get; set; }
        public DateTime PhoneDateTime { get; set; } = DateTime.Now;
    }
}
