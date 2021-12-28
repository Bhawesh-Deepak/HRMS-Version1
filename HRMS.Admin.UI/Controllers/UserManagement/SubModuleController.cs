using HRMS.Admin.UI.Helpers;
using HRMS.Core.Entities.UserManagement;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.ReqRespVm.Response.UserManagement;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.UserManagement
{
    public class SubModuleController : Controller
    {
        private readonly IGenericRepository<ModuleMaster, int> _IModuleMasterRepository;
        private readonly IGenericRepository<SubModuleMaster, int> _ISubModuleRepository;

        public SubModuleController(IGenericRepository<ModuleMaster, int> moduleRepo, IGenericRepository<SubModuleMaster, int> subModuleRepo)
        {
            _IModuleMasterRepository = moduleRepo;
            _ISubModuleRepository = subModuleRepo;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderTitle = PageHeader.HeaderSetting["SubModuleMaster"];

            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("SubModule", "SubModuleIndex")));
        }

        [HttpGet]
        public async Task<IActionResult> GetSubModuleDetails()
        {
            try
            {
                var subModuleResponse = await _ISubModuleRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
                var moduleResponse = await _IModuleMasterRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);

                var response = (from sb in subModuleResponse.Entities
                                join mm in moduleResponse.Entities
                                on sb.ModuleId equals mm.Id
                                select new SubModuleVm
                                {
                                    SubModuleId = sb.Id,
                                    SubModuleName = sb.SubModuleName,
                                    Controller = sb.ControllerName,
                                    Action = sb.ActionName,
                                    Icon = sb.SubModuleIcon,
                                    ModuleName = mm.ModuleName

                                }).ToList();

                return PartialView(ViewHelper.GetViewPathDetails("SubModule", "SubModuleList"), response);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public async Task<IActionResult> CreateSubModule(int id)
        {
            await PopulateViewBag();
            if (id == 0)
            {
                return await Task.Run(() => PartialView(ViewHelper.GetViewPathDetails("SubModule", "SubModuleCreate")));
            }
            var response = await _ISubModuleRepository.GetAllEntities(x => x.Id == id);
            if (response.ResponseStatus == Core.Entities.Common.ResponseStatus.Success)
            {
                return PartialView(ViewHelper.GetViewPathDetails("SubModule", "SubModuleCreate"), response.Entities.First());
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UpSertSubModule(SubModuleMaster model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;

                if (model.Id == 0)
                {
                    var response = await _ISubModuleRepository.CreateEntity(model);
                    return Json(new DBResponseHelper<SubModuleMaster, int>().GetDBResponseHelper(response).message);
                }

                var updateResponse = await _ISubModuleRepository.UpdateEntity(model);
                return Json(new DBResponseHelper<SubModuleMaster, int>().GetDBResponseHelper(updateResponse).message);
            }
            catch (Exception ex)
            {
                return Json("Something wents wrong please contact admin !!!");
            }

        }

        public async Task<IActionResult> DeleteSubModule(int id)
        {
            var deleteModelResponse = await _ISubModuleRepository.GetAllEntityById(x => x.Id == id);
            if (deleteModelResponse.ResponseStatus == Core.Entities.Common.ResponseStatus.Success)
            {
                deleteModelResponse.Entity.IsActive = false;
                deleteModelResponse.Entity.IsDeleted = true;

                var deleteResponse = await _ISubModuleRepository.DeleteEntity(deleteModelResponse.Entity);

                return Json(new DBResponseHelper<SubModuleMaster, int>().GetDBResponseHelper(deleteResponse));
            }

            return Json($"The Role Id {id} you have passed is not valid !!!");
        }



        #region PrivateMethod
        private async Task PopulateViewBag()
        {
            var moduleResponse = await _IModuleMasterRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            ViewBag.Module = moduleResponse.Entities;
        }
        #endregion
    }
}
