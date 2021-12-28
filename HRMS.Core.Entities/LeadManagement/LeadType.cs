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
    [Table("LeadType", Schema = "LeadManagement")]
    public class LeadType:BaseModel<int>
    {
        [Required(ErrorMessage = "this field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "this field is required.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "this field is required.")]
        public string Description { get; set; }
    }
}
