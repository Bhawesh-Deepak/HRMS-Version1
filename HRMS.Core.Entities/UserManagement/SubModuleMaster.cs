using HRMS.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities.UserManagement
{
    [Table("SubModuleMaster",Schema = "UserManagement")]
    public class SubModuleMaster: Model<int>
    {
        public int ModuleId { get; set; }
        public string SubModuleName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string SubModuleIcon { get; set; }
    }
}
