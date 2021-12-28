using HRMS.Core.ReqRespVm.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HRMS.API.Helpers
{
    public class HttpStatusCodeResult<TEntity,T> : IActionResult where TEntity : class
    {
        public GenericResponse<TEntity, T> ResponseModelData { get; set; }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(ResponseModelData)
            {
                StatusCode =Convert.ToInt32(ResponseModelData.ResponseStatus) 
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
