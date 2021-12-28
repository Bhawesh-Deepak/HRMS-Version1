using HRMS.Admin.UI.Helpers;
using HRMS.Core.Entities.Payroll;
using HRMS.Core.ReqRespVm.RequestVm;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.UserManagement
{
    public class AuthenticateController : Controller
    {
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeDetailRepository;

        public AuthenticateController(IGenericRepository<EmployeeDetail, int> iEmployeeDetailRepository)
        {
            _IEmployeeDetailRepository = iEmployeeDetailRepository;
        }

        public async Task<IActionResult> LoginIndex()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Login(AuthenticateModel model)
        //{
        //    model.Password = PasswordEncryptor.Instance.Encrypt(model.Password, "HRMSLOGINKEY");
        //}

        [HttpGet]
        public async Task<IActionResult> UserRegistration()
        {
            return PartialView();

        }


        #region PrivateMethods

        private async Task PopulateViewBag()
        {
            ViewBag.EmployeeDetails = (await _IEmployeeDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted)).Entities;
        }

        #endregion
    }
}
