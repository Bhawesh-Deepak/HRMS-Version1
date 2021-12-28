using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.UserManagement
{
    [Table("ModuleMaster",Schema = "UserManagement")]
    public class ModuleMaster: Model<int>
    {
        public string ModuleName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ModuleIcon { get; set; }
    }
}
