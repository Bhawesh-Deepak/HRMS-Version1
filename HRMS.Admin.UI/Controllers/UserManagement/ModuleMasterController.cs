using HRMS.Admin.UI.Helpers;
using HRMS.Core.Entities.UserManagement;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.UserManagement
{
    public class ModuleMasterController : Controller
    {
        private readonly IGenericRepository<ModuleMaster, int> _IModuleMasterRepository;

        public ModuleMasterController(IGenericRepository<ModuleMaster, int> moduleRepo)
        {
            _IModuleMasterRepository = moduleRepo;
        }
        public IActionResult Index()
        {
            ViewBag.HeaderTitle = PageHeader.HeaderSetting["ModuleMaster"];
            return View(ViewHelper.GetViewPathDetails("Module", "ModuleIndex"));
        }

        [HttpGet]
        public async Task<IActionResult> GetModuleDetail()
        {
            try
            {
                var response = await _IModuleMasterRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
                return PartialView(ViewHelper.GetViewPathDetails("Module", "ModuleList"), response.Entities);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public async Task<IActionResult> CreateModule(int id)
        {
            if (id == 0)
            {
                return await Task.Run(() => PartialView(ViewHelper.GetViewPathDetails("Module", "ModuleCreate")));
            }
            var response = await _IModuleMasterRepository.GetAllEntities(x => x.Id == id);
            if (response.ResponseStatus == Core.Entities.Common.ResponseStatus.Success)
            {
                return PartialView(ViewHelper.GetViewPathDetails("Module", "ModuleCreate"), response.Entities.First());
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UpsertModule(ModuleMaster model)
        {
            if (model.Id == 0)
            {
                var response = await _IModuleMasterRepository.CreateEntity(model);
                return Json(new DBResponseHelper<ModuleMaster, int>().GetDBResponseHelper(response).message);
            }

            var updateResponse = await _IModuleMasterRepository.UpdateEntity(model);
            return Json(new DBResponseHelper<ModuleMaster, int>().GetDBResponseHelper(updateResponse).message);
        }

        public async Task<IActionResult> DeleteModule(int id)
        {
            var deleteModelResponse = await _IModuleMasterRepository.GetAllEntityById(x => x.Id == id);
            if (deleteModelResponse.ResponseStatus == Core.Entities.Common.ResponseStatus.Success)
            {
                deleteModelResponse.Entity.IsActive = false;
                deleteModelResponse.Entity.IsDeleted = true;

                var deleteResponse = await _IModuleMasterRepository.DeleteEntity(deleteModelResponse.Entity);

                return Json(new DBResponseHelper<ModuleMaster, int>().GetDBResponseHelper(deleteResponse));
            }

            return Json($"The ModuleId Id {id} you have passed is not valid !!!");
        }
    }
}
