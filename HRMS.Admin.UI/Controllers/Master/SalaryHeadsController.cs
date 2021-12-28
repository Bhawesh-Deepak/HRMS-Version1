using HRMS.Admin.UI.Helpers;
using HRMS.Core.Entities.Master;
using HRMS.Core.Helpers.CommonCRUDHelper;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Master
{
    public class SalaryHeadsController : Controller
    {
        private readonly IGenericRepository<SalaryHeads, int> _ISalaryHeadRepository;

        public SalaryHeadsController(IGenericRepository<SalaryHeads, int> salaryHeadRepository)
        {
            _ISalaryHeadRepository = salaryHeadRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderTitle = PageHeader.HeaderSetting["SalaryHeadIndex"];
            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("SalaryHeads", "SalaryHeadsIndex")));
        }

        public async Task<IActionResult> GetSalaryHeadList()
        {
            var response = await _ISalaryHeadRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            return PartialView(ViewHelper.GetViewPathDetails("SalaryHeads", "_SalaryHeadList"), response.Entities);
        }

        public async Task<IActionResult> CreateSalaryHead(int id)
        {
            if (id == 0)
            {
                return PartialView(ViewHelper.GetViewPathDetails("SalaryHeads", "_SalaryHeadCreate"));
            }
            else
            {
                var response = await _ISalaryHeadRepository.GetAllEntities(x => x.Id == id);
                return PartialView(ViewHelper.GetViewPathDetails("SalaryHeads", "_SalaryHeadCreate"), response.Entities.First());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpsertSalaryHeads(SalaryHeads model)
        {
            if (model.Id == 0)
            {
                var response = await _ISalaryHeadRepository.CreateEntity(model);
                return Json(response.Message);
            }
            else
            {
                var response = await _ISalaryHeadRepository.UpdateEntity(model);
                return Json(response.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> DeleteSalaryHead(int id)
        {
            var deleteModel = await _ISalaryHeadRepository.GetAllEntityById(x => x.Id == id);

            var deleteDbModel = CrudHelper.DeleteHelper<SalaryHeads>(deleteModel.Entity, 1);

            var deleteResponse = await _ISalaryHeadRepository.DeleteEntity(deleteDbModel);

            if (deleteResponse.ResponseStatus == Core.Entities.Common.ResponseStatus.Deleted)
            {
                return Json(deleteResponse.Message);
            }
            return Json(deleteResponse.Message);
        }
    }
}
