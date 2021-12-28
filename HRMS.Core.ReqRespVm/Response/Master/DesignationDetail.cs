using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.Response.Master
{
    public class DesignationDetail
    {
        public int DesignationId { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string DesignationCode { get; set; }
        public string Desscription { get; set; }
    }
}
