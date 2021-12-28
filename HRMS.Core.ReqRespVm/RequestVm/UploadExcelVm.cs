using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.ReqRespVm.RequestVm
{
    public class UploadExcelVm
    {
        public IFormFile UploadFile { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
    }
}
