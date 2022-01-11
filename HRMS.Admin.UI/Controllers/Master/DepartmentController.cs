using HRMS.Admin.UI.Helpers;
using HRMS.Core.Entities.Master;
using HRMS.Core.Helpers.CommonCRUDHelper;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Master
{
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department, int> _IDepartmentRepository;

        public DepartmentController(IGenericRepository<Department, int> departmentRepo)
        {
            _IDepartmentRepository = departmentRepo;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderTitle = PageHeader.HeaderSetting["DepartmentIndex"];
            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("Department", "DepartmentIndex")));
        }

        public async Task<IActionResult> GetDepartmentList()
        {
            try
            {
                var response = new DBResponseHelper<Department, int>()
                    .GetDBResponseHelper(await _IDepartmentRepository
                    .GetAllEntities(x => x.IsActive && !x.IsDeleted));

                return PartialView(ViewHelper.GetViewPathDetails("Department", "DepartmentList"), response.Item2.Entities);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error","Home");
            }

        }

        public async Task<IActionResult> CreateDepartment(int id)
        {
            var response = new DBResponseHelper<Department, int>().GetDBResponseHelper(await _IDepartmentRepository.GetAllEntities(x => x.Id == id));

            if (id == 0)
            {
                return PartialView(ViewHelper.GetViewPathDetails("Department", "_CreateDepartment"));
            }
            else
            {

                return PartialView(ViewHelper.GetViewPathDetails("Department", "_CreateDepartment"), response.Item2.Entities.First());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSertDepartment(Department model)
        {
            if (model.Id == 0)
            {
                var response = await _IDepartmentRepository.CreateEntity(model);
                return Json(response.Message);
            }
            else
            {
                var response = await _IDepartmentRepository.UpdateEntity(model);
                return Json(response.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleteModel = await _IDepartmentRepository.GetAllEntityById(x => x.Id == id);

            var deleteDbModel = CrudHelper.DeleteHelper<Department>(deleteModel.Entity, 1);

            var deleteResponse = await _IDepartmentRepository.DeleteEntity(deleteDbModel);

            if (deleteResponse.ResponseStatus == Core.Entities.Common.ResponseStatus.Deleted)
            {
                return Json(deleteResponse.Message);
            }
            return Json(deleteResponse.Message);
        }
    }
}
