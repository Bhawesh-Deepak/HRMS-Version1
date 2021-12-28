using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.Response.UserManagement
{
    public class RoleAccessVm
    {
        public string RoleName { get; set; }
        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
        public string DisplayOrder { get; set; }
        public int SubModuleId { get; set; }
        public int MoudleId { get; set; }
        public bool IsMapped { get; set; }
    }
}
