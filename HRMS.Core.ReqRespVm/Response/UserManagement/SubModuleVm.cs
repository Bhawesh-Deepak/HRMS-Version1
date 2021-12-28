using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.Response.UserManagement
{
    public class SubModuleVm
    {
        public int SubModuleId { get; set; }
        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
    }
}
