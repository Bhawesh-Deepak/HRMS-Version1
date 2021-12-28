using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.LeadManagement
{
    [Table("CustomerSecondryInfo", Schema = "LeadManagement")]
    public class CustomerSecondryDetail:BaseModel<int>
    {
        public int CustomerId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
