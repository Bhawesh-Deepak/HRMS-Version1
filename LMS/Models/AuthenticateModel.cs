using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class AuthenticateModel
    {
        [Required(ErrorMessage ="User Name is required.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }
    }
}
