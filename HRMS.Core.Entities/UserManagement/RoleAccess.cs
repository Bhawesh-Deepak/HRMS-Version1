using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace HRMS.Core.Entities.UserManagement
{
    [Table("RoleAccess", Schema = "UserManagement")]
    public class RoleAccess:Model<int>
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int SubModuleId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
