using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers.ViewComponents
{
    public class MenuSubMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           ViewBag.empId= Convert.ToInt32(HttpContext.Session.GetString("empId"));
            return await Task.FromResult((IViewComponentResult)View("_MenuSubMenu"));
        }
    }
}
