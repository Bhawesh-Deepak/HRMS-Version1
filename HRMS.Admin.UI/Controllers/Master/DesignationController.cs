using HRMS.Admin.UI.Helpers;
using HRMS.Core.Entities.Common;
using HRMS.Core.Entities.Master;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.ReqRespVm.Response.Master;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Master
{
    public class DesignationController : Controller
    {
        private readonly IGenericRepository<Department, int> _IDepartmentRepository;
        private readonly IGenericRepository<Designation, int> _IDesignationRepository;
        

        public DesignationController(IGenericRepository<Department, int> departmentRepo,
            IGenericRepository<Designation, int> designationRepo)
        {
            _IDepartmentRepository = departmentRepo;
            _IDesignationRepository = designationRepo;
            
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderTitle = PageHeader.HeaderSetting["DesignationIndex"];
           
            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("Designation", "DesignationIndex")));
        }

        public async Task<IActionResult> GetDesignationList()
        {
            var departmentList = await _IDepartmentRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            var designationLIst = await _IDesignationRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);

            var responseDetails = (from dpt in departmentList.Entities
                                   join dsg in designationLIst.Entities
                                   on dpt.Id equals dsg.DepartmentId
                                   select new DesignationDetail
                                   {
                                       DesignationId = dsg.Id,
                                       DesignationCode = dsg.Code,
                                       DepartmentName = dpt.Name,
                                       Desscription = dsg.Description,
                                       DesignationName=dsg.Name
                                   }).ToList();

            return PartialView(ViewHelper.GetViewPathDetails("Designation", "DesignationDetails"), responseDetails);
        }

        public async Task<IActionResult> CreateDesignation(int id)
        {
            await PopulateViewBag();
            var response = await _IDesignationRepository.GetAllEntities(x => x.Id == id);

            if (id == 0)
            {
                return PartialView(ViewHelper.GetViewPathDetails("Designation", "DesignationCreate"));
            }
            else
            {

                return PartialView(ViewHelper.GetViewPathDetails("Designation", "DesignationCreate"), response.Entities.First());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpsertDesignation(Designation model)
        {
            if (model.Id == 0)
            {
                var response = await _IDesignationRepository.CreateEntity(model);
                return Json(response.Message);
            }
            else
            {
                var response = await _IDesignationRepository.UpdateEntity(model);
                return Json(response.Message);
            }
        }

        #region PrivateFields
        private async Task PopulateViewBag()
        {
            var departmentResponse = await _IDepartmentRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);

            if (departmentResponse.ResponseStatus == ResponseStatus.Success)
                ViewBag.DepartmentList = departmentResponse.Entities;

        }

        #endregion
    }
}
