using HRMS.Core.Entities.Payroll;
using HRMS.Core.Entities.UserManagement;
using HRMS.Core.ReqRespVm.RequestVm;
using HRMS.Services.Repository.GenericRepository;
using LMS.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.UserManagement
{
    public class AuthenticateController : Controller
    {
        private readonly IGenericRepository<AuthenticateUser, int> _IAuthenticateRepository;
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeDetailRepository;

        public AuthenticateController(IGenericRepository<AuthenticateUser, int> iAuthenticateRepository,
            IGenericRepository<EmployeeDetail, int> employeeRepository)
        {
            _IAuthenticateRepository = iAuthenticateRepository;
            _IEmployeeDetailRepository = employeeRepository;
        }

        public IActionResult Account()
        {
            return View("~/Views/Account/Account.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateModel model)
        {
            model.Password = PasswordEncryptor.Instance.Encrypt(model.Password, "SQYPAYROLLLEADMANAGEMENT");

            var response = await _IAuthenticateRepository.GetAllEntities(x => x.UserName.ToUpper().Trim()
            == model.UserName.ToUpper().Trim() && x.Password.Trim().ToUpper() == model.Password.Trim().ToUpper());

            if (response.Entities.Any())
            {
                var empDetail = await _IEmployeeDetailRepository.GetAllEntities(x => x.Id == response.Entities.First().EmployeeId);
                HttpContext.Session.SetString("empCode", empDetail.Entities.First().EmpCode.Trim());
                HttpContext.Session.SetString("empId", empDetail.Entities.First().Id.ToString());
                HttpContext.Session.SetObjectAsJson("empDetails", empDetail.Entities.First());

                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Account/Account.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("empCode");
            HttpContext.Session.Remove("empId");
            HttpContext.Session.Remove("empDetails");

            return await Task.Run(() => RedirectToAction("Account", "Authenticate"));
        }

        //public async Task<IActionResult> Lock()
        //{
            
        //}
    }
}
