using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.Master
{
    [Table("RoleMaster", Schema= "UserManagement")]
    public class RoleMaster: BaseModel<int>
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
}
