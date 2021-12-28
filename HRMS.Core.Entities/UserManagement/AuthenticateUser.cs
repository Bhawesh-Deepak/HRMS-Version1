using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.UserManagement
{
    [Table("Authenticate", Schema = "UserManagement")]
    public class AuthenticateUser: Model<int>
    {
        public int EmployeeId { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
        public string DisplayUserName { get; set; }
        public bool IsPasswordExpired { get; set; }
        public bool IsLocked { get; set; }
    }
}
