using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.Helpers.CommonCRUDHelper;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.Customer
{
    public class LeadTypeController : Controller
    {
        private readonly IGenericRepository<LeadType, int> _ILeadTypeRepository;

        public LeadTypeController(IGenericRepository<LeadType, int> LeadTypeRepo)
        {
            _ILeadTypeRepository = LeadTypeRepo;
        }
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("LeadType", "LeadTypeIndex")));
        }
        public async Task<IActionResult> GetLeadTypeList()
        {
            var response = await _ILeadTypeRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            return PartialView(ViewHelper.GetViewPathDetails("LeadType", "LeadTypeList"), response.Entities);
        }
        public async Task<IActionResult> CreateLeadType(int id)
        {
            var response = await _ILeadTypeRepository.GetAllEntities(x => x.Id == id);
            if (id == 0)
            {
                return PartialView(ViewHelper.GetViewPathDetails("LeadType", "LeadTypeCreate"));
            }
            else
            {
                return PartialView(ViewHelper.GetViewPathDetails("LeadType", "LeadTypeCreate"), response.Entities.First());
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpsertLeadType(LeadType model)
        {
            if (model.Id == 0)
            {
                var response = await _ILeadTypeRepository.CreateEntity(model);
                return Json(response.Message);
            }
            else
            {
                var response = await _ILeadTypeRepository.UpdateEntity(model);
                return Json(response.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteLeadType(int id)
        {
            var deleteModel = await _ILeadTypeRepository.GetAllEntityById(x => x.Id == id);

            var deleteDbModel = CrudHelper.DeleteHelper<LeadType>(deleteModel.Entity, 1);

            var deleteResponse = await _ILeadTypeRepository.DeleteEntity(deleteDbModel);

            if (deleteResponse.ResponseStatus == HRMS.Core.Entities.Common.ResponseStatus.Deleted)
            {
                return Json(deleteResponse.Message);
            }
            return Json(deleteResponse.Message);
        }

    }
}
