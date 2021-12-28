using HRMS.Core.Entities.Payroll;
using HRMS.Core.Entities.UserManagement;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using LMS.Helper;

namespace LMS.Controllers.UserManagement
{
    public class CredentialManagement : Controller
    {
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeRepository;
        private readonly IGenericRepository<AuthenticateUser, int> _IAuthenticateRepository;

        public CredentialManagement(IGenericRepository<EmployeeDetail, int> iEmployeeRepository,
            IGenericRepository<AuthenticateUser, int> iAuthenticateRepository)
        {
            _IEmployeeRepository = iEmployeeRepository;
            _IAuthenticateRepository = iAuthenticateRepository; ;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateCredential()
        {
            var empdetails = await _IEmployeeRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);

            var models = new List<AuthenticateUser>();

            empdetails.Entities.ToList().ForEach(data =>
            {
                var model = new AuthenticateUser();
                model.EmployeeId = data.Id;
                model.CreatedBy = 1;
                model.CreatedDate = System.DateTime.Now;
                model.UserName = data.EmpCode;
                model.RoleId = 0;
                model.DisplayUserName = data.EmployeeName.Split(" ")[0];
                model.IsPasswordExpired = false;
                model.IsLocked = false;
                model.Password = PasswordEncryptor.Instance.Encrypt("123@qwe", "SQYPAYROLLLEADMANAGEMENT");

                models.Add(model);
            });

            var response = await _IAuthenticateRepository.CreateEntities(models.ToArray());

            return Json(response);

        }
    }
}
