using HRMS.Core.Entities.Master;
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
    public class RoleAccessController : Controller
    {
        private readonly IGenericRepository<RoleMaster, int> _IRoleMasterRepository;
        private readonly IGenericRepository<ModuleMaster, int> _IModuleRepository;
        private readonly IGenericRepository<SubModuleMaster, int> _ISubModuleRepository;
        private readonly IGenericRepository<RoleAccess, int> _IRoleAccessRepository;

        public RoleAccessController(IGenericRepository<RoleMaster, int> roleMasterRepo,
            IGenericRepository<ModuleMaster, int> moduleRepo, IGenericRepository<SubModuleMaster, int> subModuleRepo,
            IGenericRepository<RoleAccess, int> roleAccessRepo
            )
        {
            _IRoleAccessRepository = roleAccessRepo;
            _IRoleMasterRepository = roleMasterRepo;
            _IModuleRepository = moduleRepo;
            _ISubModuleRepository = subModuleRepo;

        }
        public async Task<IActionResult> Index()
        {
            await PopulateViewBag();

            return View(ViewHelper.GetViewPathDetails("RoleAccess", "RoleAccessIndex"));
        }

        public async Task<IActionResult> GetRoleAccess(int roleId)
        {
            ViewBag.RoleId = roleId;
            var response = await GetRoleAccessDetails(roleId);
            return PartialView(ViewHelper.GetViewPathDetails("RoleAccess", "RoleAccessDetail"), response);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAccessPost(string[] module, string[] subModule,
            int[] DisplayOrder, int RoleId)
        {
            var deleteModel = await _IRoleAccessRepository.GetAllEntities(x => x.RoleId == RoleId);

            if (deleteModel.ResponseStatus == Core.Entities.Common.ResponseStatus.Success)
            {
                deleteModel.Entities.ToList().ForEach(data =>
                {
                    data.IsActive = false;
                    data.IsDeleted = true;
                });

                var deleteResponse = await _IRoleAccessRepository.DeleteEntities(deleteModel.Entities.ToArray());

            }
            var createModels = new List<RoleAccess>();

            for (int i = 0; i < subModule.Count(); i++)
            {
                var roleAccessModel = new RoleAccess();
                roleAccessModel.RoleId = RoleId;
                roleAccessModel.SubModuleId = Convert.ToInt32(subModule[i]);
                roleAccessModel.ModuleId = Convert.ToInt32(module[i]);
                roleAccessModel.DisplayOrder = Convert.ToInt32(DisplayOrder[i]);
                roleAccessModel.IsActive = true;
                roleAccessModel.IsDeleted = false;
                roleAccessModel.CreatedBy = 1;
                roleAccessModel.CreatedDate = DateTime.Now;

                createModels.Add(roleAccessModel);
            }

            var createResponse = await _IRoleAccessRepository.CreateEntities(createModels.ToArray());

            return Json(createResponse.Message);

        }


        #region PrivateMethods Display and populate the viewbag data

        private async Task PopulateViewBag()
        {
            var response = await _IRoleMasterRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            ViewBag.Roles = response.Entities;
        }

        private async Task<List<RoleAccessVm>> GetRoleAccessDetails(int roleId)
        {
            var modules = (await _IModuleRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted)).Entities;
            var subModules = (await _ISubModuleRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted)).Entities;
            var roleAccess = (await _IRoleAccessRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.RoleId == roleId)).Entities;

            var response = (from mm in modules.ToList()
                            join sm in subModules.ToList()
                            on mm.Id equals sm.ModuleId
                            select new RoleAccessVm
                            {
                                ModuleName = mm.ModuleName,
                                SubModuleName = sm.SubModuleName,
                                SubModuleId = sm.Id,
                                MoudleId = mm.Id

                            }).ToList();

            response.ToList().ForEach(data =>
            {
                roleAccess.ToList().ForEach(item =>
                {
                    if (data.MoudleId == item.ModuleId && data.SubModuleId == item.SubModuleId)
                    {
                        data.IsMapped = true;
                        data.DisplayOrder = item.DisplayOrder.ToString();
                    }
                });
            });

            return response;
        }

        #endregion
    }
}
