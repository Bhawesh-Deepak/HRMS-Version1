using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.Master
{
    [Table("Department", Schema = "Master")]
    public class Department: BaseModel<int>
    {
        [Required(ErrorMessage ="Department name is required.")]
        [Display(Prompt ="Department Name")]
        public string Name { get; set; }

        [Display(Prompt = "Department Code")]
        public string Code { get; set; }

        [Display(Prompt = "Department Description")]
        public string Description { get; set; }
    }
}
