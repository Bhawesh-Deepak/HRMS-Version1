using HRMS.Admin.UI.Helpers;
using HRMS.Core.Entities.Master;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Master
{
    public class RoleMasterController : Controller
    {
        private readonly IGenericRepository<RoleMaster, int> _IRoleMasterRepository;

        public RoleMasterController(IGenericRepository<RoleMaster, int> roleMasterRepo)
        {
            _IRoleMasterRepository = roleMasterRepo;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderTitle = PageHeader.HeaderSetting["RoleMasterIndex"];
            return await Task.Run(() => View(ViewHelper
                .GetViewPathDetails("RoleMaster", "RoleIndex")));
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleDetail()
        {
            try
            {
                var response = await _IRoleMasterRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
                return PartialView(ViewHelper.GetViewPathDetails("RoleMaster", "RoleDetails"), response.Entities);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public async Task<IActionResult> CreateRole(int id)
        {
            if (id == 0)
            {
                return await Task.Run(() => PartialView(ViewHelper.GetViewPathDetails("RoleMaster", "RoleCreate")));
            }
            var response = await _IRoleMasterRepository.GetAllEntities(x => x.Id == id);
            if (response.ResponseStatus == Core.Entities.Common.ResponseStatus.Success)
            {
                return PartialView(ViewHelper.GetViewPathDetails("RoleMaster", "RoleCreate"), response.Entities.First());
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UpsertRole(RoleMaster model)
        {
            model.CreatedDate = DateTime.Now;
            if (model.Id == 0)
            {
                var response = await _IRoleMasterRepository.CreateEntity(model);
                return Json(new DBResponseHelper<RoleMaster, int>().GetDBResponseHelper(response).message);
            }

            var updateResponse = await _IRoleMasterRepository.UpdateEntity(model);
            return Json(new DBResponseHelper<RoleMaster, int>().GetDBResponseHelper(updateResponse).message);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var deleteModelResponse = await _IRoleMasterRepository.GetAllEntityById(x => x.Id == id);
            if (deleteModelResponse.ResponseStatus == Core.Entities.Common.ResponseStatus.Success)
            {
                deleteModelResponse.Entity.IsActive = false;
                deleteModelResponse.Entity.IsDeleted = true;

                var deleteResponse = await _IRoleMasterRepository.DeleteEntity(deleteModelResponse.Entity);

                return Json(new DBResponseHelper<RoleMaster, int>().GetDBResponseHelper(deleteResponse));
            }

            return Json($"The Role Id {id} you have passed is not valid !!!");
        }
    }
}
