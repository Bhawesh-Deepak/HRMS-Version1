using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.Master
{
    [Table("Designation", Schema = "Master")]
    public class Designation : BaseModel<int>
    {
        [Required(ErrorMessage = "Designation name is required.")]
        [Display(Prompt = "Designation name")]
        public string Name { get; set; }

        [Display(Prompt = "Designation Code")]
        public string Code { get; set; }

        [Display(Prompt = "Designation Description")]
        public string Description { get; set; }
        public int DepartmentId { get; set; }
    }
}
