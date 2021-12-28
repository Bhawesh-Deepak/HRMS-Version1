using HRMS.Core.Entities.Common;
using HRMS.Core.ReqRespVm.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Helpers
{
    public class APIResponseHelper<TEntity, T> : ControllerBase where TEntity : class
    {
        public IActionResult GetResponse(GenericResponse<TEntity, T> responseModel)
        {
            switch (responseModel.ResponseStatus)
            {
                case ResponseStatus.Success:
                    return Ok(responseModel);

                case ResponseStatus.CodeException:
                    return BadRequest(responseModel);

                case ResponseStatus.DataBaseException:
                    return BadRequest(responseModel);

                case ResponseStatus.Created:
                    return Created(string.Empty, responseModel);

                case ResponseStatus.Deleted:
                    return Ok(responseModel);

                case ResponseStatus.AlreadyExists:
                    return BadRequest(responseModel);

                case ResponseStatus.Updated:
                    return Ok(responseModel);

                default:
                    return Ok(responseModel);

            }
        }
    }
}
