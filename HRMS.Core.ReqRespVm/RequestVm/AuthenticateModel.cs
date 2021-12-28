using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.RequestVm
{
    public class AuthenticateModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
