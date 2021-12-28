using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Controllers.CustomAction
{
    public class ExcelExportController<TEntity> : Controller where TEntity:class
    {
        public async Task<IActionResult> Index(IEnumerable<TEntity> models, string sheetName, string excelFileName)
        {
            return new ExcelResult<TEntity>(models, sheetName, excelFileName);
            
        }
    }
}
