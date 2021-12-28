using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.LeadManagement
{
    [Table("CustomerLead", Schema = "LeadManagement")]
    public class CustomerLead: BaseModel<int>
    {
        public int CustomerId { get; set; }
        public string LeadCode { get; set; }
    }
}
