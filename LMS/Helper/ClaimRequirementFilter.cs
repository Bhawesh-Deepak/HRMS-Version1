using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMS.Helper
{
    public class ClaimRequirementFilter:IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var url = context.HttpContext.Request.GetDisplayUrl();


            if (context.HttpContext.Session.GetString("empCode") == null)
            {
                context.Result = new RedirectToActionResult("Account", "Authenticate", new
                {
                    returnUrl = url
                });
            }
        }

       
    }
}