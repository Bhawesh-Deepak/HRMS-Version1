using HRMS.API.Helpers;
using HRMS.Core.Entities.Master;
using HRMS.Core.Helpers.CommonCRUDHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Controllers.Master
{
    /// <summary>
    /// Department controller API Version1
    /// </summary>
    /// <remarks>Api to </remarks>
    [Route("HRMS/V1/[controller]/[action]")]
    [ApiController]
    public class DepartmentAPI : ControllerBase
    {
        private readonly IGenericRepository<Department, int> _IDepartmentRepository;

        public DepartmentAPI(IGenericRepository<Department, int> departmentRepository)
        {
            _IDepartmentRepository = departmentRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateDepartment(Department model)
        {
            var createModel = CrudHelper.CreateHelper<Department>(model);

            var response = await _IDepartmentRepository.CreateEntity(createModel);

            return new APIResponseHelper<Department, int>().GetResponse(response);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateDepartment(Department model)
        {
            var createModel = CrudHelper.UpdateHelper<Department>(model,1);

            var response = await _IDepartmentRepository.UpdateEntity(createModel);

            return new APIResponseHelper<Department, int>().GetResponse(response);
        }


        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var models = await _IDepartmentRepository.GetAllEntities(x=>x.Id==id);

            var deleteModel = CrudHelper.DeleteHelper<Department>(models.Entities.First(),1);

            var response = await _IDepartmentRepository.DeleteEntity(deleteModel);

            return new APIResponseHelper<Department, int>().GetResponse(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var models = await _IDepartmentRepository.GetAllEntities(x => x.Id == id);

            return new APIResponseHelper<Department, int>().GetResponse(models);
        }


        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetDepartmentList()
        {
            var models = await _IDepartmentRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);

            return new APIResponseHelper<Department, int>().GetResponse(models);
        }
    }
}
