using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.LeadManagement
{
    [Table("CustomerLeadDetail", Schema = "LeadManagement")]
    public class CustomerLeadDetail: BaseModel<int>
    {
        public int EmpId { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Status is required.")]
        public int LeadType { get; set; }

        
        public string Description { get; set; }
        public DateTime? IntractionDate { get; set; } = DateTime.Now.Date;
        public TimeSpan? IntractionTime { get; set; } = DateTime.Now.TimeOfDay;
        public string Activity { get; set; } = string.Empty;
        public DateTime? NextIntractionDate { get; set; }
        public TimeSpan? NextIntractionTime { get; set; }
        public string NextIntractionActivity { get; set; }

        
        public string Comment { get; set; } = string.Empty;
    }
}
