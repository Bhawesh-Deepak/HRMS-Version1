using HRMS.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.LeadManagement
{
   
    [Table("CustomerDetail", Schema = "LeadManagement")]
    public class CustomerDetail:BaseModel<int>
    {
        [Required(ErrorMessage = "Full name is required.")]
        [Display(Prompt = "Full Name")]
        public string LeadName { get; set; }

        [Display(Prompt ="Country")]
        public string Location { get; set; }

        [Display(Prompt = "Phone No.")]
        public string Phone { get; set; }

        [Display(Prompt = "Email")]
        public string Email { get; set; }

        [Display(Prompt = "Project")]
        public string Description_Project { get; set; }
        public DateTime AssignDate { get; set; }
        [Display(Prompt = "Country")]
        public string Country { get; set; }
        [Display(Prompt = "State")]
        public string State { get; set; }
        [Display(Prompt = "City")]
        public string City { get; set; }
        [Display(Prompt = "ZipCode")]
        public string ZipCode { get; set; }
        [Display(Prompt = "Company")]
        public string CompanyName { get; set; }
        public string Website { get; set; }
        [Display(Prompt = "Industry")]
        public string Industry { get; set; }
        public string AssignedBy { get; set; } = "Supervisor";
        [Display(Prompt = "Special Remarks")]
        public string SpecialRemarks { get; set; } = string.Empty;
        public string EmpCode { get; set; } = string.Empty;
        [NotMapped]
        public int EmpId { get; set; }
        [NotMapped]
        public int LeadType { get; set; }
        [Display(Prompt = "Interested To Buy")]
        public string InterestedToBuy { get; set; }
    }
}
