using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.Master
{
    [Table("SalaryHeads", Schema = "Master")]
    public class SalaryHeads: BaseModel<int>
    {
        [Display(Prompt ="Salary Head Name")]
        [Required(ErrorMessage ="Header name is required.")]
        public string HeadName { get; set; }

        [Display(Prompt = "Salary Head Code")]
        public string HeadCode { get; set; }

        [Required(ErrorMessage = "Salary is display on day.")]
        public bool IsDependOnDay { get; set; }

        [Required(ErrorMessage = "Salary Head Type")]
        public string HeadType { get; set; }
        public string Description { get; set; }
        public bool IsDisplayOnPaySlip { get; set; }
    }
}
